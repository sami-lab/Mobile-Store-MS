using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mobile_Store_MS.Data;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.Data.Model.Customer;
using Mobile_Store_MS.Data.Model.Order;
using Mobile_Store_MS.Security.TokenSecurity;
using Mobile_Store_MS.Services;
using Mobile_Store_MS.ViewModel.CustomerViewModel;
using Mobile_Store_MS.ViewModel.Orders;
using Mobile_Store_MS.ViewModel.OrdersViewModel;
using Newtonsoft.Json;
using Stripe;

namespace Mobile_Store_MS.Controllers
{
    [Authorize(Roles = "Admin, Super Admin,Employee,User")]
    public class OrderController : Controller
    {
        // It is through IDataProtector interface Protect and Unprotect methods,
        // we encrypt and decrypt respectively
        private readonly IDataProtector protector;
        public readonly IorderRepositery iOrderRepositery;
        public utilities util;
        public UserManager<ApplicationUser> userManager;
        private readonly Microsoft.AspNetCore.Identity.UI.Services.IEmailSender _emailSender;
        // It is the CreateProtector() method of IDataProtectionProvider interface
        // that creates an instance of IDataProtector. CreateProtector() requires
        // a purpose string. So both IDataProtectionProvider and the class that
        // contains our purpose strings are injected using the contructor
        public OrderController(IorderRepositery IorderRepository, ApplicationDbContext context, IHostingEnvironment hosting, UserManager<ApplicationUser> _userManager, Microsoft.AspNetCore.Identity.UI.Services.IEmailSender emailSender, IDataProtectionProvider dataProtectionProvider, DataProctectionPurposeString dataProtectionPurposeStrings)
        {
            iOrderRepositery = IorderRepository;
            userManager = _userManager;
            util = new utilities(context, hosting);
            _emailSender = emailSender;
            this.protector = dataProtectionProvider.CreateProtector(
             dataProtectionPurposeStrings.OrderId);

        }
        // GET: Order
        [Authorize(Roles = "Admin, Super Admin,Employee")]
        public ActionResult Index(int? pageNo, int? limit)
        {
            if (pageNo == null) pageNo = 1;
            if (limit == null) limit = 20;

            int skip = (int)((pageNo - 1) * limit);
            int totalUser = iOrderRepositery.CountTotalOrders(null);
            decimal totalpages = (decimal)totalUser / (decimal)limit;
            ViewBag.TotalPages = Math.Ceiling(totalpages);
            ViewBag.CurrentPage = pageNo;
            TempData["TotalPages"] = Math.Ceiling(totalpages);
            TempData["CurrentPage"] = pageNo;
            TempData["Total"] = totalUser;
            TempData.Keep();
            if (skip >= totalUser)
            {
                ViewBag.ErrorMessage = "The Page you are Looking For Could not be found";
                return View("NotFound");
            }
            var data = iOrderRepositery.GetDetails(skip, limit);
            return View(data);
        }

