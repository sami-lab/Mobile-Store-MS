using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.Administrator
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }

        public string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string City { get; set; }
        [Required]
        [Display(Name = "City")]
        public int cityId { get; set; }

        public string StreetAdress { get; set; }

        public string PhoneNumber { get; set; }

        [Display(Name = "Profile Photo")]
        public IFormFile Photo { get; set; }
        public string Photopath { get; set; }

        public Nullable<int> store_id { get; set; }

        public string Existingphotopath { get; set; }
        public List<string> Claims { get; set; }

        public IList<string> Roles { get; set; }
    }
}
