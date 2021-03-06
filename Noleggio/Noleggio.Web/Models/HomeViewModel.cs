﻿using Noleggio.DtoModels.RentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Noleggio.Web.Models
{
    public class HomeViewModel:BaseViewModel
    {
        public SearchViewModel Search {get;set;}
        public List<RentItemDtoModel> RecentItems { get; set;}
    }
}