using Microsoft.AspNetCore.Mvc;
using Mobile_Store_MS.Data.Model.Order;
using Mobile_Store_MS.ViewModel.Orders;
using Mobile_Store_MS.ViewModel.OrdersViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Interfaces
{
    public interface IorderRepositery
    {
        List<OrderViewModel> GetDetails(int? skip, int? limit);
        List<OrderViewModel> StoreOrders(int store_id, int? skip, int? limit);
        OrderViewModel GetDetail(int id);
        bool UpdateStatus(int order_id,Status status,string LoginUserId);
        Task<int> addOrder(OrderViewModel c, IUrlHelper Url);
        int Update(EditOrderViewModel model);
        bool delete(int id,bool info);
       
    }
}
