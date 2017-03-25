using Noleggio.DbModels;
using Noleggio.Services;
using Noleggio.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noleggio.Data.Contracts;
using Noleggio.DtoModels.CommentsDto;
using Noleggio.Common.Contracts;
using Bytes2you.Validation;

namespace Noleggio.Services
{
    public class CommentService : NoleggioGenericService<Comment>, ICommentService
    {
        private IMapingService mapper;

        public CommentService(IGenericEfRepository<Comment> repository, IUnitOfWork unitOfWork, IMapingService mapper ): base(repository, unitOfWork)
        {
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();
            this.mapper = mapper;
        }

        public void AddCommnet(CommentDtoModel comment)
        {
            comment.Date = DateTime.Now;
            base.Add(mapper.Map<Comment>(comment));
        }

        public  IList<CommentDtoModel> GetAll(Guid rentItemId)
        {
            var comments = base.GetAll().Where(x => x.IsDeleted == false && x.ItemId == rentItemId).ToList();
            return mapper.Map<List<CommentDtoModel>>(comments);
            //return comments.Select(x => mapper.Map<CommentDtoModel>(x)).ToList();

        }
    }
}
