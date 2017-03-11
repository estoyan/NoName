using Noleggio.Common;
using Noleggio.DbModels;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.DBModels.Tests.CommentsTests
{
    [TestFixture]
    public class PropertiesShould
    {
        [Test]
        public void Change_Description()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var item = fixture.Create<Guid>();
            var description = "randomText";
            var commet = new Comment(user, item, description);
            var newDescription = "newDescription";

            //Act
            commet.Description = newDescription;

            //Assert
            Assert.AreSame(newDescription, commet.Description);
        }

        [Test]
        public void Set_IsDeleted()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var item = fixture.Create<Guid>();
            var description = "randomText";
            var commet = new Comment(user, item, description);

            //Act
            commet.IsDeleted = true;

            //Assert
            Assert.AreEqual(true, commet.IsDeleted);
        }

        [Test]
        public void Set_DeltedOn()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var item = fixture.Create<Guid>();
            var description = "randomText";
            var commet = new Comment(user, item, description);
            var deletedDate = fixture.Create<DateTime>();

            //Act
            commet.DeletedOn = deletedDate;

            //Assert
            Assert.AreEqual(deletedDate, commet.DeletedOn);
        }

    }
}
