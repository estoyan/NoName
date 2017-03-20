using System;

namespace Noleggio.Web.Models
{
    public class CategoryViewModel:BaseViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}