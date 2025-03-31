using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;

        private readonly IGenericRepository<Client> _genericrepo;

        public ClientService(IMapper mapper, IGenericRepository<Client> genericrepo)
        {
            _mapper = mapper;
            _genericrepo = genericrepo;

        }

        public async Task<IEnumerable<ClientResponseDto>> GetAllAsync()
        {
            var clients = await _genericrepo.GetAllAsync();

            return _mapper.Map<IEnumerable<ClientResponseDto>>(clients);
        }


        public async Task AddAsync(ClientRequestDto clientDto)
        {
            await _genericrepo.AddAsync(_mapper.Map<Client>(clientDto));
        }

        public async Task<string?> UpdateAsync(ClientRequestDto clientRequestDto, int id)
        {
            var client = await _genericrepo.GetByIdAsync(id);

            if (client == null)
            {
                return null;
            }

            try
            {
                await _genericrepo.UpdateAsync(_mapper.Map(clientRequestDto, client!));

                return "Client Updated";
            }
            catch
            {
                return null;
            }
        }

        public async Task<ClientResponseDto> GetByIdAsync(int id)
        {
            var booking = await _genericrepo.GetByIdAsync(id);

            return _mapper.Map<ClientResponseDto>(booking);
        }




    }
}
