using Noleggio.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noleggio.Data.Contracts;
using Noleggio.Services.Contracts;
using Noleggio.DtoModels;
using Noleggio.Common.Contracts;
using Bytes2you.Validation;
using AutoMapper;
using System.Collections;
using Noleggio.DtoModels.RentItems;

namespace Noleggio.Services
{
    public class RentItemService :  NoleggioGenericService<RentItem>, IRentItemService
    {
        private IMapingService mapper;

        public RentItemService(IGenericEfRepository<RentItem> repository, IUnitOfWork unitOfWork, IMapingService mapper) 
            : base(repository, unitOfWork)
        {
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();
            this.mapper = mapper;
        }

        public void Add(RentItemDtoModel item)
        {
            base.Add(mapper.Map<RentItem>(item));
        }

        public void Add(RentItemDtoModel item, IList<ImagesDtoModel> imageCollection )
        {
            var itemDb=  mapper.Map<RentItem>(item);
            base.AddMany(itemDb);
            foreach (var image in imageCollection)
            {
                var imageDb = mapper.Map<Image>(image);
                imageDb.RentItem = itemDb;
                itemDb.Images.Add(imageDb);
            }
            base.UnitOfWork.Commit();
        }


        public RentItemDetaildDtoModel GetRentItemById(Guid rentItem)
        {
            return mapper.Map<RentItemDetaildDtoModel>(base.GetById(rentItem));
        }
    }
}
