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
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Noleggio.Web.Tests.HomeControlerTests
{
    [TestFixture]
    public class Index_Should
    {


        [Test]
        public void ReturnViewWithModelWithCorrectProperties()
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedRentItemyService = new Mock<IRentItemService>();
            var categoryModel = new CategoryDtoModel()
            {
                ID = Guid.NewGuid(),
                Name = "FakeName"
            };

            var mockedList = new List<CategoryDtoModel>() { categoryModel };
            mockedCategoryService.Setup(m => m.GetAllCategories()).Returns(mockedList);

            var stubRecentItems = new List<RentItemDtoModel>();
            var stubModel = new RentItemDtoModel
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
            stubRecentItems.Add(stubModel);
            mockedRentItemyService.Setup(x => x.Recent(10)).Returns(stubRecentItems);

            // Act & Assert
            HomeController homeController = new HomeController(mockedCategoryService.Object, mockedRentItemyService.Object);
            homeController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView()
                .WithModel<HomeViewModel>(
                v =>
                {
                    Assert.AreEqual(stubModel.AvailableFrom, v.RecentItems.First().AvailableFrom);
                    Assert.AreEqual(stubModel.AvailableTo, v.RecentItems.First().AvailableTo);
                    Assert.AreEqual(stubModel.CategoryId, v.RecentItems.First().CategoryId);
                    Assert.AreEqual(stubModel.Description, v.RecentItems.First().Description);
                    Assert.AreEqual(stubModel.ItemId, v.RecentItems.First().ItemId);
                    Assert.AreEqual(stubModel.Location, v.RecentItems.First().Location);
                    Assert.AreEqual(stubModel.Name, v.RecentItems.First().Name);
                    Assert.AreEqual(stubModel.OwnerId, v.RecentItems.First().OwnerId);
                    Assert.AreEqual(stubModel.Price, v.RecentItems.First().Price);
                }
                );
        }

        [Test]
        public void ReturnViewWithEmptyModel_WhenThereNoItems()
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedRentItemyService = new Mock<IRentItemService>();
            var categoryModel = new CategoryDtoModel()
            {
                ID = Guid.NewGuid(),
                Name = "FakeName"
            };

            var mockedList = new List<CategoryDtoModel>() { categoryModel };
            mockedCategoryService.Setup(m => m.GetAllCategories()).Returns(mockedList);

            var stubRecentItems = new List<RentItemDtoModel>();

            mockedRentItemyService.Setup(x => x.Recent(10)).Returns(stubRecentItems);
            HomeController homeController = new HomeController(mockedCategoryService.Object, mockedRentItemyService.Object);

            // Act & Assert
            homeController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView()
                .WithModel<HomeViewModel>(
                v =>
                {
                    Assert.IsEmpty(v.RecentItems);
                }
                );

        }
    }
}
