using UrbanGreen.Application.Models.ItemPedido;
using UrbanGreen.Application.Models.Pedido;
using UrbanGreen.Application.Services.Interfaces;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.Application.Services.Impl;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IProdutoRepository _produtoRepository;

    public PedidoService(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository)
    {
        _pedidoRepository = pedidoRepository;
        _produtoRepository = produtoRepository;

    }

    public async Task CadastrarPedido(CreatePedidoDto pedidoDto)
    {
        var pedido = new Pedido(pedidoDto.NomeComprador);

        foreach (var item in pedidoDto.ItensPedido)
        {
            var produto = await _produtoRepository.ConsultarProdutoPorID(item.ProdutoId);

            if (produto.Quantidade <= item.Quantidade)
            {
                throw new Exception("Não temos essa quantidade de produto no estoque.");
            }

            var itemPedido = new ItemPedido(produto, item.Quantidade);
            produto.DiminuirEstoque(itemPedido.Quantidade);
            pedido.AdicionarItem(itemPedido);
        }

        await _pedidoRepository.AddAsync(pedido);
    }

    public double CalcularValorTotal(double valor, int quantidade)
    {
        double valorTotal = valor * quantidade;
        return valorTotal;
    }

    public async Task<IEnumerable<ReadPedidoDto>> ConsultarPedido(int skip = 0, int take = 20)
    {
        var consultaPedido = await _pedidoRepository.ConsultarPedido(skip, take);

    return consultaPedido.Select(pedido => new ReadPedidoDto
    {
        Id = pedido.Id,
        Data = pedido.Data,
        NomeComprador = pedido.NomeComprador,
        ValorTotal = pedido.ValorTotal,
        ItemPedidos = pedido.ItemPedidos.Select(itemPedido => new ReadItemPedidoDto
        {
            Id = itemPedido.Id,
            Quantidade = itemPedido.Quantidade,
            ProdutoId = itemPedido.ProdutoId,
            NomeProduto = itemPedido.Produto.Nome
        }).ToList()
    }).ToList();
    }

    public async Task<ReadPedidoDto> ConsultarPedidoPorID(int id)
    {
        var pedido = await _pedidoRepository.ConsultarPedidoPorID(id);

        if (pedido == null) return null;

        var readPedidoDto = new ReadPedidoDto
        {
            Id = pedido.Id,
            Data = pedido.Data,
            NomeComprador = pedido.NomeComprador,
            ValorTotal = pedido.ValorTotal,
            ItemPedidos = pedido.ItemPedidos.Select(itemPedido => new ReadItemPedidoDto
            {
                Id = itemPedido.Id,
                Quantidade = itemPedido.Quantidade,
                ProdutoId = itemPedido.ProdutoId,
                NomeProduto = itemPedido.Produto.Nome 
            }).ToList()
        };

        return readPedidoDto;
    }
    public async Task<bool> DeletarPedido(int id)
    {
            var pedido = await _pedidoRepository.ConsultarPedidoPorID(id);
            if (pedido == null) return false;
            await _pedidoRepository.DeleteAsync(pedido);
            return true;
    }
    public async Task<IEnumerable<ReadPedidoDto>> ListarItens()
    {
        var pedidos = await _pedidoRepository.GetAllAsync();
        var readPedidos = pedidos.Select(pedido => new ReadPedidoDto
        {
            Id = pedido.Id,
            Data = pedido.Data,
            NomeComprador = pedido.NomeComprador,
            ValorTotal = pedido.ValorTotal,
            ItemPedidos = pedido.ItemPedidos.Select(item => new ReadItemPedidoDto
            {
                NomeProduto = item.Produto.Nome,
                Quantidade = item.Quantidade
            }).ToList()
        }).ToList();

        return readPedidos;
    }
}
