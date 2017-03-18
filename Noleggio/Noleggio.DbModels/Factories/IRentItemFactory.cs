using System;

namespace Noleggio.DbModels.Factories
{
    interface IRentItemFactory
    {
        RentItem CreateRentItem(Guid user, Guid category, string description/*,string location*/);
    }
}
