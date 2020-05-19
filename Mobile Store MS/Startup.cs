using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobile_Store_MS.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mobile_Store_MS.Data.Interfaces;
using Mobile_Store_MS.Data.Repositeries;
using Mobile_Store_MS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Mobile_Store_MS.Security;
using Stripe;
using Mobile_Store_MS.Hubs;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Mobile_Store_MS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSession();
            services.Configure<CookieTempDataProviderOptions>(options => {
                options.Cookie.IsEssential = true;
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //Db ConString
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ConString")));
            //Options
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 7;
                options.Password.RequiredUniqueChars = 3;
                options.SignIn.RequireConfirmedEmail = true;
            }).AddDefaultUI(UIFramework.Bootstrap4)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddDefaultUI(UIFramework.Bootstrap4)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            //Token lifeSpan
            services.Configure<DataProtectionTokenProviderOptions>(o =>
               o.TokenLifespan = TimeSpan.FromHours(5));

            //Setting Up Global Authentication
           
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                  .RequireAuthenticatedUser()
                                  .Build();
                config.Filters.Add(new AuthorizeFilter(policy));

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //RealTime Features
            services.AddSignalR();
            services.AddScoped<NotificationHub>();

            //Access Denied
            services.ConfigureApplicationCookie(options =>
            options.AccessDeniedPath = new PathString("/Administration/AccessDenied"));

            //External Login
            services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.ClientId = Configuration["GoogleClientId"];
                options.ClientSecret = Configuration["GoogleClientSecret"];
            })
            .AddFacebook(options =>
            {
                options.ClientId = Configuration["FacebookClientId"];
                options.ClientSecret = Configuration["FacebookClientSecret"];
            });

            //Add Autherization Policy
            services.AddAuthorization(options =>
            {

                //
                options.AddPolicy("abcUser", policy => policy.RequireRole("Super Admin"));

                options.AddPolicy("DeleteUserPolicy", policy => 
                policy.RequireClaim("Delete User","true"));

                options.AddPolicy("EditUserPolicy", policy =>
                   policy.RequireClaim("Edit User", "true"));

                options.AddPolicy("UpdatingStatus", policy => policy.RequireAssertion(context=> 
                context.User.IsInRole("Admin") || context.User.IsInRole("Employee") && context.User.HasClaim(claim => claim.Type== "Update Status" && claim.Value=="true")
                || context.User.IsInRole("Super Admin")));

                options.AddPolicy("Purchasing", policy => policy.RequireAssertion(context =>
                context.User.IsInRole("Admin") || context.User.IsInRole("Employee") && context.User.HasClaim(claim => claim.Type == "Allow Purchasing" && claim.Value == "true")
                || context.User.IsInRole("Super Admin")));

                options.AddPolicy("EditAdmin", policy => policy.AddRequirements(new EditAdminHandler()));
                options.AddPolicy("EditRole", policy => policy.AddRequirements(new EditEmployeesHandler()));
                options.AddPolicy("EditUserRole", policy => policy.AddRequirements(new ManageRoleHandler()));
            });
           
            //Register DI
            services.AddScoped<ICompanyRepositories, CompanyRepositery>();
            services.AddScoped<ICustomerRepositery, CustomerRepositery>();
            services.AddScoped<IModelRepositery, ModelRepositery>();
            services.AddScoped<IorderRepositery, OrderRepositery>();
            services.AddScoped<IPurchasingRepositery, PurchasingRepositery>();
            services.AddScoped<IVendorRepositery, VendorRepositery>();
            services.AddScoped<IStoreRepositery, StoreRepositery>();
            services.AddScoped<IStockRepositery, StockRepositery>();
            services.AddScoped<IHomeRepoitery, HomeRepositery>();

            //Email And payment Sevice
            services.AddSingleton<Microsoft.AspNetCore.Identity.UI.Services.IEmailSender, EmailSender>();
            services.Configure<EmailAuthOptions>(Configuration);
            services.Configure<StripeSetting>(Configuration.GetSection("Stripe"));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Registering Policy
            services.AddScoped<IAuthorizationHandler, EditAdminPolicy>();
            services.AddScoped<IAuthorizationHandler, OnlyEditEmployeee>();
            services.AddScoped<IAuthorizationHandler, ManageRolePolicy>();
            services.AddSingleton<IAuthorizationHandler, CanEditOnlytheirDetails>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            StripeConfiguration.ApiKey= Configuration.GetSection("Stripe")["SecretKey"];
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseSignalR(config =>
            {
                config.MapHub<ChatHub>("/messages");
                config.MapHub<NotificationHub>("/notifications");
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseCookiePolicy();
        }
    }
}
