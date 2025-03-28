using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Core.Entities;

namespace Application.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<PaymentResponseDto>> GetAllAsync();
    }
}
