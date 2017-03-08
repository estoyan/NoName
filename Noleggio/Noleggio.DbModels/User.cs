using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.DbModels
{
    public class User 
    {
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
            this.IsHidden = false;
        }

        public User(Guid aspNetUserId, string email, string firstName, string lastName, int age, string city, string address)
            : this()
        {
            Guard.WhenArgument(aspNetUserId, nameof(aspNetUserId)).IsEmptyGuid().Throw();
            Guard.WhenArgument(email, nameof(email)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(firstName, nameof(firstName)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(lastName, nameof(lastName)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(age, nameof(age)).IsLessThan(18).Throw();
            Guard.WhenArgument(city, nameof(city)).IsNullOrEmpty().Throw();

            this.Id = aspNetUserId;
            this.Username = email;
            //this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]  
        public string LastName { get; set; }

        [Required]
        public string  City { get; set; }

        [Required]
        public string   Address { get; set; }

        [Required]
        public int Age { get; set; }

        //[Required]
        //public string Email { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Lease> Leases
        {
            get { return this.leases; }
            set { this.leases = value; }
        }

        public virtual ICollection<RentItem> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public bool IsHidden { get; set; }
    }
}
