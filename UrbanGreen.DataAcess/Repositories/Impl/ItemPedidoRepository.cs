using Microsoft.EntityFrameworkCore;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Persistence;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.DataAcess.Repositories.Impl;

public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
{
    public ItemPedidoRepository(DataContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ItemPedido>> ConsultarItemPedido(int skip, int take)
    {
        return await _dbSet
            .Include(ip => ip.Produto)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<ItemPedido> ConsultarItemPedidoPorID(int id)
    {
        return await _dbSet
        .Include(ip => ip.Produto)
        .FirstOrDefaultAsync(ip => ip.Id == id);
    }
}
