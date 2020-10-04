using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Mobile_Store_MS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS
{
    public class MyIdentityDataInitializer
    {
        public MyIdentityDataInitializer(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void SeedData
    (UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public void SeedUsers
    (UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync(Configuration["Email"]).Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = Configuration["Admin_Username"];
                user.Email = Configuration["Email"];
                user.FullName = Configuration["Name"];
                user.PhoneNumber = Configuration["Phone"];
                user.City = 1;
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync
                (user, Configuration["Admin_Password"]).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Super Admin").Wait();
                }
            }

        }

        public void SeedRoles
    (RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Employee";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Super Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Super Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
