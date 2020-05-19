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
using Mobile_Store_MS.ViewModel.CustomerViewModel;

namespace Mobile_Store_MS.Controllers
{
    [Authorize(Roles = "Admin, Super Admin,Employee")]
    public class CustomerController : Controller
    {
        public readonly ICustomerRepositery iCustomerRepositery;
        public UserManager<ApplicationUser> userManager;
        utilities util;
        public CustomerController(ICustomerRepositery ICustomerRepositery, ApplicationDbContext _context, IHostingEnvironment hostingEnvironment,UserManager<ApplicationUser> usermanager)
        {
            iCustomerRepositery = ICustomerRepositery;
            userManager = usermanager;
            util = new utilities(_context, hostingEnvironment);
        }
        // GET: Customer
        public ActionResult Index()
        {
            var data = iCustomerRepositery.GetDetails();
            return View(data);
        }
        [AllowAnonymous]
        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var data = iCustomerRepositery.GetDetail(id);
            if (data != null)
            {
                return View(data);
            }
            ViewBag.Name = "Customer";
            return View("ProductNotFound",id);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
                       
            CustomerViewModel data = new CustomerViewModel()
            {
                CustRef = util.GenerateCusRef()
            };
            ViewBag.cities = util.getCities();
            return View(data);
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    int id = iCustomerRepositery.addCustomer(model);
                    return RedirectToAction("Details", new { id = id });
                }
                ViewBag.cities = util.getCities();
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Customer/Edit/5
       
        public ActionResult Edit(int id)
        {
            var data = iCustomerRepositery.GetDetail(id);
            if(data != null)
            {
                ViewBag.cities = util.getCities();
                return View(data);
            }
            ViewBag.Name = "Customer";
            return View("ProductNotFound",id);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public ActionResult Edit(int id, CustomerViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var data = iCustomerRepositery.GetDetail(id);
                    if (data != null)
                    {
                        int modelId = iCustomerRepositery.Update(model);
                        return RedirectToAction("Details", new { id = modelId });
                    }
                    ViewBag.Name = "Customer";
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

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var data = iCustomerRepositery.GetDetail(id);
                if(data != null)
                {
                    var user =  userManager.Users.FirstOrDefault(x => x.CusRef == data.CustRef);
                    if(user != null)
                    {
                       user.CusRef = null;
                       await userManager.UpdateAsync(user);
                    }
                    bool result = iCustomerRepositery.delete(id);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                }

                ViewBag.Name = "Customer";
                return View("ProductNotFound", id);
            }
            catch
            {
                //something Went Wrong
                return View("Error");
            }
        }
    }
}