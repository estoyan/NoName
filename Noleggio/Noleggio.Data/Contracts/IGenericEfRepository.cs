using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Data.Contracts
{
    public interface IGenericEfRepository<TEntity>
        where TEntity:class
    {

        TEntity GetById(int id);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filterExpression);

        IQueryable<TEntity> GetAll<T1>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, T1>> sortExpression);

        IQueryable<T2> GetAll<T1, T2>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, T1>> sortExpression, Expression<Func<TEntity, T2>> selectExpression);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(Guid id);

    }
}
