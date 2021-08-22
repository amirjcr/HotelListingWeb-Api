using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HotelListing.EndPoint.Data.Entities;

namespace HotelListing.EndPoint.Models.Dtos
{
    public class CountryDto : CreateCountryDto
    {
        public int Id { get; set; }
        public IList<Hotel> Hotels { get; set; }

    }

    public class UpdateCountryDto : CreateCountryDto
    {
    }

    public class CreateCountryDto
    {

        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "{0} can not be empty")]
        [StringLength(70, ErrorMessage = "{0} can not be more than {1} charcters")]
        public string Name { get; set; }


        [Display(Name = "Country Code")]
        [Required(ErrorMessage = "{0} can not be empty")]
        public short Countrycode { get; set; }


        [Display(Name = "Short Country Name")]
        [Required(ErrorMessage = "{0} can not be empty")]
        [MaxLength(4, ErrorMessage = "{0} can not be more than {1} charcters")]
        public string ShortName { get; set; }
    }
}