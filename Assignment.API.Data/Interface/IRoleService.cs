using Assignment.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Assignment.API.Data.Interface
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRoleAsync();
        Task<IEnumerable<Role>> GetRoleByUserIdAsync(Guid roleId);
    }

}
