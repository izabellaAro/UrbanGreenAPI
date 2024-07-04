﻿namespace UrbanGreen.DataAcess.Interface;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entidade);
    Task UpdateAsync(TEntity entidade);
    Task DeleteAsync(TEntity entidade);
}
