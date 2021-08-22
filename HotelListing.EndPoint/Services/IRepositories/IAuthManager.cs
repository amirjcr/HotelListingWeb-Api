using System;
using HotelListing.EndPoint.Models.Dtos;
using System.Threading.Tasks;


namespace HotelListing.EndPoint.Services.IRepositories
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDto model);

        Task<string> createToken();
    }
}