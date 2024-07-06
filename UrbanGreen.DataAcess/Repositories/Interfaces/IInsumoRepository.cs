using UrbanGreenAPI.Core.Entities;

namespace UrbanGreen.DataAcess.Repositories.Interfaces;

public interface IInsumoRepository : IBaseRepository<Insumo>
{
    Task<IEnumerable<Insumo>> ConsultarInsumos(int skip, int take);
    Task<Insumo> ConsultarInsumoPorID(int id);
}
