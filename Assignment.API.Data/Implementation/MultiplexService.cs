using Assignment.API.Common.Repository;
using Assignment.API.Models;
using Assignment.API.Models.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.API.Data.Interface
{
    public class MultiplexService : RepositoryBase<Multiplex>, IMultiplexService
    {
        public MultiplexService(AssignmentDBContext context) : base(context)
        { }
        public async Task<IEnumerable<Multiplex>> GetAllMultiplexInCityByIdAsync(Guid cityId)
        {
            var multiplex = await FindByConditionAync(o => o.CityId.Equals(cityId));
            return multiplex;
        }
    }
}
