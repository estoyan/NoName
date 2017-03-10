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
    class Constructor_Should_Throw
    {
        [Test]
        public void Argument_When_AspNetUserId_IsEmpty()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = Guid.Empty;
            var randomString = fixture.Create<string>();
            var age = 42;

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new User(guid, randomString, randomString, randomString, age, randomString, randomString));
        }

        [Test]
        public void NullArgument_When_Email_IsNull()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>();
            var age = 42;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new User(guid, null, randomString, randomString, age, randomString, randomString));
        }

        [Test]
        public void NullArgument_When_Email_IsEmpty()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>();
            var age = 42;

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new User(guid, "", randomString, randomString, age, randomString, randomString));
        }

        [Test]
        public void NullArgument_When_FirstName_IsNull()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>();
            var age = 42;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new User(guid,  randomString, null, randomString, age, randomString, randomString));
        }

        [Test]
        public void NullArgument_When_FirstName_IsEmpty()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>();
            var age = 42;

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new User(guid,  randomString, "", randomString, age, randomString, randomString));
        }

        [Test]
        public void NullArgument_When_LastName_IsNull()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>();
            var age = 42;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new User(guid, randomString,  randomString, null, age, randomString, randomString));
        }

        [Test]
        public void NullArgument_When_LastName_IsEmpty()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>();
            var age = 42;

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new User(guid, randomString, randomString, "", age, randomString, randomString));
        }

        [Test]
        [TestCase(12)]
        [TestCase(17)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Argument_When_Age_IsLessThan_18(int age)
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>();

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new User(guid, randomString, randomString, randomString, age, randomString, randomString));
        }

        //[TestCase(0)]
        //public void Argument_WithCorrectMessage_When_Age_IsLessThan_18(int age)
        //{
        //    //Arange
        //    var fixture = new Fixture();
        //    Guid guid = fixture.Create<Guid>();
        //    var randomString = fixture.Create<string>();

        //    //Act 
        //    var ex= new User(guid, randomString, randomString, randomString, age, randomString, randomString)
        //    //Assert
        //    Assert.AreEqual(ExceptionMiminumAgeMessage,
        //}
    }
}
