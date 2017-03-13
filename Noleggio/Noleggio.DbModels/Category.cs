using Bytes2you.Validation;
using Noleggio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noleggio.DbModels
{
    public class Category: IDeletableEntity
    {

        readonly string CategoryNameMinLenghtExceptionMessage = string.Format("Category name cannot be less than {0} symbols", NoleggioConstants.CategoryNameMinLenght);
        readonly string CategoryNameMaxLenghtExceptionMessage = string.Format("Category name cannot be more than {0} symbols", NoleggioConstants.CategoryNameMaxLenght);
        private string name;

        private ICollection<RentItem> items;

        public Category()
        {
            this.items = new HashSet<RentItem>();
        }
        public Category(string name) : this()
        {
            this.Name = name;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; private set; }

        [Required]
        [MinLength(NoleggioConstants.CategoryNameMinLenght)]
        [MaxLength(NoleggioConstants.CategoryNameMaxLenght)]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Guard.WhenArgument(value, nameof(name)).IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, CategoryNameMinLenghtExceptionMessage).IsLessThan(NoleggioConstants.CategoryNameMinLenght).Throw();
                Guard.WhenArgument(value.Length, CategoryNameMaxLenghtExceptionMessage).IsGreaterThan(NoleggioConstants.CategoryNameMaxLenght).Throw();

                this.name = value;
            }
        }

        public virtual ICollection<RentItem> Items
        {
            get
            {
                return this.items;
            }
           private  set
            {
                this.items = value;
            }
        }

        public bool IsDeleted { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeletedOn { get; set; }
    }
}