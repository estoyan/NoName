using Bytes2you.Validation;
using Noleggio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noleggio.DbModels
{
    public class RentItem : IDeletableEntity
    {
        const string ImagePathTooLong = "Path to image cannot be longer than  100 symbols";

        private ICollection<Comment> comments;
        private ICollection<Lease> leases;
        private ICollection<Image> images;

        public RentItem()
        {
            this.leases = new HashSet<Lease>();
            this.comments = new HashSet<Comment>();
            this.images = new HashSet<Image>();
        }

        public RentItem(string user, Guid category, string description, string location) : this()
        {
            Guard.WhenArgument(user, nameof(user)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(category, nameof(category)).IsEmptyGuid().Throw();
            Guard.WhenArgument(location, nameof(location)).IsNullOrEmpty().Throw();


            this.OwnerId = user;
            this.CategoryId = category;
            this.Description = description;
            this.Location = location;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        [MaxLength(NoleggioConstants.RentItemNameMaximumLength)]
        public virtual string Name { get; set; }

        [Required]
        public string OwnerId { get; private set; }
        public virtual User Owner { get; private set; }

        [Required]
        [MaxLength(NoleggioConstants.RentItemLocationMaximumLength)]
        public virtual string Location { get; set; }

        [Required]
        public Guid CategoryId { get; private set; }
        public virtual Category Category { get; private set; }

        [Required]
        [MaxLength(NoleggioConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime AvailableFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime AvailableTo { get; set; }

        //[Required]
        //[MaxLength(NoleggioConstants.ImagePathLength, ErrorMessage = ImagePathTooLong)]
        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }
            set
            {
                this.images = value;
            }

        }

        public virtual ICollection<Lease> Leases
        {
            get
            {
                return this.leases;
            }
            private set
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
            private set
            {
                this.comments = value;
            }
        }

        public bool IsDeleted { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeletedOn { get; set; }
    }
}
