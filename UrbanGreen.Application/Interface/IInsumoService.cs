using UrbanGreenAPI.Application.Models;

namespace UrbanGreen.Application.Interface;

public interface IInsumoService
{
    Task CadastrarInsumo(CreateInsumoDto insumoDto);
    Task<IEnumerable<ReadInsumoDto>> ConsultarInsumos(int skip = 0, int take = 20);
    Task<ReadInsumoDto> ConsultarInsumoPorID(int id);
    Task<bool> AtualizarInsumo(int id, UpdateInsumoDto insumoDto);
    Task<bool> DeletarInsumo(int id);
}
