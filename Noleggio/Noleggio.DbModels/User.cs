﻿using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Noleggio.Common;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.AspNet.Identity.EntityFramework;

namespace Noleggio.DbModels
{
    public class User /*: IdentityUser*/
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

        private string lastName;
        private string firstName;
        private string city;
        private string address;

        public User()
        {
            this.comments = new HashSet<Comment>();
            this.leases = new HashSet<Lease>();
            this.items = new HashSet<RentItem>();
            this.ratings = new HashSet<Rating>();
            this.IsDeleted = false;
        }

        public User(Guid aspNetUserId, string email, string firstName, string lastName, DateTime dateOfBirth, string city, string address)
            : this()
        {
            Guard.WhenArgument(aspNetUserId, nameof(aspNetUserId)).IsEmptyGuid().Throw();
            Guard.WhenArgument(email, nameof(email)).IsNullOrEmpty().Throw();

            this.Id = aspNetUserId;
            this.Username = email;
            //this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.City = city;
            this.Address = address;
        }

        public Guid Id { get; private set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; private set; }

        [Required]
        [StringLength(Constants.UserFirstNameMaximumLenght, MinimumLength = Constants.UserClassMinimumStringLenght)]
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                Guard.WhenArgument(value, nameof(firstName)).IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, string.Format(FirstNameLengthExceptionMessage, Constants.UserClassMinimumStringLenght, Constants.UserFirstNameMaximumLenght))
                     .IsLessThan(Constants.UserClassMinimumStringLenght)
                     .IsGreaterThan(Constants.UserFirstNameMaximumLenght).Throw();
                this.firstName = value;
            }
        }

        [Required]
        [StringLength(Constants.UserLastNameMaximumLenght, MinimumLength = Constants.UserClassMinimumStringLenght)]
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                Guard.WhenArgument(value, nameof(LastName)).IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, string.Format(LastNameLengthExceptionMessage, Constants.UserClassMinimumStringLenght, Constants.UserLastNameMaximumLenght))
                   .IsLessThan(Constants.UserClassMinimumStringLenght)
                   .IsGreaterThan(Constants.UserLastNameMaximumLenght).Throw();
                this.lastName = value;
            }
        }

        [Required]
        [StringLength(Constants.UserCityMaximumLength, MinimumLength = Constants.UserClassMinimumStringLenght)]
        public string City
        {
            get
            {
                return this.city;
            }

            set
            {
                Guard.WhenArgument(value, nameof(city)).IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, string.Format(CityLengthExceptionMessage, Constants.UserClassMinimumStringLenght, Constants.UserCityMaximumLength))
                  .IsLessThan(Constants.UserClassMinimumStringLenght)
                  .IsGreaterThan(Constants.UserCityMaximumLength).Throw();
                this.city = value;
            }
        }

        [Required]
        [StringLength(Constants.UserAddressMaximumLength, MinimumLength = Constants.UserClassMinimumStringLenght)]
        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                Guard.WhenArgument(value, nameof(address)).IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, string.Format(AddressLengthExceptionMessage, Constants.UserClassMinimumStringLenght, Constants.UserAddressMaximumLength))
                  .IsLessThan(Constants.UserClassMinimumStringLenght)
                  .IsGreaterThan(Constants.UserAddressMaximumLength).Throw();

                this.address = value;
            }
        }

        [DataType(DataType.Date)]
        [Required]
        public DateTime? DateOfBirth { get; private set; }

        [NotMapped]
        public byte? Age => Calculator.Age(this.DateOfBirth);


        //[Required]
        //public string Email { get; set; }

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
    }

}
