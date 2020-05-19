using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Model.Messages
{
    public class message
    {
        [Key]
        public int Id { get; set; }
        [Required]    
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime When { get; set; }

        public bool read { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser Sender { get; set; }
    }
}
