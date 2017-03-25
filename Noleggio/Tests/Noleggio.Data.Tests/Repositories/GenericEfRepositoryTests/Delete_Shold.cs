using Moq;
using Noleggio.Data.Contracts;
using Noleggio.Data.Repositories;
using Noleggio.DbModels;
using NUnit.Framework;
using System;
using System.Data.Entity;

namespace Noleggio.Data.Tests.Repositories.GenericEfRepositoryTests
{
    [TestFixture]
    public class Delete_Shold
    {
        [Test]
        public void ThrowWhenEntityisNull()
        {
            //Arrange
            var mockDbSet = new Mock<IDbSet<IDeletableEntity>>();
            var mockedContext = new Mock<INoleggioDbContext>();
            mockedContext.Setup(x => x.Set<IDeletableEntity>()).Returns(mockDbSet.Object);
            var sut = new GenericEfRepository<IDeletableEntity>(mockedContext.Object);


            //Act&Assert
            Assert.Throws<ArgumentNullException>(() => sut.Delete(null));
        }
    }
}
