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



    }
}
