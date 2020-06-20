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
        List<OrderViewModel> UserOrders(int Cus_ref);
        OrderViewModel GetDetail(string id);
        bool UpdateStatus(string order_id,Status status,string LoginUserId);
        Task<List<Tuple<int, bool>>> addOrder(OrderViewModel c, IUrlHelper Url);
        List<Tuple<int, bool>> Update(OrderViewModel model);
        bool delete(string id,bool info);
        int CountTotalOrders(int? store_id);
    }
}
