using Noleggio.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Noleggio.Services
{
    public class ImageService:IImageService
    {

        public string SaveRentItemImage(HttpPostedFileBase file, string folder)
        {

            //if (file != null && file.ContentLength > 0)
            //{
                var imageLocation = string.Format("~/Images/RentItem/{0}/", folder);
                if (!Directory.Exists(imageLocation))
                {
                    Directory.CreateDirectory(imageLocation);
                }
            var path = Path.Combine(imageLocation, file.FileName + DateTime.Now.Second);
            file.SaveAs(path);
            //}
            return path;
        }
    }
}
