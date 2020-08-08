using Assignment.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment.API.Data.Interface
{
    public interface IAuthenticationService
    {
        Task<User> GetAuthenticatedUserAsync(LoginModel model);       
        string GenerateJSONWebToken(User model, IEnumerable<Role> roles);
    }
}
