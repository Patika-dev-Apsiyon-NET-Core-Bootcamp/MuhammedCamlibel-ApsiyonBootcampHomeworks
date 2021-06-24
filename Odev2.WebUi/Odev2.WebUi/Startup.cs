using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Odev2.Business.Abstract;
using Odev2.Business.Concrete;
using Odev2.Data.Abstract;
using Odev2.Data.Concrete;
using Odev2.WebUi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev2.WebUi
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(options => 
            {
                options.LoginPath = "/Auth/Login";
                options.AccessDeniedPath = "/Auth/Accsessdenied";
                
            });
            //services.AddDefaultIdentity<User>(options =>
            //{
            //    options.SignIn.RequireConfirmedAccount = true;
            //    options.Password.RequireDigit = true;
            //    options.Password.RequiredLength = 6;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequireNonAlphanumeric = true;
            //    options.Password.RequireUppercase = true;
            //    //Tm7&kk

            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            //    options.Lockout.MaxFailedAccessAttempts = 3;


            //}).AddEntityFrameworkStores<ApplicationDbContext>();

            //services.configureapplicationcookie(options =>
            //{
            //    options.loginpath = "/auth/login";
            //    options.accessdeniedpath = "/auth/accessdenied";
            //});

            services.AddDbContext<RestaurantContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IFoodService, FoodManager>();
            services.AddScoped<IFoodRepository, FoodRepository>();

            services.AddScoped<IRestaurantService, RestaurantManager>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IConfiguration configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                 
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Restaurant}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            SeedIdentity.Seed(userManager,roleManager,configuration).Wait();
        }
    }
}
