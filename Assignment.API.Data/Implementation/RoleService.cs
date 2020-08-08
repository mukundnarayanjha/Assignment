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
    public class RoleService : RepositoryBase<Role>, IRoleService
    {
        public RoleService(AssignmentDBContext context) : base(context)
        { }

        public async Task<IEnumerable<Role>> GetAllRoleAsync()
        {
            var role = await FindAllAsync();
            return role.OrderBy(x => x.Name);
        }
        public async Task<IEnumerable<Role>> GetRoleByUserIdAsync(Guid roleId)
        {
            var role = await FindByConditionAync(o => o.Id.Equals(roleId));
            return role;
        }
    }
}