        public ActionResult Search(int? pageNo, int? limit, string searchList, string Name, DateTime time, int Month, string RefNo, Status? OrderStatus, int? store_id)
        {

            TempData.Keep();
            if (limit == null) limit = 20;
            if (pageNo == null) pageNo = 1;
            int skip = (int)((pageNo - 1) * limit);

            ViewBag.CurrentPage = pageNo;
            var data = new List<OrderViewModel>();
            int total;
            decimal totalpages;
            switch (searchList)
            {

                case "Name":
                    data = Name != null ? (store_id != null ? (iOrderRepositery.StoreOrders((int)store_id, null, null).Where(x => x.cus_name.ToLower().Contains(Name.ToLower())).ToList()) : (iOrderRepositery.GetDetails(null, null).Where(x => x.cus_name.ToLower().Contains(Name.ToLower())).ToList())) : null;
                    total = data.Count;
                    totalpages = (decimal)total / (decimal)limit;
                    ViewBag.TotalPages = Math.Ceiling(totalpages);
                    break;
                case "Month":
                    data = Month.ToString() != null ? (store_id != null ? (iOrderRepositery.StoreOrders((int)store_id, null, null).Where(x => x.Date.Month == Month).ToList()) : (iOrderRepositery.GetDetails(null, null).Where(x => x.Date.Month == Month).ToList())) : null;
                    total = data.Count();
                    totalpages = (decimal)total / (decimal)limit;
                    ViewBag.TotalPages = Math.Ceiling(totalpages);
                    break;
                case "Date":
                    data = time != null ? (store_id != null ? (iOrderRepositery.StoreOrders((int)store_id, null, null).Where(x => x.Date == time).ToList()) : (iOrderRepositery.GetDetails(null, null).Where(x => x.Date == time).ToList())) : null;
                    total = data.Count();
                    totalpages = (decimal)total / (decimal)limit;
                    ViewBag.TotalPages = Math.Ceiling(totalpages);
                    break;
                case "RefNo":
                    int n;
                    bool isNumeric = int.TryParse(RefNo, out n);
                    data = RefNo != null ? isNumeric == true ? (store_id != null ? (iOrderRepositery.StoreOrders((int)store_id, null, null).Where(x => x.CustRef == n).ToList()) : (iOrderRepositery.GetDetails(null, null).Where(x => x.CustRef == n).ToList())) : null : null;
                    total = data.Count();
                    totalpages = (decimal)total / (decimal)limit;
                    ViewBag.TotalPages = Math.Ceiling(totalpages);
                    break;
                case "OrderStatus":
                    data = OrderStatus != null ? (store_id != null ? (iOrderRepositery.StoreOrders((int)store_id, null, null).Where(x => x.orderStatus == OrderStatus).ToList()) : (iOrderRepositery.GetDetails(null, null).Where(x => x.orderStatus == OrderStatus).ToList())) : null;
                    total = data.Count();
                    totalpages = (decimal)total / (decimal)limit;
                    ViewBag.TotalPages = Math.Ceiling(totalpages);
                    break;
                default:
                    data = store_id != null ? iOrderRepositery.StoreOrders((int)store_id, skip, limit).ToList() : iOrderRepositery.GetDetails(skip, limit).ToList();
                    total = data.Count;
                    totalpages = (decimal)total / (decimal)limit;
                    ViewBag.TotalPages = Math.Ceiling(totalpages);
                    break;
            }
            return View(store_id != null ? "StoreOrders" : "Index", data);
        }

        public ActionResult Sort(int? pageNo, int? limit, string sortBy, string order, int? store_id)
        {

            if (pageNo == null) pageNo = int.Parse(TempData["CurrentPage"] != null ? TempData["CurrentPage"].ToString() : "1");
            if (limit == null) limit = 20;
            double TotalOrders = 0;
            if (store_id != null) TotalOrders = iOrderRepositery.CountTotalOrders(store_id);
            else TotalOrders = int.Parse(TempData["Total"] != null ? TempData["Total"].ToString() : iOrderRepositery.CountTotalOrders(null).ToString());
            double tot = TotalOrders / (double)limit;
            double totalPages = TempData["TotalPages"] != null ? double.Parse(TempData["TotalPages"].ToString()) : Math.Ceiling(tot);
            TempData.Keep();
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = pageNo;
            int skip = (int)((pageNo - 1) * limit);

            if (skip >= TotalOrders)
            {
                ViewBag.ErrorMessage = "The Page you are Looking For Could not be found";
                return View("NotFound");
            }
            var data = new List<OrderViewModel>();
            if (store_id != null) data = iOrderRepositery.StoreOrders((int)store_id, skip, (int)limit).ToList();
            else data = iOrderRepositery.GetDetails(skip, (int)limit);

            switch (sortBy)
            {
                case "RefNo":
                    data = order == "Des" ? data.OrderByDescending(x => x.CustRef).ToList() : data.OrderBy(x => x.CustRef).ToList();
                    break;
                case "Amount":
                    data = order == "Des" ? data.OrderByDescending(x => x.Products.Select(t => t.price).Sum()).ToList() : data.OrderBy(x => x.Products.Select(t => t.price).Sum()).ToList();
                    break;
                case "StoreName":
                    data = order == "Des" ? data.OrderByDescending(x => x.StoreName).ToList() : data.OrderBy(x => x.StoreName).ToList();
                    break;
                case "Date":
                    data = order == "Des" ? data.OrderBy(x => x.Date.Year).ThenBy(x => x.Date.Month).ThenBy(x => x.Date.Day).ToList() : data.OrderByDescending(x => x.Date.Year).ThenByDescending(x => x.Date.Month).ThenByDescending(x => x.Date.Day).ToList();
                    break;
                default:
                    break;

            }
            return View(store_id != null ? "StoreOrders" : "Index", data);
        }

