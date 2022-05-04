using System;
using Auth.Areas.Identity.Data;
using Auth.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Auth.Areas.Identity.IdentityHostingStartup))]
namespace Auth.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthIdentityDbContextConnection")));

                services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
                .AddEntityFrameworkStores<AuthIdentityDbContext>()
                .AddDefaultTokenProviders();


                services.AddScoped<IUserClaimsPrincipalFactory<User>,
                        ApplicationUserClaimsPrincipalFactory>();
            });
        }
    }
}