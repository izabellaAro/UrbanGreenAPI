using UrbanGreen.Application.Models.ItemPedido;
using UrbanGreen.Application.Models.Pedido;
using UrbanGreen.Application.Services.Interfaces;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.Application.Services.Impl;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IItemPedidoRepository _itemPedidoRepository;
    private readonly IProdutoRepository _produtoRepository;


    public PedidoService(IPedidoRepository pedidoRepository, IItemPedidoRepository itemPedidoRepository, IProdutoRepository produtoRepository)
    {
        _pedidoRepository = pedidoRepository;
        _itemPedidoRepository = itemPedidoRepository;
        _produtoRepository = produtoRepository;

    }

    public async Task<bool> AtualizarPedido(int id, UpdatePedidoDto pedidoDto)
    {
        var pedido = await _pedidoRepository.ConsultarPedidoPorID(id);
        if (pedido == null) return false;

        double valorTotal = 0;
        var itensPedidos = new List<ItemPedido>();

        foreach (var itemId in pedidoDto.ItensPedidoIds)
        {
            var itemPedido = await _itemPedidoRepository.ConsultarItemPedidoPorID(itemId);
            if (itemPedido == null) return false;

            itensPedidos.Add(itemPedido);

            valorTotal += CalcularValorTotal(itemPedido.Produto.Valor, itemPedido.Quantidade);
        }

        pedido.Update(pedidoDto.Data, pedidoDto.NomeComprador, valorTotal);
        pedido.ItemPedidos = itensPedidos;

        await _pedidoRepository.UpdateAsync(pedido);

        return true;
    }



    public async Task CadastrarPedido(CreatePedidoDto pedidoDto)
    {
        var itensPedidos = new List<ItemPedido>();
        double valorTotal = 0;

        foreach (var item in pedidoDto.ItensPedidoIds)
        {
            var itemPedido = await _itemPedidoRepository.ConsultarItemPedidoPorID(item);
            if (itemPedido == null)
            {
                throw new Exception("Item pedido não encontrado.");
            }

            var produto = await _produtoRepository.ConsultarProdutoPorID(itemPedido.ProdutoId);

            if (produto.Quantidade <= itemPedido.Quantidade)
            {
                throw new Exception("Não temos essa quantidade de produto no estoque.");
            }

            int quantidadeAtualizada = itemPedido.Quantidade - produto.Quantidade;

            produto.Update(produto.Nome, quantidadeAtualizada, produto.Valor, produto.Imagem);

            valorTotal += CalcularValorTotal(produto.Valor, itemPedido.Quantidade);

            itensPedidos.Add(itemPedido);
        }

        var pedido = new Pedido(pedidoDto.Data, pedidoDto.NomeComprador, valorTotal)
        {
            ItemPedidos = itensPedidos
        };
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
