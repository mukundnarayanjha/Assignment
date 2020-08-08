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
    public class BookingsController : ControllerBase
    {
        private IBookingService service;
        private ICityService cityService;
        private IGenresService genresService;
        private IMovieService movieService;
        private ILanguagesService languagesService;
        private IMultiplexService multiplexService;
        public BookingsController(IBookingService _service, ICityService _cityService, IMovieService _movieService,
        IGenresService _genresService, ILanguagesService _languagesService, IMultiplexService _multiplexService)
        {
            service = _service;
            cityService = _cityService;
            multiplexService = _multiplexService;
            movieService = _movieService;
            genresService = _genresService;
            languagesService = _languagesService;
        }

        #region Public Method

        #region "Get City"  
        /// <summary>
        /// This method always returns city list if city exist in table.
        /// Return status code 500 if no records in table
        /// </summary>
        [Authorize]
        [HttpGet("getcity")]
        public async Task<IActionResult> GetCity()
        {
            var result = await cityService.GetCityAsync();
            return result != null ? (IActionResult)Ok(result) : StatusCode(500);
        }
        #endregion

        #region "Get Multiplex"  
        /// <summary>
        /// This method always returns multiplex list of particular city if multiplex exist in table.
        /// Return status code 500 if no records in table
        /// <param name="cityId">cityId</param>
        /// </summary>
        [Authorize]
        [HttpGet("getmultiplex")]
        public async Task<IActionResult> GetMultiplex(Guid cityId)
        {
            var result = await multiplexService.GetAllMultiplexInCityByIdAsync(cityId);
            return result != null ? (IActionResult)Ok(result) : StatusCode(500);
        }
        #endregion

        #region "Get Movies"  
        /// <summary>
        /// This method always returns movies list of particular Multiplex.
        /// Return status code 500 if no records in table
        /// <param name="multiplexId">multiplexId</param>
        /// </summary>
        [Authorize]
        [HttpGet("getmovies")]
        public async Task<IActionResult> GetMovies(Guid multiplexId)
        {
            var result = await movieService.GetAllMovieByMultiplexIdAsync(multiplexId);
            return result != null ? (IActionResult)Ok(result) : StatusCode(500);
        }

        /// <summary>
        /// This method always returns movies list of particular Multiplex based on language.
        /// Return status code 500 if no records in table
        /// <param name="multiplexId">multiplexId</param>
        /// <param name="languagesId">languagesId</param>
        /// </summary>
        [Authorize]
        [HttpGet("getallmoviesbymultiplexandlanguages")]
        public async Task<IActionResult> GetAllMovieByLanguagesAndMultiplex(Guid languagesId, Guid multiplexId)
        {
            var result = await movieService.GetAllMovieByLanguagesAndMultiplexIdAsync(multiplexId, languagesId);
            return result != null ? (IActionResult)Ok(result) : StatusCode(500);
        }

        /// <summary>
        /// This method always returns movies list of particular Multiplex based on Genres.
        /// Return status code 500 if no records in table
        /// <param name="multiplexId">multiplexId</param>
        /// <param name="genresId">genresId</param>
        /// </summary>
        [Authorize]
        [HttpGet("getallmoviesbymultiplexandgenres")]
        public async Task<IActionResult> GetAllMovieByGenresAndMultiplex(Guid genresId, Guid multiplexId)
        {
            var result = await movieService.GetAllMovieByGenresAndMultiplexIdAsync(multiplexId, genresId);
            return result != null ? (IActionResult)Ok(result) : StatusCode(500);
        }
        #endregion

        #region "Get all Booking"  
        /// <summary>
        /// This method always returns all booking list if boking exist in table.
        /// Return status code 500 if no records in table
        /// </summary>
        [Authorize]
        [HttpGet("getallbooking")]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllBookingAsync();
            return result != null ? (IActionResult)Ok(result) : StatusCode(500);
        }
        #endregion


        #region "Add Booking"

        /// <summary>
        /// This method always returns booked ticket id if boking ticket successfully.
        /// Return NotFoud if error occur
        /// <param name="model">contains booking information</param>
        /// </summary>
        [Authorize(Roles = "Customer")]
        [HttpPost("addbooking")]
        public async Task<IActionResult> Create([FromBody] Booking model)
        {
            if (model != null && ModelState.IsValid)
            {
                var BookingList = await service.GetAllBookingByMultiplexIdAsync(model.MultiplexId, DateTime.Now);
                var numberOfMovieShow = BookingList.Select(x => x.MovieId).Distinct();
                if (numberOfMovieShow.Count() == 1)
                {
                    if (BookingList.Count() <= 100)
                    {
                        var totalBooking = await service.GetAllBookingByIdAsync(model.UserId, DateTime.Now);
                        if (totalBooking.Count() < 5)
                        {
                            var id = await service.AddBookingAsync(model);
                            return string.IsNullOrEmpty(id.ToString()) ? NotFound() : (IActionResult)Created(string.Empty, id);
                        }
                        else
                        {
                            return BadRequest("Not allowed to book more than 5 tickets.!");
                        }
                    }
                    else
                    {
                        return BadRequest("All seat have booked.!");
                    }
                }
                else
                {
                    return BadRequest("only one show per day in multiplex.!");
                }
            }
            else { return BadRequest("BadRequest"); }
        }

        #endregion

        #endregion
    }
}
