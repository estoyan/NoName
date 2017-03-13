using Noleggio.Common;
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
    public class PropertiesShould_Throw
    {
        [Test]
        public void WhenDescriptionIsNull()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var item = new RentItem(user, category, desciption);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => item.Description = null);
        }

        [Test]
        public void WhenDescriptionLongerThanCommentMaxLength()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var item = new RentItem(user, category, desciption);
            var description = new string('c', NoleggioConstants.CommentDescriptionMaxLength + 1);
            
            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => item.Description = description);
        }


        [Test]
        public void WhenImageLocationIsNull()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var item = new RentItem(user, category, desciption);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => item.ImageLocation = null);
        }

        [Test]
        public void WhenImageLocationIsLongerThanImagePathLength()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var item = new RentItem(user, category, desciption);
            var image = new string('c', NoleggioConstants.ImagePathLength + 1);

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => item.ImageLocation = image);
        }
    }
}
