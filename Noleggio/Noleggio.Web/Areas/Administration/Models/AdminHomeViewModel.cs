using Noleggio.Web.Models;
using System.Collections.Generic;

namespace Noleggio.Web.Areas.Administration.Models
{
    public class AdminHomeViewModel:BaseViewModel
    {
        public string UserFilter { get; set; }
        public bool IsUserDeleted { get; set; }

        public string RentItemFilter { get; set; }
        public bool IsItemDeleted { get; set; }

    }
}