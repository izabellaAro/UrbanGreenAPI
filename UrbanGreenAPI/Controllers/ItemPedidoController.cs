using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrbanGreen.Application.Models.ItemPedido;
using UrbanGreen.Application.Services.Interfaces;

namespace UrbanGreenAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemPedidoController : ControllerBase
{
    private readonly IItemPedidoService _itemPedidoService;
    private readonly IProdutoService _produtoService;

    public ItemPedidoController(IItemPedidoService itemPedidoService, IProdutoService produtoService)
    {
        _itemPedidoService = itemPedidoService;
        _produtoService = produtoService;
    }

    [Authorize(Roles = "Gerente,Admin,User")]
    [HttpPost]
    public async Task<IActionResult> CadastrarItemPedido([FromBody] CreateItemPedidoDto itemPedidoDto)
    {
        var produto = await _produtoService.ConsultarProdutoPorID(itemPedidoDto.ProdutoId);

        if (produto == null)
        {
            throw new Exception("Produto não encontrado.");
        }
        await _itemPedidoService.CadastrarItemPedido(itemPedidoDto);
        return NoContent();
    }

    [Authorize(Roles = "Gerente,Admin,User")]
    [HttpGet]
    public async Task<IEnumerable<ReadItemPedidoDto>> ConsultarItemPedido([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return await _itemPedidoService.ConsultarItemPedido(skip, take);
    }

    [Authorize(Roles = "Gerente,Admin,User")]
    [HttpGet("{id}")]
    public async Task<IActionResult> ConsultarItemPedidoPorID(int id)
    {
        var itemPedido = await _itemPedidoService.ConsultarItemPedidoPorID(id);
        if (itemPedido == null) return NotFound();
        return Ok(itemPedido);
    }

    [Authorize(Roles = "Gerente,Admin,User")]
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarItemPedido(int id, [FromBody] UpdateItemPedidoDto itemPedidoDto)
    {
        var itemPedidoAtualizado = await _itemPedidoService.AtualizarItemPedido(id, itemPedidoDto);
        if (itemPedidoAtualizado == false) return NotFound();
        return NoContent();
    }

    [Authorize(Roles = "Gerente,Admin,User")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarItemPedido(int id)
    {
        var itemPedido = await _itemPedidoService.DeletarItemPedido(id);
        if (itemPedido == false) return NotFound();
        return NoContent();
    }
}