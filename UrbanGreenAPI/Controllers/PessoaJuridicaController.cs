using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrbanGreen.Application.Models.PessoaJuridica;
using UrbanGreen.Application.Services.Interfaces;

namespace UrbanGreenAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PessoaJuridicaController : ControllerBase
{
    private readonly IPessoaJuridicaService _pessoaJuridicaService;

    public PessoaJuridicaController(IPessoaJuridicaService pessoaJuridicaservice)
    {
        _pessoaJuridicaService = pessoaJuridicaservice;
    }

    [Authorize(Roles = "Gerente,Admin")]
    [HttpPost]
    public async Task<IActionResult> CadastrarPJ([FromBody] CreatePessoaJuridicaDto pessoaJuridicaDto)
    {
        await _pessoaJuridicaService.CadastrarPJ(pessoaJuridicaDto);
        return NoContent();
    }

    [Authorize(Roles = "Gerente,Admin,User")]
    [HttpGet]
    public async Task<IEnumerable<ReadPessoaJuridicaDto>> ConsultarPJ([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return await _pessoaJuridicaService.ConsultarPJ(skip, take);
    }

    [Authorize(Roles = "Gerente,Admin,User")]
    [HttpGet("{id}")]
    public async Task<IActionResult> ConsultarPJPorID(int id)
    {
        var pessoaJuridica = await _pessoaJuridicaService.ConsultarPJPorID(id);
        if (pessoaJuridica == null) return NotFound();
        return Ok(pessoaJuridica);
    }

    [Authorize(Roles = "Gerente,Admin,User")]
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarPJ(int id, [FromBody] UpdatePessoaJuridicaDto pessoaJuridicaDto)
    {
        var pjAtualizado = await _pessoaJuridicaService.AtualizarPJ(id, pessoaJuridicaDto);
        if (pjAtualizado == false) return NotFound();
        return Ok(pjAtualizado);
    }

    [Authorize(Roles = "Gerente,Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarPJ(int id)
    {
        var pessoaJuridica = await _pessoaJuridicaService.DeletarPJ(id);
        if (pessoaJuridica == false) return NotFound();
        return NoContent();
    }
}
