using Bytes2you.Validation;
using Noleggio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noleggio.DbModels
{
    public class RentItem
    {
        const string DescriptionLength = "Item description cannot be longer than {0} symbols";
        const string ImagePathTooLong = "Path to image cannot be longer than  100 symbols";
        private string description;
        private string imagePath;

        private ICollection<Comment> comments;
        private ICollection<Lease> leases;

        public RentItem()
        {
            this.leases = new HashSet<Lease>();
            this.comments = new HashSet<Comment>();
        }

        public RentItem(Guid user, Guid category, string description) : this()
        {
            Guard.WhenArgument(user, nameof(user)).IsEmptyGuid().Throw();
            Guard.WhenArgument(category, nameof(category)).IsEmptyGuid().Throw();


            this.OwnerId = user;
            this.CategoryId = category;
            this.Description = description;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        public Guid OwnerId { get; private set; }
        public virtual User Owner { get; private set; }

        [Required]
        public Guid CategoryId { get; private set; }
        public virtual Category Category { get; private set; }

        [Required]
        [MaxLength(Constants.CommentMaxLength)]
        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                Guard.WhenArgument(value, nameof(description)).IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, string.Format(DescriptionLength, Constants.CommentMaxLength)).IsGreaterThan(Constants.CommentMaxLength).Throw();

                this.description = value;
            }
        }

        [Required]
        [MaxLength(Constants.ImagePathLength, ErrorMessage = ImagePathTooLong)]
        public string ImageLocation
        {
            get
            {
                return this.imagePath;
            }

            set
            {
                Guard.WhenArgument(value, nameof(imagePath)).IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, string.Format(ImagePathTooLong, Constants.ImagePathLength)).IsGreaterThan(Constants.ImagePathLength).Throw();

                this.imagePath = value;
            }
        }

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
