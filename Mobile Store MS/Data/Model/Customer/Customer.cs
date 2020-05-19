using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Model.Customer
{
    public class Customer
    {
        [Key]
        public int cus_id { get; set; }
        [Required]
        public string cus_name { get; set; }
        [Required]       
        public int CustRef { get; set; }
       
        public string cus_phone { get; set; }

        public Nullable<int> AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
        public ICollection<Order.Order> Order { get; set; }
    }
}
