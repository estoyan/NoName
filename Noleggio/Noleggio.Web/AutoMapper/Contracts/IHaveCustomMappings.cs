using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Noleggio.Web.Contracts
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression config);
    }
}
