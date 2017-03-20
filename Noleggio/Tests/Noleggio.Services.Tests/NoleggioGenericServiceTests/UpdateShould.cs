using Moq;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using Noleggio.Services;
using Noleggio.Services.Tests.NoleggioGenericServiceTests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Services.Tests.FakeGenericRepositoryTests
{
    [TestFixture]
    public class UpdateShould
    {
        [Test]
        public void UpdateSholdCallRepositoryUpdateOnce()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var fakeCategory = new Category();
            var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.Update(fakeCategory)).Verifiable();

            //Act
            genericService.Update(fakeCategory);

            //Assert
            mockeRepository.Verify(x => x.Update(fakeCategory), Times.Once);
        }

        [Test]
        public void UpdateSholdCallRepositoryUpdateWithSameCategory()
        {
            var mockeRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var fakeCategory = new Category();
            var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.Update(fakeCategory)).Verifiable();
            
            //Act
            genericService.Update(fakeCategory);

            //Assert
            mockeRepository.Verify(x => x.Update(It.Is<Category>(y => y == fakeCategory)), Times.Once);
        }

        [Test]
        public void UpdateSholdCallUnitOfWorkComitOnce()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();
            //Act
            genericService.Update(new Category());
            //Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}

