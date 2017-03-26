using Moq;
using Noleggio.DtoModels;
using Noleggio.Services.Contracts;
using Noleggio.Web.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Noleggio.Web.Tests.RentItemControlerTests
{
    [TestFixture]
  public  class Index_Should
    {
        [Test]
        public void ReturnsDefaultView()
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedRentItemyService = new Mock<IRentItemService>();
            var categoryModel = new CategoryDtoModel()
            {
                ID = Guid.NewGuid(),
                Name = "FakeName"
            };

            RentItemsController sut = new RentItemsController(mockedCategoryService.Object, mockedRentItemyService.Object);

            // Act & Assert
            sut
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
