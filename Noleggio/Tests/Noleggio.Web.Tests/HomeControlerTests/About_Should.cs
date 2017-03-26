using Moq;
using Noleggio.DtoModels;
using Noleggio.Services.Contracts;
using Noleggio.Web.Controllers;
using Noleggio.Web.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Noleggio.Web.Tests.HomeControlerTests
{
    [TestFixture]
    public class About_Should
    {

        [Test]
        public void ReturnViewWithModelWithViewBag_Messages()
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedRentItemyService = new Mock<IRentItemService>();
            var categoryModel = new CategoryDtoModel()
            {
                ID = Guid.NewGuid(),
                Name = "FakeName"
            };

            HomeController sut = new HomeController(mockedCategoryService.Object, mockedRentItemyService.Object);

            // Act & Assert
            sut
                .WithCallTo(c => c.About())
                .ShouldRenderDefaultView();
            Assert.IsNotNull(sut.ViewBag.Message);
        }

        [Test]
        public void ReturnViewWithModelWithViewBag_SameMessages()
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedRentItemyService = new Mock<IRentItemService>();
            var categoryModel = new CategoryDtoModel()
            {
                ID = Guid.NewGuid(),
                Name = "FakeName"
            };

            HomeController sut = new HomeController(mockedCategoryService.Object, mockedRentItemyService.Object);

            // Act & Assert
            sut
                .WithCallTo(c => c.About())
                .ShouldRenderDefaultView();
            Assert.AreEqual("Your application description page.",sut.ViewBag.Message);
        }
    }
}
