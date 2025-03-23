using Core.Models;
using Core.Entities;


namespace HotelApi.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDTO request);
        Task<string> LoginAsync(UserDTO request);
    }
}
