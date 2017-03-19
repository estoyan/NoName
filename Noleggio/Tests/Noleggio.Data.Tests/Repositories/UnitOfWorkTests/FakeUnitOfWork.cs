using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noleggio.Data.Contracts;

namespace Noleggio.Data.Tests.Repositories.UnitOfWorkTests
{
    public class FakeUnitOfWork : UnitOfWork
    {
        public FakeUnitOfWork(INoleggioDbContext dbContext) 
            : base(dbContext)
        {
        }

        public new INoleggioDbContext DbContext{ get { return base.DbContext; } }
    }
}
