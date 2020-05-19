using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Mobile_Store_MS.Data;
using Mobile_Store_MS.Hubs;
using Mobile_Store_MS.Services;
using Mobile_Store_MS.ViewModel.Administrator;

namespace Mobile_Store_MS.Controllers
{

    public class AdministrationController : Controller
    {

        public RoleManager<IdentityRole> Rolemanager { get; }
        public UserManager<ApplicationUser> Usermanager { get; }
        public SignInManager<ApplicationUser> Signinmanager { get; }
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly Microsoft.AspNetCore.Identity.UI.Services.IEmailSender _emailSender;
        private IHubContext<NotificationHub> hubContext;

        utilities util;
        public AdministrationController(RoleManager<IdentityRole> rolemanager, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signinmanager, IHostingEnvironment hostingEnvironment, ApplicationDbContext db, IConfiguration configuration, Microsoft.AspNetCore.Identity.UI.Services.IEmailSender emailSender, IHubContext<NotificationHub> _hubContext)
        {
            Rolemanager = rolemanager;
            Usermanager = usermanager;
            Signinmanager = signinmanager;
            this.hostingEnvironment = hostingEnvironment;
            hubContext = _hubContext;
            _emailSender = emailSender;
            util = new utilities(db, hostingEnvironment, configuration);
        }
        [Authorize(Roles = "Super Admin")]
        public IActionResult AddEmployee()
        {
            RegisterEmployeeViewModel r = new RegisterEmployeeViewModel();

            foreach (var role in Rolemanager.Roles)
            {
                UserRoles user = new UserRoles()
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    isSelected = false
                };
                r.Roles.Add(user);
            }
            foreach (Claim claim in ClaimStore.claimstore)
            {
                UserClaim userClaim = new UserClaim()
                {
                    ClaimType = claim.Type,
                    ClaimValue = claim.Value,
                    isSelected = false,
                };
                r.Claims.Add(userClaim);
            }

