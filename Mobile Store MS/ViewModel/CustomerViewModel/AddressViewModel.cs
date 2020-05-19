using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.CustomerViewModel
{
    public class AddressViewModel
    {
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int cityId { get; set; }
        public string City { get; set; }
        [Display(Name = "Street Adress")]
        public string StreetAddress { get; set; }
    }
}
