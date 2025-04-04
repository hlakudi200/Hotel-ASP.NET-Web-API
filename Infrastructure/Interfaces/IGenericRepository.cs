﻿using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
