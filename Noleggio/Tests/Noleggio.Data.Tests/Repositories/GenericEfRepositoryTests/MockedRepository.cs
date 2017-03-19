using Noleggio.Data.Repositories;
using Noleggio.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noleggio.Data.Contracts;
using System.Data.Entity;

namespace Noleggio.Data.Tests.Repositories.GenericEfRepositoryTests
{
    public class MockedRepository<TEntity> : GenericEfRepository<TEntity> where TEntity : class, IDeletableEntity
    {
        public MockedRepository(INoleggioDbContext dbContext) : base(dbContext)
        {
        }

     public INoleggioDbContext DbContextMocked
        {
            get
            {
                return base.DbContext;
            }
        }

        public IDbSet<TEntity> DbSetMocked
        {
            get
            {
                return base.DbSet;
            }
        }
    }
}
