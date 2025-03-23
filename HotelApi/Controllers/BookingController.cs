using Application.Services;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IGenericRepository<Booking> _bookingRepository;

        public BookingController(IGenericRepository<Booking> bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        //we are creating a instace of type Igeneric? we are not directly creating an instace but we are injecting a service.
        //When the Booking Controller is instatiated,the IGenericRepo will be injected through the constructor 
        //

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bookings=await _bookingRepository.GetAllAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var booking  =await _bookingRepository.GetByIdAsync(id);
            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Booking booking)
        {
            if(booking == null)
            {
                return BadRequest();
            }
            await _bookingRepository.AddAsync(booking);
            return CreatedAtAction(nameof(Get),new {id=booking.Id},booking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] Booking booking)
        {
            if (booking == null)
            {
                return BadRequest();
            }
            await _bookingRepository.UpdateAsync(booking);
            return NoContent(); 
        }
    }
}
