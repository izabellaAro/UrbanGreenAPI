using UrbanGreen.Application.Models.ItemPedido;
using UrbanGreen.Application.Services.Interfaces;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.Application.Services.Impl
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly IProdutoRepository _produtoRepository;


        public ItemPedidoService(IItemPedidoRepository itemPedidoRepository, IProdutoRepository produtoRepository)
        {
            _itemPedidoRepository = itemPedidoRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> AtualizarItemPedido(int id, UpdateItemPedidoDto ItemPedidoDto)
        {
            var produto = await _produtoRepository.ConsultarProdutoPorID(ItemPedidoDto.ProdutoId);
            var itemPedido = await _itemPedidoRepository.ConsultarItemPedidoPorID(id);
            if (itemPedido == null || produto == null) return false;
            await _itemPedidoRepository.UpdateAsync(itemPedido);
            return true;
        }

        public async Task CadastrarItemPedido(CreateItemPedidoDto ItemPedidoDto)
        {
            var produto = await _produtoRepository.ConsultarProdutoPorID(ItemPedidoDto.ProdutoId);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            var itemPedido = new ItemPedido(produto, ItemPedidoDto.Quantidade, produto.Id);
            
            await _itemPedidoRepository.AddAsync(itemPedido);

        }

        public Task<IEnumerable<ReadItemPedidoDto>> ConsultarItemPedido(int skip = 0, int take = 20)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadItemPedidoDto> ConsultarItemPedidoPorID(int id)
        {
            var itemPedidoID = await _itemPedidoRepository.ConsultarItemPedidoPorID(id);

            if (itemPedidoID == null) return null;

            return new ReadItemPedidoDto
            {
                Id = itemPedidoID.Id,
                Quantidade = itemPedidoID.Quantidade,
                ProdutoId = itemPedidoID.ProdutoId
            };
        }

        public async Task<bool> DeletarItemPedido(int id)
        {
            var itemPedido = await _itemPedidoRepository.ConsultarItemPedidoPorID(id);
            if (itemPedido == null) return false;
            await _itemPedidoRepository.DeleteAsync(itemPedido);
            return true;
        }
    }
}
