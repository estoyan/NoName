using Moq;
using Noleggio.Common.Contracts;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using Noleggio.DtoModels;
using Noleggio.DtoModels.RentItems;
using NUnit.Framework;

namespace Noleggio.Services.Tests.RentItemServiceTests
{
    [TestFixture]
    public class AddShould
    {

        [Test]
        public void CallsREpostitoryAddOnce()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();
            mockeRepository.Setup(x => x.Add(It.IsAny<RentItem>())).Verifiable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

            //Act 
            rentItemService.Add(new RentItemDtoModel());

            //Assert
            mockeRepository.Verify(x => x.Add(It.IsAny<RentItem>()), Times.Once);
        }

        [Test]
        public void CallsREpostitoryAddWithCorrectRentItem()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();
            mockeRepository.Setup(x => x.Add(It.IsAny<RentItem>())).Verifiable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var rentItemStub = new RentItem();
            mockedMapper.Setup(x => x.Map<RentItem>(It.IsAny<RentItemDtoModel>())).Returns(rentItemStub);
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

            //Act 
            rentItemService.Add(new RentItemDtoModel());

            //Assert
            mockeRepository.Verify(x => x.Add(It.Is<RentItem>(y=>y.Equals(rentItemStub))), Times.Once);
        }



        [Test]
        public void CallsUnitOfWork_CommitOnce()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();
            var mockedMapper = new Mock<IMapingService>();
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

            //Act 
            rentItemService.Add(new RentItemDtoModel());

            //Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void CallsMapperMapOnce()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            mockedMapper.Setup(x => x.Map<RentItem>(It.IsAny<RentItemDtoModel>())).Verifiable();
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

            //Act 
            rentItemService.Add(new RentItemDtoModel());

            //Assert
            mockedMapper.Verify(x => x.Map<RentItem>(It.IsAny<RentItemDtoModel>()), Times.Once);
        }

        [Test]
        public void CallsMapperMapOnceWithSameRentItemDtoModel()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var RentItemDtoModelStub = new RentItemDtoModel();
            mockedMapper.Setup(x => x.Map<RentItem>(RentItemDtoModelStub)).Verifiable();
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

            //Act 
            rentItemService.Add(RentItemDtoModelStub);

            //Assert
            mockedMapper.Verify(x => x.Map<RentItem>(It.Is<RentItemDtoModel>(y=>y.Equals(RentItemDtoModelStub))), Times.Once);
        }
    }
}
