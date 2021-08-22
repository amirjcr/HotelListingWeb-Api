using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace HotelListing.EndPoint.Data.Entities
{
    public class Hotel
    {
        public string Id { get; set; }
        public string Name {get;set;}
        public string Address { get; set; }
        public double Rating { get; set; }
        public Country Country { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
    }
}