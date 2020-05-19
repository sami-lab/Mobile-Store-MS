using Microsoft.AspNetCore.Identity;
using Mobile_Store_MS.Data.Model;
using Mobile_Store_MS.Data.Model.Messages;
using Mobile_Store_MS.Data.Model.Order;
using Mobile_Store_MS.Data.Model.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        public int City { get; set; }      
        public string StreetAdress { get; set; }      
        public string Photopath { get; set; }

        public Nullable<int> CusRef { get; set; }

        //For Offline Customers and Employees
        public string addedBy { get; set; }
        public Nullable<int> store_id { get; set; }

        public bool isactive { get; set; }
        [ForeignKey("store_id")]
        public Store Store { get; set; }

    
        public virtual ICollection<Purchasing> Purchasing_Model { get; set; }

        public virtual ICollection<message> Messages { get; set; }
        public virtual ICollection<Notifications> Notifications { get; set; }
        public virtual ICollection<Order> Order_Model { get; set; }       
    }
}
