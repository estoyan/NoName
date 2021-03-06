﻿using Bytes2you.Validation;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using Noleggio.DtoModels;
using Noleggio.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;

namespace Noleggio.Web.Controllers
{

    public class BaseController : Controller
    {
        protected ICategoryService categoryService;

        public BaseController(ICategoryService categoryService)
        {
            Guard.WhenArgument(categoryService, nameof(categoryService)).IsNull().Throw();

            this.categoryService = categoryService;
        }

        private IEnumerable<CategoryDtoModel> GetCategories()
        {
            return this.categoryService.GetAllCategories();
        }


        [OutputCache(Duration = 10*60, Location = OutputCacheLocation.Server)]
        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {

            this.ViewBag.MainCategories = this.GetCategories();
            var result = base.BeginExecute(requestContext, callback, state);

            return result;
        }

        protected void BeginExexuteCall(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.BeginExecute(requestContext, callback, state);
        }
    }
}