using Ninject.Modules;
using Ninject.Web.Common;
using Noleggio.Data;
using Noleggio.Data.Contracts;
using Ninject.Extensions.Conventions;
using Noleggio.Data.Repositories;
using System.IO;
using System.Reflection;
using Noleggio.Services.Contracts;
using Noleggio.Services;

namespace Noleggio.Web.NinjectModules
{
    public class ServicesNinjectModule : NinjectModule

    {
        public override void Load()
        {
            //Kernel.Bind(x =>
            //{
            //    x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetAssembly(typeof(IUserService)).Location))
            //       .SelectAllClasses()
            //       .BindDefaultInterface();
            //});
            Kernel.Bind(typeof(INoleggioGenericService<>)).To(typeof(NoleggioGenericService<>));
            //Kernel.Bind<IUserService>().To<UserService>();
            Kernel.Bind<ICategoryService>().To<CategoryService>();
            Kernel.Bind<IRentItemService>().To<RentItemService>();
        }
    }
}