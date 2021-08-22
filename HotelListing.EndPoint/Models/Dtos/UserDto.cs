using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HotelListing.EndPoint.Data.Entities;
using HotelListing.EndPoint.Data.Entities.identity;

namespace HotelListing.EndPoint.Models.Dtos
{
    public class RegisterUserDTo
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "PassWord Must be Less Than 15 charchters")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }


        [Required]
        [Compare("PassWord")]
        [DataType(DataType.Password)]
        public string ConfirmPassWord { get; set; }



        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}