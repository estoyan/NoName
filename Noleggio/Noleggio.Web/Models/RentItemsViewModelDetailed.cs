using Noleggio.DtoModels;
using Noleggio.DtoModels.CommentsDto;
using Noleggio.DtoModels.RentItems;
using System.Web;

namespace Noleggio.Web.Models
{
    public class RentItemsViewModelDetailed : BaseViewModel
    {

        public HttpPostedFileBase Image { get; set; }

        public CommentDtoModel Comment {get; set;}

        public RentItemDetaildDtoModel RentItem { get; set; }
    }
}