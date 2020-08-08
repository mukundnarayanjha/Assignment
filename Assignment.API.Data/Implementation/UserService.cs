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
    public class UserService : RepositoryBase<User>, IUserService
    {
        public UserService(AssignmentDBContext context) : base(context)
        { }

        public async Task<string> CreateUserAsync(User user)
        {
            Create(user);
            await SaveAsync();
            return user.Id.ToString();
        }       

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            var users = await FindAllAsync();
            return users.OrderBy(x => x.FullName);
        }
    }
}
