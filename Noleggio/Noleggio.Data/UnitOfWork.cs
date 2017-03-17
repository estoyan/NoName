using Noleggio.Data.Contracts;
using System;

namespace Noleggio.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly INoleggioDbContext dbContext;

        public UnitOfWork(INoleggioDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext can't be null");
            }

            this.dbContext = dbContext;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
