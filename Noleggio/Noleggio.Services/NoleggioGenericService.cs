using Noleggio.DbModels;
using Noleggio.Services.Contracts;
using System;
using System.Linq;
using System.Linq.Expressions;
using Noleggio.Data.Contracts;
using Bytes2you.Validation;

namespace Noleggio.Services
{
    public abstract class NoleggioGenericService<TEntity> : INoleggioGenericService<TEntity> where TEntity : class, IDeletableEntity
    {

        private readonly IGenericEfRepository<TEntity> repository;
        private readonly IUnitOfWork unitOfWork;

        public NoleggioGenericService(IGenericEfRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(repository, nameof(repository)).IsNull().Throw();
            Guard.WhenArgument(unitOfWork, nameof(unitOfWork)).IsNull().Throw();

            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        protected IGenericEfRepository<TEntity> Repository
        {
            get
            {
                return this.repository;
            }
        }

        public void Add(TEntity entity)
        {
            this.repository.Add(entity);

            using (this.UnitOfWork)
            {
                this.UnitOfWork.Commit();
            }
        }

        public void Update(TEntity entity)
        {
            this.repository.Update(entity);

            using (this.UnitOfWork)
            {
                this.UnitOfWork.Commit();
            }
        }


        public void Delete(TEntity entity)
        {
            this.repository.Delete(entity);

            using (this.UnitOfWork)
            {
                this.UnitOfWork.Commit();
            }
        }

        public TEntity GetById(object id)
        {
            //TODO Is it ok Id to be object instead of Guid?
            Guard.WhenArgument(id, nameof(id)).IsNull().Throw();
            //if ((Guid)id < 0)
            //{
            //    throw new ArgumentNullException("Id can't be negative!");
            //}

            //if (id == null)
            //{
            //    throw new ArgumentNullException("Id can't be null!");
            //}

            return this.repository.GetById(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.repository.GetAll();
        }

        public IQueryable<TEntity> GetDeleted()
        {
            var reslut = this.repository.GetAll(x => x.IsDeleted);
            return reslut;
                //base.repository.GetAll(x => x.IsDeleted);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("Filter can't be null");
            }

            return this.repository.GetAll(filter);
        }

        public IQueryable<TEntity> GetAll<T1>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, T1>> orderBy)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("Filter can't be null");
            }

            if (orderBy == null)
            {
                throw new ArgumentNullException("OrderBy can't be null");
            }

            return this.repository.GetAll(filter, orderBy);
        }

        public IQueryable<TResult> GetAll<T1, TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, T1>> orderBy, Expression<Func<TEntity, TResult>> select)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("Filter can't be null");
            }

            if (orderBy == null)
            {
                throw new ArgumentNullException("OrderBy can't be null");
            }

            if (select == null)
            {
                throw new ArgumentNullException("Select can't be null");
            }

            return this.repository.GetAll(filter, orderBy, select);
        }
    }
}