        public async Task<ActionResult> MyOrders(int? Cusref)
        {
            if (Cusref != null)
            {
                var users = userManager.Users.SingleOrDefault(x => x.CusRef == Cusref);
                if (users != null)
                {
                    var UserData = iOrderRepositery.UserOrders((int)users.CusRef);
                    return View(UserData);
                }
                else
                {
                    ViewBag.Name = "User";
                    return View("ProductNotFound", Cusref);
                }
            }
            var user = await userManager.GetUserAsync(User);
            var data = iOrderRepositery.UserOrders((int)user.CusRef);
            return View(data);

        }

        [Authorize(Roles = "Admin, Super Admin,Employee")]
        public async Task<ActionResult> StoreOrders(int? store_id, int? pageNo, int? limit)
        {
            if (pageNo == null) pageNo = 1;
            if (limit == null) limit = 30;
            int skip = (int)((pageNo - 1) * limit);
            TempData["CurrentPage"] = pageNo;
            ViewBag.CurrentPage = pageNo;

            var data = new List<OrderViewModel>();
            if (User.IsInRole("Super Admin") && store_id != null)
            {
                data = iOrderRepositery.StoreOrders((int)store_id, skip, limit).ToList();
                int totalUser = iOrderRepositery.CountTotalOrders(store_id);
                decimal totalpages = (decimal)totalUser / (decimal)limit;
                ViewBag.TotalPages = Math.Ceiling(totalpages);
                TempData["TotalPages"] = Math.Ceiling(totalpages);
                TempData["Total"] = totalUser;
                if (skip >= totalUser)
                {
                    ViewBag.ErrorMessage = "The Page you are Looking For Could not be found";
                    return View("NotFound");
                }

                ViewBag.store_id = store_id;
                return View(data);
            }
            else if (User.IsInRole("Super Admin") && store_id == null)
            {
                return RedirectToAction("Index");
            }
            var user = await userManager.GetUserAsync(User);
            if (user.store_id != null)
            {
                data = iOrderRepositery.StoreOrders((int)user.store_id, skip, limit).ToList();
                int totalUser = iOrderRepositery.CountTotalOrders(user.store_id);
                decimal totalpages = (decimal)totalUser / (decimal)limit;
                ViewBag.TotalPages = Math.Ceiling(totalpages);
                TempData["TotalPages"] = Math.Ceiling(totalpages);
                TempData["Total"] = totalUser;
                if (skip >= totalUser)
                {
                    ViewBag.ErrorMessage = "The Page you are Looking For Could not be found";
                    return View("NotFound");
                }
                ViewBag.store_id = user.store_id;
            }
            else return View("Error");
          
            return View(data);
        }
        // GET: Order/Details/5
        public ActionResult Details(string id)
        {
            // Decrypt the employee id using Unprotect method
            var data = iOrderRepositery.GetDetail(id);
            if (data != null)
            {
                return View(data);
            }
            ViewBag.Name = "Order";
            return View("ProductNotFound", id);
        }

