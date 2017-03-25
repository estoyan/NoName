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
            using (this.unitOfWork)
            {
                this.repository.Add(entity);
                this.unitOfWork.Commit();
            }

        }
        //public void AddMany(TEntity entity)
        //{

        //    this.repository.Add(entity);
        //}

        public void Update(TEntity entity)
        {
            using (this.UnitOfWork)
            {
                this.repository.Update(entity);
                this.UnitOfWork.Commit();
            }
        }


        public void Delete(TEntity entity)
        {
            using (this.UnitOfWork)
            {
                this.repository.Delete(entity);
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
            var reslut = this.repository.GetAll().Where(x => x.IsDeleted == true);
            return reslut;
        }

    }
}
