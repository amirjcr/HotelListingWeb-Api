using System;
using AutoMapper;
using HotelListing.EndPoint.Data.Entities;
using HotelListing.EndPoint.Models.Dtos;

namespace HotelListing.EndPoint.Cofingurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
        }
    }
}