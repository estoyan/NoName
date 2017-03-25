using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Noleggio.Web.Models
{
    public class SearchViewModel:BaseViewModel
    {
        [Display(Name = "Критерии")]
        public string Filter { get; set; }

        [Display(Name = "Град")]
        public Guid CategoryId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Начална Дата")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Крайна Дата")]
        public DateTime EndDate { get; set; }

    }
}