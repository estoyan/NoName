using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Noleggio.DbModels;
using Noleggio.Services.Contracts;
using Noleggio.Web.Models;
using Bytes2you.Validation;
using System.Web.UI;

namespace Noleggio.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IRentItemService rentItemService;

        public HomeController( ICategoryService categoryService, IRentItemService rentItemService) :
            base( categoryService)
        {
            Guard.WhenArgument(rentItemService, nameof(rentItemService)).IsNull().Throw();
            this.rentItemService = rentItemService;
        }

        [OutputCache(Duration = 10, Location = OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            var recentItems=this.rentItemService.Recent(10);
            
            return View(new HomeViewModel() { RecentItems=recentItems});  
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
      
    }
}