using Microsoft.AspNetCore.Http;
using Pemex.Products.API.Model.CustomAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pemex.Products.API.Model.Request
{
    public class AdvertisementRequestModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Image]
        [MaxSize(512, ErrorMessage = "El tamaño de la imagen debe ser de 512kb o menor")]
        public IFormFile Picture { get; set; }
    }
}
