using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.ViewModel.CompanyViewModel;

namespace Mobile_Store_MS.Controllers
{
    [Authorize(Roles = "Super Admin")]
    public class CompanyController : Controller
    {
        public readonly ICompanyRepositories icompanyRepositories;

        public CompanyController(ICompanyRepositories IcompanyRepositories)
        {
            icompanyRepositories = IcompanyRepositories;
        }
        // GET: Company
        [AllowAnonymous]
        public ActionResult Index()
        {
            var data = icompanyRepositories.GetDetails();
            return View(data);
        }

        // GET: Company/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var data = icompanyRepositories.GetDetail(id);
            if(data != null)
            {
               return View(data);
            }
            //not Found
            ViewBag.Name = "Company";
            return View("ProductNotFound",id);
        }

        // GET: Company/Create
        //[Authorize(Roles ="Super Admin")]
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Super Admin")]
        [AllowAnonymous]
        public ActionResult Create(CompanyViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    int id = icompanyRepositories.addCompany(model);
                    return RedirectToAction("Details", new {id = id });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Edit/5
        [Authorize(Roles = "Super Admin")]
        public ActionResult Edit(int id)
        {
            var data = icompanyRepositories.GetDetail(id);
            if (data != null)
            {
                EditCompanyViewModel m = new EditCompanyViewModel()
                {
                    com_country = data.com_country,
                    Com_name = data.Com_name,
                    Phoneid = data.Phoneid,
                    Existingphotopath = data.Photopath,
                };
                return View(m);
            }
            ViewBag.Name = "Company";
            return View("ProductNotFound",id);
        }

        // POST: Company/Edit/5
        [HttpPost]
        [Authorize(Roles = "Super Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditCompanyViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var data = icompanyRepositories.GetDetail(id);
                    if(data != null)
                    {
                        int Phoneid = icompanyRepositories.Update(model);
                        return RedirectToAction("Details", new { id = Phoneid });
                    }
                    ViewBag.Name = "Company";
                    return View("ProductNotFound",id);
                }
                return View(model);
            }
            catch
            {                         
                return View("Error");
            }
        }

       
        // POST: Company/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Super Admin")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                bool result = icompanyRepositories.delete(id);
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