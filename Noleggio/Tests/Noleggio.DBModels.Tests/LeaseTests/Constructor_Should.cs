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
    public class Constructor_Should
    {
        [Test]
        public void ReturnNewInstance()
        {
            //Arrange
            var fixture = new Fixture();
            var item = fixture.Create<Guid>();
            var user = fixture.Create<Guid>();
            var startDate = new DateTime(2017, 03, 11);
            var endDate = new DateTime(2017,04,11);

            //Act 
            var lease = new Lease(item, user, startDate, endDate);

            //Assert
            Assert.IsNotNull(lease);
        }

        [Test]
        public void ReturnNewInstanceOfLease()
        {
            //Arrange
            var fixture = new Fixture();
            var item = fixture.Create<Guid>();
            var user = fixture.Create<Guid>();
            var startDate = new DateTime(2017, 03, 11);
            var endDate = new DateTime(2017, 04, 11);

            //Act 
            var lease = new Lease(item, user, startDate, endDate);

            //Assert
            Assert.IsInstanceOf<Lease>(lease);
        }

        [Test]
        public void SetIsDeletedToFalseAnd_ReturnsFalse()
        {
            //Arrange
            var fixture = new Fixture();
            var item = fixture.Create<Guid>();
            var user = fixture.Create<Guid>();
            var startDate = new DateTime(2017, 03, 11);
            var endDate = new DateTime(2017, 04, 11);

            //Act 
            var lease = new Lease(item, user, startDate, endDate);

            //Assert
            Assert.AreEqual(false, lease.IsDeleted);
        }

    }
}
