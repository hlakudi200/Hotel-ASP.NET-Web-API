
using Application.DTOs;
using Application.Interfaces;
using Core.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IGenericRepository<Booking> _bookingRepositoryFromGen;
        private readonly IBookingServices _bookingService;
        public BookingController(IGenericRepository<Booking> bookingRepositoryFromGen, IBookingServices bookingService)
        {
            _bookingRepositoryFromGen = bookingRepositoryFromGen;
            _bookingService = bookingService;
        }
        //we are creating a instace of type Igeneric? we are not directly creating an instace but we are injecting a service.
        //When the Booking Controller is instatiated,the IGenericRepo will be injected through the constructor 
        //


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bookings = await _bookingService.GetAllAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var booking = await _bookingService.GetByIdAsync(id);
            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookingRequestDto bookingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (bookingDto == null)
            {
                return BadRequest();
            }
            await _bookingService.AddAsync(bookingDto);
            return CreatedAtAction(nameof(Get), bookingDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BookingRequestDto bookingDto)
        {
            if (bookingDto == null)
            {
                return BadRequest();
            }

            await _bookingService.UpdateAsync(bookingDto, id);
            return NoContent();
        }
    }
}
