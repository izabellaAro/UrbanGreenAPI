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

    [HttpPost]
    public async Task<IActionResult> CadastrarPJ([FromBody] CreatePessoaJuridicaDto pessoaJuridicaDto)
    {
        await _pessoaJuridicaService.CadastrarPJ(pessoaJuridicaDto);
        return NoContent();
    }

    [HttpGet]
    public async Task<IEnumerable<ReadPessoaJuridicaDto>> ConsultarPJ([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return await _pessoaJuridicaService.ConsultarPJ(skip, take);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ConsultarPJPorID(int id)
    {
        var pessoaJuridica = await _pessoaJuridicaService.ConsultarPJPorID(id);
        if (pessoaJuridica == null) return NotFound();
        return Ok(pessoaJuridica);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarPJ(int id, [FromBody] UpdatePessoaJuridicaDto pessoaJuridicaDto)
    {
        var pjAtualizado = await _pessoaJuridicaService.AtualizarPJ(id, pessoaJuridicaDto);
        if (pjAtualizado == false) return NotFound();
        return Ok(pjAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarPJ(int id)
    {
        var pessoaJuridica = await _pessoaJuridicaService.DeletarPJ(id);
        if (pessoaJuridica == false) return NotFound();
        return NoContent();
    }
}
