using Moq;
using Noleggio.Data.Contracts;
using Noleggio.Data.Repositories;
using Noleggio.DbModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Data.Tests.Repositories.GenericEfRepositoryTests
{
    [TestFixture]
    public class Add_Should
    {
        [Test]
        public void CallOnce_DbSet_Add_WithSameArguments()
        {
            //TODO check this test
            //Arrange
            //var mockDbSet = new Mock<IDbSet<IDeletableEntity>>();
            //var entity = new Mock<IDeletableEntity>();
            //mockDbSet.Setup(x => x.Add(entity.Object)).Verifiable();
            //var context = new Mock<INoleggioDbContext>();
            //context.Setup(x => x.Set<IDeletableEntity>()).Returns(mockDbSet.Object);
            //context.Setup(x => x.Entry<IDeletableEntity>(entity.Object)).Returns(entity.Object);
            //var repository = new GenericEfRepository<IDeletableEntity>(context.Object);

            ////Act
            //repository.Add(entity.Object);

            ////Assert
            //mockDbSet.Verify(x => x.Add(entity.Object), Times.Once);
        }
    }
}
