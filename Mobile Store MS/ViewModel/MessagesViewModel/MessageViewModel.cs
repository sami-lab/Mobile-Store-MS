using Mobile_Store_MS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel
{
    public class MessageViewModel
    {
      
        public int Id { get; set; }
       
        [Display(Name ="Username")]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime When { get; set; }
        public bool read { get; set; }

        public ApplicationUser Sender { get; set; }
    }
}
