using Noleggio.DbModels;
using Noleggio.DtoModels;
using Noleggio.DtoModels.RentItems;
using System;
using System.Collections.Generic;

namespace Noleggio.Services.Contracts
{
  public interface IRentItemService:INoleggioGenericService<RentItem>
    {
        void Add(RentItemDtoModel item);
        void Add(RentItemDtoModel item, IList<ImagesDtoModel> imageCollection);
        RentItemDetaildDtoModel GetRentItemById(Guid rentItem);
    }
}
