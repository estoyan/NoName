using System;

namespace Noleggio.DbModels.Factories
{
    interface IRatingFactory
    {
        Rating CreateRating(Guid fromUser, Guid toUser, double rate);
    }
}
