using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IGenericRepository<Client> _clientRepository;
        private readonly IMapper _mapper;
        public ClientController(IGenericRepository<Client> clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clients = await _clientRepository.GetAllAsync();
            var ClientsDto = _mapper.Map<IEnumerable<ClientResponseDto>>(clients);
            return Ok(ClientsDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            return Ok(client);
        }


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
