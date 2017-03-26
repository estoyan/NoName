using Moq;
using Noleggio.Services.Contracts;
using Noleggio.Web.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Web.Tests.CommentControlerTests
{
    [TestFixture]
    public class Contact_Should
    {

        [Test]
        public void RetunNewInstance()
        {
            //Arranve
            var mockedService = new Mock<ICategoryService>();
            var mockedRentItemService = new Mock<ICommentService>();

            //Act
            var sut = new CommentController(mockedService.Object, mockedRentItemService.Object);

            //Assert
            Assert.IsNotNull(sut);
        }


        [Test]
        public void ThrowWhenRentItemServiceNull()
        {
            //Arrange 
            var mockedService = new Mock<ICategoryService>();
            //& Act & Assert
            Assert.Throws<ArgumentNullException>(() => new RentItemsController(mockedService.Object, null));

        }
    }
}
