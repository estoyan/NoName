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
        int TotalPages();
        List<RentItemDtoModel> GetRentItems(DateTime beginDate, DateTime endDate, Guid category, string filter, int page = 0);
        List<RentItemDtoModel> Recent(int amoutToTake);
        IList<RentItemDetaildDtoModel> GetByItemName(string name, int page);
        IList<RentItemDetaildDtoModel> All(bool isDelted, string filter, int page);
        IList<RentItemDetaildDtoModel> All(bool isDelted, int page);


    }
}
