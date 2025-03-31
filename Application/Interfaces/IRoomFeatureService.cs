using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Core.Entities;

namespace Application.Interfaces
{
    public interface IRoomFeatureService
    {
        Task<IEnumerable<RoomFeature>> GetAllAsync();
        Task AddAsync(RoomFeature clientDto);
        Task<string?> UpdateAsync(RoomFeature roomFeature, int id);
        Task<RoomFeature> GetByIdAsync(int id);
    }
}
