using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.Data.Model.Customer;
using Mobile_Store_MS.Data.Model.Messages;
using Mobile_Store_MS.Data.Model.Order;
using Mobile_Store_MS.Hubs;
using Mobile_Store_MS.ViewModel.MessagesViewModel;
using Mobile_Store_MS.ViewModel.Orders;
using Mobile_Store_MS.ViewModel.OrdersViewModel;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Address = Mobile_Store_MS.Data.Model.Customer.Address;
using Customer = Mobile_Store_MS.Data.Model.Customer.Customer;
using Order = Mobile_Store_MS.Data.Model.Order.Order;

namespace Mobile_Store_MS.Data.Repositeries
{
    public class OrderRepositery : IorderRepositery
    {
        public ApplicationDbContext context;
        private IHubContext<NotificationHub> _hubContext;

        //private readonly IHostingEnvironment hostingEnvironment;
        utilities util;
        UserManager<ApplicationUser> Usermanager;
        public OrderRepositery(ApplicationDbContext _context, IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager, IHubContext<NotificationHub> _hubContext)
        {
            context = _context;
            util = new utilities(context, hostingEnvironment);
            Usermanager = userManager;
            this._hubContext = _hubContext;
        }
        public async Task<int> addOrder(OrderViewModel c, IUrlHelper Url)
        {

            bool quantityCheck = util.checkingquantity(c.modelId, c.store_id, c.Quantity);
            if (quantityCheck == false) return -1;
            var price = context.BrandModel.Select(x => new { x.Price, x.modelId }).FirstOrDefault(x => x.modelId == c.modelId);
            if (c.CustRef > 0 && Convert.ToString(c.CustRef) != String.Empty)
            {
                var result = context.Customer.Select(x => new { x.cus_id, x.CustRef }).FirstOrDefault(x => x.CustRef == c.CustRef);
                if (result != null)
                {
                    c.cus_id = result.cus_id;
                }
                else
                {
                    Customer cus = new Customer()
                    {
                        cus_name = c.cus_name,
                        cus_phone = c.cus_phone,
                        CustRef = c.CustRef,
                    };
                    if (c.Address != null)
                    {
                        cus.Address = new Address()
                        {
                            City = util.getCities().FirstOrDefault(x => x.id == c.CityId).city,
                            StreetAddress = c.Address.StreetAddress
                        };
                    }
                    context.Customer.Add(cus);
                    context.SaveChanges();
                    c.cus_id = cus.cus_id;

                }
            }

            Order model = new Order()
            {
                Date = c.Date,
                Quantity = c.Quantity,
                Amount = price.Price * c.Quantity,
                store_id = c.store_id,
                modelId = c.modelId,
                cus_id = c.cus_id,
                PaymentMethod = c.Method,
            };
            if (c.orderStatus == Status.Pending) model.status = (Status)c.orderStatus;
            if (c.TakenBy != null) model.TakenBy = c.TakenBy;
            if (c.Method == PaymentMethods.Stripe)
            {
                if (c.stripeToken == null)
                {
                    return -2;
                }
                var Options = new ChargeCreateOptions
                {
                    Amount = Convert.ToInt32(util.Price(c.modelId, c.Quantity) / 0.022942),
                    Currency = "usd",
                    Description = "Order ID: " + c.order_id,
                    Source = c.stripeToken
                };
                var service = new ChargeService();
                Charge charge = service.Create(Options);
                if (charge.BalanceTransactionId == null || charge.Status.ToLower() != "succeeded")
                {
                    return -2;
                }
                model.TransactionId = charge.TransferId;
            }
            else if (c.Method == PaymentMethods.CashOnDelievery)
            {
                model.TransactionId = null;
            }
            context.Order.Add(model);
           context.SaveChanges();



            if (c.orderStatus == Status.Completed)
            {
                UpdateStatus(model.order_id, Status.Completed, c.TakenBy);
            }
           

            string StoreName = util.GetAllStores().FirstOrDefault(x => x.store_id == c.store_id).StoreName;
            //await hubContext.Groups.AddToGroupAsync(user.Id, StoreName + user.store_id);
            //_hubContext.Clients.Group(StoreName + c.store_id).SendAsync("sendNotificationToGroup");  
            var users= Usermanager.Users.Where(x => x.store_id == c.store_id).ToList();

            NotificationsViewModel n = new NotificationsViewModel();
            n.heading = "Order #" + model.order_id;
            n.Text = "Order With Status " + c.orderStatus + "is Placed";
            n.Url = Url.Action("Details", "Order", new { id = model.order_id });
            n.read = false;
            n.When = DateTime.Now;
            //await _hubContext.Clients.All.SendAsync("RecieveNotification", n);
            await _hubContext.Clients.Groups(StoreName).SendAsync("RecieveNotification", n);

            foreach (var em in users)
            {
                n.UserId = em.Id;
                await util.AddNotification(n);             
            }
           
            return model.order_id;
        }

