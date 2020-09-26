using Assignment.API.Data.Interface;
using Assignment.API.Models;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Assignment.API.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment.API.UnitTest
{
    [TestClass]
    public class AuthControllerTest
    {
        private AuthController _controller;
        private Mock<IAuthenticationService> _authenticationService;
        private Mock<IRoleService> _roleService;
        private Mock<IConfiguration> _config;
        private Fixture _fixture;

        [TestInitialize]
        public void Init()
        {
            _fixture = new Fixture();
            _authenticationService = new Mock<IAuthenticationService>();
            _roleService = new Mock<IRoleService>();
            _config = new Mock<IConfiguration>();
            _controller = new AuthController(_config.Object,_authenticationService.Object,_roleService.Object);
        }

        [TestMethod]
        public async Task WhenLoginUers_ValidInput_ControllerReturnsValidResponse()
        {
            LoginModel input = new LoginModel();
            var expected = _fixture.Create<User>();

            _authenticationService.Setup(m => m.GetAuthenticatedUserAsync(input)).Returns(Task.FromResult(expected));

            var result = await _controller.Login(input) as ObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, 200);
        }

    }
}