        public ActionResult Invoice(string id)
        {
            var data = iOrderRepositery.GetDetail(id);
            if (data != null)
            {
                if (data.orderStatus == Status.Completed)
                {
                    return View(data);
                }
                else
                {
                    RedirectToAction("Details", id);
                }
            }
            ViewBag.Name = "Order";
            return View("ProductNotFound", id);
        }
        // GET: Order/Create
        public async Task<ActionResult> Create(int? Phoneid, int? ModelId)
        {
            var user = await userManager.GetUserAsync(User);
            var Companies = util.GetAllCompany();
            ViewBag.Stores = util.GetAllStores();
            OrderViewModel data = new OrderViewModel();
            if (!(User.IsInRole("Admin") || User.IsInRole("Super Admin") || User.IsInRole("Employee")))
            {
                ViewBag.cities = util.getCities();
                data.cus_name = user.FullName;
                data.cus_phone = user.PhoneNumber;
                data.CityId = user.City;
                data.Address = new Data.Model.Customer.Address()
                {
                    StreetAddress = user.StreetAdress
                };
                // data.Address.StreetAddress = user.StreetAdress;
                if (user.CusRef != null)
                {
                    data.CustRef = (int)user.CusRef;
                }
                else
                {
                    data.CustRef = util.GenerateCusRef();
                }
            }
            else
            {
                data.CustRef = util.GenerateCusRef();
                if (user.store_id != null)
                {
                    data.store_id = (int)user.store_id;
                }
            }
            if (ModelId != null)
            {
                //data.Phoneid = Companies.FirstOrDefault(x => x.Phoneid == Phoneid).Phoneid;
                // data.modelId = (int)ModelId;
            }
            ViewBag.Companies = Companies;
            return View(data);
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrderViewModel c)
        {
            try
            {
                if(c.orders == "[]" || c.Products.Count == 0)
                {
                    ViewBag.Companies = util.GetAllCompany();
                    ViewBag.Stores = util.GetAllStores();
                    ViewBag.cities = util.getCities();
                    ModelState.AddModelError("","Products Can't be Null");
                    return View(c);
                }
                if(c.Products.Any(x=> x.Quantity <= 0))
                {
                    ViewBag.Companies = util.GetAllCompany();
                    ViewBag.Stores = util.GetAllStores();
                    ViewBag.cities = util.getCities();
                    ModelState.AddModelError("", "Products Can't be Negative");
                    return View(c);
                }
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var user = await userManager.GetUserAsync(User);
                    if (!(User.IsInRole("Admin") || User.IsInRole("Super Admin") || User.IsInRole("Employee")))
                    {
                        c.cus_name = user.FullName;
                        c.cus_phone = user.PhoneNumber;
                        c.orderStatus = Status.Pending;
                        if (user.CusRef != null)
                        {
                            if (c.CustRef != user.CusRef)
                                c.CustRef = (int)user.CusRef;
                        }
                        else
                        {
                            c.CustRef = util.GenerateCusRef();
                        }
                        user.CusRef = c.CustRef;
                        await userManager.UpdateAsync(user);

                    }
                    else
                    {
                        c.orderStatus = Status.Completed;
                        c.TakenBy = user.Id;
                    }

                    List<Tuple<int, bool>> res = await iOrderRepositery.addOrder(c, Url);
                    if (res.Any(x => x.Item2 == false && x.Item1 > 0))
                    {
                        ViewBag.Companies = util.GetAllCompany();
                        ViewBag.Stores = util.GetAllStores();
                        ViewBag.cities = util.getCities();
                        var OutOfStock = res.Where(x => x.Item2 == false);
                        var listOfModels = c.Products.Where(x => OutOfStock.Select(i => i.Item1).Contains(x.modelId)).Select(x => new { x.model_name, x.com_Name });
                        string str = "";
                        foreach (var item in listOfModels)
                        {
                            str = str + item.com_Name + " " + item.model_name + "\n";
                        }
                        ModelState.AddModelError("", "Following Product(s) is Out of Stock /n" + String.Join("/n", listOfModels));
                        return View(c);
                    }
                    else if(res.Any(x => x.Item2 == false && x.Item1 == -1))
                    {
                        ViewBag.Companies = util.GetAllCompany();
                        ViewBag.Stores = util.GetAllStores();
                        ViewBag.cities = util.getCities();
                        ModelState.AddModelError("", "Order Placed! Error in Updating Stock");
                        return View(c);
                    }
                    else if (res.Any(x => x.Item2 == false && x.Item1 == -2))
                    {
                        ViewBag.Companies = util.GetAllCompany();
                        ViewBag.Stores = util.GetAllStores();
                        ViewBag.cities = util.getCities();
                        ModelState.AddModelError("", "Error in Payment Gatway");
                        return View(c);
                    }

                    var id = res.Select(x => x.Item1).First();
                    if (!(User.IsInRole("Admin") || User.IsInRole("Super Admin") || User.IsInRole("Employee")))
                    {
                        c.order_id = id;
                        string str = await ViewToStringRenderer.RenderViewToStringAsync(HttpContext.RequestServices, $"~/Views/Template/OrderConfirmation.cshtml", c);
                        await _emailSender.SendEmailAsync(user.Email, "Order Confirmation", str);
                    }
                    string ID = protector.Protect(id.ToString());
                    return RedirectToAction("Details", new { id = ID });
                }
                ViewBag.Companies = util.GetAllCompany();
                ViewBag.Stores = util.GetAllStores();
                ViewBag.cities = util.getCities();
                return View(c);
            }
            catch (Exception e)
            {
                ViewBag.Companies = util.GetAllCompany();
                ViewBag.Stores = util.GetAllStores();
                ViewBag.cities = util.getCities();
                ModelState.AddModelError("", e.Message);
                return View(c);
            }
        }


