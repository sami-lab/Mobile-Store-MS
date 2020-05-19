using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Model.Stock
{
    public class Stock
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int modelId { get; set; }

        [Required]
        public int store_id { get; set; }

        [ForeignKey("modelId")]
        public BrandModel Model { get; set; }

        [ForeignKey("store_id")]
        public Store.Store Store { get; set; }



    }
}
