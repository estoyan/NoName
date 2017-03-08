using Bytes2you.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Noleggio.DbModels
{
    public class Rating
    {
        const int MinRate = 0;
        const int MaxRate = 5;
        const string MinRateExceptionMessage = "Minimal rating cannot be less than 0";
        const string MaxRateExceptionMessage = "Maximal rating cannot be greater than 5";

        public Rating()
        {
            this.IsHidden = false;
        }

        public Rating(Guid fromUser, Guid toUser, int rate) : this()
        {

            Guard.WhenArgument(fromUser, nameof(fromUser)).IsEmptyGuid().Throw();
            Guard.WhenArgument(toUser, nameof(toUser)).IsEmptyGuid().Throw();
            Guard.WhenArgument(rate, MinRateExceptionMessage).IsLessThan(MinRate).Throw();
            Guard.WhenArgument(rate, MaxRateExceptionMessage).IsGreaterThan(MaxRate).Throw();

            this.ToUserId = toUser;
            this.FromUserId = fromUser;
            this.Rate = rate;
        }

        public int Id { get; set; }

        [Required]
        public int Rate { get; set; }

        [Required]
        public Guid ToUserId { get; set; }
        public virtual User ToUser { get; set; }

        [Required]
        public Guid FromUserId { get; set; }
        public virtual User FromUser { get; set; }

        public bool IsHidden { get; set; }
    }
}