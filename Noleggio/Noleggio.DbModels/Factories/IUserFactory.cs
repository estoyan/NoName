using System;

namespace Noleggio.DbModels.Factories
{
   public  interface IUserFactory
    {
        User CreateUser(Guid aspNetUserId, string email, string firstName, string lastName, DateTime dateOfBirth, string city, string address);
    }
}
