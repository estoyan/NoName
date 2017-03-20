using Moq;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using NUnit.Framework;

namespace Noleggio.Services.Tests.NoleggioGenericServiceTests
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void GetByIdShouldCallRepositoryGetByIdOnce()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.GetById(1)).Verifiable();
            
            //Act
            genericService.GetById(1);
            
            //Assert
            mockeRepository.Verify(x => x.GetById(1), Times.Once);
        }

        [Test]
        [TestCase(1)]
        [TestCase(42)]
        [TestCase(876)]
        [TestCase(1000)]
        public void GetByIdShouldCallRepositoryGetByIdOnceWithSameId(object fakeId)
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.GetById(fakeId)).Verifiable();
            
            //Act
            genericService.GetById(fakeId);
            
            //Assert
            mockeRepository.Verify(x => x.GetById(It.Is<object>(y => y == fakeId)), Times.Once);
        }
    }
}
