using Noleggio.DbModels;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System;
using Noleggio.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.DBModels.Tests.UserTests
{
    [TestFixture]
    class Constructor_Should_Throw
    {
        [Test]
        public void Argument_When_AspNetUserId_IsEmpty()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = Guid.Empty;
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth=fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, randomString));
        }

        [Test]
        public void NullArgument_When_Email_IsNull()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth=fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new User(guid, null, randomString, randomString, dateOfbirth, randomString, randomString));
        }

        [Test]
        public void NullArgument_When_Email_IsEmpty()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth=fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new User(guid, "", randomString, randomString, dateOfbirth, randomString, randomString));
        }

        [Test]
        public void NullArgument_When_FirstName_IsNull()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth=fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new User(guid,  randomString, null, randomString, dateOfbirth, randomString, randomString));
        }

        [Test]
        public void NullArgument_When_FirstName_IsEmpty()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth=fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new User(guid,  randomString, "", randomString, dateOfbirth, randomString, randomString));
        }

        [Test]
        public void ArgumentException_When_FirstName_IsShorter()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var firstName = fixture.Create<string>().Substring(0, Constants.UserClassMinimumStringLenght-1);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new User(guid, randomString, firstName, randomString, dateOfbirth, randomString, randomString));
        }

        [Test]
        public void ArgumentException_When_FirstName_IsLonger()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var firstName = fixture.Create<string>().Substring(0, Constants.UserFirstNameMaximumLenght + 1);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new User(guid, randomString, firstName, randomString, dateOfbirth, randomString, randomString));
        }

        [Test]
        public void NullArgument_When_LastName_IsNull()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth=fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new User(guid, randomString,  randomString, null, dateOfbirth, randomString, randomString));
        }

        [Test]
        public void NullArgument_When_LastName_IsEmpty()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth=fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new User(guid, randomString, randomString, "", dateOfbirth, randomString, randomString));
        }

        [Test]
        public void NullArgument_When_LastName_IsShorter()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var lastName = fixture.Create<string>().Substring(0, Constants.UserClassMinimumStringLenght-1);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new User(guid, randomString, randomString, lastName, dateOfbirth, randomString, randomString));
        }

        [Test]
        public void NullArgument_When_LastName_IsLonger()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0,10);
            var lastName = fixture.Create<string>().Substring(0, Constants.UserLastNameMaximumLenght+1);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new User(guid, randomString, randomString, lastName, dateOfbirth, randomString, randomString));
        }


        [Test]
        public void NullArgument_When_City_IsNull()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new User(guid, randomString, randomString, randomString, dateOfbirth,null, randomString));
        }

        [Test]
        public void NullArgument_When_City_IsEmpty()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new User(guid, randomString, randomString, randomString, dateOfbirth, "", randomString));
        }

        [Test]
        public void NullArgument_When_City_IsShorter()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var city= fixture.Create<string>().Substring(0, Constants.UserClassMinimumStringLenght-1);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new User(guid, randomString, randomString, randomString, dateOfbirth, city, randomString));
        }

        [Test]
        public void NullArgument_When_City_IsLonger()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var city = fixture.Create<string>().Substring(0, Constants.UserCityMaximumLength + 1);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new User(guid, randomString, randomString, randomString, dateOfbirth, city, randomString));
        }


        [Test]
        public void NullArgument_When_Address_IsNull()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new User(guid, randomString, randomString, randomString, dateOfbirth,  randomString, null));
        }

        [Test]
        public void NullArgument_When_Address_IsEmpty()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new User(guid, randomString, randomString, randomString, dateOfbirth,  randomString, ""));
        }

        [Test]
        public void NullArgument_When_Address_IsShorter()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var address = fixture.Create<string>().Substring(0, Constants.UserClassMinimumStringLenght - 1);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new User(guid, randomString, randomString, randomString, dateOfbirth, randomString,address));
        }

        [Test]
        public void NullArgument_When_Address_IsLonger()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var address = fixture.Create<string>().Substring(0, Constants.UserAddressMaximumLength + 1);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, address));
        }



    }
}
