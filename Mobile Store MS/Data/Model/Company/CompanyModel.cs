using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Model
{
    public class CompanyModel
    {
        [Key]
        public int Phoneid { get; set; }
        [Required]
        public string Com_name { get; set; }
        [Required]
        public string com_country { get; set; }
        public string com_Logo { get; set; }
        public bool isActive { get; set; }

        public ICollection<BrandModel> Brand { get; set; }
        public ICollection<Vendor.Vendor> Vendor { get; set; }
    }
}
