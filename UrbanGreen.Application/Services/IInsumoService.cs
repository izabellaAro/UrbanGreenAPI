using UrbanGreenAPI.Application.Models;

namespace UrbanGreenAPI.Application.Services;

public interface IInsumoService
{
    Task CadastrarInsumo(CreateInsumoDto insumoDto);
    Task<IEnumerable<ReadInsumoDto>> ConsultarInsumos(int skip = 0, int take = 20);
    Task<bool> AtualizarInsumo(int id, UpdateInsumoDto insumoDto);
    Task<bool> DeletarInsumo(int id);
}
