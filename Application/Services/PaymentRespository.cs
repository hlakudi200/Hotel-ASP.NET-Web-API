using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class PaymentRespository : IPaymentRepository
    {
        private readonly HotelApiContext _context;
        private readonly IMapper _mapper;
        //Service Injection or dependecy injection 
        public PaymentRespository(HotelApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PaymentResponseDto>> GetAllAsync()
        {
            var payments = await _context.Payments.ToListAsync();
            return _mapper.Map<IEnumerable<PaymentResponseDto>>(payments);
        }


    }
}
