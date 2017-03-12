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

namespace Noleggio.Data.Repositories
{
    public class GenericEfRepository<TEntity> : IGenericEfRepository<TEntity> 
        where TEntity: class, IDeletableEntity
    {

        private INoleggioDbContext dbContext;
        private IDbSet<TEntity> dbSet;

        public GenericEfRepository(INoleggioDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext can't be null");
            }

            this.dbContext = dbContext;
            this.dbSet = this.DbContext.Set<TEntity>();

            if (this.dbSet == null)
            {
                throw new ArgumentNullException("This DbSet<{0}> doesn't exist in DbContext", typeof(TEntity).Name);
            }
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
            if (id == null)
            {
                throw new ArgumentNullException("Id can't be null!");
            }

            return this.DbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Adding entity can't be null");
            }

            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.GetAll(null);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filterExpression)
        {
            return this.GetAll<TEntity>(filterExpression, null);
        }

        public IQueryable<TEntity> GetAll<T1>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, T1>> sortExpression)
        {
            return this.GetAll<T1, TEntity>(filterExpression, sortExpression, null);

        }

        public IQueryable<T2> GetAll<T1, T2>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, T1>> sortExpression, Expression<Func<TEntity, T2>> selectExpression)
        {
            IQueryable<TEntity> result = this.DbSet;

            if (filterExpression != null)
            {
                result = result.Where(filterExpression);
            }

            if (sortExpression != null)
            {
                result = result.OrderBy(sortExpression);
            }

            if (selectExpression != null)
            {
                return result.Select(selectExpression);
            }
            else
            {
                return result.OfType<T2>();
            }
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
