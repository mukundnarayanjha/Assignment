using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Assignment.API.Data.Interface;
using Assignment.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration config;
        private IAuthenticationService service;
        private IRoleService roleService;
        public AuthController(IConfiguration _config, IAuthenticationService _service, IRoleService _roleService)
        {
            config = _config;
            service = _service;
            roleService = _roleService;
        }

        #region "Validate And Generate JWT For User"
        /// <summary>
        /// This method always returns JWT Token with user details if records match.
        /// Return Unauthorized if no records exist in table
        /// <param name="model">contains user login information</param>
        /// </summary>
        [AllowAnonymous]
        [HttpPost("AuthenticateUsers")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            IActionResult response = Unauthorized();
            if (!ModelState.IsValid)
            {
                return BadRequest("Cannot create token");
            }
            var user = await service.GetAuthenticatedUserAsync(model);
            if (user != null)
            {
                var roles = await roleService.GetRoleByUserIdAsync(user.RoleId);
                var tokenString =  service.GenerateJSONWebToken(user, roles);
                response = Ok(new { token = tokenString });
            }
            else
            {
                return response;
            }
            return response;
        }

        #endregion
    }
}
