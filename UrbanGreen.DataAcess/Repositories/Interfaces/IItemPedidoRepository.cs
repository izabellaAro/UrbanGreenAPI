using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Repositories.Interfaces;

public interface IItemPedidoRepository : IBaseRepository<ItemPedido>
{
    Task<IEnumerable<ItemPedido>> ConsultarItemPedido(int skip, int take);
    Task<ItemPedido> ConsultarItemPedidoPorID(int id);
}
