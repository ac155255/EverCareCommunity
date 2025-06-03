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
                .AddRoles<IdentityRole>() // ✅ Enables role management
                .AddEntityFrameworkStores<EverCareCommunityContext>();

            // Add MVC and Razor Pages
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // ✅ Seed roles on startup
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                string[] roles = { "Admin", "Doctor", "Caregiver", "Manager", "Resident" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                // Optional: seed a default user and assign a role (e.g., Doctor)
                var userManager = services.GetRequiredService<UserManager<EverCareCommunityUser>>();

                string doctorEmail = "doctor@example.com";
                string password = "SecureP@ssw0rd!";

                var doctorUser = await userManager.FindByEmailAsync(doctorEmail);
                if (doctorUser == null)
                {
                    doctorUser = new EverCareCommunityUser
                    {
                        UserName = doctorEmail,
                        Email = doctorEmail,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(doctorUser, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(doctorUser, "Doctor");
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

            app.UseAuthentication(); // ✅ Identity middleware
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            await app.RunAsync();
        }
    }
}
