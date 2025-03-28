
using Application.DTOs;
using Core.Entities;

namespace Application.Interfaces
{
    public interface IRoomRepository
    {

        Task<IEnumerable<object>> GetAllAsync();
        Task<IEnumerable<object>> GetByBookStatus(bool? bookStatus);
        Task<Room> UpdateAsync(RoomDto request);

    }
}
