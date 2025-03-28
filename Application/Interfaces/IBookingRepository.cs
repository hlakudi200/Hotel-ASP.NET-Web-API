using Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<BookingResponseDto>> GetAllAsync();
        Task AddAsync(BookingRequestDto bookingDto);
        Task UpdateAsync(BookingUpdateDto bookingUpdateDto, int id);
    }
}
