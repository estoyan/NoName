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
    public class Properties_Should
    {

        [Test]
        public void SetDeletedOnAndREturnSameValue()
        {

            //Arrange
            var fixture = new Fixture();
            var item = fixture.Create<Guid>();
            var user = fixture.Create<Guid>();
            var startDate = new DateTime(2017, 03, 11);
            var endDate = new DateTime(2017, 04, 11);
            var lease = new Lease(item, user, startDate, endDate);
            var deletedOn = new DateTime();


            //Act
            lease.DeletedOn = deletedOn;

            //Assert
            Assert.AreEqual(deletedOn, lease.DeletedOn);
        }




        [Test]
        public void IsDeletedToTrue()
        {

            //Arrange
            var fixture = new Fixture();
            var item = fixture.Create<Guid>();
            var user = fixture.Create<Guid>();
            var startDate = new DateTime(2017, 03, 11);
            var endDate = new DateTime(2017, 04, 11);
            var lease = new Lease(item, user, startDate, endDate);

            //Act
            lease.IsDeleted = true;
            //Assert
            Assert.AreEqual(true, lease.IsDeleted);
        }
    }
}
