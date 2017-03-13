using Noleggio.Common;
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
    public class NamePropertyShould
    {
        [Test]
        public void ChangeName()
        {
            //Arrange
            var fixture = new Fixture();
            var name = fixture.Create<string>().Substring(0, 10);
            var category = new Category(name);
            var newName = "anyName";
            //Act
            category.Name = newName;

            //Assert
            Assert.AreEqual(newName,category.Name);
        }

        [Test]
        public void ShouldThrowWhenNameIsShorter()
        {
            //Arrange
            var fixture = new Fixture();
            var name = fixture.Create<string>().Substring(0, 10);
            var category = new Category(name);
            var shortName = "anyName";
            shortName = shortName.Substring(0, NoleggioConstants.CategoryNameMinLenght - 1);
            //Act&Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => category.Name = shortName);
        }

        [Test]
        public void ShouldThrowWhenNameIsLonger()
        {
            //Arrange
            var fixture = new Fixture();
            var name = fixture.Create<string>().Substring(0, 10);
            var category = new Category(name);
            var longname = "anyName_longenought_sdasjisdhaduaspiudaspudaspidusapiduaspijdhapidjaspiudaspiudpiasudapioudspiadusapiduaspisduaspiudaspioduapiduaspiduasp";
            longname = longname.Substring(0, NoleggioConstants.CategoryNameMaxLenght + 1);
            //Act&Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => category.Name = longname);
        }

    }
}
