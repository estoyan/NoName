using Bytes2you.Validation;
using Noleggio.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noleggio.DbModels
{
    public class Comment
    {
        const string DescriptionMaxLenghtExceptionMessage = "Comment  cannot be more than {0} symbols";
        private string description;

        public Comment()
        {
            this.Date = DateTime.Now;
            this.IsDeleted = false;
        }

        public Comment(User user, RentItem item, string description) : this()
        {
            Guard.WhenArgument(item, nameof(item)).IsNull().Throw();
            Guard.WhenArgument(user, nameof(user)).IsNull().Throw();
           

            this.User = user;
            this.Item = item;
            this.Description = description;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        public Guid UserId { get; set; }
        public virtual User User { get; private set; }

        [Required]
        public Guid ItemId { get; set; }
        public virtual RentItem Item { get; private set; }

        [Required]
        [MaxLength(Constants.CommentDescriptionMaxLength)]
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                Guard.WhenArgument(value, nameof(description)).IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, string.Format(DescriptionMaxLenghtExceptionMessage, Constants.CommentDescriptionMaxLength)).IsGreaterThan(Constants.CommentDescriptionMaxLength).Throw();
                this.description = value;
            }
        }

        [Required]
        public DateTime Date { get; private set; }

        public bool IsDeleted { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeletedOn { get; set; }
    }
}