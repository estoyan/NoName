using Noleggio.Common.Contracts;
using Noleggio.DbModels;

namespace Noleggio.DtoModels
{
    public class UserDtoModel: IMapFrom<User>
    {
        public string FirstName { get; set;}

    }
}