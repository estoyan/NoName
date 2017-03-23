using Noleggio.Common.Contracts;
using Noleggio.DbModels;
using System;

namespace Noleggio.DtoModels
{
    public class ImagesDtoModel : IMapFrom<Image>
    {
        public string Location { get; set; }
    }
}