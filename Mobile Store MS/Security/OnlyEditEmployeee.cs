using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Security
{
    public class OnlyEditEmployeee : AuthorizationHandler<EditEmployeesHandler>
    {
        public readonly RoleManager<IdentityRole> roleManager;
        public OnlyEditEmployeee(RoleManager<IdentityRole> RoleManager)
        {
            roleManager = RoleManager;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, EditEmployeesHandler requirement)
        {
            var authFilterContext = context.Resource as AuthorizationFilterContext;
            if (authFilterContext == null)
            {
                await Task.CompletedTask;
            }
            if (context.User.IsInRole("Super Admin"))
            {
                context.Succeed(requirement);
            }
            else
            {
          
                string roleIdBeingEdited = authFilterContext.HttpContext.Request.Query["roleId"];
                var role = await roleManager.FindByIdAsync(roleIdBeingEdited);
                if(role.Name=="Super Admin" || role.Name=="Admin")
                {
                    context.Fail();
                }
                else
                {
                    context.Succeed(requirement);
                }
            }
            await Task.CompletedTask;
        }
    }
}
