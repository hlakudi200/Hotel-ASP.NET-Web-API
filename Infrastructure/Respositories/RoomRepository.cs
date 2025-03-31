using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces;



namespace Infrastructure.Respositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelApiContext _context;
        public RoomRepository(HotelApiContext context, IGenericRepository<Room> genericRepository)
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

 


    }
}

