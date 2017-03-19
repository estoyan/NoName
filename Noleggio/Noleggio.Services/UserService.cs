using Noleggio.DbModels;
using Noleggio.Data.Contracts;
using Noleggio.Services.Contracts;
using System;

namespace Noleggio.Services
{
   public  class UserService : NoleggioGenericService<User>, IUserService
    {
        public UserService(IGenericEfRepository<User> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {

        }

        public User GetByUserName(string name)
        {
            var user = base.GetAll(x => (x.UserName == name));
            return user.GetEnumerator().Current;
        }
    }
}
