namespace Noleggio.Data
{
    using Contracts;
    using DbModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System;

    public class NoleggioDbContext : IdentityDbContext<User>, INoleggioDbContext
    {
        public NoleggioDbContext()
            : base("Noleggio", throwIfV1Schema: false)
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<NoleggioDbContext>());
        }

        public virtual IDbSet<RentItem> RentItems { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public IDbSet<Lease> Leases { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Rating> Ratings { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        //void SaveChanges()
        //{
        //    base.SaveChanges();
        //}

        public static NoleggioDbContext Create()
        {
            return new NoleggioDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

                //modelBuilder.Entity<User>().ToTable("Users");
                //modelBuilder.Entity<IdentityRole>().ToTable("Roles");
                //modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
                //modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
                //modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
        }
    }
}