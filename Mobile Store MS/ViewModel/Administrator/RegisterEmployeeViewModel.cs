using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.Administrator
{
    public class RegisterEmployeeViewModel
    {
        public RegisterEmployeeViewModel()
        {
            Claims = new List<UserClaim>();
            Roles = new List<UserRoles>();
        }
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
        [Display(Name = "City")]
        public int cityId { get; set; }
        [Required]
        public string StreetAdress { get; set; }
        public string PhoneNumber { get; set; }

        public string addedBy { get; set; }
        public int store_id { get; set; }
        public string StoreName { get; set; }

        public List<UserClaim> Claims { get; set; }
        public List<UserRoles> Roles { get; set; }

        [Display(Name = "Profile Photo")]
        public IFormFile Photo { get; set; }
        public string Photopath { get; set; }
    }

    public class UserClaim
    {
        public string ClaimType { get; set; }
        public String ClaimValue { get; set; }
        public bool isSelected { get; set; }
    }
    public class UserRoles
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool isSelected { get; set; }
    }
}
