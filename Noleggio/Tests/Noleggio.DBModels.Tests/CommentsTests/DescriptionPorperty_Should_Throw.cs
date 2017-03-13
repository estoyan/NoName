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
    public class DescriptionPorperty_Should_Throw
    {

        [Test]
        public void WhenDescriptionIsNull()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var item = fixture.Create<Guid>();
            var description = "randomText";
            var commet = new Comment(user, item, description);
            var deletedDate = fixture.Create<DateTime>();

            //Act&Assert
            Assert.Throws<ArgumentNullException>(() => commet.Description = null);
        }

        [Test]
        public void WhenDescriptionIsEmpty()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var item = fixture.Create<Guid>();
            var description = "randomText";
            var commet = new Comment(user, item, description);
            var deletedDate = fixture.Create<DateTime>();

            //Act&Assert
            Assert.Throws<ArgumentException>(() => commet.Description = "");
        }

        [Test]
        public void WhenDescriptionIsMoreThan_CommentDescriptionMaxLength()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var item = fixture.Create<Guid>();
            var description = "randomText";
            var commet = new Comment(user, item, description);
            var deletedDate = fixture.Create<DateTime>();
            var newDescription = new String('x',NoleggioConstants.CommentDescriptionMaxLength+1);

            //Act&Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => commet.Description = newDescription);
        }
    }
}
