using Noleggio.Common;
using Noleggio.Common.Contracts;
using Noleggio.DbModels;
using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace Noleggio.DtoModels.CommentsDto
{
    public class CommentDtoModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Owner { get; set; }

        [MaxLength(NoleggioConstants.CommentDescriptionMaxLength)]
        public string Description { get; set; }

        public Guid ItemId { get; set; }

        public DateTime Date { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Comment, CommentDtoModel>()
                .ForMember(s => s.Owner, opt => opt.MapFrom(d => d.User.FirstName + " " + d.User.LastName));
        }
    }
}
