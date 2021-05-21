using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace WebAppMVCbasics2app.Database
{
    public class DbInitializer
    {
        public static void Initialize(PeopleDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager
            )
        {
            //context.Database.EnsureCreated();//If not using EF migrations
            context.Database.Migrate();

            if (context.Roles.Any())
                return;

            //------ Seed into database ----------------------------------------
            string[] rolesToSeed = new string[] { "Admin", "Superuser", "Customer" };

            foreach (var roleName in rolesToSeed)
            {
                IdentityRole role = new IdentityRole(roleName);

                var result = roleManager.CreateAsync(role).Result;

                if (!result.Succeeded)
                {
                    throw new Exception("Faild to create Role: " + roleName);
                }
            }

            IdentityUser user = new IdentityUser()
            {
                UserName = "Admin_seeding",
                Email = "a@a.a",
                PhoneNumber = "123123123"
            };
            IdentityResult resultUser = userManager.CreateAsync(user, "Qwerty!23456").Result;

            if (!resultUser.Succeeded)
                throw new Exception("Faild to create Admin Acc: AdminPower");

            IdentityResult resultAssign = userManager.AddToRoleAsync(user, rolesToSeed[0]).Result;

            if (!resultAssign.Succeeded)
                throw new Exception($"Faild to grant {rolesToSeed[0]} role to AdminPower");
        }
    }
}
