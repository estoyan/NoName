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

        //[Test]
        //public void CallsREpostitoryAddOnce()
        //{
        //    //Arrange
        //    var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();
        //    mockeRepository.Setup(x => x.Add(It.IsAny<RentItem>())).Verifiable();
        //    var mockedUnitOfWork = new Mock<IUnitOfWork>();
        //    var mockedMapper = new Mock<IMapingService>();
        //    var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

        //    //Act 
        //    rentItemService.Add(new RentItemDtoModel());

        //    //Assert
        //    mockeRepository.Verify(x => x.Add(It.IsAny<RentItem>()), Times.Once);
        //}

        //[Test]
        //public void CallsUnitOfWork_CommitOnce()
        //{
        //    //Arrange
        //    var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();

        //    var mockedUnitOfWork = new Mock<IUnitOfWork>();
        //    mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();
        //    var mockedMapper = new Mock<IMapingService>();
        //    var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

        //    //Act 
        //    rentItemService.Add(new RentItemDtoModel());

        //    //Assert
        //    mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        //}
    }
}
