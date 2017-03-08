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
    public class Lease
    {
        //TODO extract all exceptions in a  separete file
        const string StartDateCannobeGreater = "Start Date cannot be greater than end date";

        public Lease()
        {
        }

        public Lease(RentItem item, User user, DateTime startDate, DateTime endDate) : this()
        {
            Guard.WhenArgument(item, nameof(item)).IsNull().Throw();
            Guard.WhenArgument(user, nameof(user)).IsNull().Throw();
            Guard.WhenArgument(startDate, StartDateCannobeGreater).IsLessThanOrEqual(endDate).Throw();

            this.Item = item;
            this.User = user;
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
        public Guid ItemId { get; set; }
        public virtual RentItem Item { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

    }
}
