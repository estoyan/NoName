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
    public class DeletedOnProerty_Shold
    {
        [Test]
        public void SetGetCorectly ()
        {
            //Arrange
            var fixture = new Fixture();
            var fromUserIdMock = fixture.Create<Guid>();
            var toUserIdMock = fixture.Create<Guid>();
            var mockedRate = 2.0d;
            var deltedOnMock = new DateTime(2017, 3,21);
            var sut = new Rating(fromUserIdMock, toUserIdMock, mockedRate);


            //Act 
            sut.DeletedOn = deltedOnMock;

            //Assert
            Assert.AreEqual(deltedOnMock, sut.DeletedOn);
        }

        
    }
}
