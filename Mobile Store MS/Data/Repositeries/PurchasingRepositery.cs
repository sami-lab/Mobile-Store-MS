using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.Data.Model;
using Mobile_Store_MS.Hubs;
using Mobile_Store_MS.ViewModel.MessagesViewModel;
using Mobile_Store_MS.ViewModel.PurchasingViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Data.Repositeries
{
    public class PurchasingRepositery : IPurchasingRepositery
    {
        public ApplicationDbContext context;
        //private readonly IHostingEnvironment hostingEnvironment;
        utilities util;
        UserManager<ApplicationUser> UserManager;
        private IHubContext<NotificationHub> _hubContext;
        public PurchasingRepositery(ApplicationDbContext _context, IHostingEnvironment hostingEnvironment,UserManager<ApplicationUser> userManager, IHubContext<NotificationHub> hubContext)
        {
            context = _context;
            util = new utilities(context, hostingEnvironment);
            UserManager = userManager;
            _hubContext = hubContext;
        }
        public async Task<int> addPurchasing(PurchasingViewModel c, IUrlHelper Url)
        {
            bool res = false;
            // var price = context.BrandModel.Select(x => new { x.Price, x.modelId }).FirstOrDefault(x => x.modelId == c.modelId);
            Purchasing model = new Purchasing()
            {
                Date = c.Date,
                Quantity = c.Quantity,
                Amount = c.Amount,
                modelId = c.modelId,
                vendor_id = c.vendor_id,
                store_id=c.store_id,
                takenBy=c.takenBy,
            };
            context.Purchasings.Add(model);
            context.SaveChanges();
            res = util.updatequan(c.modelId, c.store_id, c.Quantity, "Add");
            if (res == false) return 0;
            string StoreName = util.GetAllStores().FirstOrDefault(x => x.store_id == c.store_id).StoreName;
            var users = UserManager.Users.Where(x => x.store_id == c.store_id).ToList();

            NotificationsViewModel n = new NotificationsViewModel();
            n.heading = "Purchasing #" + model.purchase_id;
            n.Text = "Items Purchased By " +c.takenBy;
            n.Url = Url.Action("Details", "Purchasing", new { id = model.purchase_id });
            n.read = false;
            n.When = DateTime.Now;
            await _hubContext.Clients.Groups(StoreName).SendAsync("RecieveNotification", n);

            foreach (var em in users)
            {
                n.UserId = em.Id;
                await util.AddNotification(n);
            }
            return model.purchase_id;
        }

        public bool delete(int id)
        {
            try
            {
                Purchasing c = new Purchasing()
                {
                    purchase_id = id
                };

                context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //Testing Must Check this
        public PurchasingViewModel GetDetail(int id)
        {

            var result = (from p in context.Purchasings
                          join
                           b in context.BrandModel
                           on p.modelId equals b.modelId
                          //join
                          //v in context.Vendor
                          //on p.vendor_id equals v.ven_id
                          //join
                          //c in context.CompanyModel
                          //on b.PhoneId equals c.Phoneid
                          //where p.purchase_id == id
                          select new PurchasingViewModel()
                          {
                              purchase_id = p.purchase_id,
                              Date = p.Date,
                              Quantity = p.Quantity,
                              Amount = p.Amount,
                              modelId = p.modelId,
                              modelName = b.model_name,
                              Phoneid = b.model.Phoneid,
                              Com_name = b.model.Com_name, //testing ?
                              vendor_id = p.vendor_id,
                              VendorName = p.Vendor_Model.ven_name,
                              VendorPhone= p.Vendor_Model.ven_phone,
                              store_id = p.Store_Model.store_id,
                              StoreName = p.Store_Model.StoreName+p.Store_Model.Ref_No,//testing?
                              StoreAdress= p.Store_Model.Address,
                              StorePhone= p.Store_Model.SupportNo,
                              takenBy= p.user.FullName,
                          }).FirstOrDefault(x => x.purchase_id == id);

            return result;
        }
       
        public  List<PurchasingViewModel> GetDetails()
        {
            var result = (from p in context.Purchasings
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
                              StoreName = s.StoreName+'#'+s.Ref_No,
                              takenBy= p.user.FullName,
                          }).ToList();

            return result;
        }

        public int Update(EditPurchasingViewModel model)
        {
            bool res = false;

            // var price = context.BrandModel.Select(x => new { x.Price, x.modelId }).FirstOrDefault(x => x.modelId == model.modelId);
            var data = context.Purchasings.Find(model.purchase_id);
            if (data != null)
            {
                data.Quantity = model.Quantity;
                data.Amount = model.Amount;
                data.modelId = model.modelId;
                data.vendor_id = model.vendor_id;
                data.store_id = model.store_id;
                if (model.store_id != model.Existing_store_id)
                {

                    bool quantityCheck = util.checkingquantity(model.modelId, model.Existing_store_id, model.Quantity);
                    if (quantityCheck == false) return -1;
                    res = util.updatequan(model.modelId, model.Existing_store_id, model.Quantity, "Subtract");
                    if (res == false) return 0;
                    res = util.updatequan(model.modelId, model.store_id, model.ExistingQuantity, "Add");
                    if (res == false) return 0;
                }
                else
                {
                    if (model.ExistingQuantity != model.Quantity)
                    {
                        if (model.Quantity > model.ExistingQuantity)
                        {
                            res = util.updatequan(model.modelId, model.store_id, (model.Quantity - model.ExistingQuantity), "Add");
                        }
                        else if (model.Quantity < model.ExistingQuantity)
                        {
                            bool quantityCheck = util.checkingquantity(model.modelId, model.store_id, (model.ExistingQuantity - model.Quantity));
                            if (quantityCheck == false) return -1;
                            res = util.updatequan(model.modelId, model.store_id, (model.ExistingQuantity - model.Quantity), "Subtract");
                        }
                        if (res == false) return 0;
                    }
                }

                context.Purchasings.Update(data);
                context.SaveChanges();
                return data.purchase_id;
            }
            else return -1;
        }
    }
}
