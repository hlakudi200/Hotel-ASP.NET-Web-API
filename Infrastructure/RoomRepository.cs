using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Core.Entities;
using HotelApi.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class RoomRepository : IRoomRepository
    {    
       private readonly HotelApiContext _context;
       private readonly DbSet<Room> _rooms;
        public RoomRepository(HotelApiContext context) {
            _context = context;
        }
        public async Task<IEnumerable> GetAvailableRoomsAsync()
        {   
            var availabeRooms = await _context.Rooms.Where(e => e.Booked == false).ToListAsync();  
            return availabeRooms;
        }

        public async Task<IEnumerable> GetBookedRoomsAsync()
        {
            var availabeRooms = await _context.Rooms.Where(e => e.Booked == true).ToListAsync();
            return availabeRooms;
        }

        public async Task<IEnumerable<Room>> GetByBookStatus(bool? bookStatus)
        {
            //var rooms = await _context.Rooms.Where(e => e.Booked == bookStatus).ToListAsync();
            var rooms = await _context.Rooms.Where(e => e.Booked == bookStatus).ToListAsync();
            return rooms;
        }
    }
}
