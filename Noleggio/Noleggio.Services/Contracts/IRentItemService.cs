using Noleggio.DbModels;
using Noleggio.DtoModels;
using Noleggio.DtoModels.RentItems;
using System;

namespace Noleggio.Services.Contracts
{
  public interface IRentItemService:INoleggioGenericService<RentItem>
    {
        void Add(RentItemDtoModel item);
        RentItemDetaildDtoModel GetRentItemById(Guid rentItem);
    }
}
