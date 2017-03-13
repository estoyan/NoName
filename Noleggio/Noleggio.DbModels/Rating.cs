using Bytes2you.Validation;
using Noleggio.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Noleggio.DbModels
{
    public class Rating : IDeletableEntity
    {

        const string MinRateExceptionMessage = "Minimal rating cannot be less than 0";
        const string MaxRateExceptionMessage = "Maximal rating cannot be greater than 5";

        private double rate;

        public Rating()
        {
            this.IsDeleted = false;
        }

        public Rating(Guid fromUser, Guid toUser, double rate) : this()
        {

            Guard.WhenArgument(fromUser, nameof(fromUser)).IsEmptyGuid().Throw();
            Guard.WhenArgument(toUser, nameof(toUser)).IsEmptyGuid().Throw();


            this.ToUserId = toUser;
            this.FromUserId = fromUser;
            this.Rate = rate;
        }

        public int Id { get; set; }

        [Required]
        public double Rate
        {
            get
            {
                return this.rate;
            }

            set
            {
                Guard.WhenArgument(value, string.Format(MinRateExceptionMessage, NoleggioConstants.MinRate)).IsLessThan(NoleggioConstants.MinRate).Throw();
                Guard.WhenArgument(value, string.Format(MaxRateExceptionMessage, NoleggioConstants.MaxRate)).IsGreaterThan(NoleggioConstants.MaxRate).Throw();
                this.rate = value;
            }
        }

        [Required]
        public Guid ToUserId { get; set; }
        public virtual User ToUser { get; set; }

        [Required]
        public Guid FromUserId { get; set; }
        public virtual User FromUser { get; set; }

        public bool IsDeleted { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeletedOn { get; set; }
    }
}