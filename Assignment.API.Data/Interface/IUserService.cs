using Assignment.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.API.Data.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        //Task<User> GetUserByIdAsync(Guid userId);        
        Task<string> CreateUserAsync(User model);
        //Task<bool> UpdateUserAsync(User model);
        //Task<bool> DeleteUserAsync(Guid Id);
    }
}
