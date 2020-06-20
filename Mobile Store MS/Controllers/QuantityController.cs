using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mobile_Store_MS.Data;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.ViewModel;

namespace Mobile_Store_MS.Controllers
{
    [Authorize(Roles = "Super Admin,Admin,Employee")]
    public class QuantityController : Controller
    {
        public readonly IStockRepositery stockRepositery;
        UserManager<ApplicationUser> Usermanager;
        utilities util;
        public QuantityController(IStockRepositery _stockRepositery,UserManager<ApplicationUser> userManager, ApplicationDbContext _context)
        {
            stockRepositery = _stockRepositery;
            Usermanager = userManager;
            util = new utilities(_context);
        }
        public IActionResult Index()
        {
            var data = stockRepositery.GetDetails().GroupBy(x => new { x.store_id ,x.StoreName , x.RefNo })
                                  .Select(x => new GroupByStock() { store_id = x.Key.store_id,StoreName=x.Key.StoreName,RefNo=x.Key.RefNo, Models = x });
            return View(data);
        }

        public IActionResult BrandStock(int id)
        {
            var data = stockRepositery.BrandStock(id);
            return View(data);
        }

        public IActionResult StoreBrandStock(int store_id,int model_id)
        {
            var data = stockRepositery.StoreBrandStock(store_id,model_id);
            return View(data);
        }
        public async Task<IActionResult> StoreStock(int? id)
        {
            var user = await Usermanager.GetUserAsync(User);
            if(user.store_id != null)
            {
                var data1 = stockRepositery.GetDetails().Where(x => x.store_id == user.store_id).GroupBy(x => new { x.store_id, x.StoreName, x.RefNo })
                                .Select(x => new GroupByStock() { store_id = x.Key.store_id, StoreName = x.Key.StoreName, RefNo = x.Key.RefNo, Models = x });
                return View(data1);
            }
           
            var data = stockRepositery.GetDetails().Where(x=> x.store_id==id).GroupBy(x => new { x.store_id, x.StoreName, x.RefNo })
                                  .Select(x => new GroupByStock() { store_id = x.Key.store_id, StoreName = x.Key.StoreName, RefNo = x.Key.RefNo, Models = x });
            return View(data);
        }
        [Authorize(Roles ="Super Admin")]
        public IActionResult AddStockManually()
        {
            ViewBag.Companies = util.GetAllCompany();
            ViewBag.Stores = util.GetAllStores();
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Super Admin")]
        public IActionResult AddStockManually(StockViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool res = stockRepositery.AddStockManually(model);
                if (!res)
                {
                    ModelState.AddModelError("", "The Action Can't be Perform! Something went Wrong");
                    return View(model);
                }
                return View("Index");
            }
            return View(model);
        }
    }
}