using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrbanGreen.Application.Models.Usuario;
using UrbanGreen.Application.Services.Interfaces;

namespace UrbanGreenAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public LoginController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] Login model)
    {
        var result = await _usuarioService.Login(model);

        if (result == null)
            return Unauthorized();

        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("registro")]
    public async Task<IActionResult> Registrar([FromBody] RegistroNovoUsuario model)
    {
        var success = await _usuarioService.Registrar(model);

        if (!success)
            return BadRequest();

        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("usuarios")]
    public async Task<IActionResult> ObterUsuarios()
    {
        var result = await _usuarioService.ListarUsuarios();

        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("usuarios/{id}")]
    public async Task<IActionResult> ObterUsuarioPorId(string id)
        => Ok(await _usuarioService.ObterUsuarioPorId(id));

    [Authorize(Roles = "Admin")]
    [HttpPut("usuarios/{id}")]
    public async Task<IActionResult> EditarUsuario(string id, [FromBody] UpdateUsuarioDto model)
    {
        var success = await _usuarioService.EditarUsuario(id, model);

        if (!success.HasValue)
            return NotFound();

        if (!success.Value)
            return BadRequest();

        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("usuarios/{id}")]
    public async Task<IActionResult> ExcluirUsuario(string id)
    {
        var success = await _usuarioService.ExcluirUsuario(id);

        if (!success.HasValue)
            return NotFound();

        if (!success.Value)
            return BadRequest();

        return Ok();
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUser()
        => Ok(await _usuarioService.GetCurrentUser(User));
}
