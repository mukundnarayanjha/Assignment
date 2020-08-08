using Assignment.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Assignment.API.Data.Interface
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMovieAsync();
        Task<IEnumerable<Movie>> GetAllMovieByMultiplexIdAsync(Guid MultiplexId);
        Task<IEnumerable<Movie>> GetAllMovieByLanguagesAndMultiplexIdAsync(Guid MultiplexId, Guid languageId);
        Task<IEnumerable<Movie>> GetAllMovieByGenresAndMultiplexIdAsync(Guid MultiplexId, Guid genresId);
        Task<string> AddMovieAsync(Movie model);
    }
}
