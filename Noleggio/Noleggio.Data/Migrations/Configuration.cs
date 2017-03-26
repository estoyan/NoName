namespace Noleggio.Data.Migrations
{
    using DbModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<NoleggioDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NoleggioDbContext context)
        {

            var categories = new Category[] { new Category("Зимни Спортове"),
                                             new Category("Автомобили"),
                                             new Category("Хоби"),
                                             new Category("Електроника"),
                                             new Category("Домашен Майстор"),
                                             new Category("Недвижими Имоти")};

            if (!context.Categories.Any())
            {
                context.Categories.AddOrUpdate(categories);

            }
           

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
           
                    RoleManager.Create(new IdentityRole("admin"));
                
            var UserManager = new UserManager<User>(new UserStore<User>(context));
            var PasswordHash = new PasswordHasher();
            if (!context.Users.Any(u => u.UserName == "admin@noleggio.com"))
            {
                var user = new User()
                {
                    Email = "admin@noleggio.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    DateOfBirth = DateTime.Now,
                    City = "Gotham",
                    Address = "Mars",
                    EmailConfirmed = true,
                    UserName = "admin@noleggio.com",
                   PasswordHash = PasswordHash.HashPassword("1q2w3e4r%T")
                };

                UserManager.Create(user);
                UserManager.AddToRole(user.Id, "admin");
            }
            context.SaveChanges();
        }
    }
}
