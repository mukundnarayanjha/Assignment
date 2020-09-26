using Assignment.API.Data.Interface;
using Assignment.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService service;
        public UsersController(IUserService _service)
        {
            service = _service;
        }
        #region "Get all user" 
        /// <summary>
        /// This method always returns user all list if record exist in table.
        /// Return status code 500 if no records in table
        /// </summary>
        [Authorize]
        [HttpGet("getuser")]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllUserAsync();
            return result != null ? (IActionResult)Ok(result) : StatusCode(500);
        }
        #endregion

        #region "Register user"
        /// <summary>
        /// This method always returns register user id if user saved successfully.
        /// Return NotFound if any error occur.
        /// <param name="model">contains user information</param>
        /// </summary>
        [AllowAnonymous]
        [HttpPost("adduser")]
        public async Task<IActionResult> Create([FromBody] User model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest(ModelState);
            var id = await service.CreateUserAsync(model);
            return string.IsNullOrEmpty(id.ToString()) ? NotFound() : (IActionResult)Created(string.Empty, id);
        }

        #endregion
    }
}
