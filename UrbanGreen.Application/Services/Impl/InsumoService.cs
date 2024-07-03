using UrbanGreenAPI.Application.Models;

namespace UrbanGreenAPI.Application.Services.Impl;

public class InsumoService : IInsumoService
{
    public Task<bool> AtualizarInsumo(int id, UpdateInsumoDto insumoDto)
    {
        throw new NotImplementedException();
    }

    public Task CadastrarInsumo(CreateInsumoDto insumoDto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ReadInsumoDto>> ConsultarInsumos(int skip = 0, int take = 20)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeletarInsumo(int id)
    {
        throw new NotImplementedException();
    }
}
