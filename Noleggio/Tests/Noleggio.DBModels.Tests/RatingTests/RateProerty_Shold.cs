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
    public class RateProerty_Shold
    {
        [Test]
        [TestCase(4.5)]
        [TestCase(0.5)]
        [TestCase(5)]
        [TestCase(0)]
        [TestCase(1)]
        public void SetGetCorectly (double rate)
        {
            //Arrange
            var fixture = new Fixture();
            var fromUserMock = fixture.Create<Guid>();
            var toUserMock = fixture.Create<Guid>();
            var mockedRate = 2.0d;
            var sut = new Rating(fromUserMock, toUserMock, mockedRate);

            //Act 
            sut.Rate =rate;

            //Assert
            Assert.AreEqual(rate, sut.Rate);
        }


        [Test]
        [TestCase(-1)]
        [TestCase(-0.5)]
        [TestCase(5.5)]
        [TestCase(10)]
        public void ThrowsWhenOutsideLimits(double rate)
        {
            //Arrange
            var fixture = new Fixture();
            var fromUserMock = fixture.Create<Guid>();
            var toUserMock = fixture.Create<Guid>();
            var mockedRate = 2.0d;
            var sut = new Rating(fromUserMock, toUserMock, mockedRate);

            //Act &Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=> sut.Rate = rate);
        }
    }
}
