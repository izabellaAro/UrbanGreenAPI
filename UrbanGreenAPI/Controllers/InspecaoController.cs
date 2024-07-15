using Microsoft.AspNetCore.Mvc;
using UrbanGreen.Application.Models.Inspecao;
using UrbanGreen.Application.Services.Interfaces;

namespace UrbanGreenAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InspecaoController : ControllerBase
{
    private readonly IInspecaoService _inspecaoService;

    public InspecaoController(IInspecaoService inspecaoService)
    {
        _inspecaoService = inspecaoService;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarInspecao([FromBody] CreateInspecaoDto inspecaoDto)
    {
        await _inspecaoService.CadastrarInspecao(inspecaoDto);
        return NoContent();
    }

    [HttpGet]
    public async Task<IEnumerable<ReadInspecaoDto>> ConsultarInspecao([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return await _inspecaoService.ConsultarInspecao(skip, take);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ConsultarInspecaoPorID(int id)
    {
        var inspecao = await _inspecaoService.ConsultarInspecaoPorID(id);
        if (inspecao == null) return NotFound();
        return Ok(inspecao);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarInspecao(int id, [FromBody] UpdateInspecaoDto inspecaoDto)
    {
        var inspecaoAtualizado = await _inspecaoService.AtualizarInspecao(id, inspecaoDto);
        if (inspecaoAtualizado == false) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarInspecao(int id)
    {
        var inspecao = await _inspecaoService.DeletarInspecao(id);
        if (inspecao == false) return NotFound();
        return NoContent();
    }
}
