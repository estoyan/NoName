namespace Noleggio.Data.Migrations
{
    using DbModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NoleggioDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NoleggioDbContext context)
        {
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
           
                    RoleManager.Create(new IdentityRole("admin"));
                
            var UserManager = new UserManager<User>(new UserStore<User>(context));
            var PasswordHash = new PasswordHasher();
            if (!context.Users.Any(u => u.UserName == "admin@admin.net"))
            {
                var user = new User("admin@noleggio.com","Admin", "Admin", DateTime.Now,"Gotham", "Mars")
                {
                   PasswordHash = PasswordHash.HashPassword("1q2w3e4r%T")
                };

                UserManager.Create(user);
                UserManager.AddToRole(user.Id, "admin");
            }
        }
    }
}
