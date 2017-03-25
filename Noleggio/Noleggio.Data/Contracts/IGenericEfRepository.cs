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

        TEntity GetById(object id);

        IQueryable<TEntity> GetAll();

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(Guid id);

    }
}
