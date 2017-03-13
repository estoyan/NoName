//using Noleggio.DbModels;
//using NUnit.Framework;
//using Ploeh.AutoFixture;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Noleggio.DBModels.Tests.UserTests
//{
//    [TestFixture]
//    class ConstructorShould_Initialize_Collections
//    {
//        [Test]
//        public void Initializie_Comments()
//        {
//            //Arange
//            var fixture = new Fixture();
//            var guid = fixture.Create<Guid>();
//            var randomString = fixture.Create<string>().Substring(0, 10);
//            var dateOfbirth = fixture.Create<DateTime>();

//            //Act
//            var user = new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, randomString);

//            //Assert
//            Assert.NotNull(user.Comments);
//        }

//        [Test]
//        public void Initializie_Leases()
//        {
//            //Arange
//            var fixture = new Fixture();
//            var guid = fixture.Create<Guid>();
//            var randomString = fixture.Create<string>().Substring(0, 10);
//            var dateOfbirth=fixture.Create<DateTime>();

//            //Act
//            var user = new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, randomString);

//            //Assert
//            Assert.NotNull(user.Leases);
//        }

//        [Test]
//        public void Initializie_Items()
//        {
//            //Arange
//            var fixture = new Fixture();
//            var guid = fixture.Create<Guid>();
//            var randomString = fixture.Create<string>().Substring(0, 10);
//            var dateOfbirth=fixture.Create<DateTime>();

//            //Act
//            var user = new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, randomString);

//            //Assert
//            Assert.NotNull(user.Items);
//        }

//        [Test]
//        public void Initializie_Ratings()
//        {
//            //Arange
//            var fixture = new Fixture();
//            var guid = fixture.Create<Guid>();
//            var randomString = fixture.Create<string>().Substring(0, 10);
//            var dateOfbirth=fixture.Create<DateTime>();

//            //Act
//            var user = new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, randomString);

//            //Assert
//            Assert.NotNull(user.Ratings);
//        }

//        [Test]
//        public void Initializie_IsDeleted_AsFalse()
//        {
//            //Arange
//            var fixture = new Fixture();
//            var guid = fixture.Create<Guid>();
//            var randomString = fixture.Create<string>().Substring(0, 10);
//            var dateOfbirth=fixture.Create<DateTime>();

//            //Act
//            var user = new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, randomString);

//            //Assert
//            Assert.AreEqual(false, user.IsDeleted);
//        }
//    }
//}
