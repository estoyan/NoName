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
   public  class RentItemProperty_Should
    {
        [Test]
        public void SetRentItem_Corectly()
        {
            //Arrange
            var mockedItem = new RentItem();
            var sut = new Comment();

            //Act
            sut.Item = mockedItem;

            //Assert
            Assert.AreEqual(mockedItem, sut.Item);
        }
    }
}
