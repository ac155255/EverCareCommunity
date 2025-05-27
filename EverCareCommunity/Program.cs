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

            // Get the database connection string
            var connectionString = builder.Configuration.GetConnectionString("EverCareCommunityContextConnection")
                ?? throw new InvalidOperationException("Connection string 'EverCareCommunityContextConnection' not found.");

            // Register the database context
            builder.Services.AddDbContext<EverCareCommunityContext>(options =>
                options.UseSqlServer(connectionString));

            // Configure Identity with role support
            builder.Services.AddDefaultIdentity<EverCareCommunityUser>(options =>
                options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>() // ✅ Enable roles
                .AddEntityFrameworkStores<EverCareCommunityContext>();

            // Add MVC + Razor Pages
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // ✅ Seed roles on app startup
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // List all roles your app needs
                string[] roles = { "ADMIN", "DOCTOR", "CAREGIVER", "RESIDENT" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }

            // Configure middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // ✅ Identity Authentication
            app.UseAuthorization();  // ✅ Role-based Authorization

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            // Run the app
            await app.RunAsync();
        }
    }
}
