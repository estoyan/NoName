using Moq;
using Noleggio.Common.Contracts;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using NUnit.Framework;
using System;

namespace Noleggio.Services.Tests.RentItemServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ReturnNewInstance()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();

            //Act 
            var rentItemService= new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

            //Assert
            Assert.IsNotNull(rentItemService);
        }

        [Test]
        public void ReturnNewInstanceOfRentItemService()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();

            //Act 
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

            //Assert
            Assert.IsInstanceOf<RentItemService>(rentItemService);
        }

        [Test]
        public void ThrowWhenIMapingServiceNull()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, null));
        }
    }
}
