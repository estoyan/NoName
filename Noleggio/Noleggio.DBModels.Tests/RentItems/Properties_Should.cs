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
   public class Properties_Should
    {

        [Test]
        public void ChangeDescription()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var item = new RentItem(user, category, desciption);
            var  newDescription = "new Descripion";

            //Act
            item.Description = newDescription;

            //Assert
            Assert.AreEqual(newDescription, item.Description);
        }

        [Test]
        public void SetImageLocation()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var item = new RentItem(user, category, desciption);
            var location = "new Location";

            //Act
            item.ImageLocation = location;

            //Assert
            Assert.AreEqual(location, item.ImageLocation);
        }

        [Test]
        public void AddLease()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var item = new RentItem(user, category, desciption);
            var lease    = new Lease();

            //Act
            item.Leases.Add(lease);

            //Assert
            Assert.AreEqual(1, item.Leases.Count());
        }

        [Test]
        public void AddLease_AndItIsSame()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var item = new RentItem(user, category, desciption);
            var lease = new Lease();

            //Act
            item.Leases.Add(lease);

            //Assert
            Assert.AreEqual(lease, item.Leases.FirstOrDefault());
        }

        [Test]
        public void AddComment()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var item = new RentItem(user, category, desciption);
            var comment = new Comment();

            //Act
            item.Comments.Add(comment);

            //Assert
            Assert.AreEqual(1, item.Comments.Count());
        }

        [Test]
        public void AddComment_AndItIsSame()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var item = new RentItem(user, category, desciption);
            var comment = new Comment();

            //Act
            item.Comments.Add(comment);

            //Assert
            Assert.AreEqual(comment, item.Comments.FirstOrDefault());
        }

        [Test]
        public void SetDeletedOnAndREturnSameValue()
        {

             //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var item = new RentItem(user, category, desciption);
            var comment = new Comment();
            var deletedOn = new DateTime();


            //Act
            item.DeletedOn = deletedOn;

            //Assert
            Assert.AreEqual(deletedOn, item.DeletedOn);

        }




        [Test]
        public void IsDeletedToTrue()
        {

            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var comment = new Comment();
            var item = new RentItem(user, category, desciption);


            //Act
            item.IsDeleted = true;
            //Assert
            Assert.AreEqual(true, item.IsDeleted);
        }

    }
}
