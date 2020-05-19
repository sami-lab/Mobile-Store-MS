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
        public QuantityController(IStockRepositery _stockRepositery,UserManager<ApplicationUser> userManager )
        {
            stockRepositery = _stockRepositery;
            Usermanager = userManager;
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
    }
}