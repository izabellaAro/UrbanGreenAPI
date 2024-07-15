﻿using Microsoft.EntityFrameworkCore;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Interface;
using UrbanGreen.DataAcess.Persistence;

namespace UrbanGreen.DataAcess.Repositories.Impl;

public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
{
    public FornecedorRepository(DataContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Fornecedor>> ConsultarFornecedor(int skip, int take)
    {
        return await _dbSet.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Fornecedor> ConsultarFornecedorPorID(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.FornecedorId == id);
    }
}
