using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.Account
{
    public class RegisterViewModel
    {
        public string id { get; set; }
        [Required]
        [Display(Name = "Full Name*")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailexist", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        
        public string City { get; set; }
        [Required]
        [Display(Name = "City")]
        public int cityId { get; set; }
        public string StreetAdress { get; set; }
        public string PhoneNumber { get; set; }
      
        public Nullable<int> store_id { get; set; }

        [Display(Name ="Profile Photo")]
        public IFormFile Photo { get; set; }
        public string Photopath { get; set; }

    }
}
