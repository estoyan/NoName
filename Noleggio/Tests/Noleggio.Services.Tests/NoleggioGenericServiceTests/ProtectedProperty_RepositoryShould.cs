using Moq;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using NUnit.Framework;

namespace Noleggio.Services.Tests.NoleggioGenericServiceTests
{
    [TestFixture]
    public class ProtectedProperty_RepositoryShould
    {
        [Test]
        public void GetDeletedShouldCallRepositoryGetAllOnce()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.GetAll(y => y.IsDeleted)).Verifiable();

            //Act
            var actualRepository = genericService.RepositoryMock;

            //Assert
            Assert.AreEqual(mockeRepository.Object, actualRepository); 
        }
    }
}
