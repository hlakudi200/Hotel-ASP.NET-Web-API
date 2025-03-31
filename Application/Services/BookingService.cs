using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Infrastructure.Interfaces;


namespace Application.Services
{
    public class BookingService : IBookingServices
    {
        private readonly IMapper _mapper;

        private readonly IGenericRepository<Booking> _genericrepo;
        private readonly IBookingRepository _bookRepository;
        public BookingService(IMapper mapper, IGenericRepository<Booking> genericrepo, IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _genericrepo = genericrepo;
            _bookRepository = bookingRepository;
        }

        public async Task<IEnumerable<BookingResponseDto>> GetAllAsync()
        {
            var bookings = await _bookRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<BookingResponseDto>>(bookings);
        }


        public async Task AddAsync(BookingRequestDto bookingDto)
        {
            await _genericrepo.AddAsync(_mapper.Map<Booking>(bookingDto));
        }

        public async Task<string> UpdateAsync(BookingRequestDto bookingUpdateDto, int id)
        {
            var booking = await _genericrepo.GetByIdAsync(id);

            if (booking == null)
            {
                return null;
            }

            try
            {
                await _genericrepo.UpdateAsync(_mapper.Map(bookingUpdateDto, booking!));

                return "Booking Updated";
            }
            catch
            {
                return null;
            }
        }

        public async Task<BookingResponseDto> GetByIdAsync(int id)
        {
            var booking = await _bookRepository.GetByIdAsync(id);

            return _mapper.Map<BookingResponseDto>(booking);
        }
    }
}
