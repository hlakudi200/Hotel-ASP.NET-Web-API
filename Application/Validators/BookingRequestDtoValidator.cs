using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Application.DTOs;
using Application.Interfaces;
using Core.Entities;
using Application.Services;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Application.Validators
{
    public class BookingRequestDtoValidator : AbstractValidator<BookingRequestDto>
    {
       
        private readonly HotelApiContext _context;
        public BookingRequestDtoValidator(IGenericRepository<Room> repository, HotelApiContext context)
        {
            _context = context;
            
            RuleFor(x => x.RoomId)
                .NotEmpty().WithMessage("RoomId is required.")
                .Must(RoomExists).WithMessage("Room with given Id does not exixt");

            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("ClienId is required")
                .Must(ClientExists).WithMessage("Client with given Id does not Exist ");

            RuleFor(x => x.Persons)
                .NotEmpty().WithMessage("Persons is required")
                .GreaterThan(0).WithMessage("Age must be greater thna 0");
            
        }

        private bool RoomExists(int roomId)
        {
            return _context.Rooms.Any(r => r.Id == roomId);
        }
        private bool ClientExists(int roomId)
        {
            return _context.Clients.Any(r => r.Id == roomId);
        }
    }
}
