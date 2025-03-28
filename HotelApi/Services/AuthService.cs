using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Entities;
using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HotelApi.Services
{
    public class AuthService(HotelApiContext context, IConfiguration configuration) : IAuthService
    {
        public async Task<string> LoginAsync(UserDTO request)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user is null)
            {
                return null;
            }
            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
            {
                return null;
            }
            //when we log in a user db context will return  a user.
            string token = CreateToken(user);

            return token;
        }

        public async Task<User?> RegisterAsync(UserDTO request)
        {

            if (await context.Users.AnyAsync(u => u.Email == request.Email))
            {
                return null;
            }

            User user = new User();

            var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);

            user.Email = request.Email;
            user.PasswordHash = hashedPassword;
            user.Role = request.Role!;
            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }
        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())//The Asyn for fiding the user in the db will provide us with a nexisiting user
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token"))!);

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescripter = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(20),
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescripter);
        }
    }
}
