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
    public class Constructor_Should
    {
        [Test]
        public void ReturnNewInstance()
        {
            //Arrange

            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var item = fixture.Create<Guid>();
            var description = "randomText";


            //Act
            var commet = new Comment(user, item, description);

            //Assert
            Assert.IsNotNull(commet);
        }

        [Test]
        public void ReturnNewInstance_OfComment()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var item = fixture.Create<Guid>();
            var description = "randomText";


            //Act
            var commet = new Comment(user, item, description);

            //Assert
            Assert.IsInstanceOf<Comment>(commet);
        }

        [Test]
        public void SetsUser()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var item = fixture.Create<Guid>();
            var description = "randomText";


            //Act
            var commet = new Comment(user, item, description);

            //Assert
            Assert.AreEqual(user,commet.UserId);
        }

        [Test]
        public void SetsItem()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var item = fixture.Create<Guid>();
            var description = "randomText";


            //Act
            var commet = new Comment(user, item, description);

            //Assert
            Assert.AreEqual(item, commet.ItemId);
        }

        [Test]
        public void SetsDescription()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var item = fixture.Create<Guid>();
            var description = "randomText";


            //Act
            var commet = new Comment(user, item, description);

            //Assert
            Assert.AreSame(description, commet.Description);
        }

        [Test]
        public void SetDate()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var item = fixture.Create<Guid>();
            var description = "randomText";


            //Act
            var commet = new Comment(user, item, description);

            //Assert
            Assert.NotNull(commet.Date);
        }
    }
}
