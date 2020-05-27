using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Mobile_Store_MS.Data;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.Hubs;
using Mobile_Store_MS.ViewModel;
using Mobile_Store_MS.ViewModel.Administrator;

namespace Mobile_Store_MS.Controllers
{

    [AllowAnonymous]
    public class HomeController : Controller
    {
        public readonly IModelRepositery iModelRepositery;
        public UserManager<ApplicationUser> Usermanager { get; }
        public readonly IHomeRepoitery homeRepoitery;
        private IHubContext<NotificationHub> _hubContext;

        utilities util;
        public HomeController(IModelRepositery imodelRepositery, IHubContext<NotificationHub> _hubContext, IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> usermanager, IHomeRepoitery _homeRepoitery, ApplicationDbContext myApp)
        {
            iModelRepositery = imodelRepositery;
            homeRepoitery = _homeRepoitery;
            Usermanager = usermanager;
            util = new utilities(myApp, hostingEnvironment);
            this._hubContext = _hubContext;

        }


        public IActionResult Index()
        {
            //util.getCities();             
            var data = iModelRepositery.GetDetails().GroupBy(x => x.CompanyName)
                                .Select(x => new GroupBYCompany() { CompanyName = x.Key, Models = x });
            return View(data);
        }
        [Authorize]
        public IActionResult Admin()
        {
            var data = homeRepoitery.Admin();
            return View(data);
        }

        [Authorize]
        public async Task<IActionResult> CreateMessages()
        {
            var user = await Usermanager.GetUserAsync(User);
            if (user.Photopath != null) ViewBag.MyImage = "/image/" + user.Photopath;
            else ViewBag.MyImage = "/image/emp.jpg";
            ViewBag.Email = user.Email;

            List<ApplicationUser> users = new List<ApplicationUser>();
            foreach (var u in Usermanager.Users.Where(x => x.Id != user.Id))
            {
                if ((u.store_id != null || await Usermanager.IsInRoleAsync(u, "Super Admin")) && u.isactive == true)
                {
                    users.Add(u);
                }
            }
            return View(users);
        }
        [Authorize]
        public async Task<IActionResult> Create(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await Usermanager.GetUserAsync(User);
                int messageId = await homeRepoitery.Create(model, user.Id);
                return Ok();
            }
            ModelState.AddModelError("", "Error in Sending Message");
            return View();
        }

        public IActionResult Models(int id)
        {
            var data = iModelRepositery.GetDetails().Where(x => x.PhoneId == id).GroupBy(x => x.CompanyName)
                                .Select(x => new GroupBYCompany() { CompanyName = x.Key, Models = x });
            return View(data);
        }
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await Usermanager.GetUserAsync(User);
            if (user != null)
            {
                RegisterEmployeeViewModel r = new RegisterEmployeeViewModel()
                {
                    id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    City = util.getCities().FirstOrDefault(x => x.id == user.City).city,
                    PhoneNumber = user.PhoneNumber,
                    Photopath = user.Photopath,
                    StreetAdress = user.StreetAdress,

                };
                if (await Usermanager.IsInRoleAsync(user, "Super Admin") || await Usermanager.IsInRoleAsync(user, "Admin"))
                {
                    var userClaims = await Usermanager.GetClaimsAsync(user);
                    var userRoles = await Usermanager.GetRolesAsync(user);
                    if (user.store_id != null)
                    {
                        r.StoreName = util.GetAllStores().FirstOrDefault(x => x.store_id == user.store_id).StoreName;
                    }
                    r.addedBy = user.addedBy;
                    foreach (var claim in userClaims)
                    {
                        UserClaim u = new UserClaim()
                        {
                            ClaimType = claim.Type,
                            ClaimValue = claim.Value
                        };
                        r.Claims.Add(u);
                    }
                    foreach (var role in userRoles)
                    {
                        UserRoles ro = new UserRoles()
                        {
                            RoleName = role
                        };
                        r.Roles.Add(ro);
                    }

                }
                return View(r);
            }
            else
            {
                RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public async Task<JsonResult> GetProfile()
        {
            var user = await Usermanager.GetUserAsync(User);
            if (user != null)
            {
                return Json(user.Photopath);
            }
            else
            {
                return Json("emp.jpg");
            }
        }

        //Total User's Messages
        public async Task<JsonResult> UserMessages(string userID, string Email)
        {
            var user = await Usermanager.GetUserAsync(User);
            var Messages =  homeRepoitery.messages(user.Id, userID, user.Email, Email);
            return Json(Messages);
        }

        //Total User's Notifications 
        public async Task<JsonResult> UserNotifications(int? pageNo, int? limit)
        {
            if (pageNo == null) pageNo = 1;
            if (limit == null) limit = 10;
            int skip = (int)((pageNo - 1) * limit);
            var user = await Usermanager.GetUserAsync(User);
            int totalNotification = homeRepoitery.UserTotalNotification(user.Id);
            var Notifications = await homeRepoitery.Notifications(user.Id, skip, (int)limit);
            return Json(new { Notifications, totalNotification, pageNo });
        }

        //Count User Unread Messages
        public async Task<JsonResult> GetUserUnreadMessagesCount()
        {
            var user = await Usermanager.GetUserAsync(User);
            var Messages = await homeRepoitery.countUserUnreadMessages(user.Email);
            return Json(Messages);
        }


        //Count Total Users Unread Messages 
        public async Task<JsonResult> GetUnreadMessagesCount()
        {
            var user = await Usermanager.GetUserAsync(User);
            int Messages = homeRepoitery.countUnreadMessages(user.Email);
            return Json(Messages);
        }
        //Count Total Unread Notifications
        public async Task<JsonResult> GetUnreadNotificationsCount()
        {
            var user = await Usermanager.GetUserAsync(User);
            int Messages = homeRepoitery.countUnreadNotifications(user.Id);
            return Json(Messages);
        }

        public async Task<JsonResult> UpdateUserMessages(string personID)
        {
            var user = await Usermanager.GetUserAsync(User);
            bool result = await homeRepoitery.UpdateMessagesRead(user.Email,personID);
            return Json(result);
        }
    }
}