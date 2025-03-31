using Application.Interfaces;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;
using Infrastructure.Interfaces;
using AutoMapper.Features;
using AutoMapper;


namespace Application.Services
{
    public class RoomService : IRoomService
    {

        private readonly IGenericRepository<Room> _genericRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public RoomService(HotelApiContext context, IGenericRepository<Room> genericRepository, IRoomRepository roomRepository, IMapper mapper)
        {

            _genericRepository = genericRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;

        }


        public async Task<IEnumerable<object>> GetByBookStatus(bool? bookStatus)
        {
            var rooms = await _roomRepository.GetByBookStatus(bookStatus);

            return rooms;

        }


        public async Task<IEnumerable<object>> GetAllAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return rooms;
        }

        public async Task<Room> UpdateAsync(RoomRequestDto request)
        {
            var foundRoom = await _genericRepository.GetByIdAsync(request.Id);

            if (foundRoom == null)
            {
                return null;
            }
            await _genericRepository.UpdateAsync(_mapper.Map(request, foundRoom));

            return foundRoom;

        }

        public async Task<Room> CreateAsync(RoomAddRequestDto request)
        {
            if (request == null)
            {
                return null;
            }
            Room room = new Room();
            await _genericRepository.AddAsync(_mapper.Map(request, room));

            return room;
        }
    }
}

