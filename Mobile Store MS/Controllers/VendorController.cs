using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile_Store_MS.Data;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.ViewModel.VendorViewModel;

namespace Mobile_Store_MS.Controllers
{
    [Authorize(Roles = "Admin, Super Admin")]
    public class VendorController : Controller
    {
        public readonly IVendorRepositery iVendorRepositery;
        public utilities util;
        public VendorController(IVendorRepositery IVendorRepositery, ApplicationDbContext context, IHostingEnvironment hosting)
        {
            iVendorRepositery = IVendorRepositery;
            util = new utilities(context, hosting);
        }
        // GET: Vendor
        public ActionResult Index()
        {
            var data = iVendorRepositery.GetDetails();
            return View(data);
        }

        // GET: Vendor/Details/5
        public ActionResult Details(int id)
        {
            var data = iVendorRepositery.GetDetail(id);
            if (data != null)
            {
                return View(data);
            }
            ViewBag.Name = "Vendor";
            return View("ProductNotFound", id);
        }

        // GET: Vendor/Create
        public ActionResult Create(int? PhoneId)
        {
            var Companies= util.GetAllCompany();
            if (!String.IsNullOrEmpty(PhoneId.ToString()))
            {
                VendorViewModel data = new VendorViewModel()
                {                   
                    PhoneId = Companies.FirstOrDefault(x => x.Phoneid == PhoneId).Phoneid
                };
                ViewBag.Companies = Companies;
                return View(data);
            }
            ViewBag.Companies = Companies;
            return View();
        }

        // POST: Vendor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendorViewModel m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    int id = iVendorRepositery.addVendor(m);
                    return RedirectToAction("Details", new { id = id });
                }
                ViewBag.Companies = util.GetAllCompany();
                return View(m);              
            }
            catch(Exception e)
            {
                ViewBag.Companies = util.GetAllCompany();
                ModelState.AddModelError("", e.Message);
                return View(m);
            }
        }

        // GET: Vendor/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Companies = util.GetAllCompany();
            var data = iVendorRepositery.GetDetail(id);
            if(data != null)
            {
                 return View(data);
            }
            ViewBag.Name = "Vendor";
            return View("ProductNotFound", id);
        }

        // POST: Vendor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VendorViewModel c)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var data = iVendorRepositery.GetDetail(id);
                    if (data != null)
                    {
                        int modelId = iVendorRepositery.Update(id,c);
                        return RedirectToAction("Details", new { id = modelId });
                    }
                    ViewBag.Name = "Vendor";
                    return View("ProductNotFound", id);
                }
                ViewBag.Companies = util.GetAllCompany();
                return View(c);
            }
            catch(Exception e)
            {
                ViewBag.Companies = util.GetAllCompany();
                ModelState.AddModelError("", e.Message);
                return View(c);
            }
        }

      
        // POST: Vendor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                bool result = iVendorRepositery.delete(id);
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