using Noleggio.DbModels;
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
    public class NameProperty_Should
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
            var item = new RentItem(user, category, desciption, location);
            var nameMocked = "new Descripion";

            //Act
            item.Name = nameMocked;

            //Assert
            Assert.AreEqual(nameMocked, item.Name);
        }
    }
}
