using Noleggio.Data;
using Noleggio.DtoModels;
using Noleggio.DtoModels.RentItems;
using Noleggio.Web.App_Start;
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity.Migrations;
using Noleggio.Data.Migrations;

namespace Noleggio.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add( new RazorViewEngine());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Config(Assembly.GetAssembly(typeof(RentItemDtoModel)));

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NoleggioDbContext, Configuration>());

        }
    }
}