            ViewBag.cities = util.getCities();
            ViewBag.Stores = util.GetAllStores();
            return View(r);
        }
        [HttpPost]
        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> AddEmployee(RegisterEmployeeViewModel model)
        {
            if (ModelState.IsValid)

            {
                var user = new ApplicationUser
                {
                    FullName = model.FullName,
                    UserName = model.Email,
                    Email = model.Email,
                    City = model.cityId,
                    PhoneNumber = model.PhoneNumber,
                    StreetAdress = model.StreetAdress,
                    store_id = model.store_id,
                    isactive = true,
                    Photopath = util.ProcessPhotoproperty(model.Photo)
                };

                var LoginUser = await Usermanager.GetUserAsync(User);
                user.addedBy = LoginUser.Id;


                var result = await Usermanager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var roles = await Usermanager.AddToRolesAsync(user, model.Roles.Where(x => x.isSelected).Select(y => y.RoleName));

                    if (!roles.Succeeded)
                    {
                        ModelState.AddModelError("", "Cannot add selected roles to user! Edit User and Insert Roles from there");
                        return View(model);
                    }
                    // Add all the claims that are selected on the UI
                    var claims = await Usermanager.AddClaimsAsync(user,
                        model.Claims.Select(c => new Claim(c.ClaimType, c.isSelected ? "true" : "false")));

                    if (!claims.Succeeded)
                    {
                        ModelState.AddModelError("", "Cannot add selected claims to user!  Edit User and Insert Claims from there");
                        return View(model);
                    }
                    var token = await Usermanager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                        new { userId = user.Id, token = token }, Request.Scheme);

                    string str = await ViewToStringRenderer.RenderViewToStringAsync(HttpContext.RequestServices, $"~/Views/Template/Email_Confirmation.cshtml", confirmationLink);
                    await _emailSender.SendEmailAsync(user.Email, "Email Confirmation", str);
                    //util.sendemail(user.Email, "Email Confirmation", $"<h2>Here is the Confirmation Link</h2></br> <a href={confirmationLink}>{confirmationLink}</a>");
                    if (Signinmanager.IsSignedIn(User) && (User.IsInRole("Admin") || User.IsInRole("Super Admin")))
                    {
                        return RedirectToAction("ListUsers", "Administration");
                    }
                    ViewBag.PageTitle = "Email Confirmation";
                    ViewBag.Title = "Registration successful";
                    ViewBag.Message = "Before you can Login, please confirm your " +
                            "email, by clicking on the confirmation link we have emailed you";
                    return View("EmailConfirmation");

                    // await Signinmanager.SignInAsync(user, isPersistent: false);
                    //return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                ViewBag.Stores = util.GetAllStores();
                ViewBag.cities = util.getCities();
                return View(model);
            }
            ViewBag.cities = util.getCities();
            ViewBag.Stores = util.GetAllStores();
            return View(model);
            //await Usermanager.AddToRolesAsync(user,
            // model.Where(x => x.IsSelected).Select(y => y.RoleName));
            //if (Signinmanager.IsSignedIn(User) && User.IsInRole("Admin"))
            // await UserManager.AddToRoleAsync(user.Id, model.UserRole);
            // Create customized claim 
            // await UserManager.AddClaimAsync(user.Id, new Claim("newCustomClaim", "claimValue"));
            //    return RedirectToAction("ListUsers", "Administration");

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [Authorize(Roles = "Super Admin")]
        [AllowAnonymous]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> CreateRole(CreateRoleViewmodel model)
        {
            var identityRole = new IdentityRole
            {
                Name = model.RoleName
            };
            var result = await Rolemanager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return RedirectToAction("GetAllRoles", "Administration");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult GetAllRoles()
        {
            var model = Rolemanager.Roles;
            return View(model);
        }
        [Authorize(Roles = "Super Admin")]
        public async Task<IActionResult> EditRole(string id)
        {
            // Find the role by Role ID
            var role = await Rolemanager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            // Retrieve all the Users
            foreach (var user in Usermanager.Users)
            {
                // If the user is in this role, add the username to
                // Users property of EditRoleViewModel. This model
                // object is then passed to the view for display
                if (await Usermanager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        [Authorize(Policy = "EditRole")]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await Rolemanager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in Usermanager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await Usermanager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "EditRole")]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await Rolemanager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await Usermanager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;


                if (model[i].IsSelected && !(await Usermanager.IsInRoleAsync(user, role.Name)))
                {
                    result = await Usermanager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await Usermanager.IsInRoleAsync(user, role.Name))
                {
                    result = await Usermanager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        [Authorize(Roles = "Admin,Super Admin,Employee")]
        public IActionResult ListUsers(int? pageNo, int? limit)
        {
            if (pageNo == null) pageNo = 1;
            if (limit == null) limit = 10;

            int skip = (int)((pageNo - 1) * limit);
            int totalUser = Usermanager.Users.Where(x => x.isactive == true).Count();
            decimal totalpages = totalUser / Convert.ToInt32(limit);
            ViewBag.TotalPages = Math.Floor(totalpages);
            ViewBag.CurrentPage = pageNo;
            if (skip >= totalUser)
            {
                ViewBag.ErrorMessage = "The Page you are Looking For Could not be found";
                return View("NotFound");
            }
            var model = Usermanager.Users.Where(x => x.isactive == true).Skip(skip).Take((int)limit);
            return View(model);
        }

        [Authorize(Roles = "Admin,Super Admin,Employee")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await Usermanager.FindByIdAsync(id);
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
                if (user.store_id != null)
                {
                    r.store_id = (int)user.store_id;
                }
                if (User.IsInRole("Super Admin") || User.IsInRole("Admin"))
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
                return View("~/Views/Home/Profile.cshtml", r);
            }
            //not Found
            ViewBag.Name = "User";
            return View("ProductNotFound", id);
        }

        [HttpGet]
        [Authorize(Policy = "EditAdmin")]
        public async Task<IActionResult> EditUser(string id)
        {

            var user = await Usermanager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            if (User.IsInRole("Admin"))
            {
                var LoginUser = await Usermanager.GetUserAsync(User);
                if (!User.HasClaim("Edit User", "true") && LoginUser.Id != id)
                {
                    return Forbid();
                }
            }
            ViewBag.Stores = util.GetAllStores();
            // GetClaimsAsync retunrs the list of user Claims
            var userClaims = await Usermanager.GetClaimsAsync(user);
            // GetRolesAsync returns the list of user Roles
            var userRoles = await Usermanager.GetRolesAsync(user);

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                cityId = user.City,
                PhoneNumber = user.PhoneNumber,
                StreetAdress = user.StreetAdress,
                store_id = user.store_id,
                Existingphotopath = user.Photopath,
                Claims = userClaims.Select(c => c.Type + ":" + c.Value).ToList(),
                Roles = userRoles
            };
            ViewBag.cities = util.getCities();
            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "EditAdmin")]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await Usermanager.FindByIdAsync(model.Id);

