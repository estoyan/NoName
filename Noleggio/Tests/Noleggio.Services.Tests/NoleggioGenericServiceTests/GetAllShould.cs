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

        [Test]
        public void GetAllShouldThrowIfFilterIsull()
        {
            //Arrange
            var mockeRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => genericService.GetAll(null));

        }


        //[Test]
        //public void GetAllShouldThrowIfOrderIsull()
        //{
        //    //Arrange
        //    var mockeRepository = new Mock<IGenericEfRepository<Category>>();
        //    var mockedUnitOfWork = new Mock<IUnitOfWork>();
        //    var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);

        //    //Act & Assert
        //    Assert.Throws<ArgumentNullException>(() => genericService.GetAll(x=>x.IsDeleted,null,x=>x.Name.Contains("a")));

        //}

        //[Test]
        //public void GetAllWithFilterShouldCallRepositoryGetAllOnceWithSameFilter()
        //{
        //    //Arrange
        //    var expectedDudes = new[]
        //    {
        //        new Comment(), new Comment()
        //    };
        //    var mockeRepository = new Mock<IGenericEfRepository<Category>>();
        //    var mockedUnitOfWork = new Mock<IUnitOfWork>();
        //    var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
        //    mockeRepository.Setup(x => x.GetAll(y => y.Name == "Test")).Verifiable();

        //    //Act
        //    genericService.GetAll();

        //    //Assert
        //    mockeRepository.Verify(x => x.GetAll(y => y.Name == "Test"), Times.Once);
        //}

    }
}


//// arrange
//var expectedDudes = new[]
//{
//        new Dude(), new Dude()
//    };
//var mock = new Mock<IInterfaceToBeMocked>();
//mock.Setup(method => method.SearchDudeByFilter(
//        x => x.DudeId.Equals(10) && x.Ride.Equals("Harley"))
//    ).Returns(expectedDudes);

//// act
//// Remark: In a real unit test this call will be made implicitly
//// by the object under test that depends on the interface
//var actualDudes = mock.Object.SearchDudeByFilter(
//    x => x.DudeId.Equals(10) && x.Ride.Equals("Harley")
//);

//// assert
//Assert.AreEqual(actualDudes, expectedDudes);