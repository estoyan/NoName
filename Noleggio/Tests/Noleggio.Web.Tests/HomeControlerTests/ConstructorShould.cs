using Moq;
using Noleggio.Services.Contracts;
using Noleggio.Web.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Web.Tests.HomeControlerTests
{
    [TestFixture]
   public  class ConstructorShould
    {
        [Test]
        public void RetunNewInstance()
        {
            //Arranve
            var mockedService = new Mock<ICategoryService>();
            var mockedRentItemService = new Mock<IRentItemService>();

            //Act
            var sut = new HomeController(mockedService.Object, mockedRentItemService.Object);

            //Assert
            Assert.IsNotNull(sut);
        }


        [Test]
        public void ThrowWhenRentItemServiceNull()
        {
            //Arrange 
            var mockedService = new Mock<ICategoryService>();
            //& Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HomeController(mockedService.Object, null));

        }
    }
}
