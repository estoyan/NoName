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
            
            item.RentItem.OwnerId = User.Identity.GetUserId();
            var imageCollection = new List<ImagesDtoModel>();
            for (var i=0; i<Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var path = Server.MapPath(string.Format("~/Images/RentItem/{0}/", item.RentItem.Name));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                     path = Path.Combine(path, file.FileName);
                    file.SaveAs(path);
                    imageCollection.Add(new ImagesDtoModel() { Location = path });
                }
            }

            this.rentItemService.Add(item.RentItem, imageCollection);
            return View("Added");
            
        }

        public ActionResult Get(Guid id)
        {
            var result=this.rentItemService.GetRentItemById(id);
            return View("RentItem",result);
        }
    }
}