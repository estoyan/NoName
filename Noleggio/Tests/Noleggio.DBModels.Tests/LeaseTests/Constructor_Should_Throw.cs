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
    public class Constructor_Should_Throw
    {
        [Test]
        public void WhenRentItemIsEmptyGuid()
        {
            //Arrange
            var fixture = new Fixture();
            var item = new Guid();
            var user = fixture.Create<Guid>();
            var startDate = new DateTime(2017, 03, 11);
            var endDate = new DateTime(2017, 04, 11);

            //Act &Assert
            Assert.Throws<ArgumentException>(()=> new Lease(item, user, startDate, endDate));
        }

        [Test]
        public void WhenUserIsEmptyGuid()
        {
            //Arrange
            var fixture = new Fixture();
            var item = fixture.Create<Guid>();
            var user = new Guid(); 
            var startDate = new DateTime(2017, 03, 11);
            var endDate = new DateTime(2017, 04, 11);

            //Act &Assert
            Assert.Throws<ArgumentException>(() => new Lease(item, user, startDate, endDate));
        }

        [Test]
        public void WhenEndDateIsBeforeStartDate()
        {
            //Arrange
            var fixture = new Fixture();
            var item = fixture.Create<Guid>();
            var user = fixture.Create<Guid>();
            var startDate = new DateTime(2017, 03, 11);
            var endDate = new DateTime(2017, 02, 11);

            //Act &Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Lease(item, user, startDate, endDate));
        }
    }
}
