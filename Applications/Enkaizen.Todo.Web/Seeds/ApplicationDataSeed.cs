using Enkaizen.Todo.Dal;
using Enkaizen.Todo.Web.Data;
using Enkaizen.Todo.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enkaizen.Todo.Web.Seeds
{
    public class ApplicationDataSeed : DataSeed
    {
        public ApplicationDataSeed(
            ApplicationDbContext dbContext, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
            : base(dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;

            adminUser = new ApplicationUser { Email = "admin@gmail.com", UserName = "shuvo" };

            regularUser1 = new ApplicationUser { Email = "regular1@gmail.com", UserName = "arif" };
            regularUser2 = new ApplicationUser { Email = "regular2@gmail.com", UserName = "mahin" };

            adminRole = new IdentityRole("Admin");
            regularRole = new IdentityRole("Regular");
        }

        public UserManager<ApplicationUser> _userManager { get; }
        public RoleManager<IdentityRole> _roleManager { get; }

        private ApplicationUser adminUser, regularUser1, regularUser2;
        private IdentityRole adminRole, regularRole;

        public async override Task SeedAsync()
        {
            try
            {
                var result = await _userManager.CreateAsync(adminUser, "Admin$2021");
                if (result.Succeeded)
                {
                    await _roleManager.CreateAsync(adminRole);
                    await _userManager.AddToRoleAsync(adminUser, adminRole.Name);
                }

                result = await _userManager.CreateAsync(regularUser1, "Shuvo$2021");
                if (result.Succeeded)
                {
                    await _roleManager.CreateAsync(regularRole);
                    await _userManager.AddToRoleAsync(regularUser1, regularRole.Name);
                }

                result = await _userManager.CreateAsync(regularUser2, "Shuvo$2021");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(regularUser1, regularRole.Name);
                }
            }
            catch (Exception ex)
            {
                // EXPECTED Exception no need to catch or worry.
            }
        }
    }
}
