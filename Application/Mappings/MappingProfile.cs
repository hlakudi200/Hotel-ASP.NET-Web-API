﻿using Application.DTOs;
using AutoMapper;
using Core.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, BookingResponseDto>().ForMember(dest => dest.ClientDto, opt => opt.MapFrom(src => src.Client));
            CreateMap<Client, ClientResponseDto>();
            CreateMap<ClientRequestDto, Client>();
            CreateMap<BookingRequestDto, Booking>();
            CreateMap<BookingUpdateDto, Booking>();
            CreateMap<RoomRequestDto, Room>();
            CreateMap<RoomAddRequestDto, Room>();
        }
    }
}
