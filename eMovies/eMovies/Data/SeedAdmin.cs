using eMovies.Models;
using Microsoft.AspNetCore.Identity;

namespace eMovies.Data
{
    public class SeedAdmin
    {
        public static async Task SeedAdminAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminEmail = "admin@example.com";

                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        FullName = "Administrator",
                        EmailConfirmed = true,
                        Country = "N/A",
                        City = "N/A",
                        State = "N/A",
                        Address = "N/A",
                        Zip = "0000",
                        DateOfBirth = DateTime.UtcNow
                    };

                    var result = await userManager.CreateAsync(newAdminUser, "Admin@123");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newAdminUser, "Admin");
                    }
                }
            }
        }

    }
}
