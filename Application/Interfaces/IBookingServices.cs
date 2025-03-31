using Application.DTOs;

namespace Application.Interfaces
{
    public interface IBookingServices
    {
        Task<IEnumerable<BookingResponseDto>> GetAllAsync();
        Task AddAsync(BookingRequestDto bookingDto);
        Task<string> UpdateAsync(BookingRequestDto bookingUpdateDto, int id);
        Task<BookingResponseDto> GetByIdAsync(int id);
    }
}
