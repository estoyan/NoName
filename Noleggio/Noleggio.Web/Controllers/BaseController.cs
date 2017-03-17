using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noleggio.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IGenericEfRepository<User> repository, IUnitOfWork unitOfWork)
        {

        }
        // GET: Base
        public void Categories()
        {
            ViewBag.Categories = new string[] { "TEst", "test2" };
            
        }
    }
}