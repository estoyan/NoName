using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Services.Contracts
{
    public interface INoleggioGenericService<T>
    {

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);


        void Delete(T entity);

        IQueryable<T> GetAll();

        IQueryable<T> GetDeleted();
    }
}
