using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.Store
{
    public class StoreViewModel
    {

        [Key]
        [Display(Name = "id")]
        public int store_id { get; set; }

        [Required]
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }

        [Required]
        [Display(Name ="City")]
        public int City { get; set; }
        public string CityName { get; set; }

        [Required]
        [Display(Name = "Complete Address")]
        public string CompleteAddress { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        public double Lng { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public double Lat { get; set; }

        [Required]
        [Display(Name = "Ref No")]
        public int Ref_No { get; set; }

        [Display(Name = "Support Phone")]
        public string SupportNo { get; set; }
    }
}
