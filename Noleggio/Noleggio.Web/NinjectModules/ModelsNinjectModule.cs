using Ninject.Modules;
using Ninject.Extensions.Conventions;
using Noleggio.DbModels.Factories;

namespace Noleggio.Web.NinjectModules
{
    public class ModelsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x => x.FromAssemblyContaining<IUserFactory>()
                                    .SelectAllInterfaces()
                                    .EndingWith("Factory")
                                    .BindToFactory()
                                    /*.Configure(c => c.InSingletonScope())*/);
        }
       
    }
}