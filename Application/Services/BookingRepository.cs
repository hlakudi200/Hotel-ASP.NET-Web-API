using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Application.Services
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IMapper _mapper;
        private readonly HotelApiContext _context;
        private readonly IGenericRepository<Booking> _genericrepo;
        public BookingRepository(HotelApiContext context, IMapper mapper, IGenericRepository<Booking> genericrepo)
        {
            _context = context;
            _mapper = mapper;
            _genericrepo = genericrepo; 
        }

        public async Task<IEnumerable<BookingResponseDto>> GetAllAsync()
        {
            var bookings = await _context.Bookings.Include(b => b.Client).ToListAsync();
            return _mapper.Map<IEnumerable<BookingResponseDto>>(bookings);
        }


        public async Task AddAsync(BookingRequestDto bookingDto)
        {
            await _context.AddAsync(_mapper.Map<Booking>(bookingDto));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookingUpdateDto bookingUpdateDto,int id)
        {
            var booking = await _genericrepo.GetByIdAsync(id);
            
            _context.Update(_mapper.Map(bookingUpdateDto,booking!));
            await _context.SaveChangesAsync();
        }
    }
}
