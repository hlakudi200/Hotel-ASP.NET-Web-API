using Application.DTOs;
using Application.Interfaces;
using Core.Entities;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Interfaces;

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
                .Must(RoomExists).WithMessage("Room with given Id does not exist")
                .Must(RoomAvailable).WithMessage("Room is not available");

            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("ClienId is required")
                .Must(ClientExists).WithMessage("Client with given Id does not Exist ");

            RuleFor(x => x.Persons)
                .NotEmpty().WithMessage("Persons is required")
                .GreaterThan(0).WithMessage("Persons cannot be less than 0")
                .LessThan(4).WithMessage("Person must be less than 4");


            RuleFor(x => x.CheckInDate)
                .NotEmpty().WithMessage("Check-in date is required")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Check-in date cannot be in the past");

            RuleFor(x => x.CheckOutDate)
                .NotEmpty().WithMessage("Check-out date is require")
                .GreaterThanOrEqualTo(x => x.CheckInDate).WithMessage("Check-out date must be after the check-in date");

        }

        private bool RoomAvailable(int roomId)
        {
            var roomObj = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
            return roomObj != null && roomObj.Booked;
        }
        private bool RoomExists(int roomId)
        {
            var roomObj = _context.Rooms.Any(r => r.Id == roomId);
            return roomObj;
        }


        private bool ClientExists(int roomId)
        {
            return _context.Clients.Any(r => r.Id == roomId);
        }

    }
}
