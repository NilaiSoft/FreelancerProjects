﻿using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(FreelancerProjects.Web.Areas.Identity.IdentityHostingStartup))]
namespace FreelancerProjects.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}