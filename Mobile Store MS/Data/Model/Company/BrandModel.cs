using Mobile_Store_MS.Data.Model.Company;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Model
{
    //about model of each comapny
    public class BrandModel
    {
        [Key]
        public int modelId { get; set; }
        [Required]
        public string model_name { get; set; }
        [Required]
        public mob_type mob_type { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public System.DateTime LaunchDate { get; set; }

        [Required]
        public String ProcessorName {get; set;}
        [Required]
        public string RAM { get; set; }
        [Required]
        public string internal_storage { get; set; }
        [Required]
        public string Display { get; set; }
        public string Front_Cam { get; set; }
        public string back_cam { get; set; }
        [Required]
        public bool front_flash { get; set; }
        [Required]
        public bool FingerPrint { get; set; }
        [Required]
        public string SimType { get; set; }
        public string Networktype { get; set; }
        public string Android { get; set; }
        [Required]
        public string Battery { get; set; }
        [Required]
        public int Price { get; set; }
      
        
        [Required]
        public int PhoneId { get; set; }

        [ForeignKey("PhoneId")]
        public CompanyModel model { get; set; }
        //images table should map
        public ICollection<ModelImages> Images { get; set; }


        public ICollection<Order.Order> Orders { get; set; }
        public ICollection<Purchasing> Purchasing { get; set; }
        public ICollection<Stock.Stock> Stock { get; set; }
    }

    public enum mob_type
    {
       KeyPad,
       Touch
    }
}
