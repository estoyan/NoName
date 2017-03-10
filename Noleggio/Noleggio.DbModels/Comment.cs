using Bytes2you.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noleggio.DbModels
{
    public class Comment
    {
        const int DescriptionMaxLenght = 200;
        readonly string DescriptionMaxLenghtExceptionMessage = "Comment  cannot be more than {0} symbols";

        public Comment()
        {
            this.Date = DateTime.Now;
            this.IsHidden = false;
        }

        public Comment(User user, RentItem item, string description) : this()
        {
            Guard.WhenArgument(item, nameof(item)).IsNull().Throw();
            Guard.WhenArgument(user, nameof(user)).IsNull().Throw();
            Guard.WhenArgument(description, nameof(description)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(description.Length, string.Format(DescriptionMaxLenghtExceptionMessage,description)).IsGreaterThan(DescriptionMaxLenght).Throw();

            this.User = user;
            this.Item = item;
            this.Description = description;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public Guid ItemId { get; set; }
        public virtual RentItem Item { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool IsHidden { get; set; }
    }
}