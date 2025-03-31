using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Respositories
{
    public class BookingRespository : IBookingRepository
    {
        private readonly HotelApiContext _context;
        public BookingRespository(HotelApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            var bookings = await _context.Bookings.Include(c => c.Client).ToListAsync();
            return bookings;
        }
        public async Task<Booking> GetByIdAsync(int id)
        {
            var booking = await _context.Bookings
                .Include(b => b.Client)
                .FirstOrDefaultAsync(b => b.Id == id);
            return booking!;
        }
    }
}
