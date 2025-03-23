using Core.Models;
using Core.Entities;
using HotelApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : Controller
    {


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO request)  //we basicaly just pass in the string email and string password ,hen we can use that,so we need an object of type User which when we use the context methods we will be provided the user ,in case of registering and loggin in a user 
        {  //all the other inputs must be included using the dto 

            var user = await authService.RegisterAsync(request);
            if (user is null)
            {
                return BadRequest("Email already exist");
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDTO request)
        {
            var token = await authService.LoginAsync(request);

            if (token is null)
            {
                return BadRequest("Invalid email or password");
            }


            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AutheticatedOnlyEndpoint()
        {
            return Ok("You are authenticated");
        }

        [Authorize(Roles = "admin")]
        [HttpGet("admin")]
        public IActionResult AutheticatedOnlyEndpointAdmin()
        {
            return Ok("You are authenticated and Authorised as Admin");
        }





        //we can serilize in form of data ,even if is not the user 


    }
}
