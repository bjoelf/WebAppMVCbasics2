using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebAppMVCbasics2app.Models;

namespace WebAppMVCbasics2app.Database
{
    public class DbInitializer
    {
        public static void Initialize(PeopleDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> appUser
            )
        {
            //context.Database.EnsureCreated();//If not using EF migrations
            context.Database.Migrate();

            if (context.Roles.Any())
                return;

            //------ Seed into database ----------------------------------------
            string[] rolesToSeed = new string[] { "Admin", "User"};

            foreach (var roleName in rolesToSeed)
            {
                IdentityRole role = new IdentityRole(roleName);

                var result = roleManager.CreateAsync(role).Result;

                if (!result.Succeeded)
                {
                    throw new Exception("Faild to create Role: " + roleName);
                }
            }

            AppUser user = new AppUser()
            {
                UserName = "AdminSeeding",
                LastName = "Admin",
                FirstName = "Super",
                BirthDate = "2021-05-21",
                Email = "a@a.a",
                PhoneNumber = "123123123"
            };

            IdentityResult resultUser = appUser.CreateAsync(user, "Qwerty!23456").Result;

            if (!resultUser.Succeeded)
            {
                throw new Exception("Faild to create Admin Acc: AdminSeeding");
            }

            IdentityResult resultAssign = appUser.AddToRoleAsync(user, rolesToSeed[0]).Result;

            if (!resultAssign.Succeeded)
            {
                throw new Exception($"Faild to grant {rolesToSeed[0]} role to AdminSeeding");
            }
        }
    }
}
