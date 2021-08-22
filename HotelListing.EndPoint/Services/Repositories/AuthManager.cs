using System;
using HotelListing.EndPoint.Models.Dtos;
using System.Threading.Tasks;
using HotelListing.EndPoint.Services.IRepositories;
using Microsoft.AspNetCore.Identity;
using HotelListing.EndPoint.Data.Entities.identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Security.Claims;

namespace HotelListing.EndPoint.Services.Repositories
{
    public class AuthManager : IAuthManager
    {

        private readonly UserManager<AppUser> _um;
        private readonly IConfiguration _configuration;
        private AppUser _user;

        public AuthManager(UserManager<AppUser> um, IConfiguration configuration)
        {
            _um = um;
            _configuration = configuration;
        }

        public async Task<string> createToken()
        {
            var signinCredentials = GetSginInCredentials();
            var claims = await GetClaims();
            var generateTokenoption = GenerateToken(signinCredentials, claims);


            SigningCredentials GetSginInCredentials()
            {
                var Key = Environment.GetEnvironmentVariable("JWTKEY");
                var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

                return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            }
            async Task<List<Claim>> GetClaims()
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name,_user.UserName)
                };

                foreach (var roles in await _um.GetRolesAsync(_user))
                    claims.Add(new Claim(ClaimTypes.Role, roles));


                return claims;
            }
            JwtSecurityToken GenerateToken(SigningCredentials param1, List<Claim> param2)
            {
                var jwtsetting = _configuration.GetSection("JwtSetting");
                var token = new JwtSecurityToken(issuer: jwtsetting.GetSection("Issuer").Value,
                claims: param2,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtsetting.GetSection("Lifetime").Value)),
                signingCredentials: param1);


                return token;
            }


            return new JwtSecurityTokenHandler().WriteToken(generateTokenoption);
        }

        public async Task<bool> ValidateUser(LoginUserDto model)
        {
            _user = await _um.FindByNameAsync(model.UserName);

            return (_user != null && await _um.CheckPasswordAsync(_user, model.PassWord));
        }
    }
}