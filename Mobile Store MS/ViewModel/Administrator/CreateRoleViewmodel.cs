using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.Administrator
{
    public class CreateRoleViewmodel
    {
        [Required]
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
