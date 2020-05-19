using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Mobile_Store_MS.Data;
using Mobile_Store_MS.Data.Repositeries;
using Mobile_Store_MS.Hubs;
using Mobile_Store_MS.Services;
using Mobile_Store_MS.ViewModel.Account;
using Mobile_Store_MS.ViewModel.Administrator;

namespace Mobile_Store_MS.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> Usermanager { get; }
        public RoleManager<IdentityRole> Rolemanager { get; }
        public SignInManager<ApplicationUser> Signinmanager { get; }
        private readonly Microsoft.AspNetCore.Identity.UI.Services.IEmailSender _emailSender;
        public readonly IConfiguration Configuration;
        private readonly IHostingEnvironment hostingEnvironment;
        private IHubContext<NotificationHub> hubContext;
        utilities util;
        public AccountController(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signinmanager, RoleManager<IdentityRole> roleManager, Microsoft.AspNetCore.Identity.UI.Services.IEmailSender emailSender, IConfiguration configuration, ApplicationDbContext _context, IHostingEnvironment hostingEnvironment, IHubContext<NotificationHub> _hubContext)
        {
            Usermanager = usermanager;
            Signinmanager = signinmanager;
            Rolemanager = roleManager;
            _emailSender = emailSender;
            Configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
            util = new utilities(_context, hostingEnvironment, configuration);
            hubContext = _hubContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (User.IsInRole("Super Admin")) return RedirectToAction("AddEmployee", "Administration");
            ViewBag.cities = util.getCities();
            if (Signinmanager.IsSignedIn(User) && User.IsInRole("Admin"))
            {
                if (!User.HasClaim(claim => claim.Type == "Create User" && claim.Value == "true"))
                {
                    return Forbid();
                    //return RedirectToAction("~/Administration/AccessDenied.cshtml");
                }
            }
            ViewBag.Stores = util.GetAllStores();
            var LoginUser = await Usermanager.GetUserAsync(User);
            RegisterViewModel r = new RegisterViewModel();
            if (LoginUser.store_id != null)
                r.store_id = LoginUser.store_id;


            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
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
                    Photopath = util.ProcessPhotoproperty(model.Photo),
                    isactive= true
                };
                if (Signinmanager.IsSignedIn(User) && User.IsInRole("Admin") || User.IsInRole("Super Admin"))
                {

                    if (!User.HasClaim(claim => claim.Type == "Create User" && claim.Value == "true"))
                    {
                        return Forbid();
                        //return RedirectToAction("~/Administration/AccessDenied.cshtml");
                    }
                    // Groups
                    //ChatHub chat = new ChatHub();
                   //var group= util.GetAllStores().Select(x=> new { x.StoreName ,x.store_id}).FirstOrDefault(x=> x.store_id==model.store_id);
                    //await chat.JoinGroup(group.StoreName + group.store_id);
                    var LoginUser = await Usermanager.GetUserAsync(User);
                    user.store_id = model.store_id;
                    user.addedBy = LoginUser.Id;
                }

                var result = await Usermanager.CreateAsync(user, model.Password);
                if (!(Signinmanager.IsSignedIn(User) && User.IsInRole("Admin") || User.IsInRole("Super Admin")))
                {                  
                    var roles = await Usermanager.AddToRoleAsync(user, "User");
                }
                else if(Signinmanager.IsSignedIn(User) && model.store_id != null && User.IsInRole("Admin"))
                {
                    var roles = await Usermanager.AddToRoleAsync(user, "Employee");
                } 
                if (result.Succeeded)
                {
                    var token = await Usermanager.GenerateEmailConfirmationTokenAsync(user);

                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                        new { userId = user.Id, token = token }, Request.Scheme);

                    string str = await ViewToStringRenderer.RenderViewToStringAsync(HttpContext.RequestServices, $"~/Views/Template/Email_Confirmation.cshtml", confirmationLink);

                    
                    await _emailSender.SendEmailAsync(user.Email, "Email Confirmation",str);
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
            ViewBag.Stores = util.GetAllStores();
            ViewBag.cities = util.getCities();
            return View(model);
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailexist(string email)
        {
            var user = await Usermanager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in Use");
            }
        }
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("index", "Home");
            }

            var user = await Usermanager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
                return View("NotFound");
            }

            var result = await Usermanager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                string str = await ViewToStringRenderer.RenderViewToStringAsync(HttpContext.RequestServices, $"~/Views/Template/Welcome.cshtml", user.FullName);
                await _emailSender.SendEmailAsync(user.Email, "Welcome To Mobile Store", str);
                if(user.store_id != null)
                {
                  string StoreName=  util.GetAllStores().FirstOrDefault(x => x.store_id == user.store_id).StoreName;
                   await hubContext.Groups.AddToGroupAsync(user.Id,StoreName+user.store_id);
                }
                return View("EmailConfirmed");
            }

            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("Error");
        }
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await Signinmanager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            model.ExternalLogins =
        (await Signinmanager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = await Usermanager.FindByEmailAsync(model.Email);

                if (user != null && !user.EmailConfirmed &&
                            (await Usermanager.CheckPasswordAsync(user, model.Password)))
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                    return View(model);
                }
                var result = await Signinmanager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);


                if (result.Succeeded)
                {
                    if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        //LocalRedirect(returnUrl);
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        if (User.IsInRole("Admin") || User.IsInRole("Super Admin") || User.IsInRole("Employee"))
                            return RedirectToAction("Admin", "Home");
                        else
                            return RedirectToAction("index", "Home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(string Email)
        {

            if (Email == null)
            {
                ModelState.AddModelError("", "Email Can't be null");
                return View();
            }
            if (ModelState.IsValid)
            {

                // Find the user by email
                var user = await Usermanager.FindByEmailAsync(Email);
                // If the user is found AND Email is confirmed
                if (user != null && await Usermanager.IsEmailConfirmedAsync(user))
                {
                    // Generate the reset password token
                    var token = await Usermanager.GeneratePasswordResetTokenAsync(user);

                    // Build the password reset link
                    var passwordResetLink = Url.Action("ResetPassword", "Account",
                            new { email = Email, token = token }, Request.Scheme);

                   
                    string str = await ViewToStringRenderer.RenderViewToStringAsync(HttpContext.RequestServices, $"~/Views/Template/ResetPassword.cshtml", passwordResetLink);

                    //util.sendemail(user.Email, "Reset Account Password", str);
                    //await _emailSender.SendEmailAsync(user.Email, "Reset Account Password", $"<h2>Here is the Reset Password Confirmation Link</h2></br> <a href ={passwordResetLink}>{passwordResetLink}</a>");
                    await _emailSender.SendEmailAsync(user.Email, "Reset Account Password", str);


                    ViewBag.PageTitle = "Email Confirmation";
                    ViewBag.Title = "Password Reset Success";
                    ViewBag.Message = "Before you can Login, please Reset your " +
                            "Password, by clicking on the Reset Password link we have emailed you";
                    return View("EmailConfirmation");
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist or is not confirmed
                ViewBag.PageTitle = "Email Confirmation";
                ViewBag.Title = "Password Reset Success";
                ViewBag.Message = "Before you can Login, please Reset your " +
                        "Password, by clicking on the Reset Password link we have emailed you";
                return View("EmailConfirmation");
            }

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            // If password reset token or email is null, most likely the
            // user tried to tamper the password reset link
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await Usermanager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    // reset the user password
                    var result = await Usermanager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }
                    // Display validation errors. For example, password reset token already
                    // used to change the password or password complexity rules not met
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist
                return View("ResetPasswordConfirmation");
            }
            // Display validation errors if model state is not valid
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account",
                                new { ReturnUrl = returnUrl });
            var properties = Signinmanager
                .ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);//redirect to provider signin page
        }
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            LoginViewModel loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins =
                        (await Signinmanager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState
                    .AddModelError(string.Empty, $"Error from external provider: {remoteError}");

                return View("Login", loginViewModel);
            }

            // Get the login information about the user from the external login provider
            var info = await Signinmanager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState
                    .AddModelError(string.Empty, "Error loading external login information.");

                return View("Login", loginViewModel);
            }

            // If the user already has a login (i.e if there is a record in AspNetUserLogins
            // table) then sign-in the user with this external login provider
            var signInResult = await Signinmanager.ExternalLoginSignInAsync(info.LoginProvider,
                info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            // If there is no record in AspNetUserLogins table, the user may not have
            // a local account
            else
            {
                // Get the email claim value
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                if (email != null)
                {
                    // Create a new user without password if we do not have a user already
                    var user = await Usermanager.FindByEmailAsync(email);

                    if (user == null)
                    {
                        user = new ApplicationUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };

                        await Usermanager.CreateAsync(user);
                    }

                    // Add a login (i.e insert a row for the user in AspNetUserLogins table)
                    await Usermanager.AddLoginAsync(user, info);
                    await Signinmanager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }

                // If we cannot find the user email we cannot continue
                ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
                ViewBag.ErrorMessage = "Please contact support on " + Configuration["Email"];

                return View("Error");
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await Signinmanager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        [HttpGet]
        public async Task<IActionResult> ChangePassword(string id)
        {
            var user = new ApplicationUser();
            if (id != null)
            {
                if (User.IsInRole("Super Admin"))
                {
                    user = await Usermanager.FindByIdAsync(id);
                    if (user == null)
                    {
                        ViewBag.ErrorMessage = $"The User ID {id} is invalid";
                        return View("NotFound");
                    }
                }
                else
                {
                    return View("~Administration/AccessDenied.cshtml");
                }
            }
            else
            {
                user = await Usermanager.GetUserAsync(User);
            }

            var userHasPassword = await Usermanager.HasPasswordAsync(user);

            if (!userHasPassword)
            {
                return RedirectToAction("AddPassword");
            }
            ChangePasswordViewModel c = new ChangePasswordViewModel()
            {
                Id = user.Id
            };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                if (User.IsInRole("Super Admin"))
                {
                    user = await Usermanager.FindByIdAsync(model.Id);
                }
                else
                {
                    user = await Usermanager.GetUserAsync(User);
                }
                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                // ChangePasswordAsync changes the user password
                var result = await Usermanager.ChangePasswordAsync(user,
                    model.CurrentPassword, model.NewPassword);

                // The new password did not meet the complexity rules or
                // the current password is incorrect. Add these errors to
                // the ModelState and rerender ChangePassword view
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                // Upon successfully changing the password refresh sign-in cookie
                if (!User.IsInRole("Super Admin"))
                    await Signinmanager.RefreshSignInAsync(user);
                return View("ChangePasswordConfirmation");
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> AddPassword()
        {
            var user = await Usermanager.GetUserAsync(User);

            var userHasPassword = await Usermanager.HasPasswordAsync(user);

            if (userHasPassword)
            {
                return RedirectToAction("ChangePassword");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPassword(AddPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await Usermanager.GetUserAsync(User);

                var result = await Usermanager.AddPasswordAsync(user, model.NewPassword);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                await Signinmanager.RefreshSignInAsync(user);

                return View("AddPasswordConfirmation");
            }

            return View(model);
        }

    }
}