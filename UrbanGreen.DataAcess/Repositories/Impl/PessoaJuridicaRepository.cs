using Microsoft.EntityFrameworkCore;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Persistence;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.DataAcess.Repositories.Impl;

public class PessoaJuridicaRepository : BaseRepository<PessoaJuridica>, IPessoaJuridicaRepository
{
    public PessoaJuridicaRepository(DataContext context) : base(context) { }

    public async Task<IEnumerable<PessoaJuridica>> ConsultarPJ(int skip, int take)
    {
        return await _dbSet.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<PessoaJuridica> ConsultarPJPorID(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }
}