        public bool UpdateStatus(int order_id, Status status, string LoginUserId)
        {
            var order = context.Order.FirstOrDefault(x => x.order_id == order_id);

            if (order.status == status) return true;
            if (status == Status.Pending || status == Status.Processing && order.status == Status.Completed)
            {
                return false;
            }
            else if (status == Status.Completed)
            {
                bool res = util.updatequan(order.modelId, order.store_id, order.Quantity, "Subtract");
                if (res == false) return false;
            }
            order.status = status;
            order.TakenBy = LoginUserId;
            context.Order.Update(order);
            context.SaveChanges();
            return true;

        }
        public bool delete(int id, bool info)
        {
            try
            {
                var order = context.Order.FirstOrDefault(x => x.order_id == id);
                if ((int)order.status >= 1 && info == false)
                {
                    return false;
                }
                else
                {
                    if (order.status == Status.Completed)
                    {
                        bool result = util.updatequan(order.modelId, order.store_id, order.Quantity, "Add");
                        if (!result) return false;
                    }
                }
                context.Entry(order).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public OrderViewModel GetDetail(int id)
        {
            var result = (from v in context.Order
                          join
                           b in context.BrandModel
                           on v.modelId equals b.modelId
                          join
                          c in context.Customer
                          on v.cus_id equals c.cus_id
                          join
                          e in context.CompanyModel
                          on b.PhoneId equals e.Phoneid
                          join
                          s in context.Stores
                          on v.store_id equals s.store_id
                          select new OrderViewModel()
                          {
                              order_id = v.order_id,
                              CustRef = c.CustRef,
                              Date = v.Date,
                              Quantity = v.Quantity,
                              Amount = v.Amount,
                              modelId = v.modelId,
                              model_name = b.model_name,
                              Phoneid = e.Phoneid,
                              com_Name = e.Com_name,
                              store_id = s.store_id,
                              StoreName = s.StoreName + '#' + s.Ref_No,
                              StorePhone = s.SupportNo,
                              StoreAdress = s.Address,
                              cus_id = v.cus_id,
                              cus_name = c.cus_name,
                              cus_phone = c.cus_phone,
                              CityId = c.Address.City != null ? util.getCities().FirstOrDefault(x => x.city == c.Address.City).id : 0,
                              CityName = c.Address.City,
                              orderStatus = v.status,
                              TakenBy = v.user_Model.FullName,
                              StrretAddress = c.Address.StreetAddress
                          }).FirstOrDefault(x => x.order_id == id);

            return result;
        }

        public List<OrderViewModel> GetDetails(int? skip, int? limit)
        {
         

            if (skip == null) skip = 0;
            var result = (from v in context.Order
                          join
                           b in context.BrandModel
                           on v.modelId equals b.modelId
                          join
                          c in context.Customer
                          on v.cus_id equals c.cus_id
                          join
                          e in context.CompanyModel
                          on b.PhoneId equals e.Phoneid
                          join
                          s in context.Stores
                          on v.store_id equals s.store_id
                          select new OrderViewModel()
                          {
                              order_id = v.order_id,
                              Date = v.Date,
                              Quantity = v.Quantity,
                              Amount = v.Amount,
                              modelId = v.modelId,
                              model_name = b.model_name,
                              StoreName = s.StoreName + s.Ref_No,
                              com_Name = e.Com_name,
                              cus_id = v.cus_id,
                              cus_name = c.cus_name,
                              orderStatus = v.status,
                              TakenBy = v.TakenBy,
                              CustRef = c.CustRef,
                          }).
                          OrderByDescending(x => x.Date.Year).ThenByDescending(x => x.Date.Month).ThenByDescending(x => x.Date.Day).Skip((int)skip).TakeIfNotNull(limit).ToList();

            return result;
        }


        public List<OrderViewModel> StoreOrders(int store_id,int? skip, int? limit)
        {

            if (skip == null) skip = 0;
            var result = (from v in context.Order
                          join
                           b in context.BrandModel
                           on v.modelId equals b.modelId
                          join
                          c in context.Customer
                          on v.cus_id equals c.cus_id
                          join
                          e in context.CompanyModel
                          on b.PhoneId equals e.Phoneid
                          join
                          s in context.Stores
                          on v.store_id equals s.store_id
                          where v.store_id == store_id
                          select new OrderViewModel()
                          {
                              order_id = v.order_id,
                              Date = v.Date,
                              Quantity = v.Quantity,
                              Amount = v.Amount,
                              modelId = v.modelId,
                              model_name = b.model_name,
                              StoreName = s.StoreName + s.Ref_No,
                              com_Name = e.Com_name,
                              cus_id = v.cus_id,
                              cus_name = c.cus_name,
                              orderStatus = v.status,
                              TakenBy = v.TakenBy,
                              CustRef = c.CustRef,
                          }).
                          OrderByDescending(x => x.Date.Year).ThenByDescending(x => x.Date.Month).ThenByDescending(x => x.Date.Day).Skip((int)skip).TakeIfNotNull(limit).ToList();

            return result;
        }
        public int Update(EditOrderViewModel model)
        {
            bool res = false;
            var data = context.Order.Find(model.order_id);
            if (data.status == Status.Completed)
            {
                if (model.store_id != model.Existing_store_id)
                {
                    bool quantityCheck = util.checkingquantity(model.modelId, model.store_id, model.Quantity);
                    if (quantityCheck == false) return -1;
                    res = util.updatequan(model.modelId, model.store_id, model.Quantity, "Subtract");
                    if (res == false) return 0;
                    res = util.updatequan(model.modelId, model.Existing_store_id, model.ExistingQuantity, "Add");
                    if (res == false) return 0;
                }
                else
                {
                    if (model.ExistingQuantity != model.Quantity)
                    {
                        if (model.Quantity > model.ExistingQuantity)
                        {
                            bool quantityCheck = util.checkingquantity(model.modelId, model.store_id, (model.Quantity - model.ExistingQuantity));
                            if (quantityCheck == false) return -1;
                            res = util.updatequan(model.modelId, model.store_id, (model.Quantity - model.ExistingQuantity), "Subtract");
                        }
                        else if (model.Quantity < model.ExistingQuantity)
                        {
                            res = util.updatequan(model.modelId, model.store_id, (model.ExistingQuantity - model.Quantity), "Add");
                        }
                        if (res == false) return 0;
                    }
                }
            }
            var price = context.BrandModel.Select(x => new { x.Price, x.modelId }).FirstOrDefault(x => x.modelId == model.modelId);

            if (data != null)
            {
                data.Quantity = model.Quantity;
                data.Amount = price.Price * model.Quantity;
                data.modelId = model.modelId;
                Customer cus = new Customer()
                {
                    cus_id = model.cus_id,
                    cus_name = model.cus_name,
                    cus_phone = model.cus_phone,
                    CustRef = model.CustRef,
                };
                if (model.StrretAddress != null)
                {
                    cus.Address = new Address()
                    {
                        City = util.getCities().FirstOrDefault(x => x.id == model.CityId).city,
                        StreetAddress = model.StrretAddress
                    };
                }
                //context.Entry(cus).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.Customer.Update(cus);
                context.SaveChanges();
            }
            context.Order.Update(data);
            //context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return data.order_id;
        }


    }
    public static class LinqExtensions
    {
        public static IEnumerable<TResult> TakeIfNotNull<TResult>(this IEnumerable<TResult> source, int? count)
        {
            return !count.HasValue ? source : source.Take(count.Value);
        }
    }
}
