﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Noleggio.DbModels;
using Noleggio.Services.Contracts;

namespace Noleggio.Web.Controllers
{
    public class HomeController : BaseController
    { 
        public HomeController( ICategoryService categoryService) :
            base( categoryService)
        {
        }

        public ActionResult Index()
        {
            return View();
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
        public ActionResult Search()
        {
            return View();
        }
    }
}