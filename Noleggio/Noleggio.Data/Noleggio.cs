namespace Noleggio.Data
{
    using Contracts;
    using DbModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class Noleggio : DbContext, INoleggioDbContext
    {
        // Your context has been configured to use a 'Noleggio' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Noleggio.Data.Noleggio' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Noleggio' 
        // connection string in the application configuration file.
        public Noleggio()
            : base("Noleggio")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Noleggio>());
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<RentItem> RentItems { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Category> MainCategory { get; set; }

        public IDbSet<Lease> Leases { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        void INoleggioDbContext.SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}