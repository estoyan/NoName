using Noleggio.DbModels;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.DBModels.Tests.CategoryTests
{
    [TestFixture]
    public class ItemsProperty_Should
    {

        [Test]
        public void AddNewRentItemToCollection()
        {
            //Arrange
            var fixture = new Fixture();
            var name = fixture.Create<string>().Substring(0, 10);
            var category = new Category(name);
            var item = new RentItem();

            //Act
            category.Items.Add(item);

            //Assert
            Assert.AreEqual(1,category.Items.Count);
        }

        [Test]
        public void AddNewRentItemToCollection_AndReturnsTheSame()
        {
            //Arrange
            var fixture = new Fixture();
            var name = fixture.Create<string>().Substring(0, 10);
            var category = new Category(name);
            var item = new RentItem();

            //Act
            category.Items.Add(item);

            //Assert
            Assert.AreEqual(item, category.Items.First());
        }
    }
}