            if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
            {
                var LoginUser = await Usermanager.GetUserAsync(User);
                if (!User.HasClaim("Edit User", "true") && LoginUser.Id != model.Id)
                {
                    return Forbid();
                }
            }
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.FullName;
                user.PhoneNumber = model.PhoneNumber;
                user.StreetAdress = model.StreetAdress;
                user.store_id = model.store_id;
                user.City = model.cityId;
                if (model.Photo != null)
                {
                    if (model.Existingphotopath != null)
                    {
                        string filepath = Path.Combine(hostingEnvironment.WebRootPath, "Image", model.Existingphotopath);
                        System.IO.File.Delete(filepath);
                    }
                    user.Photopath = util.ProcessPhotoproperty(model.Photo);
                }
                var result = await Usermanager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    if (User.IsInRole("Admin") || User.IsInRole("Super Admin") || User.IsInRole("Employee"))
                        return RedirectToAction("GetUserById", new { id = user.Id });
                    else
                        return RedirectToAction("~/Views/Home/Profile.cshtml");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [HttpPost]
        [Authorize(Policy = "EditAdmin")]
        [Authorize(Policy = "DeleteUserPolicy")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await Usermanager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {

                if (await Usermanager.IsInRoleAsync(user, "Admin") || await Usermanager.IsInRoleAsync(user, "Employee"))
                {
                    var claims = await Usermanager.GetClaimsAsync(user);
                    var claimResult = await Usermanager.RemoveClaimsAsync(user, claims);
                    if (!claimResult.Succeeded)
                    {
                        ModelState.AddModelError("", "Cannot remove user existing claims");
                        return View("ListUsers");
                    }
                    var roles = await Usermanager.GetRolesAsync(user);
                    var RolesResult = await Usermanager.RemoveFromRolesAsync(user, roles);

                    if (!RolesResult.Succeeded)
                    {
                        ModelState.AddModelError("", "Cannot remove user existing roles");
                        return View("ListUsers");
                    }

                    user.isactive = false;
                    var result1 = await Usermanager.UpdateAsync(user);
                    if (user.store_id != null)
                    {
                        string StoreName = util.GetAllStores().FirstOrDefault(x => x.store_id == user.store_id).StoreName;
                        await hubContext.Groups.RemoveFromGroupAsync(user.Id, StoreName + user.store_id);
                    }
                    if (result1.Succeeded)
                    {
                        return RedirectToAction("ListUsers");
                    }
                    foreach (var error in result1.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View("ListUsers");
                }
                var result = await Usermanager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }
        }

        [HttpPost]
        [Authorize(Policy = "abcUser")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await Rolemanager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                try
                {
                    var result = await Rolemanager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("GetAllRoles");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View("GetAllRoles");
                }
                catch
                {
                    //Log the exception to a file. We discussed logging to a file
                    // using Nlog in Part 63 of ASP.NET Core tutorial

                    // Pass the ErrorTitle and ErrorMessage that you want to show to
                    // the user using ViewBag. The Error view retrieves this data
                    // from the ViewBag and displays to the user.
                    ViewBag.ErrorTitle = $"{role.Name} role is in use";
                    ViewBag.ErrorMessage = $"{role.Name} role cannot be deleted as there are users in this role. If you want to delete this role, please remove the users from the role and then try to delete";
                    return View("Error");
                }
            }
        }

        [HttpGet]

        [Authorize(Policy = "EditUserRole")]
        public async Task<IActionResult> ManageRoles(string userId)
        {
            ViewBag.userId = userId;

            var user = await Usermanager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRoles>();

            foreach (var role in Rolemanager.Roles)
            {
                var Eachuserviewmodel = new UserRoles
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await Usermanager.IsInRoleAsync(user, role.Name))
                {
                    Eachuserviewmodel.isSelected = true;
                }
                else
                {
                    Eachuserviewmodel.isSelected = false;
                }

                model.Add(Eachuserviewmodel);
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "EditUserRole")]
        public async Task<IActionResult> ManageRoles(List<UserRoles> model, string userId)
        {
            var user = await Usermanager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var roles = await Usermanager.GetRolesAsync(user);
            var result = await Usermanager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await Usermanager.AddToRolesAsync(user,
                model.Where(x => x.isSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { id = userId });
        }


        [Authorize(Policy = "EditUserRole")]
        public async Task<IActionResult> ManageClaims(string userId)
        {
            var user = await Usermanager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            var model = new UserCliamsViewModel()
            {
                userId = userId
            };
            var existingUserClaims = await Usermanager.GetClaimsAsync(user);
            foreach (Claim claim in ClaimStore.claimstore)
            {
                UserClaims userclaim = new UserClaims()
                {
                    ClaimType = claim.Type,
                    Value = claim.Value
                };
                // If the user has the claim, set IsSelected property to true, so the checkbox
                // next to the claim is checked on the UI
                if (existingUserClaims.Any(c => c.Type == claim.Type && c.Value == "true"))
                {
                    userclaim.IsSelected = true;
                }
                model.Claims.Add(userclaim);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageClaims(UserCliamsViewModel model)
        {
            var user = await Usermanager.FindByIdAsync(model.userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.userId} cannot be found";
                return View("NotFound");
            }

            // Get all the user existing claims and delete them
            var claims = await Usermanager.GetClaimsAsync(user);
            var result = await Usermanager.RemoveClaimsAsync(user, claims);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing claims");
                return View(model);
            }

            // Add all the claims that are selected on the UI

            result = await Usermanager.AddClaimsAsync(user,
                model.Claims.Select(c => new Claim(c.ClaimType, c.IsSelected ? "true" : "false")));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected claims to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { id = model.userId });

        }
    }
}