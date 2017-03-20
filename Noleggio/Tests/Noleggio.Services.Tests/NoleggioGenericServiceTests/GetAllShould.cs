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
    public class GetAllShould
    {

        [Test]
        public void GetAllShouldCallRepositoryGetAllOnce()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.GetAll()).Verifiable();

            //Act
            genericService.GetAll();

            //Assert
            mockeRepository.Verify(x => x.GetAll(), Times.Once);
        }

    }
}
