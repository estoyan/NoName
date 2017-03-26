using Moq;
using Noleggio.DtoModels;
using Noleggio.DtoModels.RentItems;
using Noleggio.Services.Contracts;
using Noleggio.Web.Controllers;
using Noleggio.Web.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;


namespace Noleggio.Web.Tests.RentItemControlerTests
{
    [TestFixture]
    public class SearchShould
    {

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(5)]
        public void RenderRentItemView(int id)
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedRentItemyService = new Mock<IRentItemService>();
            var searchViewModelStub = new SearchViewModel()
            {
                CategoryId = Guid.NewGuid(),
                StartDate = new DateTime(2017, 03, 20),
                EndDate = new DateTime(2017, 03, 26),
                Filter = "someFilter",
                LoginView = new LoginViewModel()
            };

            var homeViewModelStub = new HomeViewModel()
            {
                Search = searchViewModelStub
            };

            var stubReturnModel = new RentItemDtoModel
            {
                AvailableFrom = new DateTime(2017, 03, 26),
                AvailableTo = new DateTime(2017, 04, 26),
                CategoryId = Guid.NewGuid().ToString(),
                Description = "test description",
                Images = new List<ImagesDtoModel>(),
                ItemId = Guid.NewGuid().ToString(),
                Location = "SomeLocation",
                Name = "FakeName",
                OwnerId = Guid.NewGuid().ToString(),
                Price = 10.2m

            };

            var mockedViewModel = new List<RentItemDtoModel>() { stubReturnModel };
            mockedRentItemyService.Setup(x => x.GetRentItems(searchViewModelStub.StartDate,
                searchViewModelStub.EndDate,
                searchViewModelStub.CategoryId,
                searchViewModelStub.Filter, id - 1)).Returns(mockedViewModel);

            RentItemsController sut = new RentItemsController(mockedCategoryService.Object, mockedRentItemyService.Object);
   
            //sut.ControllerContext.
            // Act & Assert
            sut
                .WithCallTo(c => c.Search(homeViewModelStub, id))
                .ShouldRenderPartialView("_RentItemsPartialView")
                .WithModel<List<RentItemDtoModel>>(
                v =>
                {
                    Assert.AreEqual(stubReturnModel.AvailableFrom, v.First().AvailableFrom);
                    Assert.AreEqual(stubReturnModel.AvailableTo, v.First().AvailableTo);
                    Assert.AreEqual(stubReturnModel.CategoryId, v.First().CategoryId);
                    Assert.AreEqual(stubReturnModel.Description, v.First().Description);
                    Assert.AreEqual(stubReturnModel.ItemId, v.First().ItemId);
                    Assert.AreEqual(stubReturnModel.Location, v.First().Location);
                    Assert.AreEqual(stubReturnModel.Name, v.First().Name);
                    Assert.AreEqual(stubReturnModel.OwnerId, v.First().OwnerId);
                    Assert.AreEqual(stubReturnModel.Price, v.First().Price);

                });


        }
        public void RenderRentItemViewWithEmtyModelIfNotItemsFound()
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedRentItemyService = new Mock<IRentItemService>();
            var searchViewModelStub = new SearchViewModel()
            {
                CategoryId = Guid.NewGuid(),
                StartDate = new DateTime(2017, 03, 20),
                EndDate = new DateTime(2017, 03, 26),
                Filter = "someFilter",
                LoginView = new LoginViewModel()
            };

            var homeViewModelStub = new HomeViewModel()
            {
                Search = searchViewModelStub
            };


            var mockedViewModel = new List<RentItemDtoModel>();
            mockedRentItemyService.Setup(x => x.GetRentItems(searchViewModelStub.StartDate,
                searchViewModelStub.EndDate,
                searchViewModelStub.CategoryId,
                searchViewModelStub.Filter, 1)).Returns(mockedViewModel);

            RentItemsController sut = new RentItemsController(mockedCategoryService.Object, mockedRentItemyService.Object);

            // Act & Assert
            sut
                .WithCallTo(c => c.Search(homeViewModelStub, null))
                .ShouldRenderPartialView("_RentItemsPartialView")
                .WithModel<List<RentItemDtoModel>>(
                v =>
                {
                    Assert.AreEqual(0, v.Count);
                });


        }

        [Test]
        public void RenderRentItemViewAndFillTempData()
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedRentItemyService = new Mock<IRentItemService>();
            var searchViewModelStub = new SearchViewModel()
            {
                CategoryId = Guid.NewGuid(),
                StartDate = new DateTime(2017, 03, 20),
                EndDate = new DateTime(2017, 03, 26),
                Filter = "someFilter",
                LoginView = new LoginViewModel()
            };

            var homeViewModelStub = new HomeViewModel()
            {
                Search = searchViewModelStub
            };

            var stubReturnModel = new RentItemDtoModel();
            var mockedViewModel = new List<RentItemDtoModel>() { stubReturnModel };
            mockedRentItemyService.Setup(x => x.GetRentItems(searchViewModelStub.StartDate,
                searchViewModelStub.EndDate,
                searchViewModelStub.CategoryId,
                searchViewModelStub.Filter, 0)).Returns(mockedViewModel);

            RentItemsController sut = new RentItemsController(mockedCategoryService.Object, mockedRentItemyService.Object);

            // Act & Assert
            sut.WithCallTo(c => c.Search(homeViewModelStub, null));
            Assert.IsNotNull(sut.TempData["model"]);
        }

        [Test]
        public void RenderRentItemViewAndFillTempDataAndPreservsItAfterThreeCalls()
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedRentItemyService = new Mock<IRentItemService>();
            var searchViewModelStub = new SearchViewModel()
            {
                CategoryId = Guid.NewGuid(),
                StartDate = new DateTime(2017, 03, 20),
                EndDate = new DateTime(2017, 03, 26),
                Filter = "someFilter",
                LoginView = new LoginViewModel()
            };

            var homeViewModelStub = new HomeViewModel()
            {
                Search = searchViewModelStub
            };

            var stubReturnModel = new RentItemDtoModel();
            var mockedViewModel = new List<RentItemDtoModel>() { stubReturnModel };
            mockedRentItemyService.Setup(x => x.GetRentItems(searchViewModelStub.StartDate,
                searchViewModelStub.EndDate,
                searchViewModelStub.CategoryId,
                searchViewModelStub.Filter, 0)).Returns(mockedViewModel);

            RentItemsController sut = new RentItemsController(mockedCategoryService.Object, mockedRentItemyService.Object);

            // Act & Assert 
            sut.WithCallTo(c => c.Search(homeViewModelStub, null));
            Assert.IsNotNull(sut.TempData["model"]);
            sut.WithCallTo(c => c.Search(homeViewModelStub, null));
            Assert.IsNotNull(sut.TempData["model"]);
            sut.WithCallTo(c => c.Search(homeViewModelStub, null));
            Assert.IsNotNull(sut.TempData["model"]);
        }
    }
}
