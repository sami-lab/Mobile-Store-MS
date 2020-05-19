using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Model.Vendor
{
    public class Vendor
    {
        [Key]
        public int ven_id { get; set; }
        [Required]
        public string ven_name { get; set; }
        [Phone]
        public long ven_phone { get; set; }
        [Required]
        public int PhoneId { get; set; }

        [ForeignKey("PhoneId")]
        public CompanyModel model { get; set; }

        public ICollection<Purchasing> Purchasing { get; set; }

    }
}
