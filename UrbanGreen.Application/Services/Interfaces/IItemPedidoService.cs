using UrbanGreen.Application.Models.ItemPedido;

namespace UrbanGreen.Application.Services.Interfaces;

public interface IItemPedidoService
{
    Task CadastrarItemPedido(CreateItemPedidoDto itemPedidoDto);
    Task<IEnumerable<ReadItemPedidoDto>> ConsultarItemPedido(int skip = 0, int take = 20);
    Task<ReadItemPedidoDto> ConsultarItemPedidoPorID(int id);
    Task<bool> AtualizarItemPedido(int id, UpdateItemPedidoDto itemPedidoDto);
    Task<bool> DeletarItemPedido(int id);
}
