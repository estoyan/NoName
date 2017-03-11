using Bytes2you.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noleggio.DbModels
{
    public class Lease
    {
        const string StartDateCannobeGreater = "Start Date cannot be greater than end date";

        public Lease()
        {
        }

        public Lease(Guid rentItem, Guid user, DateTime startDate, DateTime endDate) : this()
        {
            Guard.WhenArgument(rentItem, nameof(rentItem)).IsEmptyGuid().Throw();
            Guard.WhenArgument(user, nameof(user)).IsEmptyGuid().Throw();
            Guard.WhenArgument(startDate, StartDateCannobeGreater).IsGreaterThanOrEqual(endDate).Throw();

            this.ItemId = rentItem;
            this.UserId = user;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        public DateTime StartDate { get; private set; }

        [Required]
        public DateTime EndDate { get; private set; }

        [Required]
        public Guid ItemId { get; private set; }
        public virtual RentItem Item { get; private set; }

        [Required]
        public Guid UserId { get; private set; }
        public virtual User User { get; private set; }

    }
}
