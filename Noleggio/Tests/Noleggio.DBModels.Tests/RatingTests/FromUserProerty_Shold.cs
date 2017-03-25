using Noleggio.DbModels;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.DBModels.Tests.RatingTests
{
    [TestFixture]
    public class FromUserProerty_Shold
    {
        [Test]
        public void SetGetCorectly ()
        {
            //Arrange
            var fixture = new Fixture();
            var fromUserIdMock = fixture.Create<Guid>();
            var toUserIdMock = fixture.Create<Guid>();
            var mockedRate = 2.0d;
            var userMock = new User();
            var sut = new Rating(fromUserIdMock, toUserIdMock, mockedRate);


            //Act 
            sut.FromUser = userMock;

            //Assert
            Assert.AreEqual(userMock, sut.FromUser);
        }

        
    }
}
