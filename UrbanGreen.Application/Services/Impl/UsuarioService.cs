using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UrbanGreen.Application.Models.Usuario;
using UrbanGreen.Application.Services.Interfaces;
using UrbanGreen.Core.Entities;

namespace UrbanGreen.Application.Services.Impl;
public class UsuarioService : IUsuarioService
{
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly IConfiguration _configuration;

    public UsuarioService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    private async Task<string> GerarJwtToken(Usuario user)
    {
        var userRoles = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(300),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<ConsultaUsuarioDto> GetCurrentUser(ClaimsPrincipal userClaim)
    {
        var id = userClaim.Claims.LastOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        var user = await _userManager.FindByIdAsync(id);
        var roles = userClaim.Claims
            .Where(c => c.Type == "role" || c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();

        return new ConsultaUsuarioDto(user.Id, user.UserName, user.Email, roles.FirstOrDefault());
    }

    public async Task<List<ConsultaUsuarioDto>> ListarUsuarios()
    {
        var usuarios = _userManager.Users.ToList();
        var dtos = new List<ConsultaUsuarioDto>();

        foreach (var usuario in usuarios)
        {
            var roles = await _userManager.GetRolesAsync(usuario);

            dtos.Add(new ConsultaUsuarioDto(usuario.Id, usuario.UserName, usuario.Email, roles.FirstOrDefault()));
        }

        return dtos;
    }

    public async Task<bool?> ExcluirUsuario(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return null;

        var result = await _userManager.DeleteAsync(user);

        return result.Succeeded;
    }

    public async Task<bool> Registrar(RegistroNovoUsuario model)
    {
        var user = new Usuario { UserName = model.NomeUsuario, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Senha);

        if (!result.Succeeded)
            return false;

        if (!string.IsNullOrEmpty(model.Role))
        {
            await _userManager.AddToRoleAsync(user, model.Role);
        }

        return true;
    }

    public async Task<dynamic> Login(Login model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.NomeUsuario, model.Senha, false, false);

        if (!result.Succeeded)
            return null;

        var user = await _userManager.FindByNameAsync(model.NomeUsuario);
        var token = await GerarJwtToken(user);

        return new { token };
    }

    public async Task<ConsultaUsuarioDto> ObterUsuarioPorId(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return null;

        return new ConsultaUsuarioDto(user.Id, user.UserName, user.Email, "");
    }

    public async Task<bool?> EditarUsuario(string id, UpdateUsuarioDto model)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return null;

        user.UserName = model.NomeUsuario;
        user.Email = model.Email;

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
            return false;

        if (!string.IsNullOrEmpty(model.NovaSenha))
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResult = await _userManager.ResetPasswordAsync(user, token, model.NovaSenha);

            if (!passwordResult.Succeeded)
                return false;
        }

        return true;
    }
}