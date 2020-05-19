using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Model.Store
{
    public class Store
    {
        [Key]
        public int store_id { get; set; }

        [Required]
        public string StoreName { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }
       
        public int City { get; set; }
        
        [Required]
        public string Address { get; set; }

        [Required]
        public double Lng { get; set; }

        [Required]
        public double Lat { get; set; }

        [Required]
        public int Ref_No { get; set; }

        [Required]
        public string SupportNo { get; set; }


        public ICollection<Stock.Stock> Stock { get; set; }

        public ICollection<Purchasing> Purchasing { get; set; }

        public ICollection<Order.Order> Order { get; set; }

        public ICollection<ApplicationUser> Employees { get; set; }

    }
}
