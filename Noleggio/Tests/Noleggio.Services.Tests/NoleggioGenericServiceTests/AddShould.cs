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
   public class AddShould
    {
        [Test]
        public void AddSholdCallRepositoryAddOnce()
        {
            var mockeRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var fakeCategory = new Category();

            var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.Add(fakeCategory)).Verifiable();
            genericService.Add(fakeCategory);
            mockeRepository.Verify(x => x.Add(fakeCategory), Times.Once);
        }

        [Test]
        public void AddSholdCallRepositoryAddWithSameUser()
        { 
            var mockeRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var fakecategory = new Category();
            var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.Add(fakecategory)).Verifiable();
            genericService.Add(fakecategory);
            mockeRepository.Verify(x => x.Add(It.Is<Category>(y => y == fakecategory)), Times.Once);
        }

        [Test]
        public void AddSholdCallUnitOfWorkComitOnce()
        {
            var mockeRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();
            genericService.Add(new Category());
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}

