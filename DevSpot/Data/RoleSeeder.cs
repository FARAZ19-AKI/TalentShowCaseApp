using DevSpot.Constants;
using Microsoft.AspNetCore.Identity;

namespace DevSpot.Data
{
    public static class RoleSeeder
    {
        public static async Task RoleSeederAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(Roles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            }

            if (!await roleManager.RoleExistsAsync(Roles.User))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.User));
            }

            if (!await roleManager.RoleExistsAsync(Roles.RegisteredUser))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.RegisteredUser));
            }
        }
    }
}
