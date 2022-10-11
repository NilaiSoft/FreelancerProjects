using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FreelancerProjects.Framework.Infrastructure;
using FreelancerProjects.Models;
using FreelancerProjects.Web.Configs;
using FreelancerProjects.Web.Infrastructure;

namespace FreelancerProjects.Web
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

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                //options.SignIn.RequireConfirmedPhoneNumber = true;
                //options.SignIn.RequireConfirmedAccount = true;
                //options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddAutoMapper();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.Register();
            services.WebRegister();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for projection scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePages("text/plain", "Status code page, status code: {0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                   name: "Freelancer",
                   areaName: "Freelancer",
                   pattern: "Freelancer/{controller=Home}/{action=Index}");

                endpoints.MapAreaControllerRoute(
                   name: "Customer",
                   areaName: "Customer",
                   pattern: "Customer/{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(name: "Home",
                    pattern: "Store",
                    defaults: new { controller = "Home", action = "Index" });


                //endpoints.MapControllerRoute(
                //    name: "Homepage",
                //    pattern: "{controller=Home}/{action=Index}");

                endpoints.MapRazorPages();
            });

            app.ExceptionHandler();


        }
    }
}
