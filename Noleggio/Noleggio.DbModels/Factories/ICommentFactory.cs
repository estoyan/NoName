using System;

namespace Noleggio.DbModels.Factories
{
    interface ICommentFactory
    {
        Comment CreateComment(Guid user, Guid rentItem, string description);
    }
}
