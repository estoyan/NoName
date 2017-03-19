using Noleggio.DbModels;
using Noleggio.DtoModels;

namespace Noleggio.Services.Contracts
{
  public interface IRentItemService:INoleggioGenericService<RentItem>
    {
        void Add(RentItemDtoModel item);
    }
}
