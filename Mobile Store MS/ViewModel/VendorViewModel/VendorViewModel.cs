using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.VendorViewModel
{
    public class VendorViewModel
    {
        [Display(Name="ID")]
        public int ven_id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string ven_name { get; set; }

       
        [Display(Name = "Phone")]
        [RegularExpression(@"^[0][1-9]\d{9}$|^[1-9]\d{9}$", ErrorMessage = "Must be Valid Phone No")]
        public long ven_phone { get; set; }

       
        [Display(Name = "Company Name")]
        public string ven_comName { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public int PhoneId { get; set; }
       
    }
}
