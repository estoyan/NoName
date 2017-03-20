using Moq;
using Noleggio.Common.Contracts;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using Noleggio.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Services.Tests.CategoryServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ReturnInstance()
        {
            //Arrange
            var mockedRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfwork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();

            //Act
            var service = new CategoryService(mockedRepository.Object, mockedUnitOfwork.Object, mockedMapper.Object);

            //Assert
            Assert.IsNotNull(service);
        }

        [Test]
        public void ReturnInstanceOfCategoryService()
        {
            //Arrange
            var mockedRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfwork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();

            //Act
            var service = new CategoryService(mockedRepository.Object, mockedUnitOfwork.Object, mockedMapper.Object);

            //Assert
            Assert.IsInstanceOf<CategoryService>(service);
        }


        [Test]
        public void ShouldThrowWhenMapperServiceIsNull()
        {
            //Arrange
            var mockedRepository = new Mock<IGenericEfRepository<Category>>();
            var mockedUnitOfwork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();

            //Act&Assert
           Assert.Throws<ArgumentNullException>(()=>new CategoryService(mockedRepository.Object, mockedUnitOfwork.Object, null));

        }
    }
}
