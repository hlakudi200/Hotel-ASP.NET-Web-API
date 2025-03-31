using Application.DTOs;
using Application.Interfaces;
using Core.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {

        private readonly IRoomService _roomRepository;

        public RoomController(IRoomService room)
        {

            _roomRepository = room;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return Ok(rooms);
        }


        [HttpGet("GetAvailableRooms{bookStatus}")]
        public async Task<IActionResult> GetRoomByStatus(bool bookStatus)
        {
            var rooms = await _roomRepository.GetByBookStatus(bookStatus);
            return Ok(rooms);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoomAddRequestDto room)
        {
            if (room == null)
            {
                return BadRequest();
            }

            await _roomRepository.CreateAsync(room);
            return CreatedAtAction(nameof(Get), room);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RoomRequestDto room)
        {
            if (room == null)
            {
                return BadRequest();
            }
            await _roomRepository.UpdateAsync(room);
            return Ok("Room Updated");
        }

    }
}
