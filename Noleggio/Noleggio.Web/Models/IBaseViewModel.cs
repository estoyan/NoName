using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Noleggio.Web.Models
{
    public interface IBaseViewModel
    {
         LoginViewModel LoginView { get; set; }
    }
}