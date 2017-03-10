using Noleggio.DbModels;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.DBModels.Tests.UserTests
{
    [TestFixture]
    public class Constructor_Should_Create_NewInstance
    {
        [Test]
        public void Create_NewInstance()
        {
            //Arange
            var fixture = new Fixture();
            var guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth=fixture.Create<DateTime>();

            //Act
            var user = new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, randomString);

            //Assert
            Assert.IsNotNull(user);
        }

        [Test]
        public void Create_NewInstance_OfUser()
        {
            //Arange
            var fixture = new Fixture();
            var guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth=fixture.Create<DateTime>();

            //Act
            var user = new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, randomString);

            //Assert
            Assert.AreEqual(typeof(User), user.GetType());
        }

       
    }
}
