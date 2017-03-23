using Noleggio.DtoModels;
using System.Web;

namespace Noleggio.Web.Models
{
    public class RentItemsViewModel : BaseViewModel
    {

        public HttpPostedFileBase Image { get; set; }

        public RentItemDtoModel RentItem { get; set; }
    }
}