using System;
using HotelListing.EndPoint.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.EndPoint.Configurations.Entities
{
    public class CountryConfiguratoin : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    Id = 1,
                    ShortName = "IR",
                    Name = "IRAN",
                    Countrycode = 98
                },
                new Country
                {
                    Id = 2,
                    ShortName = "UK",
                    Name = "UNITED KINGDOM",
                    Countrycode = 3
                },
                new Country
                {
                    Id = 3,
                    ShortName = "RU",
                    Name = "RUSSIA",
                    Countrycode = 7
                },
                new Country
                {
                    Id = 4,
                    ShortName = "UEA",
                    Name = "UNITED EMART ARIBA",
                    Countrycode = 11
                }
            );
        }
    }
}