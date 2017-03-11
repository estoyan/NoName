using Bytes2you.Validation;
using Noleggio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noleggio.DbModels
{
    public class Category
    {

        readonly string CategoryNameMinLenghtExceptionMessage = string.Format("Category name cannot be less than {0} symbols", Constants.CategoryNameMinLenght);
        readonly string CategoryNameMaxLenghtExceptionMessage = string.Format("Category name cannot be more than {0} symbols", Constants.CategoryNameMaxLenght);
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
        [MinLength(Constants.CategoryNameMinLenght)]
        [MaxLength(Constants.CategoryNameMaxLenght)]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Guard.WhenArgument(value, nameof(name)).IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, CategoryNameMinLenghtExceptionMessage).IsLessThan(Constants.CategoryNameMinLenght).Throw();
                Guard.WhenArgument(value.Length, CategoryNameMaxLenghtExceptionMessage).IsGreaterThan(Constants.CategoryNameMaxLenght).Throw();

                this.name = value;
            }
        }

        public virtual ICollection<RentItem> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
            }
        }
    }
}