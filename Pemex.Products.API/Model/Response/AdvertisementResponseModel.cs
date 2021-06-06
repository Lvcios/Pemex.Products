using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pemex.Products.API.Model.Response
{
    public class AdvertisementResponseModel
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string PictureBase64 { get; set; }
    }
}
