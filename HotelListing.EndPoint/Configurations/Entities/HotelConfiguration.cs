using System;
using HotelListing.EndPoint.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.EndPoint.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                         new Hotel
                         {
                             Id = Guid.NewGuid().ToString(),
                             Name = "Big Hotel",
                             Address = "dubai",
                             CountryId = 4,
                             Rating = 4.8
                         },
                         new Hotel
                         {
                             Id = Guid.NewGuid().ToString(),
                             Name = "Uk Hotel",
                             Address = "Lodon",
                             CountryId = 2,
                             Rating = 4
                         },
                         new Hotel
                         {
                             Id = Guid.NewGuid().ToString(),
                             Name = "Russia Plus",
                             Address = "Moskow",
                             CountryId = 3,
                             Rating = 5
                         },
                         new Hotel
                         {
                             Id = Guid.NewGuid().ToString(),
                             Name = "Espinas plas",
                             Address = "Tehran Satadat Abad",
                             CountryId = 1,
                             Rating = 4.35
                         }
                        );
        }
    }
}