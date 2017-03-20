using Noleggio.Common;
using Noleggio.Common.Contracts;
using Noleggio.DbModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Noleggio.DtoModels.CommentsDto
{
    public class CommentsDtoModel : IMapFrom<Comment>
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [MaxLength(NoleggioConstants.CommentDescriptionMaxLength)]
        public string Description { get; set; }

        public DateTime Date { get; private set; }
    }
}
