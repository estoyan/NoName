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
    public class Delete
    {
        [Test]
        public void DeleteSholdCallRepositoryDeleteOnce()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var fakeCategory = new Category();
            var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.Delete(fakeCategory)).Verifiable();

            //Act
            genericService.Delete(fakeCategory);

            //Assert
            mockeRepository.Verify(x => x.Delete(fakeCategory), Times.Once);
        }

        [Test]
        public void DeleteSholdCallRepositoryDeleteWithSameCategory()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var fakeCategory = new Category();
            var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.Delete(fakeCategory)).Verifiable();
           
            //Act
            genericService.Delete(fakeCategory);
           
            //Assert
            mockeRepository.Verify(x => x.Delete(It.Is<Category>(y => y == fakeCategory)), Times.Once);
        }

        [Test]
        public void DeleteSholdCallUnitOfWorkComitOnce()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();
           
            //Act
            genericService.Delete(new Category());
          
            //Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

    }
}


