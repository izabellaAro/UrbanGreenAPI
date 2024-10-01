using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Repositories.Interfaces;

public interface ITipoItemInspecaoRepository : IBaseRepository<TipoItemInspecao>
{
    Task<IEnumerable<TipoItemInspecao>> ConsultarItens();
}
