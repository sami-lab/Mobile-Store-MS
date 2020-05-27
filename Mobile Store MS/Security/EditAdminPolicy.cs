using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Mobile_Store_MS.Data;
using Mobile_Store_MS.ViewModel.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Security
{
    public class EditAdminPolicy: AuthorizationHandler<EditAdminHandler>
    {
        public readonly UserManager<ApplicationUser> userManager;
        public EditAdminPolicy(UserManager<ApplicationUser> Usermanager)
        {
            userManager = Usermanager;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, EditAdminHandler requirement)
        {

            var authFilterContext = context.Resource as AuthorizationFilterContext;
            if (authFilterContext == null)
            {
                await Task.CompletedTask;
            }
            string loggedInAdminId = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            //var LoginUser = await userManager.FindByIdAsync(loggedInAdminId);
            //string adminIdBeingEdited = authFilterContext.HttpContext.Request.Query["userId"];
            string[] a = authFilterContext.HttpContext.Request.Path.Value.Split('/');
            string adminIdBeingEdited = a[a.Length - 1];
            var user = await userManager.FindByIdAsync(adminIdBeingEdited);
            if (user == null) context.Fail();

            if (!context.User.IsInRole("Super Admin"))
            {
                if (context.User.IsInRole("User") && loggedInAdminId == adminIdBeingEdited) context.Succeed(requirement);
                if (!await userManager.IsInRoleAsync(user, "Super Admin") && !await userManager.IsInRoleAsync(user, "Admin") && context.User.HasClaim(claim => claim.Type == "Edit User" && claim.Value == "true"))
                {
                    if (context.User.IsInRole("Employee") && !await userManager.IsInRoleAsync(user, "User"))  context.Fail();
                    else context.Succeed(requirement);
                }
                else
                {
                    await Task.CompletedTask;
                    //context.Fail();
                }

            }
            else
            {
                context.Succeed(requirement);
            }
            await Task.CompletedTask;
        }
    }
}
