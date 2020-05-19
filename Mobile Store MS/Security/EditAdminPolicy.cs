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
                //int LoginUserClaimValue;
                //var c = await userManager.GetClaimsAsync(LoginUser);
                //foreach (Claim claim in ClaimStore.claimstore)
                //{
                   //if(claim.Type == c.Select(x=> x.Type))
                //}

                //var c= await userManager.GetClaimsAsync(LoginUser);
                //string r=
                //int n;
                //bool isNumeric = int.TryParse(c.Select(l=> l.Value), out n);
                if (!await userManager.IsInRoleAsync(user, "Super Admin") && !await userManager.IsInRoleAsync(user, "Admin"))
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
