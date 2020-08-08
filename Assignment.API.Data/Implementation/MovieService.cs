using Assignment.API.Common.Repository;
using Assignment.API.Data.Interface;
using Assignment.API.Models;
using Assignment.API.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.API.Data.Implementation
{
    public class MovieService : RepositoryBase<Movie>, IMovieService
    {
        public MovieService(AssignmentDBContext context) : base(context)
        { }

        public async Task<string> AddMovieAsync(Movie model)
        {
            Create(model);
            await SaveAsync();
            return model.Id.ToString();
        }

        public async Task<IEnumerable<Movie>> GetAllMovieAsync()
        {
            var movies = await FindAllAsync();
            return movies.OrderBy(x => x.CreatedDate);
        }

        public async Task<IEnumerable<Movie>> GetAllMovieByGenresAndMultiplexIdAsync(Guid MultiplexId, Guid genresId)
        {
            var movies = await FindByConditionAync(o => o.MultiplexId.Equals(MultiplexId) && o.GenreId.Equals(genresId));
            return movies.ToList();
        }

        public async Task<IEnumerable<Movie>> GetAllMovieByLanguagesAndMultiplexIdAsync(Guid MultiplexId, Guid languageId)
        {
            var movies = await FindByConditionAync(o => o.MultiplexId.Equals(MultiplexId) && o.LanguageId.Equals(languageId));
            return movies.ToList();
        }

        public async Task<IEnumerable<Movie>> GetAllMovieByMultiplexIdAsync(Guid MultiplexId)
        {
            var movies = await FindByConditionAync(o => o.MultiplexId.Equals(MultiplexId));
            return movies.ToList();
        }
    }
}

