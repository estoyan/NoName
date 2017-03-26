using Moq;
using Noleggio.Services.Contracts;
using Noleggio.Web.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Web.Tests.BaseControlerTests
{
    [TestFixture]
   public  class Constructor_Should
    {
   
        [Test]
        public void RetunNewInstance()
        {
            //Arranve
            var mockedService = new Mock<ICategoryService>();

            //Act
            var sut = new BaseController(mockedService.Object);

            //Assert
            Assert.IsNotNull(sut);
        }


        [Test]
        public void ThrowWhenCategoryServiceNull()
        {
            //Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(()=> new BaseController(null));

        }
    }
}
