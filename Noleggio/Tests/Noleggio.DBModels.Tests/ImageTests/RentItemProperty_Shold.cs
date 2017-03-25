using Noleggio.DbModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.DBModels.Tests.ImageTests
{
    [TestFixture]
    public class RentItemProperty_Shold
    {
        [Test]
        public void SetCorectly()
        {
            //Arrange
            var mockedLocation = "location";
            var mockedItem = new RentItem();
            var sut = new Image(mockedLocation);

            //Act
            sut.RentItem = mockedItem;

            //Assert
            Assert.AreEqual(mockedItem, sut.RentItem);
        }
    }
}
