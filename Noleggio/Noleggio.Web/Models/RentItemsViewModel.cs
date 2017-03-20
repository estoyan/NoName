using Noleggio.DtoModels;

namespace Noleggio.Web.Models
{
    public class RentItemsViewModel : BaseViewModel
    {
        public RentItemDtoModel Rentitem { get; set; }
        public LoginViewModel LoginView { get; set; }
    }
}