using Noleggio.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Noleggio.DbModels;
using Bytes2you.Validation;

namespace Noleggio.Data.Repositories
{
    public class GenericEfRepository<TEntity> : IGenericEfRepository<TEntity> 
        where TEntity: class, IDeletableEntity
    {

        private INoleggioDbContext dbContext;
        private IDbSet<TEntity> dbSet;

        public GenericEfRepository(INoleggioDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "DbContext can't be null").IsNull().Throw();

            this.dbContext = dbContext;
            this.dbSet = this.DbContext.Set<TEntity>();
            Guard.WhenArgument(dbSet, string.Format("This DbSet<{0}> doesn't exist in DbContext", typeof(TEntity).Name)).IsNull().Throw();

        }


        protected INoleggioDbContext DbContext
        {
            get
            {
                return this.dbContext;
            }
        }

        protected IDbSet<TEntity> DbSet
        {
            get
            {
                return this.dbSet;
            }
        }

        public TEntity GetById(object id)
        {
            Guard.WhenArgument(id, nameof(id)).IsNull().Throw();
            return this.DbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            Guard.WhenArgument(entity, nameof(entity)).IsNull().Throw();

            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.dbSet;
        }
        

        public TEntity GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }


        public void Delete(Guid id)
        {
            var item = this.GetById(id);
            if (item != null)
            {
                this.Delete(item);
            }
        }

        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            this.Update(entity);
        }


        private DbEntityEntry AttachIfDetached(TEntity entity)
        {
            var entry = this.DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            return entry;
        }
    }
}
