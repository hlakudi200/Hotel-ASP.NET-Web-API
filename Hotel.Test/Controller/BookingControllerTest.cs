using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Core.Entities;
using FakeItEasy;
using FluentAssertions;
using HotelApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Test.Controller
{
    public class BookingControllerTest
    {
        private readonly IGenericRepository<Booking> _bookingRepositoryFromGen;
        private readonly IBookingRepository _bookingRepository;
        public BookingControllerTest()
        {
            _bookingRepositoryFromGen = A.Fake<IGenericRepository<Booking>>();
            _bookingRepository = A.Fake<IBookingRepository>();

        }


        [Fact]
        public async void BookingConrollerGetBookingsReturnOk()
        {
            //arragne 
            var fakeData = A.Fake<IEnumerable<Booking>>();
            var fakeDataDto = A.Fake<IEnumerable<BookingRequestDto>>();
            //var ReturnFakeDta= await _bookingRepository.GetAllAsync().Result(fakeData);
            A.CallTo(() => _bookingRepository.GetAllAsync());
            var controller = new BookingController(_bookingRepositoryFromGen, _bookingRepository);

            //Act 
            var result = await controller.Get();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


    }
}
