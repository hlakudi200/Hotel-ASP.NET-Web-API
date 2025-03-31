using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientResponseDto>> GetAllAsync();
        Task AddAsync(ClientRequestDto clientDto);
        Task<string?> UpdateAsync(ClientRequestDto clientRequestDto, int id);
        Task<ClientResponseDto> GetByIdAsync(int id);
    }
}
