using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noleggio.DbModels
{
    public class Category
    {
        const int CategoryNameMinLenght = 3;
        const int CategoryNameMaxLenght = 30;
        readonly string CategoryNameMinLenghtExceptionMessage = string.Format("Category name cannot be less than {0} symbols", CategoryNameMinLenght);
        readonly string CategoryNameMaxLenghtExceptionMessage = string.Format("Category name cannot be more than {0} symbols", CategoryNameMaxLenght);

        private ICollection<RentItem> items;

        public Category()
        {
            this.items = new HashSet<RentItem>();
        }
        public Category(string name):this ()
        {
            Guard.WhenArgument(name, nameof(name)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(name.Length, CategoryNameMinLenghtExceptionMessage).IsLessThan(CategoryNameMinLenght).Throw();
            Guard.WhenArgument(name.Length, CategoryNameMaxLenghtExceptionMessage).IsGreaterThan(CategoryNameMaxLenght).Throw();

            this.Name = name;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; private set; }

        [Required]
        [MinLength(CategoryNameMinLenght)]
        [MaxLength(CategoryNameMaxLenght)]
        public string Name { get; set; }

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