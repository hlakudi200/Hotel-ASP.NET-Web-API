using Application.Services;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {   
        private readonly Application.Services.IGenericRepository<Room> _roomRepository;
        private readonly IRoomRepository _roomRepository2;

        public RoomController(Application.Services.IGenericRepository<Room> roomRepository,IRoomRepository room)
        {   
            _roomRepository = roomRepository;
            _roomRepository2 = room;
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
            var room= await _roomRepository.GetByIdAsync(id);
            return Ok(room);
        }

        [HttpGet("GetAvailableRooms")]
        public async Task<IActionResult> GetAvailableRooms()
        {
            var availabaeRooms= await _roomRepository2.GetAvailableRoomsAsync();
            return Ok(availabaeRooms);
        }

        [HttpGet("GetAvailableRooms{bookStatus}")]
        public async Task<IActionResult> GetRoomByStatus(bool bookStatus)
        {
            var rooms = await _roomRepository2.GetByBookStatus(bookStatus);
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
            await _roomRepository.AddAsync(room);
            return CreatedAtAction(nameof(Get),new {id=room.Id},room);
        }

  
        
      
    }
}
