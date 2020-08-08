using Assignment.API.Common.Repository;
using Assignment.API.Data.Interface;
using Assignment.API.Models;
using Assignment.API.Models.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.API.Data.Implementation
{
    public class AuthenticationService : RepositoryBase<User>, IAuthenticationService
    {
        private IConfiguration config;
        public AuthenticationService(IConfiguration _config,AssignmentDBContext context) : base(context)
        {
            config = _config;
        }

        public string GenerateJSONWebToken(User model, IEnumerable<Role> roles)
        {
            var claims = new[]
           {
                new Claim(ClaimTypes.Role, roles.Select(x=>x.Name).FirstOrDefault()),
                new Claim(ClaimTypes.Email, model.EmailId),
                new Claim(ClaimTypes.GivenName,  model.FullName),
                new Claim(ClaimTypes.Name,  model.UserName),
                new Claim(ClaimTypes.NameIdentifier, model.Id.ToString())
            };

            //shared key between the token server and the resource server
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["AuthSection:JWtConfig:Key"]));
            var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var SecurityToken = new JwtSecurityToken(
                issuer: config["AuthSection:JWtConfig:Issuer"],
                audience: config["AuthSection:JWtConfig:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(SecurityToken);
        }

        public async Task<User> GetAuthenticatedUserAsync(LoginModel model)
        {
            var user = await FindByConditionAync(o => o.EmailId.Equals(model.EmailId) && o.Password.Equals(model.Password));
            return user.FirstOrDefault();
        }        
    }
}
