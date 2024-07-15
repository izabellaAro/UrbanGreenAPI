using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Repositories.Interfaces;

public interface IInspecaoRepository : IBaseRepository<Inspecao>
{
    Task<IEnumerable<Inspecao>> ConsultarInspecao(int skip, int take);
    Task<Inspecao> ConsultarInspecaoPorID(int id);
}
