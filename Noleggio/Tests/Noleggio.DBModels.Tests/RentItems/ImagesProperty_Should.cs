using Noleggio.DbModels;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;

namespace Noleggio.DBModels.Tests.RentItems
{
    [TestFixture]
    public class ImagesProperty_Should
    {
        [Test]
        public void ReturnsCollectionofImages()
        {
            //Arrange& Act
            var fixture = new Fixture();
            var user = fixture.Create<Guid>().ToString();
            var category = fixture.Create<Guid>();
            var desciption = "random string";
            var location = "random string";
            var sut = new RentItem(user, category, desciption, location);


            //Assert
            Assert.IsInstanceOf<ICollection<Image>>(sut.Images);
        }
    }
}
