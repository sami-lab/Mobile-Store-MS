using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel
{
    public class StockViewModel
    {
        
        public int id { get; set; }

        [Required]
        public int Quantity { get; set; }


        [Display(Name = "Company Name")]
        public int Phoneid { get; set; }
        [Display(Name ="Company Name")]
        public string Com_name { get; set; }

        [Required]
        [Display(Name = "Model Name")]
        public int modelId { get; set; }
        [Display(Name = "Model Name")]
        public string model_name { get; set; }


        [Required]
        public int store_id { get; set; }
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }
        public int RefNo { get; set; }

        [Display(Name = "Operation")]
        public string option { get; set; }
        
    }
}
