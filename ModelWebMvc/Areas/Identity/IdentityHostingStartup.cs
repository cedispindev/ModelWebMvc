using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelWebMvc.Areas.Identity.Data;
using ModelWebMvc.Data;

[assembly: HostingStartup(typeof(ModelWebMvc.Areas.Identity.IdentityHostingStartup))]
namespace ModelWebMvc.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ModelWebMvcContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ModelWebMvcContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;

                })
                    .AddEntityFrameworkStores<ModelWebMvcContext>();
            });
        }
    }
}