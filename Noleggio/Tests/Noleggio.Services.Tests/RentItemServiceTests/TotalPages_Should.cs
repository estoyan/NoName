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
    public class TotalPages_Should
    {
        [Test]
        public void CallGetAllOnce()
        {
            //Arrange

            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();
            mockeRepository.Setup(x => x.GetAll()).Returns(new List<RentItem>().AsQueryable()). Verifiable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var RentItemDtoModelStub = new RentItemDtoModel();
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);
            //Act 
            rentItemService.TotalPages();

            //Assert
            mockeRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void ShouldRightTotalPages()
        {
            //TODO Ask Viktor how more precisly to test here!
           
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();
            var rentItemsStub = new List<RentItem>() { new RentItem(), new RentItem(), new RentItem() };
            mockeRepository.Setup(x => x.GetAll()).Returns(rentItemsStub.AsQueryable());
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var RentItemDtoModelStub = new RentItemDtoModel();
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);
            
            //Act & Asssert
            Assert.AreEqual(3,rentItemService.TotalPages());

            
        }
    }
}
