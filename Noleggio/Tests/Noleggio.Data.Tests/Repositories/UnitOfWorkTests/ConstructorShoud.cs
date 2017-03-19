using Moq;
using Noleggio.Data.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Data.Tests.Repositories.UnitOfWorkTests
{
    [TestFixture]
 public    class ConstructorShould
    {
        [Test]
        public void ReturnNewInstance()
        {
            //Arrange
            var mockedContext = new Mock<INoleggioDbContext>();

            //Act
            var actulaUnitOfWork = new UnitOfWork(mockedContext.Object);

            //Assert
            Assert.IsNotNull(actulaUnitOfWork);
        }

        [Test]
        public void ReturnNewInstanceOfUnitOfWork()
        {
            //Arrange
            var mockedContext = new Mock<INoleggioDbContext>();

            //Act
            var actulaUnitOfWork = new UnitOfWork(mockedContext.Object);

            //Assert
            Assert.IsInstanceOf<IUnitOfWork>(actulaUnitOfWork);
        }

        [Test]
        public void SetsDbContext()
        {
            //Arrange
            var mockedContext = new Mock<INoleggioDbContext>();

            //Act
            var actulaUnitOfWork = new FakeUnitOfWork(mockedContext.Object);

            //Assert
            Assert.IsNotNull(actulaUnitOfWork.DbContext);
        }


        [Test]
        public void SetsSameDbContext()
        {
            //Arrange
            var mockedContext = new Mock<INoleggioDbContext>();

            //Act
            var actulaUnitOfWork = new FakeUnitOfWork(mockedContext.Object);

            //Assert
            Assert.AreSame(mockedContext.Object,actulaUnitOfWork.DbContext);
        }

    }
}
