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
        //[Test]
        //public void Id_Correct()
        //{
        //    //Arange
        //    var fixture = new Fixture();
        //    Guid guid = fixture.Create<Guid>();
        //    var randomString = fixture.Create<string>().Substring(0, 10);
        //    var dateOfbirth = fixture.Create<DateTime>();

        //    //Act 
        //    var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, randomString);

        //    //Assert
        //    Assert.AreEqual( user.Id);
        //}

        //[Test]
        //public void UserName_Correct()
        //{
        //    //Arange
        //    var fixture = new Fixture();
        //    Guid guid = fixture.Create<Guid>();
        //    var email = fixture.Create<string>().Substring(0, 10);
        //    var randomString = fixture.Create<string>().Substring(0, 10);
        //    var dateOfbirth = fixture.Create<DateTime>();

        //    //Act 
        //    var user = new User( email, randomString, randomString, dateOfbirth, randomString, randomString);

        //    //Assert
        //    Assert.AreEqual(email, user.Username);
        //}

        [Test]
        public void FirstName_Correct()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var firstName = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act 
            var user = new User( randomString, firstName, randomString, dateOfbirth, randomString, randomString);

            //Assert
            Assert.AreEqual(firstName, user.FirstName);
        }

        [Test]
        public void LastName_Correct()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var lastName = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act 
            var user = new User( randomString, randomString, lastName, dateOfbirth, randomString, randomString);

            //Assert
            Assert.AreEqual(lastName, user.LastName);
        }

        [Test]
        public void DateOfBirth_Correct()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act 
            var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, randomString);

            //Assert
            Assert.AreEqual(dateOfbirth, user.DateOfBirth);
        }

        [Test]
        public void City_Correct()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var city = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act 
            var user = new User( randomString, randomString, randomString, dateOfbirth, city, randomString);

            //Assert
            Assert.AreEqual(city, user.City);
        }

        [Test]
        public void Address_Correct()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var address = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();

            //Act 
            var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, address);

            //Assert
            Assert.AreEqual(address, user.Address);
        }
        //TODO add test for Age
        //[Test]
        //public void Age_Calls_Calulator.Age()
        //{
        //    //Arange
        //    var fixture = new Fixture();
        //    Guid guid = fixture.Create<Guid>();
        //    var address = fixture.Create<string>().Substring(0, 10);
        //    var randomString = fixture.Create<string>().Substring(0, 10);
        //    var dateOfbirth = fixture.Create<DateTime>();
        //    var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, address);
        //    var mockCalulator
        //    //Act & Assert


        //}

        [Test]
        public void LeasesAndItShouldHaveOnlyOneLease()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var address = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();
            var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, address);
            var lease = new Lease();

            //Act 
            user.Leases.Add(lease);

            //Assert
            Assert.AreEqual(1, user.Leases.Count);
        }


        [Test]
        public void LeasesAndItShouldHaveTheSameLease()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var address = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();
            var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, address);
            var lease = new Lease();

            //Act 
            user.Leases.Add(lease);

            //Assert
            Assert.AreEqual(lease, user.Leases.FirstOrDefault());
        }

        [Test]
        public void CommentsAndItShouldHaveOnlyOneComment()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var address = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();
            var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, address);
            var comment = new Comment();

            //Act 
            user.Comments.Add(comment);

            //Assert
            Assert.AreEqual(1, user.Comments.Count);
        }


        [Test]
        public void CommentsAndItShouldHaveTheSameComment()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var address = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();
            var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, address);
            var comment = new Comment();

            //Act 
            user.Comments.Add(comment);

            //Assert
            Assert.AreEqual(comment, user.Comments.FirstOrDefault());
        }


        [Test]
        public void ItemsAndItShouldHaveOnlyOneRentItem()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var address = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();
            var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, address);
            var item = new RentItem();

            //Act 
            user.Items.Add(item);

            //Assert
            Assert.AreEqual(1, user.Items.Count);
        }


        [Test]
        public void ItemsAndItShouldHaveTheSameItem()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var address = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();
            var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, address);
            var item = new RentItem();

            //Act 
            user.Items.Add(item);

            //Assert
            Assert.AreEqual(item, user.Items.FirstOrDefault());
        }

        [Test]
        public void RatingsAndItShouldHaveOnlyOneRating()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var address = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();
            var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, address);
            var rating = new Rating();

            //Act 
            user.Ratings.Add(rating);

            //Assert
            Assert.AreEqual(1, user.Ratings.Count);
        }


        [Test]
        public void RatingsAndItShouldHaveTheSameRating()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var address = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();
            var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, address);
            var rating = new Rating();

            //Act 
            user.Ratings.Add(rating);

            //Assert
            Assert.AreEqual(rating, user.Ratings.FirstOrDefault());
        }

        [Test]
        public void DeletedOn()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var address = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();
            var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, address);
            var rating = new Rating();
            var deletedOn = new DateTime();

            //Act 
            user.DeletedOn = deletedOn;

            //Assert
            Assert.IsNotNull(user.DeletedOn);
        }

        [Test]
        public void DeletedOnAndREturnSameValue()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var address = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();
            var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, address);
            var rating = new Rating();
            var deletedOn = new DateTime();

            //Act 
            user.DeletedOn = deletedOn;

            //Assert
            Assert.AreEqual(deletedOn, user.DeletedOn);
        }


        [Test]
        public void IsDeletedREturnsFalse()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var address = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();
            var rating = new Rating();

            //Act 
            var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, address);

            //Assert
            Assert.AreEqual(false, user.IsDeleted);
        }


        [Test]
        public void IsDeletedToTrue()
        {
            //Arange
            var fixture = new Fixture();
            Guid guid = fixture.Create<Guid>();
            var address = fixture.Create<string>().Substring(0, 10);
            var randomString = fixture.Create<string>().Substring(0, 10);
            var dateOfbirth = fixture.Create<DateTime>();
            var rating = new Rating();
            var user = new User( randomString, randomString, randomString, dateOfbirth, randomString, address);


            //Act 
            user.IsDeleted = true;

            //Assert
            Assert.AreEqual(true, user.IsDeleted);
        }


    }
}
