using Moq;
using Noleggio.Common.Contracts;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using Noleggio.DtoModels.RentItems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Services.Tests.RentItemServiceTests
{
    [TestFixture]
    public class GetRentItemById_Should
    {

        [Test]
        public void CallsRepositoryGetByIdOnce()
        {
            //Arrange
            
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();
            var stubId = Guid.NewGuid();
            mockeRepository.Setup(x => x.GetById(stubId)).Verifiable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var RentItemDtoModelStub = new RentItemDtoModel();
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);
            //Act 
            rentItemService.GetRentItemById(stubId);

            //Assert
            mockeRepository.Verify(x => x.GetById(stubId), Times.Once);
        }


        [Test]
        public void CallsRepositoryGetByIdOnceWithSameId()
        {
            //Arrange

            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();
            var stubId = Guid.NewGuid();
            mockeRepository.Setup(x => x.GetById(stubId)).Verifiable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var RentItemDtoModelStub = new RentItemDtoModel();
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);
            //Act 
            rentItemService.GetRentItemById(stubId);

            //Assert
            mockeRepository.Verify(x => x.GetById(It.Is<Guid>(y=>y==stubId)), Times.Once);
        }

        [Test]
        public void CallsMapperMapOnce()
        {
            //Arrange

            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();
            var stubId = Guid.NewGuid();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var RentItemDtoModelStub = new RentItem();
            mockedMapper.Setup(x => x.Map<RentItemDetaildDtoModel>(RentItemDtoModelStub)).Verifiable();
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);
            //Act 
            rentItemService.GetRentItemById(stubId);

            //Assert
            mockedMapper.Verify(x => x.Map<RentItemDetaildDtoModel>(It.IsAny<RentItem>()), Times.Once);
        }

        [Test]
        public void CallsMapperMapOnceWithSameObject()
        {
            //Arrange

            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();
            var stubId = Guid.NewGuid();
            var rentItemDtoModelStub = new RentItem();
            mockeRepository.Setup(x => x.GetById(stubId)).Returns(rentItemDtoModelStub);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            mockedMapper.Setup(x => x.Map<RentItemDetaildDtoModel>(rentItemDtoModelStub)).Verifiable();
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);
            //Act 
            rentItemService.GetRentItemById(stubId);

            //Assert
            mockedMapper.Verify(x => x.Map<RentItemDetaildDtoModel> (It.Is<RentItem>(y=>y.Equals(rentItemDtoModelStub))), Times.Once);
        }
    }
}
