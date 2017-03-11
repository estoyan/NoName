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
    public class ConstructorShould_Throw
    {
        [Test]
        public void WhenItemIsNUll()
        {
            //Arange
            var fixture = new Fixture();
            var user = fixture.Create<Guid>();
            var description = "randomText";

            //Act&assert
            Assert.Throws<ArgumentNullException>(() => new Comment(user, new Guid(), description));
        }

        [Test]
        public void WhenUserIsNull()
        {
            //Arange
            var fixture = new Fixture();
            var item = fixture.Create<Guid>();
            var description = "randomText";

            //Act&assert
            Assert.Throws<ArgumentNullException>(() => new Comment(new Guid(), item, description));
        }
    }
}
