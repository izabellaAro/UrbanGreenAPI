using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Repositories.Interfaces;

public interface IPedidoRepository : IBaseRepository<Pedido>
{
    Task<IEnumerable<Pedido>> GetAllAsync();
    Task<IEnumerable<Pedido>> ConsultarPedido(int skip, int take);
    Task<Pedido> ConsultarPedidoPorID(int id);
}
