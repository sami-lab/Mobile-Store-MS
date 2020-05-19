using Mobile_Store_MS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.MessagesViewModel
{
    public class NotificationsViewModel
    {
       
        public int Id { get; set; }
        [Required]
        public string heading { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime When { get; set; }


        public string Url { get; set; }
        public bool read { get; set; }

        public string UserId { get; set; }
       
        public ApplicationUser User { get; set; }
    }
}
