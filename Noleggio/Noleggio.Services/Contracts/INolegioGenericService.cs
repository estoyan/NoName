using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Services.Contracts
{
    public interface INolegioGenericService<T>
    {

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Hide(T entity);

        void Delete(T entity);

        IQueryable<T> GetAll();

        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);

        IQueryable<T> GetAll<T1>(
           Expression<Func<T, bool>> filter,
           Expression<Func<T, T1>> orderBy);

        IQueryable<TResult> GetAll<T1, TResult>(
           Expression<Func<T, bool>> filter,
           Expression<Func<T, T1>> orderBy,
           Expression<Func<T, TResult>> select);

        IQueryable<T> GetDeleted();
    }
}
