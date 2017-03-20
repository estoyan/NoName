using Noleggio.Common.Contracts;
using Noleggio.DbModels;
using Noleggio.DtoModels.CommentsDto;
using System;
using System.Collections.Generic;

namespace Noleggio.DtoModels.RentItems
{
    public class RentItemDetaildDtoModel: RentItemDtoModel, IMapFrom<RentItem>
    {
        public Guid Id { get; set; }
        public UserDtoModel Owner { get; set; }

        public ICollection<CommentsDtoModel> Comments { get; set; }


    }
}
