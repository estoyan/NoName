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
   public class Constructor_Should
    {
        [Test]
        public void ShuoldReturnNewIntance()
        {
            //Arrange
            var fixture = new Fixture();
            var fromUserMock = fixture.Create<Guid>();
            var toUserMock = fixture.Create<Guid>();
            var mockedRate = 2.0d;

            //Act 
            var sut = new Rating(fromUserMock, toUserMock, mockedRate);

            //Assert
            Assert.IsNotNull(sut);
        }

        [Test]
        public void ShuoldThrowWhenFromUserIsEmptyGuid()
        {
            //Arrange
            var fixture = new Fixture();
            var toUserMock = fixture.Create<Guid>();
            var mockedRate = 2.0d;

            //Act & Assert
           Assert.Throws<ArgumentException>(()=> new Rating(new Guid(), toUserMock, mockedRate));
        }

        [Test]
        public void ShuoldThrowWhenToUserIsEmptyGuid()
        {
            //Arrange
            var fixture = new Fixture();
            var fromUserMock = fixture.Create<Guid>();
            var mockedRate = 2.0d;

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new Rating( fromUserMock,new Guid(), mockedRate));
        }

        [Test]
        public void ShuoldThrowWhenBothUsersAreEmptyGuid()
        {
            //Arrange
            var fixture = new Fixture();
            var mockedRate = 2.0d;

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new Rating(new Guid(), new Guid(), mockedRate));
        }
    }
}