        public IActionResult GetProduct(int Phoneid, string[] modelId, string[] models)
        {
            var data = new List<Products>();
            string[] modelsexist = new string[] { }; int[] modelsExists = new int[] { };
            if (modelId[0] != null)
            {
                var ids = modelId[0].Split(',');
                int[] idslist = Array.ConvertAll(ids, i => int.Parse(i));
                string CompanyName = util.GetAllCompany().FirstOrDefault(x => x.Phoneid == Phoneid).Com_name;
                var list = util.getModelList(Phoneid).Where(x => idslist.Contains(x.modelId)).ToList();
                if (!String.IsNullOrEmpty(models[0]))
                {
                    modelsexist = models[0].Split(',');
                    modelsExists = Array.ConvertAll(modelsexist, i => int.Parse(i));
                    ViewData["Index"] = modelsExists.Length;
                }
                else
                    ViewData["Index"] = 0;
                var Prices = util.Price(idslist);
                for (int i = 0; i < list.Count(); i++)
                {
                    if (modelsExists.Length == 0 || !modelsExists.Contains(list[i].modelId))
                    {
                        Products p = new Products()
                        {
                            modelId = list[i].modelId,
                            model_name = list[i].model_name,
                            Phoneid = Phoneid,
                            com_Name = CompanyName,
                            price = Prices.FirstOrDefault(x => x.Item1 == list[i].modelId).Item2,
                            Quantity = 1,
                        };

                        data.Add(p);
                    }
                }
            }
            return PartialView("_DisplayOrder", data);
        }
        [HttpPost]
        public PartialViewResult ShowParitalView(OrderViewModel orderView)
        {
            try
            {
                orderView.Products = JsonConvert.DeserializeObject<List<Products>>(orderView.orders);
                var pricesArray = orderView.Products.Select(x => new { x.modelId, x.Quantity }).ToList();
                double TotalPrices = 0;
                var prices = util.Price(pricesArray.Select(x => x.modelId).ToArray()).ToList();
                pricesArray.ForEach(x => TotalPrices += prices.FirstOrDefault(p => p.Item1 == x.modelId).Item2 * x.Quantity);

                ViewBag.TotalPrices = TotalPrices-orderView.TotalAmount;
                //orderView.Products.com_Name = util.GetAllCompany().FirstOrDefault(x => x.Phoneid == orderView.Phoneid).Com_name;
                //orderView.model_name = util.getModelList(orderView.Phoneid).FirstOrDefault(x => x.modelId == orderView.modelId).model_name;
                orderView.StoreName = util.GetAllStores().FirstOrDefault(x => x.store_id == orderView.store_id).StoreName;
                if (String.IsNullOrEmpty(Convert.ToString(orderView.CityId)))
                {
                    orderView.CityName = util.getCities().FirstOrDefault(x => x.id == orderView.CityId).city;
                }

                return PartialView("OrderSummary", orderView);
            }
            catch
            {
                return PartialView("OrderSummary", orderView);
            }
        }
        [HttpPost]
        [Authorize(policy: "UpdatingStatus")]
        public async Task<IActionResult> UpdateStatus(OrderStatus s)
        {
            var user = await userManager.GetUserAsync(User);
            bool result = iOrderRepositery.UpdateStatus(s.order_id, (Status)s.orderStatus, user.Id);
            if (result)
                return RedirectToAction("StoreOrders");
            ViewBag.ErrorTitle = "Error on Updating Status";
            ViewBag.ErrorMessage = "Cannot Update Status of Selected Order";
            return View("Error");

        }


        public JsonResult GetStore(double lng, double lat)
        {
            int storeid = util.getStoreId(lat, lng);
            return Json(storeid);
        }

