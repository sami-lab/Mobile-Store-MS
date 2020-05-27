using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Mobile_Store_MS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Security
{
    public class ManageRolePolicy: AuthorizationHandler<ManageRoleHandler>
    {
        public readonly UserManager<ApplicationUser> userManager;
        public ManageRolePolicy(UserManager<ApplicationUser> Usermanager)
        {
            userManager = Usermanager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageRoleHandler requirement)
        {

            var authFilterContext = context.Resource as AuthorizationFilterContext;
            if (authFilterContext == null)
            {
                await Task.CompletedTask;
            }
            string loggedInAdminId = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            //string[] a = authFilterContext.HttpContext.Request.Path.Value.Split('/');
            //string adminIdBeingEdited = a[a.Length - 1];
            string adminIdBeingEdited = authFilterContext.HttpContext.Request.Query["userId"];
            var user = await userManager.FindByIdAsync(adminIdBeingEdited);
            if (user == null) context.Fail();

            if (!context.User.IsInRole("Super Admin"))
            {
                if (!await userManager.IsInRoleAsync(user, "Super Admin") || !await userManager.IsInRoleAsync(user, "Admin"))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    // context.User.HasClaim(claim => claim.Type == "Edit Role" && claim.Value == "true")
                    context.Fail();
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
