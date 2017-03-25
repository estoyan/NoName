using Noleggio.DtoModels;
using Noleggio.DtoModels.RentItems;
using System.Web;

namespace Noleggio.Web.Models
{
    public class RentItemsViewModel : BaseViewModel
    {

        public HttpPostedFileBase Image { get; set; }

        public RentItemDetaildDtoModel RentItem { get; set; }
    }
}