        public JsonResult GetStoreByCityId(int cityId)
        {
            int storeid = util.getStoreId(cityId);
            return Json(storeid);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(string id)
        {

            var data = iOrderRepositery.GetDetail(id);
            if (data != null)
            {
                ViewBag.Companies = util.GetAllCompany();
                ViewBag.Stores = util.GetAllStores();
                ViewBag.cities = util.getCities();
                ViewBag.TotalPrice = data.Products.Sum(x => x.price);
                return View(data);
            }
            ViewBag.Name = "Order";
            return View("ProductNotFound", id);

        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, OrderViewModel c)
        {
          
            double prices = 0;
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                  
                    var data = iOrderRepositery.GetDetail(id);
                    if (data != null)
                    {
                        prices = data.Products.Sum(x => x.price);
                        if (c.orders == "[]" || c.Products.Count == 0)
                        {
                            ViewBag.Companies = util.GetAllCompany();
                            ViewBag.Stores = util.GetAllStores();
                            ViewBag.cities = util.getCities();
                            ViewBag.TotalPrice = prices;
                            ModelState.AddModelError("", "Products Can't be Null");
                            return View(c);
                        }
                        if (c.Products.Any(x => x.Quantity <= 0))
                        {
                            ViewBag.Companies = util.GetAllCompany();
                            ViewBag.Stores = util.GetAllStores();
                            ViewBag.cities = util.getCities();
                            ViewBag.TotalPrice = prices;
                            ModelState.AddModelError("", "Products Can't be Negative");
                            return View(c);
                        }
                        c.order_id = data.order_id;
                        c.Products =  JsonConvert.DeserializeObject<List<Products>>(c.orders);
                        List<Tuple<int, bool>> res = iOrderRepositery.Update(c);
                        if (res.Any(x => x.Item2 == false && x.Item1 > 0))
                        {
                            ViewBag.Companies = util.GetAllCompany();
                            ViewBag.Stores = util.GetAllStores();
                            ViewBag.cities = util.getCities();
                            ViewBag.TotalPrice = prices;
                            var OutOfStock = res.Where(x => x.Item2 == false);
                            var listOfModels = c.Products.Where(x => OutOfStock.Select(i => i.Item1).Contains(x.modelId)).Select(x => new { x.model_name, x.com_Name });
                            string str = "";
                            foreach (var item in listOfModels)
                            {
                                str = str + item.com_Name + " " + item.model_name + "\n";
                            }
                            ModelState.AddModelError("", "Following Product(s) is Out of Stock \n" + String.Join("/n", listOfModels));
                            return View(c);
                        }
                        if (res.Any(x => x.Item2 == false && x.Item1 == 0)) return View("Error");
                        if (res.Any(x => x.Item2 == false && x.Item1 == -2))
                        {
                            ViewBag.Companies = util.GetAllCompany();
                            ViewBag.Stores = util.GetAllStores();
                            ViewBag.cities = util.getCities();
                            ViewBag.TotalPrice = prices;
                            ModelState.AddModelError("", "Error in Payment Gatway! Sorry for inconvenience");
                            return View(c);
                        }
                        return RedirectToAction("Details", new
                        {
                            id = id
                        });
                    }
                    ViewBag.Name = "Order";
                    return View("ProductNotFound", id);
                }
                ViewBag.Companies = util.GetAllCompany();
                ViewBag.Stores = util.GetAllStores();
                ViewBag.cities = util.getCities();
                ViewBag.TotalPrice = prices;
                return View(c);
            }
            catch (Exception e)
               {
                ViewBag.Companies = util.GetAllCompany();
                ViewBag.Stores = util.GetAllStores();
                ViewBag.cities = util.getCities();
                ViewBag.TotalPrice = prices;
                ModelState.AddModelError("", e.Message);
                return View(c);
            }
        }



        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here
                bool result;
                if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
                {
                    result = iOrderRepositery.delete(id, true);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    result = iOrderRepositery.delete(id, false);
                }
                if (result)
                {
                    return RedirectToAction("MyOrders");
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

        public JsonResult GetAllModels(int PhoneId)
        {
            var list = util.getModelList(PhoneId);
            return Json(list);
        }


        [AcceptVerbs("Get", "Post")]
        public JsonResult quantityCheck(int Quantity)
        {
            if (Quantity > 0)
            {
                return Json(true);
            }
            else
            {
                return Json("Quantity can't be negative");
            }
        }

        public JsonResult Price(int modelId,int Quantity)
        {
            int[] modelID = new int[] { modelId };
            List<Tuple<int,int>> price = util.Price(modelID);
            return Json(price.FirstOrDefault(x=> x.Item1 == modelId).Item2*Quantity);
        }

    }
}