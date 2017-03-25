using Noleggio.DbModels;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.DBModels.Tests.LeaseTests
{
    [TestFixture]
    public class ItemProperty_Should
    {
        [Test]
        public void SetItemCorectly()
        {
            //Arrange
            var fixture = new Fixture();
            var itemId = fixture.Create<Guid>();
            var userId = fixture.Create<Guid>();
            var startDate = new DateTime(2017, 03, 11);
            var endDate = new DateTime(2017, 04, 11);
            var lease = new Lease(itemId, userId, startDate, endDate);
            var mockedItem = new RentItem();

            //Act
            lease.Item = mockedItem;

            //Assert
            Assert.AreEqual(mockedItem, lease.Item);
        }
    }
}
