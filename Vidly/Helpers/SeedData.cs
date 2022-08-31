using Microsoft.AspNetCore.Identity;

namespace Vidly.Helpers
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider, string testUserPw)
        {
            string adminId = await EnsureUser(serviceProvider, testUserPw, Constants.AdminEmail);
            await EnsureRole(serviceProvider, adminId, Constants.StoreManagerRoleName);
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider, string userPassword, string userName)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var user = await userManager.FindByNameAsync(userName);

            if(user == null)
            {
                user = new IdentityUser
                {
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, userPassword);
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider, string userId, string roleName)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(roleName))
                await roleManager.CreateAsync(new IdentityRole(roleName));

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var user = await userManager.FindByIdAsync(userId);

            if (user == null) throw new Exception("User's password is not strong enough.");

            return await userManager.AddToRoleAsync(user, roleName);
        }
    }
}
