
using System;
using AutoMapper;
using Noleggio.Common.Contracts;
using Noleggio.DbModels;

namespace Noleggio.DtoModels
{
   public class UserDtoModel: IMapFrom<User>, IHaveCustomMappings
    {
        public string Name { get; set;}

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<User, UserDtoModel>()
               .ForMember(s => s.Name, opt => opt.MapFrom(d => d.FirstName + " " + d.LastName));
        }
    }
}