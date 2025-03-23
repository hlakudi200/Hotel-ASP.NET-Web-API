﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Core.Interfaces;
using HotelApi.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {    
        private readonly HotelApiContext _context;
        private readonly DbSet<T> _dbsets;

        public GenericRepository(HotelApiContext context)
        {
            _context = context;
            _dbsets = _context.Set<T>();

        }


        public async Task AddAsync(T entity)
        {
            await _dbsets.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity=await _dbsets.FindAsync(id);
            if (entity != null)
            {
                _dbsets.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbsets.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbsets.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbsets.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
