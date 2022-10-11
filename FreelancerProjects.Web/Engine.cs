using Microsoft.Extensions.DependencyInjection;

namespace FreelancerProjects.Web
{
    public static class Engine
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
        }
    }
}
