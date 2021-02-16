using Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProject.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = System.Enum.GetNames(typeof(Roles));
            //Seed Roles
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {

            var superAdmin = new AppUser()
            {
                Email = "superadmin@superadmin.com",
                UserName = "superadmin@superadmin.com",
                FullName = "Super Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            await TryToAddUser(userManager, superAdmin, Roles.SuperAdmin.ToString());

            var admin = new AppUser()
            {
                Email = "admin@admin.com",
                UserName = "admin@admin.com",
                FullName = "Admin Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            await TryToAddUser(userManager, admin, Roles.Admin.ToString());

            var customer = new AppUser()
            {
                Email = "customer@customer.com",
                UserName = "customer@customer.com",
                FullName = "Customer Customer",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            await TryToAddUser(userManager, customer, Roles.Customer.ToString());

        }
        private static async Task TryToAddUser(UserManager<AppUser> userManager, AppUser userToAdd, string role)
        {
            if (await userManager.FindByEmailAsync(userToAdd.Email) == null)
            {
                if (await userManager.FindByNameAsync(userToAdd.UserName) == null)
                {
                    if (await userManager.FindByIdAsync(userToAdd.Id) == null)
                    {
                        await userManager.CreateAsync(userToAdd, "_Utn2021_");
                        await userManager.AddToRoleAsync(userToAdd, role);
                    }
                }
            }
        }
    }
}


// var usersToSeed = new AppUser[]{
//     new AppUser()
//     {
//         Email = "superadmin@superadmin.com",
//         UserName = "superadmin",
//         FullName = "Super Admin",
//         EmailConfirmed = true,
//         PhoneNumberConfirmed = true
//     },
//     new AppUser()
//     {
//         Email = "admin@admin.com",
//         UserName = "admin",
//         FullName = "Admin Admin",
//         EmailConfirmed = true,
//         PhoneNumberConfirmed = true
//     },
//     new AppUser()
//     {
//         Email = "customer@customer.com",
//         UserName = "customer",
//         FullName = "Customer Customer",
//         EmailConfirmed = true,
//         PhoneNumberConfirmed = true
//     }
// };