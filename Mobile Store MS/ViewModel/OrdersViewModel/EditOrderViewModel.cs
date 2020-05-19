using Mobile_Store_MS.ViewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.ViewModel.OrdersViewModel
{
    public class EditOrderViewModel: OrderViewModel
    {
        public int ExistingQuantity { get; set; }
        public int Existing_store_id { get; set; }
    }
}
