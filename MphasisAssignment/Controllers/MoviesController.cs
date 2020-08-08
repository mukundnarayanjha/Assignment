using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.API.Data.Interface;
using Assignment.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MphasisAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService service;
        public MoviesController(IMovieService _service)
        {
            service = _service;
        }
        #region "Get all movies" 
        /// <summary>
        /// This method always returns all movies list if record exist in table.
        /// Return status code 500 if no records in table
        /// </summary>
        [Authorize]
        [HttpGet("getmovies")]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllMovieAsync();
            return result != null ? (IActionResult)Ok(result) : StatusCode(500);
        }
        #endregion

        #region "Add Movie"
        /// <summary>
        /// This method always returns saved movie id if movie saved successfully.
        /// Return NotFound if any error occur.
        /// <param name="model">contains movie information</param>
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPost("addmovies")]
        public async Task<IActionResult> Create([FromBody] Movie model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest(ModelState);
            var id = await service.AddMovieAsync(model);
            return string.IsNullOrEmpty(id.ToString()) ? NotFound() : (IActionResult)Created(string.Empty, id);
        }

        #endregion
    }
}
