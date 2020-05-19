﻿using Mobile_Store_MS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel
{
    public class ChatViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<MessageViewModel> Messages { get; set; }
    }
}
