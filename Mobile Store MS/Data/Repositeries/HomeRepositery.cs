using Microsoft.AspNetCore.Identity;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.Data.Model.Messages;
using Mobile_Store_MS.ViewModel;
using Mobile_Store_MS.ViewModel.Administrator;
using Mobile_Store_MS.ViewModel.MessagesViewModel;
using Mobile_Store_MS.ViewModel.Orders;
using Mobile_Store_MS.ViewModel.PurchasingViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Repositeries
{
    
    public class HomeRepositery : IHomeRepoitery
    {
        public UserManager<ApplicationUser> userManager;
        public ApplicationDbContext context;
        public HomeRepositery(UserManager<ApplicationUser> usermanager, ApplicationDbContext _context)
        {
            userManager = usermanager;
            context = _context;
        }
        public dashboard Admin()
        {
            dashboard d = new dashboard();
            //Purchase and Sale
            d.LastMonthSales = context.Order.OrderBy(x => x.Date).Where(x => (x.Date - DateTime.Now).TotalDays <= 30).Sum(x => x.Products.Select(t=> t.price).Sum());
            d.LastMonthPurchasing = context.Purchasings.OrderBy(x => x.Date).Where(x => (x.Date - DateTime.Now).TotalDays <= 30).Sum(x => x.Amount);
            d.TotalSalesCount = context.Order.Count();
            d.TotalPurchasingCount = context.Purchasings.Count();
            d.TotalSales = context.Order.Sum(x => x.Products.Select(p=> p.price).Sum());
            d.TotalPurchasing = context.Purchasings.Sum(x => x.Amount);
            d.MonthlyProfit = d.LastMonthSales - d.LastMonthPurchasing;
            d.TotalProfit = d.TotalSales - d.TotalPurchasing;
            #region Recent Orders and Purchase
            //Recent Orders
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
                          }).OrderBy(x => x.Date).Take(10).ToList();
            d.Orders = result;

            //Recent Purchase
            var Purchase = (from p in context.Purchasings
                            join
                             b in context.BrandModel
                             on p.modelId equals b.modelId
                            join
                            v in context.Vendor
                            on p.vendor_id equals v.ven_id
                            join
                            c in context.CompanyModel
                            on b.PhoneId equals c.Phoneid
                            join
                            s in context.Stores
                            on p.store_id equals s.store_id
                            select new PurchasingViewModel()
                            {
                                purchase_id = p.purchase_id,
                                Date = p.Date,
                                Quantity = p.Quantity,
                                Amount = p.Amount,
                                modelId = p.modelId,
                                modelName = b.model_name,
                                Com_name = c.Com_name,
                                vendor_id = p.vendor_id,
                                VendorName = v.ven_name,
                                store_id = s.store_id,
                                StoreName = s.StoreName + '#' + s.Ref_No,
                                takenBy = p.user.FullName,
                            }).OrderBy(x => x.Date).Take(10).ToList();
            d.Purchasing = Purchase;
            #endregion

            //Graphs
            var DailyGraphSale = context.Order.Select(x=> new { x.Date,x.Products}).Where(x => (x.Date - DateTime.Now).TotalDays <= 30).ToList()
             .GroupBy(x => x.Date.ToString("yyyy/MM/dd"))
                   .Select(pr => new Graph()
                   {
                       Day = pr.Key.ToString(),
                       Amount = pr.Select(x=> x.Products.Select(t=> t.price).Sum()).Sum()
                   });
            var json = JsonConvert.SerializeObject(DailyGraphSale);
            //d.Sales = json;
            d.Sales = DailyGraphSale.ToList();
            var DailyGraphPurchasing = context.Purchasings.Where(x => (x.Date - DateTime.Now).TotalDays <= 30).ToList()
                   .GroupBy(x => x.Date.ToString("yyyy/MM/dd"))
                   .Select(pr => new Graph()
                   {
                       Day = pr.Key.ToString(),
                       Amount = pr.Sum(x => x.Amount)
                   });
            //d.Purchasings= JsonConvert.SerializeObject(DailyGraphPurchasing);
            d.Purchasings = DailyGraphPurchasing.ToList();
            //Brands
            d.CompaniesData = context.BrandModel
                             .GroupBy(x => x.PhoneId)
                             .Select(pr => new GroupByCompany()
                             {
                                 PhoneID = pr.Key,
                                 ComapanyName = pr.Select(x => new { x.PhoneId, x.model.Com_name }).FirstOrDefault(r => r.PhoneId == pr.Key).Com_name,
                                 BrandsTotal = pr.Where(x => x.PhoneId == pr.Key).Count()
                             }).ToList();
           
            //Users
            d.User = userManager.Users.Take(5).ToList();
            d.TotalUsers = userManager.Users.Count();
            d.Employees = userManager.Users.Where(x => x.store_id != null && x.isactive == true).Select(x => new RegisterEmployeeViewModel()
            {
                id = x.Id,
                Email = x.Email,
                StoreName = x.Store.StoreName,
            }).Take(5).ToList();
            d.TotalEmployees = userManager.Users.Where(x => x.store_id != null && x.isactive == true).Count();

            //Store Statistics



            var stats = context.Stores.Select(s => new StoreStats()
            {
                StoreID = s.store_id,
                StoreName = s.StoreName + s.Ref_No,
                RefNo = s.Ref_No,
                MonthPurchasing = s.Purchasing != null ? s.Purchasing.Where(x => (x.Date - DateTime.Now).TotalDays <= 30).Sum(x => x.Amount) : 0,
                MonthPurchasingCount = s.Purchasing != null ? s.Purchasing.Where(x => (x.Date - DateTime.Now).TotalDays <= 30).Count() : 0,
                AverageMonthlyPurchasing = s.Purchasing != null ?  Math.Round((double)s.Purchasing.Where(x => (x.Date - DateTime.Now).TotalDays <= 30).Sum(x => x.Amount) / 30,2) : 0,
                MonthSales = s.Order != null ? s.Order.Where(x => (x.Date - DateTime.Now).TotalDays <= 30).Sum(x => x.Products.Select(t=> t.price).Sum()) : 0,
                MonthSalesCount = s.Purchasing != null ? s.Purchasing.Where(x => (x.Date - DateTime.Now).TotalDays <= 30).Count() : 0,
                AverageMonthlySale = s.Order != null ? Math.Round(s.Order.Where(x => (x.Date - DateTime.Now).TotalDays <= 30).Sum(x => x.Products.Select(t => t.price).Sum()) / 30,2 ): 0,
                MonthlyProfit = (s.Purchasing != null ? s.Purchasing.Where(x => (x.Date - DateTime.Now).TotalDays <= 30).Sum(x => x.Amount) : 0) - (s.Order != null ? s.Order.Where(x => (x.Date - DateTime.Now).TotalDays <= 30).Sum(x => x.Products.Select(t => t.price).Sum()) : 0),
                AnnualPurchasing = s.Purchasing != null ? s.Purchasing.Where(x => (x.Date - DateTime.Now).TotalDays <= 360).Sum(x => x.Amount) : 0,
                AnnualSales = s.Order != null ? s.Order.Where(x => (x.Date - DateTime.Now).TotalDays <= 360).Sum(x => x.Products.Select(t => t.price).Sum()) : 0,
                AnnualProfit = (s.Purchasing != null ? s.Purchasing.Where(x => (x.Date - DateTime.Now).TotalDays <= 360).Sum(x => x.Amount) : 0) - (s.Order != null ? s.Order.Where(x => (x.Date - DateTime.Now).TotalDays <= 360).Sum(x => x.Products.Select(t => t.price).Sum()) : 0),
                CompletedOrders = s.Order != null ? s.Order.Where(x => x.status == Model.Order.Status.Completed).Count() : 0,
                ProcessOrders = s.Order != null ? s.Order.Where(x => x.status == Model.Order.Status.Processing).Count() : 0,
                PendingOrders = s.Order != null ? s.Order.Where(x => x.status == Model.Order.Status.Pending).Count() : 0,
                TotalEmployees = s.Employees != null ? userManager.Users.Where(x => x.store_id != null && x.store_id == s.store_id).Count() : 0,
                TotalBrands = s.Stock != null ? s.Stock.Where(x => x.store_id == s.store_id).Count() : 0,
            }).ToList();
            d.Stores = stats;

            d.Stores = stats;

            return d;
        }


        public async Task<int> Create(MessageViewModel message, string userId)
        {
            message model = new message()
            {
                Text = message.Text,
                UserName = message.UserName,
                When = DateTime.Now,
                UserId = userId,
                read = false
            };
            await context.Messages.AddAsync(model);
            await context.SaveChangesAsync();
            return model.Id;
        }

        public  List<MessageViewModel> messages(string userID, string personId, string userEmail, string Email)
        {
            //|| x.UserName == userEmail || x.UserId == personId
            var messages = context.Messages.Where(x => x.UserId == userID && x.UserName == Email || x.UserName == userEmail && x.UserId == personId).Select(x => new MessageViewModel()
            {
                Id = x.Id,
                UserName = x.UserName,
                Text = x.Text,
                When = x.When,
                read = x.read,
            }).OrderByDescending(x => x.When).Take(100).ToList();         
            return messages;
        }
        public int UserTotalNotification(string userID)
        {
            return context.Notification.Where(x => x.UserId == userID).Count();
        }

        public async  Task<List<NotificationsViewModel>> Notifications(string userID, int? skip, int? limit)
        {
            if (skip == null) skip = 0;
            var notifications = context.Notification.Where(x => x.UserId == userID).Select(x => new NotificationsViewModel()
            {
                Id = x.Id,
                heading = x.heading,
                Text = x.Text,
                Url = x.Url,
                read = x.read,
                UserId = x.UserId,
                When = x.When
            }).OrderByDescending(x => x.When).Skip((int)skip).TakeIfNotNull(limit).ToList();
            bool update = await UpdateNotificationRead(userID);
            return notifications;
        }

        public async Task<bool> UpdateMessagesRead(string Email, string PersonId)
        {
            try
            {
                var messages = context.Messages.Where(x => (x.UserId == PersonId && x.UserName == Email)  && x.read == false);
                foreach (var m in messages)
                {
                    m.read = true;
                    context.Messages.Update(m);
                }
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> UpdateNotificationRead(string userID)
        {
            try
            {
                var notifications = context.Notification.Where(x => x.UserId == userID && x.read == false);
                foreach (var m in notifications)
                {
                    m.read = true;
                    context.Notification.Update(m);
                }
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public int countUnreadNotifications(string userID)
        {
            int notifications = context.Notification.Where(x => x.UserId == userID && x.read == false).Count();
            return notifications;
        }
        public int countUnreadMessages(string userEmail)
        {
            int Messages = context.Messages.Where(x => x.UserName == userEmail  && x.read == false).Count();
            return Messages;
        }

        public async Task<List<UnreadMessages>> countUserUnreadMessages(string UserEmail)
        {
          
            List<UnreadMessages> messages = new List<UnreadMessages>();
            foreach (var u in userManager.Users.Where(x => x.Id != UserEmail))
            {
                if ((u.store_id != null || await userManager.IsInRoleAsync(u, "Super Admin")) && u.isactive == true)
                {
                    int count = context.Messages.Where(x => (x.UserId == u.Id && x.UserName == UserEmail) && x.read == false).Count();
                    messages.Add(new UnreadMessages() { userID = u.Id, count = count });
                }
            }
          
            return messages;
        }
    }

    public class UnreadMessages
    {
        public string userID;
        public int count;

    }
}
