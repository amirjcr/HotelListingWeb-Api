using System;
using Microsoft.AspNetCore.Identity;


namespace HotelListing.EndPoint.Data.Entities.identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}