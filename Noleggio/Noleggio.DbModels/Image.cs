using Bytes2you.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noleggio.DbModels
{
    public class Image : IDeletableEntity
    {
        public Image()
        {

        }
        public Image( string location)
        {
            Guard.WhenArgument(location, nameof(location)).IsNullOrEmpty().Throw();
            this.Location = location;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public string Location { get; set; }

        [Required]
        public Guid RentItemId { get; private set; }
        public virtual RentItem RentItem { get;  set; }


        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
   
    }
}