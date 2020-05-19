using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Security
{
    public class CanEditOnlytheirDetails : AuthorizationHandler<EditAdminHandler>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EditAdminHandler requirement)
        {
            var authFilterContext = context.Resource as AuthorizationFilterContext;
            if (authFilterContext == null)
            {
                return Task.CompletedTask;
            }
            string loggedInAdminId = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            //string adminIdBeingEdited = authFilterContext.HttpContext.Request.Query["id"];
            string[] a = authFilterContext.HttpContext.Request.Path.Value.Split('/');
            string adminIdBeingEdited = a[a.Length - 1];
            if(context.User.IsInRole("Super Admin"))
            {
                context.Succeed(requirement);
            }
            if (adminIdBeingEdited.ToLower() == loggedInAdminId.ToLower())
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
