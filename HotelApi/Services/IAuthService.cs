using Core.Entities;
using Core.Models;


namespace HotelApi.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDTO request);
        Task<string> LoginAsync(UserDTO request);
    }
}
