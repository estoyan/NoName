using Noleggio.DbModels;
using Noleggio.DtoModels;
using System.Collections.Generic;
using System.Linq;

namespace Noleggio.Services.Contracts
{
    public interface IUserService:INoleggioGenericService<User>
    {
        List<UserDtoModel> GetByUserName(string name);
        List<UserDtoModel> All(bool isDelted, string filter);
        List<UserDtoModel> All(bool isDelted);
    }
}
