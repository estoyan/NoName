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
    public class Constructor_Should
    {
        [Test]
        public void ReturnNewInstance()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>().ToString(); ;
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var location = "random string";

            //Act
            var item = new RentItem(user, category, desciption,location);

            //Assert
            Assert.IsNotNull(item);
        }

        [Test]
        public void ReturnNewInstanceOf_RentItem()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>().ToString(); ;
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var location = "random string";

            //Act
            var item = new RentItem(user, category, desciption,location);

            //Assert
            Assert.IsInstanceOf<RentItem>(item);
        }

        [Test]
        public void Initialize_LeaseCollection()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>().ToString(); ;
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var location = "random string";

            //Act
            var item = new RentItem(user, category, desciption,location);

            //Assert
            Assert.IsNotNull(item.Leases);
        }

        [Test]
        public void Initialize_CommentsCollection()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>().ToString(); ;
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var location = "random string";

            //Act
            var item = new RentItem(user, category, desciption,location);

            //Assert
            Assert.IsNotNull(item.Comments);
        }

        [Test]
        public void Sets_Owner()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>().ToString(); ;
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var location = "random string";

            //Act
            var item = new RentItem(user, category, desciption,location);

            //Assert
            Assert.AreEqual(user, item.OwnerId);
        }

        [Test]
        public void Sets_Category()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>().ToString(); ;
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var location = "random string";

            //Act
            var item = new RentItem(user, category, desciption,location);

            //Assert
            Assert.AreEqual(category, item.CategoryId);
        }

        [Test]
        public void Sets_Description()
        {
            //Arrange
             var fixture = new Fixture();
            var user = fixture.Create<Guid>().ToString(); ;
            var category = fixture.Create<Guid>();
            var desciption = "random string description";
            var location = "random string";

            //Act
            var item = new RentItem(user, category, desciption,location);

            //Assert
            Assert.AreEqual(desciption, item.Description);
        }

        [Test]
        public void Sets_Location()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>().ToString(); ;
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var location = "random string location";

            //Act
            var item = new RentItem(user, category, desciption, location);

            //Assert
            Assert.AreEqual(location, item.Location);
        }


        [Test]
        public void SetIsDeletedToFalseAnd_ReturnsFalse()
        {


            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>().ToString(); ;
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var location = "random string";


            //Act
            var item = new RentItem(user, category, desciption,location);

            //Assert
            Assert.AreEqual(false, item.IsDeleted);
        }
    }
}
