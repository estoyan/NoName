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
using Noleggio.Common;

namespace Noleggio.Services
{
    public class RentItemService : NoleggioGenericService<RentItem>, IRentItemService
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

        public void Add(RentItemDtoModel item, IList<ImagesDtoModel> imageCollection)
        {
            var itemDb = mapper.Map<RentItem>(item);
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

        public int TotalPages()
        {
            var pagesCount = base.GetAll().Count();
            var result = 0;
            if (pagesCount % NoleggioConstants.PagingSize == 0)
            {
                result = pagesCount / NoleggioConstants.PagingSize;
            }
            else
            {
                result = result = pagesCount / NoleggioConstants.PagingSize + 1;
            }

            return result;
        }

        public List<RentItemDtoModel> GetRentItems(DateTime beginDate, DateTime endDate, Guid category, string filter, int page = 0)
        {
            return base.GetAll().Where(x =>x.IsDeleted==false
             && x.CategoryId == category
             && x.AvailableFrom >= beginDate
             && x.AvailableTo <= endDate
             || x.Description.Contains(filter)
             || x.Name.Contains(filter))
           .OrderBy(x => x.Name)
           .Skip(page * NoleggioConstants.PagingSize)
           .Take(NoleggioConstants.PagingSize)
           .ToList()
           .Select(x => mapper.Map<RentItemDtoModel>(x))
           .ToList();
        }

        public List<RentItemDtoModel> Recent(int amoutToTake)
        {
            return base.GetAll()
                .Where(x=>x.IsDeleted==false)
                .OrderBy(x => x.CreatedOn)
                .Take(amoutToTake)
                .ToList()
                .Select(x => mapper.Map<RentItemDtoModel>(x))
                .ToList();
        }


        public IList<RentItemDetaildDtoModel> All(bool isDeleted, int page)
        {
            return base.GetAll().Where(x => x.IsDeleted == isDeleted)
                        .Skip(page * NoleggioConstants.PagingSize)
                        .Take(NoleggioConstants.PagingSize)
                        .ToList()
                        .Select(x => this.mapper.Map<RentItemDetaildDtoModel>(x))
                        .ToList();
        }

        public IList<RentItemDetaildDtoModel> All(bool isDeleted, string filter, int page)
        {
            return base.GetAll().Where(x => x.IsDeleted == isDeleted
            && (x.Name.Contains(filter)
            || x.Description.Contains(filter)))
                        .Skip(page * NoleggioConstants.PagingSize)
                        .Take(NoleggioConstants.PagingSize)
                        .ToList()
                        .Select(x => this.mapper.Map<RentItemDetaildDtoModel>(x))
                        .ToList();
        }


        public IList<RentItemDetaildDtoModel> GetByItemName(string name, int page)
        {
            return base.GetAll().Select(x => x.Name.Contains(name))
            .Skip(page * NoleggioConstants.PagingSize)
                        .Take(NoleggioConstants.PagingSize)
                        .ToList()
                        .Select(x => this.mapper.Map<RentItemDetaildDtoModel>(x))
                        .ToList();
        }

    }
}
