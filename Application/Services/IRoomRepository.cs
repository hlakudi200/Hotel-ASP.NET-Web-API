using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.Services
{
    public interface IRoomRepository
    {
        Task<IEnumerable> GetAvailableRoomsAsync();
        Task<IEnumerable> GetBookedRoomsAsync();

        Task<IEnumerable<Room>> GetByBookStatus(bool? bookStatus);
    }
}
