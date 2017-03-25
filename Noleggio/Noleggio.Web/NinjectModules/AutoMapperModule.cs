using Ninject.Modules;
using Noleggio.Common;
using Noleggio.Common.Contracts;

namespace Noleggio.Web.NinjectModules
{
    public class AutoMapperModule: NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IMapingService>().To<MappingService>();
            //Kernel.Bind<IMapperConfigurationExpression>().To<AutoMapperModule>();
        }
    }
}