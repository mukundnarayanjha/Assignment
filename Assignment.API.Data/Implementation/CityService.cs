using Assignment.API.Common.Repository;
using Assignment.API.Models;
using Assignment.API.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.API.Data.Interface
{
    public class CityService : RepositoryBase<City>, ICityService
    {
        public CityService(AssignmentDBContext context) : base(context)
        { }
        public async Task<IEnumerable<City>> GetCityAsync()
        {
            var city = await FindAllAsync();
            return city.OrderBy(x => x.Name);
        }
    }
}
