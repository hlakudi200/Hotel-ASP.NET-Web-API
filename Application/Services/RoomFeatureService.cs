using Application.Interfaces;
using Core.Entities;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class RoomFeatureService:IRoomFeatureService
    {

        private readonly IGenericRepository<RoomFeature> _genericrepo;

        public RoomFeatureService(IGenericRepository<RoomFeature> genericrepo)
        {

            _genericrepo = genericrepo;

        }

        public async Task<IEnumerable<RoomFeature>> GetAllAsync()
        {
            var roomFeatures = await _genericrepo.GetAllAsync();

            return roomFeatures;
        }


        public async Task AddAsync(RoomFeature roomFeature)
        {
            await _genericrepo.AddAsync(roomFeature);
        }

        public async Task<string?> UpdateAsync(RoomFeature RoomFeature, int id)
        {
            var roomFeature = await _genericrepo.GetByIdAsync(id);

            if (roomFeature == null)
            {
                return null;
            }

            try
            {
                await _genericrepo.UpdateAsync(roomFeature);

                return "RoomFeature Updated";
            }
            catch
            {
                return null;
            }
        }

        public async Task<RoomFeature> GetByIdAsync(int id)
        {
            var roomFeature = await _genericrepo.GetByIdAsync(id);

            return roomFeature;
        }
    }
}
