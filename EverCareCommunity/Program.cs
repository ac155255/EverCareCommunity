using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EverCareCommunity.Data;
using EverCareCommunity.Areas.Identity.Data;

namespace EverCareCommunity
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("EverCareCommunityContextConnection")
                                   ?? throw new InvalidOperationException("Connection string 'EverCareCommunityContextConnection' not found.");

            builder.Services.AddDbContext<EverCareCommunityContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<EverCareCommunityUser>(options =>
                options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>() // ✅ Enable roles
                .AddEntityFrameworkStores<EverCareCommunityContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // ✅ Seed roles
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] roles = { "Manager", "Caregiver", "Admin" };

                foreach (var role in roles)
                {
                    var exists = await roleManager.RoleExistsAsync(role);
                    if (!exists)
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication(); // ✅ Needed if using Identity
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            await app.RunAsync(); // ✅ Use async
        }
    }
}
