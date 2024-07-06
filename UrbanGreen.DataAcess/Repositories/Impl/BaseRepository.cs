using Microsoft.EntityFrameworkCore;
using UrbanGreen.DataAcess.Persistence;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.DataAcess.Repositories.Impl;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(DataContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entidade)
    {
        await _context.AddAsync(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entidade)
    {
        _context.Remove(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entidade)
    {
        _context.Update(entidade);
        await _context.SaveChangesAsync();
    }
}
