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
    public class Properties_Should_SetGet
    {
        [Test]
        public void Id_Correct()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = Guid.Empty;
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act 
            var user= new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, randomString);

            //Assert
            Assert.AreEqual(guid, user.Id);
        }

        [Test]
        public void UserName_Correct()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = Guid.Empty;
            var email = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act 
            var user = new User(guid, email, randomString, randomString, dateOfbirth, randomString, randomString);

            //Assert
            Assert.AreEqual(email, user.Username);
        }

        [Test]
        public void FirstName_Correct()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = Guid.Empty;
            var firstName = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act 
            var user = new User(guid, randomString, firstName, randomString, dateOfbirth, randomString, randomString);

            //Assert
            Assert.AreEqual(firstName, user.FirstName);
        }

        [Test]
        public void LastName_Correct()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = Guid.Empty;
            var lastName = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act 
            var user = new User(guid, randomString, randomString, lastName, dateOfbirth, randomString, randomString);

            //Assert
            Assert.AreEqual(lastName, user.LastName);
        }

        [Test]
        public void DateOfBirth_Correct()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = Guid.Empty;
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act 
            var user = new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, randomString);

            //Assert
            Assert.AreEqual(dateOfbirth, user.DateOfBirth);
        }

        [Test]
        public void City_Correct()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = Guid.Empty;
            var city = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act 
            var user = new User(guid, randomString, randomString, randomString, dateOfbirth, city, randomString);

            //Assert
            Assert.AreEqual(city, user.City);
        }

        [Test]
        public void Address_Correct()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = Guid.Empty;
            var address = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act 
            var user = new User(guid, randomString, randomString, randomString, dateOfbirth,  randomString, address);

            //Assert
            Assert.AreEqual(address, user.Address);
        }
        //TODO add test for Age
        //[Test]
        //public void Age_Calls_Calulator.Age()
        //{
        //    //Arange
        //    var fixture = new Fixture();
        //    Guid guid = Guid.Empty;
        //    var address = fixture.Create<string>().Substring(0, 10);
        //    var randomString = fixture.Create<string>().Substring(0, 10);
        //    var dateOfbirth = fixture.Create<DateTime>();
        //    var user = new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, address);
        //    var mockCalulator
        //    //Act & Assert


        //}
    }
}
