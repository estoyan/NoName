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
   public  class PropertiesShould
    {
        [Test]
        public void Set_IsDeleted()
        {

 
            //Arrange
            var fixture = new Fixture();
            var name = fixture.Create<string>().Substring(0, 10);
            var category = new Category(name);

            //Act
            category.IsDeleted = true;

            //Assert
            Assert.AreEqual(true, category.IsDeleted);
        }

        [Test]
        public void Set_DeltedOn()
        {
            //Arrange
            var fixture = new Fixture();
            var name = fixture.Create<string>().Substring(0, 10);
            var category = new Category(name);
            var deletedDate = new DateTime();

            //Act
            category.DeletedOn = deletedDate;

            //Assert
            Assert.AreEqual(deletedDate, category.DeletedOn);
        }
    }
}
