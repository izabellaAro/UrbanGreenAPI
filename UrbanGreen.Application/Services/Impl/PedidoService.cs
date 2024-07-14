using UrbanGreen.Application.Models.Pedido;
using UrbanGreen.Application.Services.Interfaces;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.Application.Services.Impl
{
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
            var itemPedido = await _itemPedidoRepository.ConsultarItemPedidoPorID(pedidoDto.ItemPedidoId);
            var pedido = await _pedidoRepository.ConsultarPedidoPorID(id);
            if (pedido == null || itemPedido == null) return false;
            pedido.Update(pedidoDto.Data, pedidoDto.NomeComprador, itemPedido, itemPedido.Id);          
            await _pedidoRepository.UpdateAsync(pedido);
            return true;
        }

        public async Task CadastrarPedido(CreatePedidoDto pedidoDto)
        {
            var itemPedido = await _itemPedidoRepository.ConsultarItemPedidoPorID(pedidoDto.ItemPedidoId);
            var produto = await _produtoRepository.ConsultarProdutoPorID(itemPedido.ProdutoId);
            var valorTotal = CalcularValorTotal(produto.Valor, itemPedido.Quantidade);
            if (itemPedido == null)
            {
                throw new Exception("Item pedido não encontrado.");
            }
            
            var pedido = new Pedido(pedidoDto.Data, pedidoDto.NomeComprador, itemPedido, itemPedido.Id, valorTotal);
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
                ItemPedidoId = pedido.ItemPedidoId
            }).ToList();
        }

        public async Task<ReadPedidoDto> ConsultarPedidoPorID(int id)
        {
            var pedidoID = await _pedidoRepository.ConsultarPedidoPorID(id);
            var itemPedido = await _itemPedidoRepository.ConsultarItemPedidoPorID(pedidoID.ItemPedidoId);
            var produto = await _produtoRepository.ConsultarProdutoPorID(itemPedido.ProdutoId);
            if (pedidoID == null) return null;
            return new ReadPedidoDto
            {
                Id = pedidoID.Id,
                Data = pedidoID.Data,
                NomeComprador = pedidoID.NomeComprador,
                ValorTotal = pedidoID.ValorTotal,
                ItemPedidoId = pedidoID.ItemPedidoId,
                NomeProduto = produto.Nome,
                QuantidadeProduto = produto.Quantidade
            };
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

            return pedidos.Select(pedido => new ReadPedidoDto
            {
                Id = pedido.Id,
                Data = pedido.Data,
                NomeComprador = pedido.NomeComprador,
                ValorTotal = pedido.ValorTotal,
                ItemPedidoId = pedido.ItemPedidoId,
                NomeProduto = pedido.ItemPedido.Produto.Nome,
                QuantidadeProduto = pedido.ItemPedido.Produto.Quantidade

            }).ToList();
        }
    }
}
