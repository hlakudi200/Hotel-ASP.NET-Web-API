using Application.Interfaces;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;


namespace Application.Services
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelApiContext _context;

        public RoomRepository(HotelApiContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<object>> GetByBookStatus(bool? bookStatus)
        {

            var rooms = await _context.Rooms
             .Where(r => r.Booked == bookStatus)
             .Include(r => r.RoomFeatures)


             .ThenInclude(rf => rf.Feature)
             .Select(r => new
             {
                 r.Id,
                 r.RoomNo,
                 r.RoomType,
                 r.Booked,
                 r.Locked,
                 Features = r.RoomFeatures.Select(f => f.Feature.FeatureName)
             }).ToListAsync();

            return rooms;
        }


        public async Task<IEnumerable<object>> GetAllAsync()
        {
            var rooms = await _context.Rooms
             .Include(r => r.RoomFeatures)
             .ThenInclude(rf => rf.Feature)
             .Select(r => new
             {
                 r.Id,
                 r.RoomNo,
                 r.RoomType,
                 r.Booked,
                 r.Locked,
                 Features = r.RoomFeatures.Select(f => f.Feature.FeatureName)
             }).ToListAsync();

            return rooms;
        }

        public async Task<Room> UpdateAsync(RoomDto request)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == request.Id);


            if (room == null)
            {
                return null;
            }

            room.Locked = request.Locked;
            room.Booked = request.Booked;
            _context.Update(room);
            await _context.SaveChangesAsync();
            return room;

        }

    }
}

