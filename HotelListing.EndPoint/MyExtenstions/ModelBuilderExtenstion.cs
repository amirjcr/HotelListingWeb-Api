using System;
using Microsoft.EntityFrameworkCore;
using HotelListing.EndPoint.Configurations.Entities;

namespace HotelListing.EndPoint.MyExtenstions
{
    public static class ModelBuilderExtenstion
    {

        public static void SeedingIntoDatabase(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new HotelConfiguration());
            builder.ApplyConfiguration(new CountryConfiguratoin());
        }

    }
}