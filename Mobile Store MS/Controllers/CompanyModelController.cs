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
using Mobile_Store_MS.ViewModel;
using Mobile_Store_MS.ViewModel.ModelsViewModel;

namespace Mobile_Store_MS.Controllers
{
    [Authorize(Roles = "Admin, Super Admin")]
    public class CompanyModelController : Controller
    {
        public readonly IModelRepositery iModelRepositery;
        utilities util;
        public CompanyModelController(IModelRepositery imodelRepositery, ApplicationDbContext context, IHostingEnvironment hosting)
        {
            iModelRepositery = imodelRepositery;
            util = new utilities(context, hosting);
        }
        // GET: ComapnyModel
        [AllowAnonymous]
        public ActionResult Index()
        {
            var data = iModelRepositery.GetDetails().OrderBy(x=> x.LaunchDate).GroupBy(x => x.CompanyName)
                                  .Select(x => new GroupBYCompany() { CompanyName = x.Key, Models = x });
            return View(data);
        }

        // GET: ComapnyModel/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var data = iModelRepositery.GetDetail(id);
            if (data != null)
            {
                return View(data);
            }
            ViewBag.Name = "Model";
            return View("ProductNotFound",id);
        }

        // GET: ComapnyModel/Create
        public ActionResult Create(int? PhoneId)
        {
            var Companies = util.GetAllCompany();
            if (!String.IsNullOrEmpty(PhoneId.ToString()))
            {
                ModelViewModel data = new ModelViewModel()
                {
                    PhoneId = Companies.FirstOrDefault(x => x.Phoneid == PhoneId).Phoneid
                };
                ViewBag.Companies = Companies;
                return View(data);
            }
            ViewBag.Companies = Companies;
            return View();
        }

        // POST: ComapnyModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModelViewModel m)
        {

            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    int id = iModelRepositery.addModel(m);
                    return RedirectToAction("Details", new { id = id });
                }
                ViewBag.Companies = util.GetAllCompany();
                return View(m);
            }
            catch (Exception e)
            {
                ViewBag.Companies = util.GetAllCompany();
                ModelState.AddModelError("", e.Message);
                return View(m);
            }
        }

        // GET: ComapnyModel/Edit/5
        public ActionResult Edit(int id)
        {
            //Images should be fill when implementing GetDetaild(id)
            var data = iModelRepositery.GetDetail(id);
            if (data != null)
            {
                ViewBag.Companies = util.GetAllCompany();
                EditViewModel m = new EditViewModel()
                {
                    modelId = data.modelId,
                    model_name = data.model_name,
                    mob_type = data.mob_type,
                    RAM = data.RAM,
                    RAMCapacity = data.RAMCapacity,
                    internal_storage = data.internal_storage,
                    ROMCapacity = data.ROMCapacity,
                    Display = data.Display,
                    Battery = data.Battery,
                    Price = data.Price,                 
                    SimType = data.SimType, //require end
                    back_cam = data.back_cam,
                    Front_Cam = data.Front_Cam,
                    front_flash = data.front_flash,
                    FingerPrint = data.FingerPrint,
                    Networktype = data.Networktype,
                    PhoneId = data.PhoneId,
                    ExistingImagesPath = data.Images,
                    CompanyName = data.CompanyName,
                    Android = data.Android,
                    LaunchDate= data.LaunchDate,
                    ProcessorName=data.ProcessorName
                };

                return View(m);
            }
            ViewBag.Name = "Model";
            return View("ProductNotFound",id);
        }

        // POST: ComapnyModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditViewModel m)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var data = iModelRepositery.GetDetail(id);
                    if (data != null)
                    {
                        int modelId = iModelRepositery.Update(m);
                        return RedirectToAction("Details", new { id = modelId });
                    }
                    ViewBag.Name = "Model";
                    return View("ProductNotFound",id);
                }
                ViewBag.Companies = util.GetAllCompany();
                ModelState.AddModelError("", "Something Went Wrong");
                return View(m);
            }
            catch (Exception e)
            {
                ViewBag.Companies = util.GetAllCompany();
                ModelState.AddModelError("", e.Message);
                return View(m);
            }
        }

        [AllowAnonymous]
        public JsonResult GetCompanies()
        {
            var result = util.GetAllCompany();
            if (result != null) return Json(result);
            else { return Json(false); }
        }
        [AllowAnonymous]
        public JsonResult GetModels(int PhoneId)
        {
            var result = util.getModelList(PhoneId);
            if (result != null) return Json(result);
            else { return Json(false); }
        }
        [AllowAnonymous]
        public JsonResult RemoveImage(int imgId)
        {
            bool result = util.RemoveImage(imgId);
            if (result) return Json(true);
            else { return Json(false); }
        }

        // POST: ComapnyModel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                bool result = iModelRepositery.delete(id);
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