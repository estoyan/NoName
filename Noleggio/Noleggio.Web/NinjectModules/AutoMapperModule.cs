using Ninject.Modules;
using Noleggio.Web.AutoMapper;
using Noleggio.Web.AutoMapper.Contracts;

namespace Noleggio.Web.NinjectModules
{
    public class AutoMapperModule: NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IMapingService>().To<MappingService>();
        }
    }
}