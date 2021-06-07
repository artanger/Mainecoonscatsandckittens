using System;
using Mainecoonscatsandckittens.Areas.Identity.Data;
using Mainecoonscatsandckittens.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Mainecoonscatsandckittens.Areas.Identity.IdentityHostingStartup))]
namespace Mainecoonscatsandckittens.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MainecoonscatsandckittensContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MainecoonscatsandckittensContextConnection")));

                  services.AddDefaultIdentity<MainecoonscatsandckittensUser>(options =>
                  {
                      options.SignIn.RequireConfirmedAccount = false;
                      options.Password.RequireLowercase = false;
                      options.Password.RequireUppercase = false;
                  })
                    .AddEntityFrameworkStores<MainecoonscatsandckittensContext>();
            });
        }
    }
}