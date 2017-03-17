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
        public string Name { get; set; }
      
        //TODO add image property to the model
        //public string Image { get; set; }


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