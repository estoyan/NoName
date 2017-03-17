using Ninject.Modules;
using Ninject.Web.Common;
using Noleggio.Data;
using Noleggio.Data.Contracts;
using Ninject.Extensions.Conventions;
using Noleggio.Data.Repositories;
using System.IO;
using System.Reflection;

namespace Noleggio.Web.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetAssembly(typeof(INoleggioDbContext)).Location))
                    .SelectAllClasses()
                    .BindDefaultInterface();
            });
            this.Rebind<INoleggioDbContext>().To<NoleggioDbContext>().InRequestScope();
            this.Rebind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
        }
    }
}