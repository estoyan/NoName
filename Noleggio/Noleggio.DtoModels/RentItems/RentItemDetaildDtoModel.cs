using Noleggio.Common.Contracts;
using Noleggio.DbModels;
using Noleggio.DtoModels.CommentsDto;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace Noleggio.DtoModels.RentItems
{
    public class RentItemDetaildDtoModel: RentItemDtoModel, IMapFrom<RentItem>, IHaveCustomMappings 
    {

        public string Owner { get; set; }

        public CategoryDtoModel Category { get; set; }

        public List<CommentDtoModel> Comments { get; set; }

        public bool IsDeleted { get; set; }

        public override void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<RentItem, RentItemDetaildDtoModel>()
                .ForMember(s => s.Owner, opt => opt.MapFrom(d => d.Owner.FirstName + " " + d.Owner.LastName));
            config.CreateMap<RentItemDetaildDtoModel, RentItem>()
                .ForMember(s => s.Owner, opt => opt.Ignore());
            //config.CreateMap<RentItemDetaildDtoModel, RentItem>()
            //    .ForMember(s => s.IsDeleted, opt => opt.NullSubstitute(false));
            base.CreateMappings(config);
    }


    }
}
