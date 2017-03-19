using Noleggio.DtoModels;

namespace Noleggio.Web.Models
{
    public class RentItemsViewModel : IBaseViewModel
    {
        public RentItemDtoModel Rentitem { get; set; }
        public LoginViewModel LoginView { get; set; }
    }
}