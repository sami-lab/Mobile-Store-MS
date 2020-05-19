using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.CompanyViewModel
{
    public class CompanyViewModel
    {
        public int Phoneid { get; set; }
        [Display(Name ="Company Name")]
        [Required(ErrorMessage = "Name Field is Required")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 Characters!")]
        public string Com_name { get; set; }
        [Required(ErrorMessage = "Country Field is Required")]
        [Display(Name = "Company Destination")]
        public string com_country { get; set; }
        public bool isActive { get; set; }
        public IFormFile Photo { get; set; }
        public string Photopath { get; set; }
    }
}
