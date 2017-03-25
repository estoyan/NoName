using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Noleggio.Services.Contracts
{
    public interface IImageService
    {
        string SaveRentItemImage(HttpPostedFileBase file, string folder);
    }
}
