using Noleggio.DbModels;
using Noleggio.DtoModels.CommentsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Services.Contracts
{
    public interface ICommentService: INoleggioGenericService<Comment>
    {
        void AddCommnet(CommentDtoModel comment);

        IList<CommentDtoModel> GetAll(Guid rentItemId);
    }
}
