using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Noleggio.Common;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace Noleggio.DbModels
{
    public class User : IdentityUser, IDeletableEntity
    {

        const string ExceptionMiminumAgeMessage = "Mimimum allowed age is {0}";
        const string ExceptionMaxinumAgeMessage = "Maximum allowed age is {0}";
        const string FirstNameLengthExceptionMessage = "First Name should be between {0} and {1} symbols";
        const string LastNameLengthExceptionMessage = "Last Name should be between {0} and {1} symbols";
        const string CityLengthExceptionMessage = "City should be between {0} and {1} symbols";
        const string AddressLengthExceptionMessage = "Address should be between {0} and {1} symbols";

        private ICollection<Comment> comments;
        private ICollection<Lease> leases;
        private ICollection<RentItem> items;
        private ICollection<Rating> ratings;

        public User()
        {
            this.comments = new HashSet<Comment>();
            this.leases = new HashSet<Lease>();
            this.items = new HashSet<RentItem>();
            this.ratings = new HashSet<Rating>();
            this.IsDeleted = false;
        }

        public User(/*Guid aspNetUserId,*/ string email, string firstName, string lastName, DateTime dateOfBirth, string city, string address)
            : this()
        {
            //Guard.WhenArgument(aspNetUserId, nameof(aspNetUserId)).IsEmptyGuid().Throw();
            Guard.WhenArgument(email, nameof(email)).IsNullOrEmpty().Throw();

            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.City = city;
            this.Address = address;
        }

        [Required]
        [StringLength(NoleggioConstants.UserFirstNameMaximumLenght, MinimumLength = NoleggioConstants.UserClassMinimumStringLenght)]
        public string FirstName { get; set;  }
     

        [Required]
        [StringLength(NoleggioConstants.UserLastNameMaximumLenght, MinimumLength = NoleggioConstants.UserClassMinimumStringLenght)]
        public string LastName { get; set; }

        [Required]
        [StringLength(NoleggioConstants.UserCityMaximumLength, MinimumLength = NoleggioConstants.UserClassMinimumStringLenght)]
        public string City { get; set; }


        [Required]
        [StringLength(NoleggioConstants.UserAddressMaximumLength, MinimumLength = NoleggioConstants.UserClassMinimumStringLenght)]
        public string Address { get; set; }
     
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get;  set; }

        [NotMapped]
        public byte? Age => AgeCalculator.Age(this.DateOfBirth);
        
        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            private set { this.comments = value; }
        }

        public virtual ICollection<Lease> Leases
        {
            get { return this.leases; }
            private set { this.leases = value; }
        }

        public virtual ICollection<RentItem> Items
        {
            get { return this.items; }
            private set { this.items = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            private set { this.ratings = value; }
        }

        public bool IsDeleted { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeletedOn { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

}
