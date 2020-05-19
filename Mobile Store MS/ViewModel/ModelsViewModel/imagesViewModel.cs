using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.ModelsViewModel
{
    public class imagesViewModel
    {     
        public int imageId { get; set; }
        public string Image_Path { get; set; }
        [Required]
        public int modelId { get; set; }
      
        public ModelViewModel model { get; set; }
    }
}
