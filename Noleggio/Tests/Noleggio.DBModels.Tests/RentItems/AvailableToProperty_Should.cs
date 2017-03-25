using Noleggio.DbModels;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System;

namespace Noleggio.DBModels.Tests.RentItems
{
    [TestFixture]
    public class AvailableToProperty_Should
    {
        [Test]
        public void SetAndGetCorectly()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>().ToString();
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var location = "random string";
            var sut = new RentItem(user, category, desciption, location);
            var mockedAvailableTo = new DateTime(2017, 03, 20);

            //Act
            sut.AvailableTo = mockedAvailableTo;

            //Assert
            Assert.AreEqual(mockedAvailableTo, sut.AvailableTo);
        }
    }
}
