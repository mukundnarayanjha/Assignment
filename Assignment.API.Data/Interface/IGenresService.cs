using Assignment.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.API.Data.Interface
{
    public interface IGenresService
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
    }
}
