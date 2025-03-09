using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EverCareCommunity.Data;
using EverCareCommunity.Areas.Identity.Data;

namespace EverCareCommunity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("EverCareCommunityContextConnection") ?? throw new InvalidOperationException("Connection string 'EverCareCommunityContextConnection' not found.");

            builder.Services.AddDbContext<EverCareCommunityContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<EverCareCommunityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<EverCareCommunityContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}