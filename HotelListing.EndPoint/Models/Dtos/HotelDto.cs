
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;



namespace HotelListing.EndPoint.Models.Dtos
{
    public class HotelDto : CreateHotelDto
    {
        public string Id { get; set; }
    }
    public class UpdateHotelDto : CreateHotelDto { }
    public class CreateHotelDto
    {

        [Display(Name = "Hotel Name")]
        [Required(ErrorMessage = "{0} can not be empty")]
        [StringLength(70, ErrorMessage = "{0} can not be more than {1} charcters")]
        public string Name { get; set; }

        [Display(Name = " Rating Hotel")]
        [Required(ErrorMessage = "{0} can not be empty")]
        [Range(1, 5, ErrorMessage = "{0} should be between {1}")]
        public double Rating { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Display(Name = "Hotel Address")]
        [Required(ErrorMessage = "{0} can not be empty")]
        [MaxLength(300, ErrorMessage = "{0} can not be more than {1} charcters")]
        public string Address { get; set; }
    }
}

