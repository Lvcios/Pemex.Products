using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pemex.Products.API.Model.Request
{
    public class AdvertisementPageRequestModel: PageRequestModel
    {
        public string Title { get; set; }
        public string Type { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "El precio mínimo del producto debe igual o mayor a cero")]
        public decimal MinPrice { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "El precio máximo del producto debe igual o mayor a cero")]
        public decimal MaxPrice { get; set; }
    }
}
