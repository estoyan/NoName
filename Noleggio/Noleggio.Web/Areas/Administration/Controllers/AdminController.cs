using Bytes2you.Validation;
using Noleggio.Common;
using Noleggio.Services.Contracts;
using Noleggio.Web.Areas.Administration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noleggio.Web.Areas.Administration.Controllers
{
    //[Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private IUserService userService;
        private IRentItemService rentItemService;

        public AdminController(IUserService userservice, IRentItemService rentItemService)
        {
            Guard.WhenArgument(userservice, nameof(userservice)).IsNull().Throw();
            Guard.WhenArgument(rentItemService, nameof(rentItemService)).IsNull().Throw();
            this.userService = userservice;
            this.rentItemService = rentItemService;
        }
       
        // GET: Administration/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllUsers(AdminHomeViewModel model, int? page)
        {
            page = page == null ? 0 : page - 1;

            var users=this.userService.All(model.IsUserDeleted);
            ViewBag.TotalPages = this.TotalPages(users.Count());
            users.RemoveRange(0, (int)page * NoleggioConstants.PagingSize);

            return View("Users", users.Take(NoleggioConstants.PagingSize).ToList());
        }

        //public ActionResult AllRentItems(AdminHomeViewModel model,int? id)
        //{
        //    id = id == null ? 0 : id - 1;
        //    if (model == null)
        //    {
        //        model = (AdminHomeViewModel)TempData["model"];
        //    }
        //    if (TempData.ContainsKey("model"))
        //    {
        //        TempData.Remove("model");
        //        TempData.Add("model", model);
        //    }
        //    else
        //    {
        //        TempData.Add("model", model);
        //    }
        //    var users = this.rentItemService.All(model.IsItemDeleted, model.RentItemFilter, (int)id);

        //    return View(users);
        //}

        public ActionResult SearchUser(AdminHomeViewModel model, int? page)
        {
            page = page == null ? 0 : page - 1;
            if (model == null)
            {
                model = (AdminHomeViewModel)TempData["model"];
            }
            if (TempData.ContainsKey("model"))
            {
                TempData.Remove("model");
                TempData.Add("model", model);
            }
            else
            {
                TempData.Add("model", model);
            }
            var users = this.userService.All(model.IsUserDeleted, model.UserFilter);
            ViewBag.TotalPages = this.TotalPages(users.Count());
            users.RemoveRange(0, (int)page * NoleggioConstants.PagingSize);

            return View("Users", users.Take(NoleggioConstants.PagingSize).ToList());
        }

        //public ActionResult SearchRentItem(AdminHomeViewModel model)
        //{
        //    return null;
        //}

        private int TotalPages(int items)
        {
            if (items % NoleggioConstants.PagingSize == 0)
            {

                return items / NoleggioConstants.PagingSize;
            }

            return (items / NoleggioConstants.PagingSize) + 1;
        }
    }
}