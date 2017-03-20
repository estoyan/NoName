using Moq;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Services.Tests.NoleggioGenericServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ReturnNewInstance()
        {
            //Arrange
            var mockedRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfwork = new Mock<IUnitOfWork>();

            //Act
            var service = new NoleggioGenericServiceMock(mockedRepository.Object, mockedUnitOfwork.Object);

            //Assert
            Assert.IsNotNull(service);
        }

        [Test]
        public void ReturnNewInstanceOfNoleggioGenericService()
        {
            //Arrange
            var mockedRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfwork = new Mock<IUnitOfWork>();

            //Act
            var service = new NoleggioGenericServiceMock(mockedRepository.Object, mockedUnitOfwork.Object);

            //Assert
            Assert.IsInstanceOf<NoleggioGenericService<Category>>(service);
        }

        [Test]
        public void ConstructorShoulDThrowIfRepositoryIsNull()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            //Act&Assert
            Assert.Throws<ArgumentNullException>(() => new NoleggioGenericServiceMock(null, mockedUnitOfWork.Object));
        }
        [Test]
        public void ConstructorShoulDThrowIfUnitOfWorkIsNull()
        {
            var mockeRepository = new Mock<IGenericEfRepository<Category>>();
            Assert.Throws<ArgumentNullException>(() => new NoleggioGenericServiceMock(mockeRepository.Object, null));
        }

    }
}

