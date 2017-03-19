using System;

namespace Noleggio.Web.Models
{
    public class CategoryViewModel:IBaseViewModel
    {
        public Guid Id { get; set; }

        public LoginViewModel LoginView { get; set; }
     
        public string Name { get; set; }
    }
}