using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mobile_Store_MS.Data;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.ViewModel.PurchasingViewModel;

namespace Mobile_Store_MS.Controllers
{
    [Authorize(Roles = "Admin, Super Admin,Employee")]
    public class PurchasingController : Controller
    {
        public readonly IPurchasingRepositery iPurchasingRepositery;
        public utilities util;
        public UserManager<ApplicationUser> userManager;
        public PurchasingController(IPurchasingRepositery IPurchasingRepositery,ApplicationDbContext context,UserManager<ApplicationUser> _userManager)
        {
            iPurchasingRepositery = IPurchasingRepositery;
            util = new utilities(context);
            userManager = _userManager;
        }
        // GET: Purchasing
        public ActionResult Index()
        {
            var data = iPurchasingRepositery.GetDetails().OrderBy(x => x.StoreName);            
            return View(data);
        }

        public async Task<ActionResult> StorePurchasing(int? store_id)
        {
            if (User.IsInRole("Super Admin") && store_id != null)
            {
                var data1 = iPurchasingRepositery.GetDetails().Where(x => x.store_id == store_id).OrderBy(x => x.Date);
                return View(data1);
            }
            else if (User.IsInRole("Super Admin") && store_id == null)
            {
                var data1 = iPurchasingRepositery.GetDetails().OrderBy(x => x.Date);
                return View(data1);
            }
            var user = await userManager.GetUserAsync(User);
            if (user.store_id != null)
            {
                var data1 = iPurchasingRepositery.GetDetails().Where(x => x.store_id == user.store_id);
                return View(data1);
            }
            
            var data = iPurchasingRepositery.GetDetails().Where(x=> x.store_id==store_id).OrderBy(x=> x.Date);
            return View(data);
        }
        // GET: Purchasing/Details/5
        public  ActionResult Details(int id)
        {
            var data = iPurchasingRepositery.GetDetail(id);
            if (data != null)
            {
                return View(data);
            }
            ViewBag.Name = "Purchasing";
            return View("ProductNotFound", id);
        }

    // GET: Purchasing/Create
       [Authorize(policy: "Purchasing")]
        public async Task<ActionResult> Create(int? store_id,int? modelId,int? PhoneId)
        {
            ViewBag.Stores =  util.GetAllStores();
            ViewBag.Companies = util.GetAllCompany();     
            if(store_id != null)
            {
                PurchasingViewModel p = new PurchasingViewModel();
                if(modelId != null && PhoneId != null)
                {
                    p.modelId = (int)modelId;
                    p.Phoneid = (int)PhoneId;
                }
                p.store_id = (int)store_id;
                return View(p);
            }
            else
            {
                var user = await userManager.GetUserAsync(User);
                if (user.store_id != null)
                {
                    PurchasingViewModel p = new PurchasingViewModel();
                    p.store_id = (int)user.store_id;
                    return View(p);
                }
            }
           
            return View();  
        }

        // POST: Purchasing/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(policy: "Purchasing")]
        public async Task<ActionResult> Create(PurchasingViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    var user = await userManager.GetUserAsync(User);
                    model.takenBy = user.Id ;
                    int id = await iPurchasingRepositery.addPurchasing(model,Url);
                    if (id == 0) return View("Error");
                    return RedirectToAction("Details", new { id = id });
                }
                ViewBag.Stores = util.GetAllStores();
                ViewBag.Companies = util.GetAllCompany();
                return View(model);
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }

        // GET: Purchasing/Edit/5
        [Authorize(policy: "Purchasing")]
        public ActionResult Edit(int id)
        {

            var data = iPurchasingRepositery.GetDetail(id);
            if (data != null)
            {
                ViewBag.Stores = util.GetAllStores();
                ViewBag.Companies = util.GetAllCompany();
                EditPurchasingViewModel e = new EditPurchasingViewModel()
                {
                    purchase_id = data.purchase_id,
                    Quantity = data.Quantity,
                    Amount = data.Amount,
                    Date = data.Date,
                    store_id= data.store_id,
                    modelId = data.modelId,
                    modelName = data.modelName,
                    Phoneid= data.Phoneid,
                    Com_name = data.Com_name,
                    vendor_id = data.vendor_id,
                    VendorName = data.VendorName,
                    ExistingQuantity = data.Quantity,
                    Existing_store_id= data.store_id
                };
                return View(e);
            }
            ViewBag.Name = "Purchasing";
            return View("ProductNotFound", id);
        }

        // POST: Purchasing/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(policy: "Purchasing")]
        public ActionResult Edit(int id, EditPurchasingViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var data = iPurchasingRepositery.GetDetail(id);
                    if (data != null)
                    {
                        int modelId = iPurchasingRepositery.Update(model);
                        if (modelId == -1)
                        {
                            ViewBag.Stores = util.GetAllStores();
                            ViewBag.Companies = util.GetAllCompany();
                            ModelState.AddModelError("", "Out of Stock");
                            return View();
                        }
                        else if (modelId == 0)
                        {
                            ViewBag.Stores = util.GetAllStores();
                            ViewBag.Companies = util.GetAllCompany();
                            return View("Error");
                        }
                        return RedirectToAction("Details", new { id = modelId });
                    }
                    ViewBag.Name = "Purchasing";
                    return View("ProductNotFound", id);
                }
                ViewBag.Stores = util.GetAllStores();
                ViewBag.Companies = util.GetAllCompany();
                return View(model);
            }
            catch
            {
                return View("Error");
            }
        }

      
        // POST: Purchasing/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(policy: "Purchasing")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                bool result = iPurchasingRepositery.delete(id);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                //something Went Wrong
                ViewBag.ErrorTitle = "Error on Deleting Purchase";
                ViewBag.ErrorMessage = "Out of Stock";
                return View("Error");
            }
            catch
            {
                //something Went Wrong
                return View("Error");
            }
        }


        public JsonResult GetAllVendors(int PhoneId)
        {
            if (PhoneId.ToString() == null) return Json(null);
            var list = util.GetAllVendors(PhoneId);
            return Json(list);
        }
        [AcceptVerbs("Get", "Post")]
        public JsonResult AmountCheck(int Amount)
        {
            if (Amount > 0)
            {
                return Json(true);
            }
            else
            {
                return Json("Amount can't be negative or Zero");
            }
        }
        
    }
}