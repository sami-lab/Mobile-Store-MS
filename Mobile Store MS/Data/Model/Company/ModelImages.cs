using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Model.Company
{
    public class ModelImages
    {
        [Key]
        public int imageId { get; set; }
        public string Image_Path { get; set; }
        [Required]
        public int modelId { get; set; }

       
        [ForeignKey("modelId")]
        public BrandModel model { get; set; }
    }
}
