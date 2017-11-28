using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using TP.Core.IdentityConfig;
using TP.Core.Users;

namespace TP.EntityFrameworkCore.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TPDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TPDbContext context)
        {
            //初始化用户角色信息
            var userManager = new TPUserManager(new UserStore<User>(context));
            var roleManager = new TPRoleManager(new RoleStore<IdentityRole>(context));
            const string name = "admin@example.com";
            const string password = "123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new User { UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
            context.SaveChanges();
        }
    }
}
