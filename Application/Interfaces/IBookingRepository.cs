using Application.DTOs;

namespace Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<BookingResponseDto>> GetAllAsync();
        Task AddAsync(BookingRequestDto bookingDto);
        Task UpdateAsync(BookingRequestDto bookingUpdateDto, int id);
    }
}
