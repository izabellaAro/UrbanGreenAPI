using Microsoft.EntityFrameworkCore;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Persistence;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.DataAcess.Repositories.Impl;

public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
    public ProdutoRepository(DataContext context) : base(context) { }

    public async Task<IEnumerable<Produto>> ConsultarProdutos(int skip, int take)
    {
        return await _dbSet.Skip(skip).Take(take).ToListAsync();
    }
    public async Task<Produto> ConsultarProdutoPorID(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }
}
