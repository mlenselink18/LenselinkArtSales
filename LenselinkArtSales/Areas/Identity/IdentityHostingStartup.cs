using System;
using LenselinkArtSales.Areas.Identity.Data;
using LenselinkArtSales.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LenselinkArtSales.Areas.Identity.IdentityHostingStartup))]
namespace LenselinkArtSales.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LenselinkArtSalesContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LenselinkArtSalesContextConnection")));

                services.AddDefaultIdentity<LenselinkArtSalesUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<LenselinkArtSalesContext>();
            });
        }
    }
}