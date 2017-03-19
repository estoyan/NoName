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
    public class ConstructorShould
    {
        [Test]
        public void Initilize()
        {
            //Arrange
            var mockDbSet = new Mock<IDbSet<IDeletableEntity>>();
            var context = new Mock<INoleggioDbContext>();
            context.Setup(x => x.Set<IDeletableEntity>()).Returns(mockDbSet.Object);

            //Act
            var repository = new GenericEfRepository<IDeletableEntity>(context.Object);

            //Assert
            Assert.IsInstanceOf<IGenericEfRepository<IDeletableEntity>>(repository);
        }

        [Test]
        public void ThrowWhenContextIsNull()
        {
            //Arrange&Act&Assert
            Assert.Throws<ArgumentNullException>(()=> new GenericEfRepository<IDeletableEntity>(null));

        }
    }
}
