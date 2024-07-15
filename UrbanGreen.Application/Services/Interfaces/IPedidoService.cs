using UrbanGreen.Application.Models.Pedido;

namespace UrbanGreen.Application.Services.Interfaces;

public interface IPedidoService
{
    Task CadastrarPedido(CreatePedidoDto pedidoDto);
    Task<IEnumerable<ReadPedidoDto>> ConsultarPedido(int skip = 0, int take = 20);
    Task<ReadPedidoDto> ConsultarPedidoPorID(int id);
    Task<bool> AtualizarPedido(int id, UpdatePedidoDto pedidoDto);
    Task<bool> DeletarPedido(int id);
    Task<IEnumerable<ReadPedidoDto>> ListarItens();
    double CalcularValorTotal(double valor, int quantidade);
}
