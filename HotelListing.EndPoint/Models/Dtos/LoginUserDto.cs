using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HotelListing.EndPoint.Data.Entities;

namespace HotelListing.EndPoint.Models.Dtos
{
    public class LoginUserDto
    {


        [Required]
        public string UserName { get; set; }


        [Required]
        [StringLength(15, ErrorMessage = "PassWord Must be Less Than 15 charchters")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        public bool RemmberMe { get; set; }
    }
}