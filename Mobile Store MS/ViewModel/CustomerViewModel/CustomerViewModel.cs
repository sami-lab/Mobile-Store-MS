using Mobile_Store_MS.Data.Model.Customer;
using Mobile_Store_MS.ViewModel.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.CustomerViewModel
{
    public class CustomerViewModel
    {
        [Display(Name ="Customer ID")]
        public int cus_id { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        public string cus_name { get; set; }
        [Required]
        [Display(Name = "CustRef(Unique)")]
        public int CustRef { get; set; }
       
        [Display(Name = "Customer Phone")]
        [RegularExpression(@"^[0][1-9]\d{9}$|^[1-9]\d{9}$", ErrorMessage = "Must be Valid Phone No")]
        public string cus_phone { get; set; }
        public int AddressId { get; set; }
        public AddressViewModel Address { get; set; }

        public ICollection<OrderViewModel> Order { get; set; }
    }
}
