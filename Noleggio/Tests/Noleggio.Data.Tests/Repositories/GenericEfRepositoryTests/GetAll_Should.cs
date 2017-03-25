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
    public class GetAll_Should
    {
        [Test]
        public void ReturnDbSet()
        {
            //Arrange
            var mockDbSet = new Mock<IDbSet<IDeletableEntity>>();
            var mockedContext = new Mock<INoleggioDbContext>();
            mockedContext.Setup(x => x.Set<IDeletableEntity>()).Returns(mockDbSet.Object);
            var sut = new GenericEfRepository<IDeletableEntity>(mockedContext.Object);

            //Act
            var actual = sut.GetAll();

            //Assert
            Assert.AreEqual(mockDbSet.Object, actual);
        }
    }
}
