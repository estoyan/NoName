using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Noleggio.DbModels;
using Noleggio.Services.Contracts;
using Bytes2you.Validation;
using Noleggio.Web.Models;
using Noleggio.Common.Contracts;
using Microsoft.AspNet.Identity;

namespace Noleggio.Web.Controllers
{
    public class RentItemsController : BaseController
    {
        private IRentItemService rentItemService;

        public RentItemsController(ICategoryService categoryService, IRentItemService rentItemService
            ) 
            : base( categoryService)
        {
            Guard.WhenArgument(rentItemService, nameof(rentItemService)).IsNull().Throw();
            this.rentItemService = rentItemService;
        }

        // GET: RentItems
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();  

        }

        [HttpPost]
        public ActionResult Add(RentItemsViewModel item)
        {
            
            item.Rentitem.OwnerId = User.Identity.GetUserId();
            this.rentItemService.Add(item.Rentitem);
            return View("Added");

        }
    }
}