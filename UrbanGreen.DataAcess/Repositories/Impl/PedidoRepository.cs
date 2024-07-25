using Microsoft.EntityFrameworkCore;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Persistence;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.DataAcess.Repositories.Impl;

public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
{
    public PedidoRepository(DataContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Pedido>> ConsultarPedido(int skip, int take)
    {
        return await _dbSet
            .Include(p => p.ItemPedidos)
            .ThenInclude(ip => ip.Produto)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<Pedido> ConsultarPedidoPorID(int id)
    {
        return await _dbSet
            .Include(p => p.ItemPedidos)
            .ThenInclude(ip => ip.Produto)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Pedido>> GetAllAsync()
    {
        return await _dbSet
            .Include(p => p.ItemPedidos)
            .ThenInclude(ip => ip.Produto)
            .ToListAsync();
    }
}
