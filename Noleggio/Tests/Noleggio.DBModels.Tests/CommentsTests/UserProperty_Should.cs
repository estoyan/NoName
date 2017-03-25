using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Noleggio.DbModels;

namespace Noleggio.DBModels.Tests.CommentsTests
{
    [TestFixture]
   public  class UserPorperty_Should
    {
        [Test]
        public void SetUser_Corectly()
        {
            //Arrange
            var mockedUser = new User();
            var sut = new Comment();

            //Act
            sut.User = mockedUser;

            //Assert
            Assert.AreEqual(mockedUser, sut.User);
        }
    }
}
