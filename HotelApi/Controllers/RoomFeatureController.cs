using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomFeatureController : ControllerBase
    {
        private readonly IRoomFeatureService _roomFeatureService;
        public RoomFeatureController(IRoomFeatureService roomFeatureService)
        {
            _roomFeatureService = roomFeatureService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roomFeatures = await _roomFeatureService.GetAllAsync();

            return Ok(roomFeatures);
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
