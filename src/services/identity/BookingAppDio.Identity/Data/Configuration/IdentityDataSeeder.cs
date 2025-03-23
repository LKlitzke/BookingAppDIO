using BookingAppDio.Core.EFCore;
using BookingAppDio.Identity.Models;
using BookingAppDio.Identity.Models.Constants;
using Microsoft.AspNetCore.Identity;

namespace BookingAppDio.Identity.Data.Configuration
{
    public class IdentityDataSeeder : IDataSeeder
    {
        private readonly RoleManager<IdentityRole<long>> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityDataSeeder(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<long>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAllAsync()
        {
            await SeedRoles();
            await SeedUsers();
        }

        private async Task SeedRoles()
        {
            if (await _roleManager.RoleExistsAsync(Constants.Role.Admin) == false)
                await _roleManager.CreateAsync(new(Constants.Role.Admin));

            if (await _roleManager.RoleExistsAsync(Constants.Role.User) == false)
                await _roleManager.CreateAsync(new(Constants.Role.User));
        }

        private async Task SeedUsers()
        {
            if (await _userManager.FindByNameAsync("lucas.silva") == null)
            {
                var user = new ApplicationUser
                {
                    FirstName = "Lucas",
                    LastName = "Silva",
                    UserName = "lucas.silva",
                    Email = "lucas.silva@hotmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PassportNumber = "123456789"
                };

                var result = await _userManager.CreateAsync(user, "Admin@123456");

                if (result.Succeeded)
                    await _userManager.AddToRoleAsync(user, Constants.Role.Admin);
            }

            if (await _userManager.FindByNameAsync("john.doe") == null)
            {
                var user = new ApplicationUser
                {
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "john.doe",
                    Email = "john.doe@hotmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PassportNumber = "12356513877"
                };

                var result = await _userManager.CreateAsync(user, "User@123456");

                if (result.Succeeded)
                    await _userManager.AddToRoleAsync(user, Constants.Role.User);
            }
        }
    }
}
