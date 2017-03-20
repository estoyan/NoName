using Noleggio.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noleggio.Data.Contracts;

namespace Noleggio.Services.Tests.NoleggioGenericServiceTests
{
    public class NoleggioGenericServiceMock : NoleggioGenericService<Category>
    {
        public NoleggioGenericServiceMock(IGenericEfRepository<Category> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public IGenericEfRepository<Category> RepositoryMock
        {
            get
            {
                return base.Repository;
            }
        }
    }
}
