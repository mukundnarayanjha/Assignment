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
    public class MoviesControllerTest
    {
        private MoviesController _controller;
        private Mock<IMovieService> _uow;
        private Fixture _fixture;

        [TestInitialize]
        public void Init()
        {
            _fixture = new Fixture();
            _uow = new Mock<IMovieService>();
            _controller = new MoviesController(_uow.Object);
        }
        [TestMethod]
        public async Task GetCollection_CheckUserNotNull_Returns_AllMoviesDetails()
        {
            var expected = _fixture.Create<IEnumerable<Movie>>();

            _uow.Setup(m => m.GetAllMovieAsync()).Returns(Task.FromResult(expected));

            var result = await _controller.GetAll() as ObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Value);
        }

        [TestMethod]
        public async Task WhenAddMovie_InvalidModelState_ControllerReturnedBadRequest()
        {
            const Movie input = null;
            var expected = _fixture.Create<Guid>();

            _uow.Setup(m => m.AddMovieAsync(input)).Returns(Task.FromResult(expected.ToString()));

            var result = await _controller.Create(input) as ObjectResult;
            Assert.IsNotNull(result, "BadRequest");

        }

        [TestMethod]
        public async Task WhenAddMovie_ValidInput_ControllerReturnsValidResponse()
        {
            Movie input = new Movie();
            var expected = _fixture.Create<Guid>();

            _uow.Setup(m => m.AddMovieAsync(input)).Returns(Task.FromResult(expected.ToString()));

            var result = await _controller.Create(input) as ObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, 201);
        }
    }
}
