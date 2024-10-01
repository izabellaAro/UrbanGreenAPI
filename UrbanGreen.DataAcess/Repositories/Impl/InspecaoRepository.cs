using Microsoft.EntityFrameworkCore;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Persistence;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.DataAcess.Repositories.Impl;

public class InspecaoRepository : BaseRepository<Inspecao>, IInspecaoRepository
{
    public InspecaoRepository(DataContext context) : base(context) {}

    public async Task<IEnumerable<Inspecao>> ConsultarInspecao(int skip, int take)
    {
        return await _dbSet
            .Include(x => x.Itens)
                .ThenInclude(x => x.TipoItemInspecao)
            .Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Inspecao> ConsultarInspecaoPorID(int id)
    {
        return await _dbSet
            .Include(x => x.Itens)
                .ThenInclude(x => x.TipoItemInspecao)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
