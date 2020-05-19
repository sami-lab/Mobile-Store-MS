using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Model
{
    public class Purchasing
    {
        [Key]
        public int purchase_id { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public System.DateTime Date { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Amount { get; set; }

        [Required]
        public int modelId { get; set; }

        [Required]
        public int vendor_id { get; set; }

        [Required]
        public int store_id { get; set; }
       
        [Required]
      
        public string takenBy { get; set; }

        [ForeignKey("takenBy")]
        public ApplicationUser user { get; set; }
        [ForeignKey("modelId")]
        public BrandModel Brand_model { get; set; }

        [ForeignKey("vendor_id")]
        public Vendor.Vendor Vendor_Model { get; set; }

        [ForeignKey("store_id")]
        public Store.Store Store_Model { get; set; }
    }
   
}
