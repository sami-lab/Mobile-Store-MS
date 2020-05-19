using Mobile_Store_MS.Data.Model.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.OrdersViewModel
{
    public class OrderStatus
    {
        [Display(Name = "Order ID")]
        public int order_id { get; set; }
        [Display(Name = "Order Status")]
        public Status? orderStatus { get; set; }

    }
}
