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
    public class DeletedOn_Should
    {
        [Test]
        public void SetCorectly()
        {
            //Arrange
            var mockedLocation = "location";
            var mockedDate = new DateTime(2017, 03, 21);
            var sut = new Image(mockedLocation);

            //Act
            sut.DeletedOn = mockedDate;

            //Assert
            Assert.AreEqual(mockedDate, sut.DeletedOn);
        }
    }
}
