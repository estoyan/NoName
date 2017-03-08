using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noleggio.DbModels
{
    public class RentItem
    {
        //TODO extract constants to a sepaerte file
        const int CommentMaxLength = 200;
        const int ImagePathLength = 100;
        readonly string DescriptionLength = string.Format("Item description cannot be longer than {0} symbols",CommentMaxLength);
        const string ImagePathTooLong = "Path to image cannot be longer than  100 symbols";
    
        private ICollection<Comment> comments;
        private ICollection<Lease> leases;

        public RentItem()
        {
            this.leases = new HashSet<Lease>();
            this.comments = new HashSet<Comment>();
        }

        public RentItem(User user, Category category, string description) : this()
        {
            Guard.WhenArgument(user, nameof(user)).IsNull().Throw();
            Guard.WhenArgument(category, nameof(category)).IsNull().Throw();
            Guard.WhenArgument(description, nameof(description)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(description.Length, DescriptionLength).IsGreaterThan(CommentMaxLength).Throw();

            this.Owner = user;
            this.Category = category;
            this.Description = description;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        public Guid OwnerId { get; set; }
        public virtual User Owner { get; private set; }

        [Required]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; private set; }

        [Required]
        [MaxLength(CommentMaxLength)]
        public string Description { get; private set; }

        [Required]
        [MaxLength(ImagePathLength,ErrorMessage =ImagePathTooLong)]
        public string ImageLocation { get; set; }

        public virtual ICollection<Lease> Leases
        {
            get
            {
                return this.leases;
            }
            set
            {
                this.leases = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
    }
}
