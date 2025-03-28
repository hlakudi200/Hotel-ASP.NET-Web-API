using Application.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IGenericRepository<Client> _clientRepository;

        public ClientController(IGenericRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clients = await _clientRepository.GetAllAsync();
            return Ok(clients);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            return Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }

            await _clientRepository.AddAsync(client);
            return CreatedAtAction(nameof(Get), new { id = client.Id }, client);

        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }

            await _clientRepository.UpdateAsync(client);
            return Ok(client);
        }

    }
}
