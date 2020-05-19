using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Mobile_Store_MS.Data.Model;
using Mobile_Store_MS.ViewModel.CompanyViewModel;

namespace Mobile_Store_MS.ViewModel.ModelsViewModel
{
    public class ModelViewModel
    {
        [Key]
        [Display(Name ="Model ID")]
        public int modelId { get; set; }
        [Required]
        [Display(Name ="Model Name")]
        public string model_name { get; set; }
        [Required]
        [Display(Name = "Model Type")]
        public mob_type mob_type { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Launch Date")]
        public System.DateTime LaunchDate { get; set; }

        [Required]
        [Display(Name = "Processor Name")]
        public string ProcessorName { get; set; }
        [Required]
        [Display(Name = "RAM")]
        public string RAM { get; set; }
        [Required]
        public string RAMCapacity { get; set; }
        [Required]
        [Display(Name = "Internal Storage")]
        public string internal_storage { get; set; }
        [Required]
        public string ROMCapacity { get; set; }
        [Required]
        [Display(Name = "Display")]
        public string Display { get; set; }

        [Display(Name = "Front Camera")]
        public string Front_Cam { get; set; }

        [Display(Name = "Back Camera")]
        public string back_cam { get; set; }

        [Display(Name = "Front Flash")]
        public bool front_flash { get; set; }
        [Display(Name = "Finger Print")]
        public bool FingerPrint { get; set; }
        [Required]
        [Display(Name = "Sim Type")]
        public string SimType { get; set; }
        [Display(Name = "Network Type")]
        public string Networktype { get; set; }
        public string Android { get; set; }
       [Required]
        [Display(Name = "Battery")]
        public string Battery { get; set; }
        [Required]
        public int Price { get; set; }

        //[Required]
        //public int Quantity { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public int PhoneId { get; set; }
        public string CompanyName { get; set; }
        public string ImageName { get; set; }
       
        //public CompanyViewModel.CompanyViewModel model { get; set; }
        //images table should map
        public List<IFormFile> Photos { get; set; }
        public List<imagesViewModel> Images { get; set; }
    }
   
    public class EditViewModel: ModelViewModel
    {
        public List<imagesViewModel> ExistingImagesPath { get; set; }   
    }
}
