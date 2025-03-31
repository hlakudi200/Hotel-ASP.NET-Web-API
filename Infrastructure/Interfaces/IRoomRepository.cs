using Core.Entities;

namespace Infrastructure.Interfaces
{
    public interface IRoomRepository
    {

        Task<IEnumerable<object>> GetAllAsync();
        Task<IEnumerable<object>> GetByBookStatus(bool? bookStatus);


    }
}
