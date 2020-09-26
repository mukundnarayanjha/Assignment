using Assignment.API.Data.Interface;
using Assignment.API.Models;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Assignment.API.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment.API.UnitTest
{
    [TestClass]
    public class BookingsControllerTest
    {
        private BookingsController _controller;
        private Mock<IBookingService> _bookingservice;
        private Mock<ICityService> _cityService;
        private Mock<IGenresService> _genresService;
        private Mock<IMovieService> _movieService;
        private Mock<ILanguagesService> _languagesService;
        private Mock<IMultiplexService> _multiplexService;
        private Fixture _fixture;

        [TestInitialize]
        public void Init()
        {
            _fixture = new Fixture();
            _bookingservice = new Mock<IBookingService>();
            _cityService = new Mock<ICityService>();
            _genresService = new Mock<IGenresService>();
            _movieService = new Mock<IMovieService>();
            _languagesService = new Mock<ILanguagesService>();
            _multiplexService = new Mock<IMultiplexService>();
            _controller = new BookingsController(_bookingservice.Object, _cityService.Object, _movieService.Object,
                                                 _genresService.Object, _languagesService.Object, _multiplexService.Object);
        }
        [TestMethod]
        public async Task GetCollection_CheckUserNotNull_Returns_AllBookingsDetails()
        {
            var expected = _fixture.Create<IEnumerable<Booking>>();

            _bookingservice.Setup(m => m.GetAllBookingAsync()).Returns(Task.FromResult(expected));

            var result = await _controller.GetAll() as ObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Value);
        }

        [TestMethod]
        public async Task WhenCreatingBooking_InvalidModelState_ControllerReturnedBadRequest()
        {
            const Booking input = null;
            var expected = _fixture.Create<Guid>();

            _bookingservice.Setup(m => m.AddBookingAsync(input)).Returns(Task.FromResult(expected.ToString()));

            var result = await _controller.Create(input) as ObjectResult;
            Assert.IsNotNull(result, "BadRequest");

        }

        [TestMethod]
        public async Task WhenCreatingBooking_ValidInput_ControllerReturnsValidResponse()
        {
            Booking input = new Booking();
            var expected = _fixture.Create<Guid>();

            _bookingservice.Setup(m => m.AddBookingAsync(input)).Returns(Task.FromResult(expected.ToString()));

            var result = await _controller.Create(input) as ObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, 201);
        }
    }
}
