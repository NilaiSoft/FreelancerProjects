using Microsoft.Extensions.DependencyInjection;
using FreelancerProjects.Services;
using FreelancerProjects.Services.UnitOfWork;
using System;
using System.Linq;

namespace FreelancerProjects.Web.Infrastructure
{
    public static class DependencyRegistrar
    {
        public static void WebRegister(this IServiceCollection services)
        {
            var appServices = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.FullName.EndsWith("ModelFactory") 
                && t.FullName.StartsWith("FreelancerProjects.Web.Factories")
                && (t.IsClass || t.IsInterface))
                .Select(x => x);

            appServices = appServices
                .Where(x => x.FullName.StartsWith("FreelancerProjects.Web.Factories"));

            foreach (var IService in appServices
                .Where(x => x.FullName.StartsWith("FreelancerProjects.Web.Factories")))
            {
                var Service = appServices.FirstOrDefault
                    (x => x.Name == IService.Name.Substring
                    (1, IService.Name.Length - 1));
                if (Service != null)
                    services.AddScoped(IService, Service);
            }

        }
    }
}
