using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.Data.Model.Customer;
using Mobile_Store_MS.Data.Model.Messages;
using Mobile_Store_MS.Data.Model.Order;
using Mobile_Store_MS.Hubs;
using Mobile_Store_MS.Security.TokenSecurity;
using Mobile_Store_MS.Services;
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
        private readonly IDataProtector protector;
        private readonly ILogger<OrderRepositery> logger;
        //private readonly IHostingEnvironment hostingEnvironment;
        utilities util;
        UserManager<ApplicationUser> Usermanager;
        public OrderRepositery(ApplicationDbContext _context, IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager, IHubContext<NotificationHub> _hubContext, IDataProtectionProvider dataProtectionProvider, DataProctectionPurposeString dataProtectionPurposeStrings,ILogger<OrderRepositery> _logger)
        {
            context = _context;
            util = new utilities(context, hostingEnvironment);
            Usermanager = userManager;
            this._hubContext = _hubContext;
            this.protector = dataProtectionProvider.CreateProtector(
              dataProtectionPurposeStrings.OrderId);
            logger = _logger;
        }
        public async Task<List<Tuple<int, bool>>> addOrder(OrderViewModel c, IUrlHelper Url)
        {

            List<Tuple<int, bool>> quantityCheck = util.checkingquantity(c.Products, c.store_id);
            if (quantityCheck.Any(x => x.Item2 == false)) return quantityCheck;
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

            var prices = util.Price(c.Products.Select(x => x.modelId).ToArray());
            Order model = new Order()
            {
                Date = DateTime.Now,
                store_id = c.store_id,
                cus_id = c.cus_id,
                status = Status.Pending,
                PaymentMethod = c.Method,
                Products = c.Products.Select(x => new Model.Order.Product()
                {
                    //Phoneid = x.Phoneid,
                    modelId = x.modelId,
                    Quantity = x.Quantity,
                    price = prices.FirstOrDefault(p => p.Item1 == x.modelId).Item2 * x.Quantity,
                }).ToList()
            };
            if (c.TakenBy != null) model.TakenBy = c.TakenBy;
            if (c.Method == PaymentMethods.Stripe)
            {
                if (c.stripeToken == null)
                {
                    return new List<Tuple<int, bool>>()
                    {
                        new Tuple<int, bool>(-2,false)
                    };
                }
                double a = model.Products.Sum(x => x.price) * 0.63;
                //double per = 2.9 / 100 * a;
                var Options = new ChargeCreateOptions
                {
                    Amount = Convert.ToInt32(a),
                    Currency = "usd",
                    Description = "Customer Ref: " + c.CustRef,
                    Source = c.stripeToken
                };
                var service = new ChargeService();
                Charge charge = service.Create(Options);
                if (charge.BalanceTransactionId == null || charge.Status.ToLower() != "succeeded")
                {
                    return new List<Tuple<int, bool>>()
                    {
                        new Tuple<int, bool>(-2,false)
                    };
                }
                model.Charges = new List<OrderCharges>()
                {
                    new OrderCharges()
                    {
                        ChargeId = charge.Id,
                        priority= 1,
                    }
                };
            }


            context.Order.Add(model);
            context.SaveChanges();


            if (c.orderStatus == Status.Completed)
            {
                bool res = UpdateStatus(protector.Protect(model.order_id.ToString()), Status.Completed, c.TakenBy);
                if (!res) return new List<Tuple<int, bool>>() { new Tuple<int, bool>(-1, false) };
            }




            string StoreName = util.GetAllStores().FirstOrDefault(x => x.store_id == c.store_id).StoreName;
            c.StoreName = StoreName;
            var users = Usermanager.Users.Where(x => x.store_id == c.store_id).ToList();

            NotificationsViewModel n = new NotificationsViewModel();
            n.heading = "Order #" + model.order_id;
            n.Text = "Order With Status " + c.orderStatus + " is Placed";
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
            context.SaveChanges();

            return new List<Tuple<int, bool>>()
                    {
                        new Tuple<int, bool>(model.order_id,true)
                    }; ;
        }

        public bool UpdateStatus(string order_id, Status status, string LoginUserId)
        {
            string decryptedId = protector.Unprotect(order_id);
            int decryptedIntId = Convert.ToInt32(decryptedId);

            var order = context.Order
            .FirstOrDefault(x => x.order_id == decryptedIntId);
            if (order != null)
            {

                if (order.status == status) return true;
                if (status == Status.Pending || status == Status.Processing && order.status == Status.Completed)
                {
                    return false;
                }
                else if (status == Status.Completed)
                {
                    var ProductsList = order.Products.Select(x => new Products()
                    {
                        id = x.id,
                        price = x.price,
                        Quantity = x.Quantity,

                        modelId = x.modelId,
                        order_id = x.order_id
                    }).Where(x => x.order_id == order.order_id).ToList();
                    List<Tuple<int, bool>> quantityCheck = util.checkingquantity(ProductsList, order.store_id);
                    if (quantityCheck.Any(x => x.Item2 == false)) return false;
                    bool res = util.updatequan(ProductsList, order.store_id, "Subtract");
                    if (res == false) return false;
                }
                order.status = status;
                order.TakenBy = LoginUserId;

                context.Order.Update(order);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool delete(string id, bool info)
        {
            try
            {

                string decryptedId = protector.Unprotect(id);
                int decryptedIntId = Convert.ToInt32(decryptedId);

                var order = context.Order.Include(x=> x.Charges).Include(x=> x.Cus_model).Include(x=> x.Products).FirstOrDefault(x => x.order_id == decryptedIntId);
                if ((int)order.status >= 1 && info == false)
                {
                    return false;
                }
                else
                {
                    if (order.status == Status.Completed)
                    {
                        var ProductsList = order.Products.Select(x => new Products()
                        {
                            Quantity = x.Quantity,
                            modelId = x.modelId,
                            id= x.id,
                            order_id= x.order_id,
                            price= x.price
                        }).ToList();
                        bool result = util.updatequan(ProductsList, order.store_id, "Add");
                        if (!result) return false;
                    }
                }
                if (order.PaymentMethod == PaymentMethods.Stripe)
                {
                    var Service = new ChargeService();
                    var service = new RefundService();
                    foreach (var charge in order.Charges.OrderBy(x=>x.priority))
                    {
                        try
                        {
                            var charg = Service.Get(charge.ChargeId);
                            double Amount = charg.Amount - charg.AmountRefunded;
                            Amount -= (2.9 / 100 * Amount);
                            var options = new RefundCreateOptions
                            {
                                Charge = charge.ChargeId,
                                Amount = Convert.ToInt64(Amount)
                            };
                            var refund = service.Create(options);
                            if(refund != null) logger.LogCritical(Amount + "Refunded To " + order.Cus_model.CustRef + "Date" + DateTime.Now);
                        }
                        catch (Exception)
                        {
                            logger.LogError("Fail To Refund To " + order.Cus_model.CustRef + "Date" + DateTime.Now);
                            return false;
                        }
                    }


                }
                context.Entry(order).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public OrderViewModel GetDetail(string id)
        {
            string decryptedId = protector.Unprotect(id);
            int decryptedIntId = Convert.ToInt32(decryptedId);

            var result = (from v in context.Order
                          join
                          c in context.Customer
                          on v.cus_id equals c.cus_id
                          join
                          s in context.Stores
                          on v.store_id equals s.store_id
                          select new OrderViewModel()
                          {
                              order_id = v.order_id,
                              CustRef = c.CustRef,
                              Date = v.Date,
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
                              Method = v.PaymentMethod,
                              StrretAddress = c.Address.StreetAddress,
                              Products = (from p in context.Products
                                          where p.order_id == v.order_id
                                          select new Products()
                                          {
                                              id = p.id,
                                              modelId = p.modelId,
                                              model_name = p.BrandModel.model_name,
                                              Phoneid = p.BrandModel.PhoneId,
                                              com_Name = p.BrandModel.model.Com_name,
                                              price = p.price,
                                              Quantity = p.Quantity
                                          }).ToList()

                          }).FirstOrDefault(x => x.order_id == decryptedIntId);

            return result;
        }

        public List<OrderViewModel> GetDetails(int? skip, int? limit)
        {
            //var Stores = util.GetAllStores();
            //foreach(var store in Stores)
            //{
            //    var Com = util.GetAllCompany();
            //    foreach(var c in Com)
            //    {
            //        var models = util.getModelList(c.Phoneid);
            //        foreach(var m in models)
            //        {
            //            Mobile_Store_MS.Data.Model.Stock.Stock s = new Mobile_Store_MS.Data.Model.Stock.Stock()
            //            {
            //                modelId = m.modelId,
            //                store_id = store.store_id,
            //                Quantity = 0,
            //            };
            //            context.Stock.Add(s);

            //        }
            //    }
            //}
            //context.SaveChanges();
            if (skip == null) skip = 0;
            var result = (from v in context.Order
                          join
                          c in context.Customer
                          on v.cus_id equals c.cus_id
                          join
                          s in context.Stores
                          on v.store_id equals s.store_id
                          select new OrderViewModel()
                          {

                              order_id = v.order_id,
                              Encryptedorder_id = protector.Protect(v.order_id.ToString()),
                              Date = v.Date,
                              StoreName = s.StoreName + s.Ref_No,
                              cus_id = v.cus_id,
                              cus_name = c.cus_name,
                              orderStatus = v.status,
                              TakenBy = v.TakenBy,
                              CustRef = c.CustRef,
                              Products = (from p in context.Products
                                          where p.order_id == v.order_id
                                          select new Products()
                                          {
                                              id = p.id,
                                              modelId = p.modelId,
                                              model_name = p.BrandModel.model_name,
                                              Phoneid = p.BrandModel.PhoneId,
                                              com_Name = p.BrandModel.model.Com_name,
                                              price = p.price,
                                              Quantity = p.Quantity
                                          }).ToList()
                          }).
                          OrderByDescending(x => x.Date.Year).ThenByDescending(x => x.Date.Month).ThenByDescending(x => x.Date.Day).ThenByDescending(x => x.CustRef).Skip((int)skip).TakeIfNotNull(limit).ToList();

            return result;
        }

        public List<OrderViewModel> StoreOrders(int store_id, int? skip, int? limit)
        {

            if (skip == null) skip = 0;
            var result = (from v in context.Order
                          join
                          c in context.Customer
                          on v.cus_id equals c.cus_id
                          join
                          s in context.Stores
                          on v.store_id equals s.store_id
                          where v.store_id == store_id
                          select new OrderViewModel()
                          {
                              order_id = v.order_id,
                              Encryptedorder_id = protector.Protect(v.order_id.ToString()),
                              Date = v.Date,
                              StoreName = s.StoreName + s.Ref_No,
                              cus_id = v.cus_id,
                              cus_name = c.cus_name,
                              orderStatus = v.status,
                              TakenBy = v.TakenBy,
                              CustRef = c.CustRef,
                              Products = (from p in context.Products
                                          where p.order_id == v.order_id
                                          select new Products()
                                          {
                                              id = p.id,
                                              modelId = p.modelId,
                                              model_name = p.BrandModel.model_name,
                                              Phoneid = p.BrandModel.PhoneId,
                                              com_Name = p.BrandModel.model.Com_name,
                                              price = p.price,
                                              Quantity = p.Quantity
                                          }).ToList()
                          }).
                          OrderByDescending(x => x.Date.Year).ThenByDescending(x => x.Date.Month).ThenByDescending(x => x.Date.Day).Skip((int)skip).TakeIfNotNull(limit).ToList();

            return result;
        }

        public List<OrderViewModel> UserOrders(int Cus_ref)
        {
            var result = (from v in context.Order
                          join
                          c in context.Customer
                          on v.cus_id equals c.cus_id
                          join
                          s in context.Stores
                          on v.store_id equals s.store_id
                          where c.CustRef == Cus_ref
                          select new OrderViewModel()
                          {
                              order_id = v.order_id,
                              Encryptedorder_id = protector.Protect(v.order_id.ToString()),
                              Date = v.Date,
                              StoreName = s.StoreName + s.Ref_No,
                              cus_id = v.cus_id,
                              cus_name = c.cus_name,
                              orderStatus = v.status,
                              TakenBy = v.TakenBy,
                              CustRef = c.CustRef,
                              Products = (from p in context.Products
                                          where p.order_id == v.order_id
                                          select new Products()
                                          {
                                              id = p.id,
                                              modelId = p.modelId,
                                              model_name = p.BrandModel.model_name,
                                              Phoneid = p.BrandModel.PhoneId,
                                              com_Name = p.BrandModel.model.Com_name,
                                              price = p.price,
                                              Quantity = p.Quantity
                                          }).ToList()
                          }).
                      OrderByDescending(x => x.Date.Year).ThenByDescending(x => x.Date.Month).ThenByDescending(x => x.Date.Day).ToList();
            return result;
        }

        public List<Tuple<int, bool>> Update(OrderViewModel model)
        {
            bool res = true; //For return Response if false
            double TotalPrice = 0; //For calculating Total Price after Deduction from exisiting one

            //For Calculating Price if quantity changes
            //Quantity of Item Should Update in DB
            var ListForPrice = new List<Tuple<int, int>>();
            //List of items which Quantity Increases or decreses
            //Quantity of Item Should Update in DB
            var modifiedItemsAdded = new List<Products>();
            var modifiedItemsRemoved = new List<Products>();

            var data = context.Order.Include(x => x.Charges).Include(x=> x.Cus_model).Include(x=> x.Cus_model.Address).Where(x => x.order_id == model.order_id).FirstOrDefault();
            if (data == null) return new List<Tuple<int, bool>>() { new Tuple<int, bool>(0, false) };

            var ProductsList = context.Products.Where(x => x.order_id == model.order_id).Select(x => new Products()
            {
                id = x.id,
                Quantity = x.Quantity,
                modelId = x.modelId,
                order_id = x.order_id,
                price = x.price
            }).ToList();
            model.Products.ForEach(x => x.order_id = data.order_id);

            //Quantity of Item Should Update in DB as well as add it to as Order with status completed
            var NewItems = model.Products.Except(model.Products.Where(o => ProductsList.Select(s => s.modelId).ToList().Contains(o.modelId)));
            //Quantity of Item Should Update in DB as well as remove it to from Order Table.
            var RemoveItems = ProductsList.Except(ProductsList.Where(o => model.Products.Select(s => s.modelId).ToList().Contains(o.modelId)));

            ListForPrice = util.Price(model.Products.Select(x => x.modelId).ToArray());
            if (model.store_id != data.store_id)
            {
                //Working For Checking Quantity Changes. If changes update Product table with Quantity and Prices
                foreach (var item in model.Products)
                {
                    var found = ProductsList.FirstOrDefault(x => x.modelId == item.modelId);
                    if (found != null)
                    {
                        if (item.Quantity > found.Quantity)
                        {
                            int PriceOfEach = ListForPrice.FirstOrDefault(x => x.Item1 == found.modelId).Item2;
                            TotalPrice += PriceOfEach * (item.Quantity - found.Quantity);
                            found.Quantity = item.Quantity;
                            found.price = PriceOfEach * item.Quantity;
                            modifiedItemsAdded.Add(found);
                        }
                        else if (item.Quantity < found.Quantity)
                        {
                            int PriceOfEach = ListForPrice.FirstOrDefault(x => x.Item1 == found.modelId).Item2;
                            TotalPrice -= PriceOfEach * (found.Quantity - item.Quantity);
                            found.Quantity = item.Quantity;
                            found.price = PriceOfEach * item.Quantity;
                            modifiedItemsRemoved.Add(found);
                        }

                    }
                }
            }
            else
            {
                //Working For Checking Quantity Changes. If changes update Product table with Quantity and Prices
                foreach (var p in model.Products)
                {
                    var found = ProductsList.FirstOrDefault(y => y.modelId == p.modelId);
                    if (found != null)
                    {
                        if (found.Quantity > p.Quantity)
                        {
                            int PriceOfEach = ListForPrice.FirstOrDefault(x => x.Item1 == found.modelId).Item2;
                            TotalPrice -= PriceOfEach * (found.Quantity - p.Quantity);
                            found.Quantity = p.Quantity;
                            found.price = PriceOfEach * p.Quantity;
                            modifiedItemsRemoved.Add(found);
                        }
                        else if (found.Quantity < p.Quantity)
                        {
                            int PriceOfEach = ListForPrice.FirstOrDefault(x => x.Item1 == found.modelId).Item2;
                            TotalPrice += PriceOfEach * (p.Quantity - found.Quantity);
                            found.Quantity = p.Quantity;
                            found.price = PriceOfEach * p.Quantity;
                            modifiedItemsAdded.Add(found);
                        }
                    }
                }
            }

            //If Status is not Completed we dont need to Check for Any Quantity Exist
            if (data.status == Status.Completed)
            {
                 //checking For Quantity             
                if (data.store_id != model.store_id)
                {
                    List<Tuple<int, bool>> quantityCheck = util.checkingquantity(model.Products, model.store_id);
                    if (quantityCheck.Any(x => x.Item2 == false)) return quantityCheck;
                }
                //Updating Product Table if any exisitng item quantity changes(Added)
                if (modifiedItemsAdded.Count != 0)
                {
                    //Checking For Stock Exist or not?
                    if (data.store_id == model.store_id)
                    {
                        var quantityCheck = util.checkingquantity(modifiedItemsAdded, model.store_id);
                        if (quantityCheck.Any(x => x.Item2 == false)) return quantityCheck;
                    }
                    var dataModel = modifiedItemsAdded.Select(x => new Model.Order.Product()
                    {
                        id = x.id,
                        modelId = x.modelId,
                        //Phoneid = x.Phoneid,
                        price = x.price,
                        Quantity = x.Quantity,
                        order_id = x.order_id
                    }).ToList();
                    context.Products.UpdateRange(dataModel);  
                }
                //Updating Product Table if any exisitng item quantity changes(removed)
                if (modifiedItemsRemoved.Count != 0)
                {
                    var dataModel = modifiedItemsRemoved.Select(x => new Model.Order.Product()
                    {
                        id = x.id,
                        modelId = x.modelId,
                        //Phoneid = x.Phoneid,
                        price = x.price,
                        Quantity = x.Quantity,
                        order_id = x.order_id
                    }).ToList();             
                   context.Products.UpdateRange(dataModel);
                }
                //Add New Items To Product Table if added
                if (NewItems != null)
                {
                    if (data.store_id == model.store_id)
                    {
                        var quantityCheck = util.checkingquantity(NewItems.ToList(), model.store_id);
                        if (quantityCheck.Any(x => x.Item2 == false)) return quantityCheck;
                    }
                    var dataModel = NewItems.Select(x => new Model.Order.Product()
                    {
                        modelId = x.modelId,
                        price = ListForPrice.FirstOrDefault(p => p.Item1 == x.modelId).Item2 * x.Quantity,
                        Quantity = x.Quantity,
                        order_id = x.order_id
                    }).ToList();
                    TotalPrice += dataModel.Sum(x => x.price);
                    context.Products.AddRange(dataModel);
                }
                //Removing Exisiting Items from Product Table if removed
                if (RemoveItems != null)
                {
                    var dataModel = RemoveItems.Select(x => new Model.Order.Product()
                    {
                        id = x.id,
                        modelId = x.modelId,
                        order_id = x.order_id,
                        Quantity = x.Quantity
                    });
                    TotalPrice -= RemoveItems.Sum(x => x.price);              
                    context.Products.RemoveRange(dataModel);
                }

            }
            else
            {
                if (modifiedItemsAdded.Count != 0)
                { 
                    var dataModel = modifiedItemsAdded.Select(x => new Model.Order.Product()
                    {
                        id = x.id,
                        modelId = x.modelId,
                        //Phoneid = x.Phoneid,
                        price = x.price,
                        Quantity = x.Quantity,
                        order_id = x.order_id
                    }).ToList();              
                    context.Products.UpdateRange(dataModel);
                }
                //Updating Product Table if any exisitng item quantity changes(removed)
                if (modifiedItemsRemoved.Count != 0)
                {
                    var dataModel = modifiedItemsRemoved.Select(x => new Model.Order.Product()
                    {
                        id = x.id,
                        modelId = x.modelId,
                        //Phoneid = x.Phoneid,
                        price = x.price,
                        Quantity = x.Quantity,
                        order_id = x.order_id
                    }).ToList();
                    context.Products.UpdateRange(dataModel);
                }
                //Add New Items To Product Table if added
                if (NewItems.Count() != 0)
                {
                    var dataModel = NewItems.Select(x => new Model.Order.Product()
                    {
                        modelId = x.modelId,
                        //Phoneid = x.Phoneid,
                        price = ListForPrice.FirstOrDefault(p => p.Item1 == x.modelId).Item2 * x.Quantity,
                        Quantity = x.Quantity,
                        order_id = x.order_id
                    }).ToList();
                    TotalPrice += dataModel.Sum(x => x.price);        
                    context.Products.AddRange(dataModel);
                }
                //Removing Exisiting Items from Product Table if removed
                if (RemoveItems.Count() != 0)
                {
                    var dataModel = RemoveItems.Select(x => new Model.Order.Product()
                    {
                        id = x.id,
                        modelId = x.modelId,
                        order_id = x.order_id,
                        Quantity = x.Quantity
                    });
                    TotalPrice -= RemoveItems.Sum(x => x.price);                   
                    context.Products.RemoveRange(dataModel);
                }
            }

            if (TotalPrice > 0)
            {
                if (data.PaymentMethod == PaymentMethods.Stripe)
                {
                    var Options = new ChargeCreateOptions
                    {
                        Amount = Convert.ToInt32(TotalPrice * 0.63),
                        Currency = "usd",
                        Description = "Customer Ref: " + model.CustRef,
                        Source = model.stripeToken
                    };
                    var service = new ChargeService();
                    Charge charge = service.Create(Options);
                    if (charge.BalanceTransactionId == null || charge.Status.ToLower() != "succeeded")
                    {
                        return new List<Tuple<int, bool>>()
                    {
                        new Tuple<int, bool>(-2,false)
                    };
                    }
                    else
                    {
                        logger.LogInformation(TotalPrice + "Charged from "+model.CustRef);
                        OrderCharges o = new OrderCharges()
                        {
                            ChargeId = charge.Id,
                            priority = data.Charges.Max(x => x.priority) + 1,
                            order_id = data.order_id
                        };
                        data.Charges.Add(o);
                       
                    }
                }
            }
            else if (TotalPrice < 0)
            {
                if (data.PaymentMethod == PaymentMethods.Stripe)
                {
                    int count = 0;
                    TotalPrice = Math.Abs(TotalPrice);
                    logger.LogCritical(TotalPrice + "Should be Refunded To " + model.CustRef);
                    double Amount = (TotalPrice * 0.63) - ((1 / 100) * TotalPrice);
                    double AmountToCut = 0;
                    double Remaining = Amount;
                    var ChargeService = new ChargeService();
                    var service = new RefundService();
                    foreach (var charge in data.Charges.OrderBy(x => x.priority))
                    {
                        count++;
                        try
                        {
                            var charg = ChargeService.Get(charge.ChargeId);
                            double ChargeAmount = charg.Amount - charg.AmountRefunded;
                            if (Amount > ChargeAmount) AmountToCut = ChargeAmount;
                            else if (Amount < ChargeAmount) AmountToCut = Amount;
                            else AmountToCut = Amount;
                            var options = new RefundCreateOptions
                            {
                                Charge = charge.ChargeId,
                                Amount = Convert.ToInt64(AmountToCut)
                            };
                            Refund refund = service.Create(options);
                            Amount -= AmountToCut;
                            logger.LogCritical(AmountToCut + "Refunded To " + model.CustRef + "Date"+DateTime.Now);
                            if (refund != null && Amount <= 0)
                            {
                                break;
                            }
                        }
                        catch(StripeException  e)
                        {
                            switch (e.StripeError.ErrorType)
                            {
                                case "api_connection_error":
                                    logger.LogError("Connection Error Occured in Reefunding To " + model.CustRef + "Date" + DateTime.Now);
                                    return new List<Tuple<int, bool>>()
                    {
                        new Tuple<int, bool>(-2,false)
                    };
                                case "api_error":
                                    logger.LogError("Connection Error Occured in Reefunding To " + model.CustRef + "Date" + DateTime.Now);
                                    return new List<Tuple<int, bool>>()
                    {
                        new Tuple<int, bool>(-2,false)
                    };
                            }
                            if (data.Charges.Count == count)
                            {
                                return new List<Tuple<int, bool>>()
                    {
                        new Tuple<int, bool>(-2,false)
                    };
                            }
                        }
                    }
                }
            }

            data.Cus_model.cus_name = model.cus_name;
            data.Cus_model.cus_phone = model.cus_phone;
            if (model.StrretAddress != null)
            {
                data.Cus_model.Address = new Address()
                {
                    City = util.getCities().FirstOrDefault(x => x.id == model.CityId).city,
                    StreetAddress = model.StrretAddress
                };
            }
            data.store_id = model.store_id;

            context.Order.Update(data);
            //context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            //Updating Stock after Checking payments
            if ((int)data.status >= 1)
            {
                if (data.store_id != model.store_id)
                {
                    res = util.updatequan(model.Products, model.store_id, "Subtract");
                    if (res == false) GenerateError(model.Products, model.store_id, "Subtract");
                    res = util.updatequan(ProductsList, data.store_id, "Add");
                    if (res == false) GenerateError(ProductsList, data.store_id, "Add");
                }
                else
                {
                    if (modifiedItemsAdded.Count != 0)
                    {
                        res = util.updatequan(modifiedItemsAdded, model.store_id, "Subtract");
                        if (res == false) GenerateError(modifiedItemsAdded, model.store_id, "Subtract");
                    }
                    if (modifiedItemsRemoved.Count != 0)
                    {
                        res = util.updatequan(modifiedItemsRemoved, model.store_id, "Add");
                        if (res == false) GenerateError(modifiedItemsRemoved, model.store_id, "Add");
                    }
                    if (NewItems != null)
                    {
                        res = util.updatequan(NewItems.ToList(), model.store_id, "Subtract");
                        if (res == false) GenerateError(NewItems.ToList(), model.store_id, "Subtract");
                    }
                    if (RemoveItems != null)
                    {
                        res = util.updatequan(RemoveItems.ToList(), model.store_id, "Add");
                        if (res == false) GenerateError(RemoveItems.ToList(), model.store_id, "Add");
                    }
                }
            }
            return new List<Tuple<int, bool>>() { new Tuple<int, bool>(data.order_id, true) };
        }

        public int CountTotalOrders(int? store_id)
        {
            if (store_id != null)
            {
                return context.Order.Where(x => x.store_id == store_id).Count();
            }
            return context.Order.Count();
        }

        public void GenerateError(List<Products> products,int store_id,string operation)
        {
            string ErrorMessage = "Unable To" +operation+ "Following Models Stock\n";
            string models = "", Quant = "";
            foreach (var pro in products)
            {
                models += pro.modelId + ",";
                Quant += pro.Quantity + ",";
            }
            ErrorMessage += "Models: " + models + "\n" + "Quantity: " + Quant + "\n";
            ErrorMessage += "Store: " + store_id + " Operation: "+operation;
            logger.LogCritical(ErrorMessage);
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
