using Moq;
using Noleggio.Common.Contracts;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using Noleggio.DtoModels;
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
    public class Add_WithImages_Should
    {

        [Test]
        public void CallsREpostitoryAddOnceWithEmtpyImageList()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();
            mockeRepository.Setup(x => x.Add(It.IsAny<RentItem>())).Verifiable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);
            var emtptyImagesList = new List<ImagesDtoModel>();
            //Act 
            rentItemService.Add(new RentItemDtoModel(), emtptyImagesList);

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
            var emtptyImagesList = new List<ImagesDtoModel>();

            //Act 
            rentItemService.Add(new RentItemDtoModel(), emtptyImagesList);

            //Assert
            mockeRepository.Verify(x => x.Add(It.Is<RentItem>(y => y.Equals(rentItemStub))), Times.Once);
        }

        [Test]
        public void CallsREpostitoryAddWithCorrectRentItemWithAnImageInImageList()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();
            mockeRepository.Setup(x => x.Add(It.IsAny<RentItem>())).Verifiable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var rentItemStub = new RentItem();
            var imageStub = new Image();
            mockedMapper.Setup(x => x.Map<RentItem>(It.IsAny<RentItemDtoModel>())).Returns(rentItemStub);
            mockedMapper.Setup(x => x.Map<Image>(It.IsAny<ImagesDtoModel>())).Returns(imageStub);
            
            mockedMapper.Setup(x => x.Map<RentItem>(It.IsAny<RentItemDtoModel>())).Returns(rentItemStub);
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);
            var imagesListWithAnImage = new List<ImagesDtoModel>() { new ImagesDtoModel() };

            //Act 
            rentItemService.Add(new RentItemDtoModel(), imagesListWithAnImage);
            rentItemStub.Images.Add(imageStub);

            //Assert
            mockeRepository.Verify(x => x.Add(It.Is<RentItem>(y => y.Equals(rentItemStub))), Times.Once);
        }



        [Test]
        public void CallsUnitOfWork_CommitOnceWithEmtpyImageList()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();
           var mockedMapper = new Mock<IMapingService>();
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);
            var emtptyImagesList = new List<ImagesDtoModel>();

            //Act 
            rentItemService.Add(new RentItemDtoModel(), emtptyImagesList);

            //Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }


        [Test]
        public void CallsUnitOfWork_CommitOnceWithAnImageInImageList()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();
            var mockedMapper = new Mock<IMapingService>();
            mockedMapper.Setup(x => x.Map<RentItem>(It.IsAny<RentItemDtoModel>())).Returns(new RentItem());
            mockedMapper.Setup(x => x.Map<Image>(It.IsAny<ImagesDtoModel>())).Returns(new Image());
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);
            var imagesListWithAnImage = new List<ImagesDtoModel>() { new ImagesDtoModel() };

            //Act 
            rentItemService.Add(new RentItemDtoModel(), imagesListWithAnImage);

            //Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void CallsMapperMapOnceWithEmtpyImageList()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            mockedMapper.Setup(x => x.Map<RentItem>(It.IsAny<RentItemDtoModel>())).Verifiable();
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);
            var emtptyImagesList = new List<ImagesDtoModel>();

            //Act 
            rentItemService.Add(new RentItemDtoModel(), emtptyImagesList);

            //Assert
            mockedMapper.Verify(x => x.Map<RentItem>(It.IsAny<RentItemDtoModel>()), Times.Once);
        }
        [Test]
        public void CallsMapperMapTwiceWithOneImageInImageList()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            mockedMapper.Setup(x => x.Map<RentItem>(It.IsAny<RentItemDtoModel>())).Returns(new RentItem()).Verifiable();
            mockedMapper.Setup(x => x.Map<Image>(It.IsAny<ImagesDtoModel>())).Returns(new Image()).Verifiable();
            var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);
            var imagesListWithAnImage = new List<ImagesDtoModel>() { new ImagesDtoModel() };

            //Act 
            rentItemService.Add(new RentItemDtoModel(), imagesListWithAnImage);

            //Assert
            mockedMapper.Verify(x => x.Map<RentItem>(It.IsAny<RentItemDtoModel>()), Times.Once);
            mockedMapper.Verify(x => x.Map<Image>(It.IsAny<ImagesDtoModel>()), Times.Once);
        }


            //[Test]
            //TODO Check this test
            //public void CallsMapperMapOnceWithSameRentItemDtoModel()
            //{
            //    //Arrange
            //    var mockeRepository = new Mock<IGenericEfRepository<RentItem>>();

            //    var mockedUnitOfWork = new Mock<IUnitOfWork>();
            //    var mockedMapper = new Mock<IMapingService>();
            //    var RentItemDtoModelStub = new RentItemDtoModel();
            //    mockedMapper.Setup(x => x.Map<RentItem>(RentItemDtoModelStub)).Verifiable();
            //    var rentItemService = new RentItemService(mockeRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);
            //    var emtptyImagesList = new List<ImagesDtoModel>();

            //    //Act 
            //    rentItemService.Add(new RentItemDtoModel(), emtptyImagesList); ;

            //    //Assert

            //    mockedMapper.Verify(x => x.Map<RentItem>(It.Is<RentItemDtoModel>(y => y.Equals(RentItemDtoModelStub))), Times.Once);
            //}
        }
}
