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
    public class Constructor_Should
    {

        [Test]
        public void ReturnNewInstance()
        {
            //Arrange & Act
            var sut = new Image();
            
            //Assert
            Assert.IsNotNull(sut);

        }
        [Test]
        public void SetLocation()
        {
            //Arrange & Act
            var mockedLocation = "location";
            var sut = new Image(mockedLocation);
            //Assert
            Assert.AreEqual(mockedLocation, sut.Location);
            
        }
        [Test]

        public void ThrowIfLocatonIsNullOrEmpty()
        {
            //Arrange&Act&Assert
            Assert.Throws<ArgumentNullException>(() => new Image(null));
            
        }
    }
}
