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

namespace Noleggio.Web.Tests.RentItemControlerTests
{
    [TestFixture]
    public class Get_Should
    {
        [Test]
        public void RenderRentItemView()
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedRentItemyService = new Mock<IRentItemService>();
            var categoryModel = new CategoryDtoModel()
            {
                ID = Guid.NewGuid(),
                Name = "FakeName"
            };
            var stubId = Guid.NewGuid();
            var stubModel = new RentItemDetaildDtoModel()
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
                Price = 10.2m,
                Category = new CategoryDtoModel(),
                Comments = new List<DtoModels.CommentsDto.CommentDtoModel>(),
                IsDeleted = false,
                Owner = "someOwner"
            };
            mockedRentItemyService.Setup(x => x.GetRentItemById(stubId)).Returns(stubModel);

            RentItemsController sut = new RentItemsController(mockedCategoryService.Object, mockedRentItemyService.Object);

            // Act & Assert
            sut
                .WithCallTo(c => c.Get(stubId))
                .ShouldRenderView("RentItem")
                .WithModel<RentItemsViewModelDetailed>(
                v =>
                {
                    Assert.AreEqual(stubModel.AvailableFrom, v.RentItem.AvailableFrom);
                    Assert.AreEqual(stubModel.AvailableTo, v.RentItem.AvailableTo);
                    Assert.AreEqual(stubModel.CategoryId, v.RentItem.CategoryId);
                    Assert.AreEqual(stubModel.Description, v.RentItem.Description);
                    Assert.AreEqual(stubModel.ItemId, v.RentItem.ItemId);
                    Assert.AreEqual(stubModel.Location, v.RentItem.Location);
                    Assert.AreEqual(stubModel.Name, v.RentItem.Name);
                    Assert.AreEqual(stubModel.OwnerId, v.RentItem.OwnerId);
                    Assert.AreEqual(stubModel.Price, v.RentItem.Price);
                    Assert.AreEqual(stubModel.Category, v.RentItem.Category);
                    Assert.AreEqual(stubModel.Comments, v.RentItem.Comments);
                    Assert.AreEqual(stubModel.IsDeleted, v.RentItem.IsDeleted);
                    Assert.AreEqual(stubModel.Owner, v.RentItem.Owner);

                });


        }

        [Test]
        public void CallRentItemsServiceGetRentItemById_Once()
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedRentItemyService = new Mock<IRentItemService>();
            var categoryModel = new CategoryDtoModel()
            {
                ID = Guid.NewGuid(),
                Name = "FakeName"
            };
            var stubId = Guid.NewGuid();
            var rentItemStub = new RentItemDetaildDtoModel();
            mockedRentItemyService.Setup(x => x.GetRentItemById(stubId)).Returns(rentItemStub);

            RentItemsController sut = new RentItemsController(mockedCategoryService.Object, mockedRentItemyService.Object);

            // Act 
            sut.WithCallTo(c => c.Get(stubId));

            //Assert
            mockedRentItemyService.Verify(x => x.GetRentItemById(stubId), Times.Once);
        }

        [Test]
        public void CallRentItemsServiceGetRentItemById_OnceWithSameId()
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedRentItemyService = new Mock<IRentItemService>();
            var categoryModel = new CategoryDtoModel()
            {
                ID = Guid.NewGuid(),
                Name = "FakeName"
            };
            var stubId = Guid.NewGuid();
            var rentItemStub = new RentItemDetaildDtoModel();
            mockedRentItemyService.Setup(x => x.GetRentItemById(stubId)).Returns(rentItemStub).Verifiable();

            RentItemsController sut = new RentItemsController(mockedCategoryService.Object, mockedRentItemyService.Object);

            // Act 
            sut.WithCallTo(c => c.Get(stubId));

            //Assert
            mockedRentItemyService.Verify(x => x.GetRentItemById(It.Is<Guid>(y=>y.Equals(stubId))), Times.Once);
        }

    }
}
