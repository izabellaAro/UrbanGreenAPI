using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrbanGreen.Application.Models.Produto;
using UrbanGreen.Application.Services.Interfaces;

namespace UrbanGreenAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [Authorize(Roles = "Gerente,Admin")]
    [HttpPost]
    public async Task<IActionResult> CadastrarProduto([FromForm] CreateProdutoDto produtoDto)
    {
        await _produtoService.CadastrarProduto(produtoDto);
        return NoContent();
    }

    [Authorize(Roles = "Gerente,Admin,User")]
    [HttpGet]
    public async Task<IEnumerable<ReadProdutoDto>> ConsultarProdutos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return await _produtoService.ConsultarProdutos(skip, take);
    }

    [Authorize(Roles = "Gerente,Admin,User")]
    [HttpGet("{id}")]
    public async Task<IActionResult> ConsultarProdutoPorID(int id)
    {
        var produto = await _produtoService.ConsultarProdutoPorID(id);
        if (produto == null) return NotFound();
        return Ok(produto);
    }

    [Authorize(Roles = "Gerente,Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarProduto(int id, [FromForm] UpdateProdutoDto produtoDto)
    {
        var produtoAtualizado = await _produtoService.AtualizarProduto(id, produtoDto);
        if (produtoAtualizado == false) return NotFound();
        return NoContent();
    }

    [Authorize(Roles = "Gerente,Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarProduto(int id)
    {
        var produto = await _produtoService.DeletarProduto(id);
        if (produto == false) return NotFound();
        return NoContent();
    }

    [Authorize(Roles = "Gerente,Admin,User")]
    [HttpGet("{id}/imagem")]
    public async Task<IActionResult> ObterImagemProduto(int id)
    {
        var imagem = await _produtoService.ObterImagemProduto(id);

        if (imagem == null) return NotFound();

        return Ok(imagem);
    }
}