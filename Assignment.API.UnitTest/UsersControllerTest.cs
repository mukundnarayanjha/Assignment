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
    public class UsersControllerTest
    {
        private UsersController _controller;
        private Mock<IUserService> _uow;
        private Fixture _fixture;

        [TestInitialize]
        public void Init()
        {
            _fixture = new Fixture();
            _uow = new Mock<IUserService>();
            _controller = new UsersController(_uow.Object);
        }
        [TestMethod]
        public async Task GetCollection_CheckUserNotNull_Returns_AllUserDetails()
        {
            var expected = _fixture.Create<IEnumerable<User>>();

            _uow.Setup(m => m.GetAllUserAsync()).Returns(Task.FromResult(expected));

            var result = await _controller.GetAll() as ObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Value);
        }

        [TestMethod]
        public async Task whenCreatingUsers_InvalidModelState_ControllerReturnedBadRequest()
        {
            const User input = null;
            var expected = _fixture.Create<Guid>();

            _uow.Setup(m => m.CreateUserAsync(input)).Returns(Task.FromResult(expected.ToString()));

            var result = await _controller.Create(input) as ObjectResult;
            Assert.IsNotNull(result, "BadRequest");

        }

        [TestMethod]
        public async Task whenCreatingUers_ValidInput_ControllerReturnsValidResponse()
        {
            User input = new User();
            var expected = _fixture.Create<Guid>();

            _uow.Setup(m => m.CreateUserAsync(input)).Returns(Task.FromResult(expected.ToString()));

            var result = await _controller.Create(input) as ObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, 201);
        }
    }
}
