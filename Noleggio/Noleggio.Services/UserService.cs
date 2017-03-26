using Noleggio.Common;
using Noleggio.DbModels;
using Noleggio.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noleggio.Data.Contracts;
using Noleggio.Common.Contracts;
using Bytes2you.Validation;
using Noleggio.DtoModels;

namespace Noleggio.Services
{
    public class UserService : NoleggioGenericService<User>, IUserService
    {
        private IMapingService mappingService;
        public UserService(IGenericEfRepository<User> repository, IUnitOfWork unitOfWork, IMapingService mappingService) : base(repository, unitOfWork)
        {
            Guard.WhenArgument(mappingService, nameof(mappingService)).IsNull().Throw();
            this.mappingService = mappingService;
        }

        public List<UserDtoModel> All(bool isDeleted)
        {
            //return mapper.Map<RentItemDetaildDtoModel>(base.GetById(rentItem));

            return mappingService.Map<List<UserDtoModel>>(
                base.GetAll()
                .Where(x => x.IsDeleted == isDeleted)
                .ToList());
                
                 //.Select(x => this.mappingService.Map<UserDtoModel>(x))
                 //.ToList();
        }

        public List<UserDtoModel> All(bool isDeleted, string filter)
        {
            Guard.WhenArgument(filter, filter).IsNullOrEmpty().Throw();

            return mappingService.Map<List<UserDtoModel>>(base.GetAll().Where(x => x.IsDeleted == isDeleted
                                  && (x.UserName.Contains(filter)
                                  || x.FirstName.Contains(filter)
                                  || x.LastName.Contains(filter)))
                                  .ToList());
                        //.Select(x => this.mappingService.Map<UserDtoModel>(x))
                        //.ToList();
        }


        public List<UserDtoModel> GetByUserName(string name)
        {
            Guard.WhenArgument(name, name).IsNullOrEmpty().Throw();

            return mappingService.Map<List<UserDtoModel>>(base.GetAll().Select(x => x.UserName.Contains(name)
                                || x.FirstName.Contains(name)
                                || x.LastName.Contains(name)).
                                ToList());
                       //.Select(x => this.mappingService.Map<UserDtoModel>(x))
                       // .ToList()
                       // ;
        }
    }
}
