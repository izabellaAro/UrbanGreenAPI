using UrbanGreen.Application.Models.Inspecao;

namespace UrbanGreen.Application.Services.Interfaces;

public interface IInspecaoService
{
    Task CadastrarInspecao(CreateInspecaoDto inspecaoDto);
    Task<IEnumerable<ReadInspecaoDto>> ConsultarInspecao(int skip = 0, int take = 20);
    Task<ReadInspecaoDto> ConsultarInspecaoPorID(int id);
    Task<bool> AtualizarInspecao(int id, UpdateInspecaoDto inspecaoDto);
    Task<bool> DeletarInspecao(int id);
    Task<IList<ReadTipoItensInspecaoDto>> ConsultarTiposItens();
}
