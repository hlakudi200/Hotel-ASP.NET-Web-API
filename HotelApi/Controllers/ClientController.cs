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
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(clients);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            return Ok(client);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientRequestDto clientRequestDto)
        {
            if (clientRequestDto == null)
            {
                return BadRequest();
            }
            await _clientService.AddAsync(clientRequestDto);
            return CreatedAtAction(nameof(Get), clientRequestDto);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClientRequestDto clientRequestDto)
        {
            if (clientRequestDto == null)
            {
                return BadRequest();
            }

            await _clientService.UpdateAsync(clientRequestDto, id);
            return Ok(clientRequestDto);
        }

    }
}
