﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UrbanGreen.Application.Models.Usuario;
using UrbanGreen.Core.Entities;

namespace UrbanGreenAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly IConfiguration _configuration;

    public LoginController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Login model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.NomeUsuario, model.Senha, false, false);

        if (!result.Succeeded)
            return Unauthorized();

        var user = await _userManager.FindByNameAsync(model.NomeUsuario);
        var token = await GerarJwtToken(user);

        return Ok(new { token });
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("registro")]
    public async Task<IActionResult> Registrar([FromBody] RegistroNovoUsuario model)
    {
        var user = new Usuario { UserName = model.NomeUsuario, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Senha);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        if (!string.IsNullOrEmpty(model.Role))
        {
            await _userManager.AddToRoleAsync(user, model.Role);
        }

        return Ok();
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
}
