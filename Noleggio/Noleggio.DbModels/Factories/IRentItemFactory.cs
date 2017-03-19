using System;

namespace Noleggio.DbModels.Factories
{
    interface IRentItemFactory
    {
        RentItem CreateRentItem(string user, Guid category, string description/*,string location*/);
    }
}
