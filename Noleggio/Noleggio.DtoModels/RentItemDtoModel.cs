using Noleggio.Common;
using Noleggio.Common.Contracts;
using Noleggio.DbModels;
using System.ComponentModel.DataAnnotations;
using System;

namespace Noleggio.DtoModels
{
    public class RentItemDtoModel: IMapFrom<RentItem>
    {
        public string OwnerId { get; set; }

        [Required(ErrorMessage = "{0}тое задължително")]
        [Display(Name = "Име")]
        [MaxLength(NoleggioConstants.RentItemNameMaximumLength)]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "{0}ът е задължителен")]
        [Display(Name = "Място")]
        [MaxLength(NoleggioConstants.RentItemLocationMaximumLength)]
        public string Location { get; set; }

        [Required(ErrorMessage = "{0}то е задължително")]
        [Display(Name = "Описание")]
        [MaxLength(NoleggioConstants.CommentMaxLength)]
        public string Description { get; set; }

        public Guid CategoryId { get; set; }

   
    }
}