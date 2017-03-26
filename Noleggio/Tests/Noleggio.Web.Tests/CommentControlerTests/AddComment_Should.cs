//using Moq;
//using Noleggio.DtoModels.CommentsDto;
//using Noleggio.Services.Contracts;
//using Noleggio.Web.Controllers;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Security.Principal;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using TestStack.FluentMVCTesting;

//namespace Noleggio.Web.Tests.CommentControlerTests
//{
//    [TestFixture]
//    public class AddComment_Should
//    {
//        [Test]
//        public void CallCommentServiceOnceForCreationAndToGetAllComments()
//        {
//            //Arrange


//            var mockedService = new Mock<ICategoryService>();
//            var mockedCommentService = new Mock<ICommentService>();
//            mockedCommentService.Setup(x => x.AddCommnet(It.IsAny<CommentDtoModel>())).Verifiable();
//            var commentStub = "random comment";
//            var itemIdStub = Guid.NewGuid();
//            mockedCommentService.Setup(x => x.GetAll(itemIdStub)).Verifiable();
//            var sut = new CommentController(mockedService.Object, mockedCommentService.Object);

//            // Stub Identity

//            var guidStub = new string[] { Guid.NewGuid().ToString() };
//            HttpContext.Current.User = new GenericPrincipal(
//    new GenericIdentity("username"),
//    guidStub
//    );
//            //Act
//            sut.WithCallTo(x => x.AddComment(commentStub, itemIdStub));

//            //Assert
//            mockedCommentService.Verify(x => x.AddCommnet(It.IsAny<CommentDtoModel>()), Times.Once);
//            mockedCommentService.Verify(x => x.GetAll(itemIdStub), Times.Once);
//        }

//        [Test]
//        public void CallCommentServiceOnceForCreationAndToGetAllCommentsWithSameItemId()
//        {
//            //Arranve
//            var mockedService = new Mock<ICategoryService>();
//            var mockedCommentService = new Mock<ICommentService>();
//            mockedCommentService.Setup(x => x.AddCommnet(It.IsAny<CommentDtoModel>())).Verifiable();
//            var commentStub = "random comment";
//            var itemIdStub = Guid.NewGuid();
//            mockedCommentService.Setup(x => x.GetAll(itemIdStub)).Verifiable();
//            var sut = new CommentController(mockedService.Object, mockedCommentService.Object);


//            //Act
//            sut.WithCallTo(x => x.AddComment(commentStub, itemIdStub));

//            //Assert
//            mockedCommentService.Verify(x => x.AddCommnet(It.IsAny<CommentDtoModel>()), Times.Once);
//            mockedCommentService.Verify(x => x.GetAll(It.Is<Guid>(y => y == itemIdStub)), Times.Once);
//        }


//        [Test]
//        public void ShouldREturnCommetnPartialView()
//        {
//            //Arranve
//            var mockedService = new Mock<ICategoryService>();
//            var mockedCommentService = new Mock<ICommentService>();
//            var commentStub = "random comment";
//            var itemIdStub = Guid.NewGuid();
//            mockedCommentService.Setup(x => x.GetAll(itemIdStub)).Returns(new List<CommentDtoModel>());
//            var sut = new CommentController(mockedService.Object, mockedCommentService.Object);


//            //Act&Assert
//            sut.WithCallTo(x => x.AddComment(commentStub, itemIdStub))
//                .ShouldRenderPartialView("_CommentsPartial");
//        }

//        [Test]
//        public void ShouldREturnCommetnPartialViewWithExactModel()
//        {
//            //Arranve
//            var mockedService = new Mock<ICategoryService>();
//            var mockedCommentService = new Mock<ICommentService>();
//            var commentStub = "random comment";
//            var itemIdStub = Guid.NewGuid();
//            var commentDtoModelStub = new CommentDtoModel() { ItemId = itemIdStub, Description = commentStub, UserId = Guid.NewGuid(), Id = Guid.NewGuid() };
//            var resultStub = new List<CommentDtoModel>() { commentDtoModelStub };
//            mockedCommentService.Setup(x => x.GetAll(itemIdStub)).Returns(resultStub);
//            var sut = new CommentController(mockedService.Object, mockedCommentService.Object);


//            //Act&Assert
//            sut.WithCallTo(x => x.AddComment(commentStub, itemIdStub))
//                .ShouldRenderPartialView("_CommentsPartial")
//                .WithModel<List<CommentDtoModel>>(x =>
//                {
//                    Assert.AreEqual(commentDtoModelStub.Date, x.First().Date);
//                    Assert.AreEqual(commentDtoModelStub.Description, x.First().Description);
//                    Assert.AreEqual(commentDtoModelStub.Id, x.First().Id);
//                    Assert.AreEqual(commentDtoModelStub.ItemId, x.First().ItemId);
//                    Assert.AreEqual(commentDtoModelStub.UserId, x.First().UserId);
//                });
//        }
//    }
//}
