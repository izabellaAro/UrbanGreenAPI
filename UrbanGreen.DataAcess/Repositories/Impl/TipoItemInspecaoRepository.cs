using Microsoft.EntityFrameworkCore;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Persistence;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.DataAcess.Repositories.Impl;

public class TipoItemInspecaoRepository : BaseRepository<TipoItemInspecao>, ITipoItemInspecaoRepository
{
    public TipoItemInspecaoRepository(DataContext context) : base(context) { }

    public async Task<IEnumerable<TipoItemInspecao>> ConsultarItens()
    {
        return await _dbSet.ToListAsync();
    }
}
