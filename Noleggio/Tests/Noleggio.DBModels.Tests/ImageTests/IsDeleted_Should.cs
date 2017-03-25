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
    public class IsDeleted_Should
    {
        [Test]
        public void ReturnFalseWhenItemIntialized()
        {
            //Arrange&Act
            var mockedLocation = "location";
            var sut = new Image(mockedLocation);

            //Assert
            Assert.AreEqual(false, sut.IsDeleted);
        }

        [Test]
        public void SetCorectly()
        {
            //Arrange
            var mockedLocation = "location";
            var sut = new Image(mockedLocation);

            //Act
            sut.IsDeleted = true;

            //Assert
            Assert.AreEqual(true, sut.IsDeleted);
        }
    }
}
