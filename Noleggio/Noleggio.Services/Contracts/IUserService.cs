using Noleggio.DbModels;

namespace Noleggio.Services.Contracts
{
    public interface IUserService:INoleggioGenericService<User>
    {
        User GetByUserName(string name);
    }
}
