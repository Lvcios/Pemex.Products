using System;
using System.Collections.Generic;
using System.Text;

namespace Pemex.Products.Repository.CQRS.Advertisement.Model
{
    public class AdvertisementPageQueryModel
    {
        public int Page { get; set; }
        public int SizePage { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
