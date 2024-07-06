using Microsoft.EntityFrameworkCore;
using UrbanGreen.DataAcess.Persistence;
using UrbanGreen.DataAcess.Repositories.Interfaces;
using UrbanGreenAPI.Core.Entities;

namespace UrbanGreen.DataAcess.Repositories.Impl;

public class InsumoRepository : BaseRepository<Insumo>, IInsumoRepository
{
    public InsumoRepository(DataContext context) : base(context) { }

    public async Task<IEnumerable<Insumo>> ConsultarInsumos(int skip, int take)
    {
        return await _dbSet.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Insumo> ConsultarInsumoPorID(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }
}
