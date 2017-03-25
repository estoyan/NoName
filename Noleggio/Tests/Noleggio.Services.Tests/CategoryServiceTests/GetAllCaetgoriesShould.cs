using Moq;
using Noleggio.Common.Contracts;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using Noleggio.DtoModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Services.Tests.CategoryServiceTests
{
    [TestFixture]
    public class GetAllCaetgoriesShould
    {

        //[Test]
        //public void CallsRepositoryGetAllOnce()
        //{
            //    //Arrange
            //    var mockedRepository = new Mock<IGenericEfRepository<Category>>();
            //    mockedRepository.Setup(x => x.GetAll(y=> !y.IsDeleted)).Verifiable();
            //    var mockedResult = new List<Category>();
            //    mockedResult.Add(new Category());
            //    mockedRepository.Setup(x => x.GetAll(y => !y.IsDeleted)).Returns(mockedResult.AsQueryable());
            //    var mockedUnitOfwork = new Mock<IUnitOfWork>();
            //    var mockedMapper = new Mock<IMapingService>();
            //    var service = new CategoryService(mockedRepository.Object, mockedUnitOfwork.Object, mockedMapper.Object);

            //    //Act
            //    var result =service.GetAllCategories();
            //    //Assert
            //    mockedRepository.Verify(x => x.GetAll(y => !y.IsDeleted), Times.Once);
            //}

            //TODO Check this test 
            //[Test]
            //public void CallsMapperServiceOnce()
            //{
            //    //Arrange
            //    var mockedRepository = new Mock<IGenericEfRepository<Category>>();
            //    var mockedUnitOfwork = new Mock<IUnitOfWork>();
            //    var mockedMapper = new Mock<IMapingService>();
            //    var mockedResult = new List<Category>();
            //    mockedResult.Add(new Category());
            //    mockedRepository.Setup(x => x.GetAll(y => !y.IsDeleted)).Returns(mockedResult.AsQueryable());
            //    mockedMapper.Setup(x => x.Map<CategoryDtoModel>(mockedResult)).Verifiable();
            //    var service = new CategoryService(mockedRepository.Object, mockedUnitOfwork.Object, mockedMapper.Object);

            //    //Act
            //    var result = service.GetAllCategories();
            //    //Assert
            //    mockedMapper.Verify(x => x.Map<CategoryDtoModel>(mockedResult), Times.Once);
            //}
        }
}
