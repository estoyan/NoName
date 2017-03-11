using System;

namespace Noleggio.DbModels.Factories
{
    interface IUserFactory
    {
        User CreateUser(Guid aspNetUserId, string email, string firstName, string lastName, DateTime dateOfBirth, string city, string address);
    }
}
