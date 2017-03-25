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
using System.IO;
using Noleggio.DtoModels;
using Noleggio.Web.Infrastructure;
using Noleggio.Common;

namespace Noleggio.Web.Controllers
{
    public class RentItemsController : BaseController
    {
        private IRentItemService rentItemService;

        public RentItemsController(ICategoryService categoryService, IRentItemService rentItemService
            )
            : base(categoryService)
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

            item.RentItem.OwnerId = User.Identity.GetUserId();
            var imageCollection = new List<ImagesDtoModel>();
            for (var i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var imageLocation = string.Format("~/Images/RentItem/{0}/", item.RentItem.Name);
                    var path = Server.MapPath(imageLocation);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //path = Path.Combine(path, file.FileName);
                    file.SaveAs(Path.Combine(path, file.FileName));
                    imageCollection.Add(new ImagesDtoModel() { Location = imageLocation + "/" + file.FileName });
                }
            }

            this.rentItemService.Add(item.RentItem, imageCollection);
            return View("Added");

        }

        public ActionResult Get(Guid id)
        {
            var result = this.rentItemService.GetRentItemById(id);

            return View("RentItem", new RentItemsViewModelDetailed() { RentItem = result });
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Search(HomeViewModel model, int? id)
        {
            id = id == null ? 0 : id - 1;
            if (model.Search == null)
            {
                model = (HomeViewModel)TempData["model"];
            }
            var filteredItems = this.rentItemService.GetRentItems(model.Search.StartDate, model.Search.EndDate, model.Search.CategoryId, model.Search.Filter, (int)id);
            this.ViewBag.TotalPages = this.rentItemService.TotalPages();
            if (TempData.ContainsKey("model"))
            {
                TempData.Remove("model");
                TempData.Add("model", model);
            }
            else
            {
                TempData.Add("model", model);
            }
            return this.PartialView("_RentItemsPartialView", filteredItems);
        }
    }
}