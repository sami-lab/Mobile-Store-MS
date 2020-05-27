using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mobile_Store_MS.Data;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.ViewModel.Store;

namespace Mobile_Store_MS.Controllers
{

    public class StoreController : Controller
    {
        public readonly IStoreRepositery storeRepositery;
        public readonly utilities util;
        public readonly UserManager<ApplicationUser> Usermanager;
        public StoreController(IStoreRepositery _storeRepositery,ApplicationDbContext _context, IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> usermanager)
        {
            storeRepositery = _storeRepositery;
            util = new utilities(_context,hostingEnvironment);
            Usermanager = usermanager;
        }
        [Authorize(Roles = "Super Admin,Admin,Employee")]
        public async Task<IActionResult> Index(int? store_id)
        {
            if (User.IsInRole("Super Admin") && store_id != null)
            {
                var data1 = storeRepositery.GetDetails().Where(x => x.store_id == store_id).OrderBy(x => x.Date);
                return View(data1);
            }
            else if (User.IsInRole("Super Admin") && store_id == null)
            {
                var data1 = storeRepositery.GetDetails().OrderBy(x => x.Date);
                return View(data1);
            }
            var user = await Usermanager.GetUserAsync(User);
            if (user.store_id != null)
            {
                return View(storeRepositery.GetDetails().Where(x=> x.store_id== user.store_id));
            }
            var data = storeRepositery.GetDetails();
            ViewBag.data = data;
            return View(data);
        }
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var data = storeRepositery.GetDetail(id);
            if (data != null)
            {
                return View(data);
            }
            //not Found
            ViewBag.Name = "Store";
            return View("ProductNotFound", id);
        }
        [Authorize(Roles = "Super Admin,Admin,Employee")]
        public async Task<ActionResult> GetEmployees(int? store_id)
        {
            if(User.IsInRole("Super Admin") && store_id == null)
            {
                return View(Usermanager.Users.Where(x => x.store_id != null));
            }
            else if(User.IsInRole("Super Admin") && store_id != null){
                var model = Usermanager.Users.Where(x => x.store_id == store_id);
                return View(model);
            }
            var user = await Usermanager.GetUserAsync(User);
            if (user.store_id != null)
            {
                return View(Usermanager.Users.Where(x => x.store_id == user.store_id));
            }
            var model1 = Usermanager.Users.Where(x=> x.store_id == store_id);
            return View(model1);
        }

        [Authorize(Roles = "Super Admin,Admin,Employee")]
        public async Task<ActionResult> GetStock()
        {
            var user = await Usermanager.GetUserAsync(User);
            if(user.store_id != null)
            {
                return RedirectToAction("StoreStock", "Quantity",new { id= user.store_id});
            }
            return RedirectToAction("Index", "Quantity");
        }
      
        [Authorize(Roles = "Super Admin")]
        public ActionResult Create()
        {
            ViewBag.cities = util.getCities();
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Super Admin")]
        public ActionResult Create(StoreViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    int id = storeRepositery.addStore(model);
                    return RedirectToAction("Details", new { id = id });
                }
                ViewBag.cities = util.getCities();
                return View(model);
            }
            catch
            {
                return View("Error");
            }
        }


      
        [Authorize(Roles = "Super Admin")]
        public ActionResult Edit(int id)
        {
            var data = storeRepositery.GetDetail(id);
            data.StoreName = data.StoreName.Split('#')[0];
            if (data != null)
            {
                ViewBag.cities = util.getCities();
                return View(data);
            }
            ViewBag.Name = "Store";
            return View("ProductNotFound", id);
        }

        
        [HttpPost]
        [Authorize(Roles = "Super Admin")]       
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StoreViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var data = storeRepositery.GetDetail(id);
                    if (data != null)
                    {
                        int Id = storeRepositery.Update(model);
                        return RedirectToAction("Details", new { id = Id });
                    }
                    ViewBag.Name = "Store";
                    return View("ProductNotFound", id);
                }
                ViewBag.cities = util.getCities();
                return View(model);
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Super Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                bool result = storeRepositery.delete(id);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                //something Went Wrong
                return View("Error");
            }
            catch
            {
                //something Went Wrong
                return View("Error");
            }
        }
    }
}
