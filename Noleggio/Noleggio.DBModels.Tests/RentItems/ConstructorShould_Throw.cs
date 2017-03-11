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
    public class ConstructorShould_Throw
    {

        [Test]
        public void WhenUserIsEmptyGuid()
        {
            //Arrange
            var fixture = new Fixture();
            var user = new Guid();
            var category = fixture.Create<Guid>();
            var desciption = "random string";

            //Act & Assert
           Assert.Throws<ArgumentException>(()=>new RentItem(user, category, desciption));
        }


        [Test]
        public void WhenCategoryIsEmptyGuid()
        {
            //Arrange
            var fixture = new Fixture();
            var category = new Guid();
            var user = fixture.Create<Guid>();
            var desciption = "random string";

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new RentItem(user, category, desciption));
        }
    }
    }
