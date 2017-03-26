using Moq;
using Noleggio.DtoModels;
using Noleggio.Services.Contracts;
using Noleggio.Web.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;
using System.Web.Mvc;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noleggio.Web.Tests.BaseControlerTests.Mocks;

namespace Noleggio.Web.Tests.BaseControlerTests
{
    [TestFixture]
    public class BeginExecute_Should
    {

        //[Test]
        //public void ReturnViewWithModelWithCorrectProperties()
        //{
        //    // Arrange
        //    var mockedService = new Mock<ICategoryService>();
        //    var categoryModel = new CategoryDtoModel()
        //    {
        //        ID = Guid.NewGuid(),
        //        Name = "FakeName"
        //    };
        //    var mockedList = new List<CategoryDtoModel>() { categoryModel };

        //    mockedService.Setup(m => m.GetAllCategories()).Returns(mockedList);

        //    // Act
        //    BaseController baseController = new StubController(mockedService.Object);
        //    //Assert

        //    Assert.NotNull(baseController.ViewBag.MainCategories);


        //}
    }
}
