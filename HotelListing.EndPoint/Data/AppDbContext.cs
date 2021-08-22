using System;
using Microsoft.EntityFrameworkCore;
using HotelListing.EndPoint.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HotelListing.EndPoint.Data.Entities.identity;
using HotelListing.EndPoint.Configurations.Entities;
using HotelListing.EndPoint.MyExtenstions;



namespace HotelListiing.EndPoint.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> colunries { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

        
            builder.SeedingIntoDatabase();

        }


    }
}