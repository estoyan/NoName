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
//    public class Constructor_Should_SetProperties
//    {
//        [Test]
//        public void Initialize_Comments()
//        {
//            //Arange
//            var fixture = new Fixture();
//            var guid = fixture.Create<Guid>();
//            var randomString = fixture.Create<string>().Substring(0, 10);
//            var dateOfbirth = fixture.Create<DateTime>();

//            //Act
//            var user = new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, randomString);

//            //Assert
//            Assert.IsNotNull(user.Comments);
//        }

//        [Test]
//        public void Initialize_Leases()
//        {
//            //Arange
//            var fixture = new Fixture();
//            var guid = fixture.Create<Guid>();
//            var randomString = fixture.Create<string>().Substring(0, 10);
//            var dateOfbirth = fixture.Create<DateTime>();

//            //Act
//            var user = new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, randomString);

//            //Assert
//            Assert.IsNotNull(user.Leases);
//        }

//        [Test]
//        public void Initialize_RentItems()
//        {
//            //Arange
//            var fixture = new Fixture();
//            var guid = fixture.Create<Guid>();
//            var randomString = fixture.Create<string>().Substring(0, 10);
//            var dateOfbirth = fixture.Create<DateTime>();

//            //Act
//            var user = new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, randomString);

//            //Assert
//            Assert.IsNotNull(user.Items);
//        }

//        [Test]
//        public void Initialize_Ratings()
//        {
//            //Arange
//            var fixture = new Fixture();
//            var guid = fixture.Create<Guid>();
//            var randomString = fixture.Create<string>().Substring(0, 10);
//            var dateOfbirth = fixture.Create<DateTime>();

//            //Act
//            var user = new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, randomString);

//            //Assert
//            Assert.IsNotNull(user.Ratings);
//        }


//        [Test]
//        public void SetIsDeletedFalse()
//        {
//            //Arange
//            var fixture = new Fixture();
//            Guid guid = fixture.Create<Guid>();
//            var address = fixture.Create<string>().Substring(0, 10);
//            var randomString = fixture.Create<string>().Substring(0, 10);
//            var dateOfbirth = fixture.Create<DateTime>();
//            var rating = new Rating();

//            //Act 
//            var user = new User(guid, randomString, randomString, randomString, dateOfbirth, randomString, address);

//            //Assert
//            Assert.AreEqual(false, user.IsDeleted);
//        }
//    }
//}
