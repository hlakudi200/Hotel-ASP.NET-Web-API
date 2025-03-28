using Application.DTOs;
using Core.Entities;


namespace HotelApi.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<string> LoginAsync(UserDto request);
    }
}
