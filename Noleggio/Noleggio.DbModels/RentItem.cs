using Bytes2you.Validation;
using Noleggio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noleggio.DbModels
{
    public class RentItem: IDeletableEntity
    {
        const string ImagePathTooLong = "Path to image cannot be longer than  100 symbols";

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
        [MaxLength(NoleggioConstants.CommentMaxLength)]
        public string Description { get; set; }
       
        [Required]
        [MaxLength(NoleggioConstants.ImagePathLength, ErrorMessage = ImagePathTooLong)]
        public string ImageLocation { get; set; }

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
