using Moq;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using NUnit.Framework;
using System.Data.Entity;

namespace Noleggio.Data.Tests.Repositories.GenericEfRepositoryTests
{
    [TestFixture]
    public class ProtectedPropertyDbContext_Should
    {
        [Test]
        public void ReturnSameDbSet()
        {
            //Arrange
            var mockDbSet = new Mock<IDbSet<IDeletableEntity>>();
            var context = new Mock<INoleggioDbContext>();
            context.Setup(x => x.Set<IDeletableEntity>()).Returns(mockDbSet.Object);

            //Act
            var repository = new MockedRepository<IDeletableEntity>(context.Object);

            //Assert
            Assert.AreEqual(context.Object, repository.DbContextMocked);
        }
    }
}

