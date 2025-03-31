
using Application.DTOs;
using Core.Entities;

namespace Application.Interfaces
{
    public interface IRoomService
    {

        Task<IEnumerable<object>> GetAllAsync();
        Task<IEnumerable<object>> GetByBookStatus(bool? bookStatus);
        Task<Room> UpdateAsync(RoomRequestDto request);
        Task<Room> CreateAsync(RoomAddRequestDto request);

    }
}
