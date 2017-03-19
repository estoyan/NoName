using Noleggio.DbModels;
using Noleggio.DtoModels;
using System.Collections.Generic;

namespace Noleggio.Services.Contracts
{
    public interface ICategoryService :INoleggioGenericService<Category>
    {
        IEnumerable<CategoryDtoModel> GetAllCategories();
    }
}
