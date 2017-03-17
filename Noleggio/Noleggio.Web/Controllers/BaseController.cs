using Bytes2you.Validation;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using Noleggio.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Noleggio.Web.Controllers
{
    public class BaseController : Controller
    {
        private INoleggioGenericService<User> userService;
        private INoleggioGenericService<Category> categoryService;

        public BaseController(INoleggioGenericService<User> userService, INoleggioGenericService<Category> categoryService)
        {
            Guard.WhenArgument(userService, nameof(userService)).IsNull().Throw();
            Guard.WhenArgument(categoryService, nameof(categoryService)).IsNull().Throw();

            this.userService = userService;
            this.categoryService = categoryService;
        }

        //TODO make a transformation of User to UserViewModel
        public User DetailedUser { get; private set; }

        private IEnumerable<Category> GetCategories()
        {
            return this.categoryService.GetAll();
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            // Work with data before BeginExecute to prevent "NotSupportedException: A second operation started on this context before a previous asynchronous operation completed."
            this.DetailedUser = this.userService.GetById((requestContext.HttpContext.User.Identity.Name));

            this.ViewBag.MainCategories = this.GetCategories();

            // Calling BeginExecute before PrepareSystemMessages for the TempData to has values
            var result = base.BeginExecute(requestContext, callback, state);

            //var systemMessages = this.PrepareSystemMessages();
            //this.ViewBag.SystemMessages = systemMessages;

            return result;
        }
    }
}