﻿using Noleggio.DbModels;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.DBModels.Tests.RentItems
{
    [TestFixture]
    public class PriceProperty_Should
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
            decimal mockedPrice = 10.20M ;

            //Act
            sut.Price = mockedPrice;

            //Assert
            Assert.AreEqual(mockedPrice, sut.Price);
        }
    }
}
