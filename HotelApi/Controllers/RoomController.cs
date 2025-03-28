using Application.DTOs;
using Application.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IGenericRepository<Room> _roomRepositoryFromGen;
        private readonly IRoomRepository _roomRepository;

        public RoomController(IGenericRepository<Room> roomRepository, IRoomRepository room)
        {
            _roomRepositoryFromGen = roomRepository;
            _roomRepository = room;
        }

        // GET: api/<RoomController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return Ok(rooms);
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var room = await _roomRepositoryFromGen.GetByIdAsync(id);
            return Ok(room);
        }



        [HttpGet("GetAvailableRooms{bookStatus}")]
        public async Task<IActionResult> GetRoomByStatus(bool bookStatus)
        {
            var rooms = await _roomRepository.GetByBookStatus(bookStatus);
            return Ok(rooms);
        }

        // POST api/<RoomController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Room room)
        {
            if (room == null)
            {
                return BadRequest();
            }
            await _roomRepositoryFromGen.AddAsync(room);
            return CreatedAtAction(nameof(Get), new { id = room.Id }, room);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RoomDto room)
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
