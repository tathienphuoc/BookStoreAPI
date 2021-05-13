using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Data
{
    public class UserSeed
    {
        public static async Task SeedUsers(UserManager<Account> userManager, 
            RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;
            var user = new Account() {
                FullName = "SGU",
                HomeAddress = "SGU",
                UserName = "customer",
                Image = null,
                IsBlocked = true,
                Email = "tutranthanh012@gmail.com",
                CreditCard = null,
                ShoppingCart = null,
                Reviews = null,
                Order_Receipts = null
            };
                    
            var roles = new List<AppRole>
            {
                new AppRole{Name = "Customer"},
                new AppRole{Name = "Admin"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
            user.UserName = user.UserName.ToLower();
            await userManager.CreateAsync(user, "123456789");
            await userManager.AddToRoleAsync(user, "Customer");
            var admin = new Account
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "admin");
            await userManager.AddToRolesAsync(admin, new[] {"Admin"});
        }
    }
}
