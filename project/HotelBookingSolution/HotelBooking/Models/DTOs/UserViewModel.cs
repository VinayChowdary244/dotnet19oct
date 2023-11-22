﻿using HotelBooking.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models.DTOs
{
    public class UserViewModel : UserDTO
    {
        [Required(ErrorMessage = "Re type password cannot be empty")]
        [Compare("Password", ErrorMessage = "Password and retype password do not match")]
        public string ReTypePassword { get; set; }
    }
}