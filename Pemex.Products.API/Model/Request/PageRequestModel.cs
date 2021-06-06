using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pemex.Products.API.Model.Request
{
    public class PageRequestModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El número de página debe ser mayor a 1")]
        public int Page { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El tamaño de página debe ser mayor a 1")]
        public int SizePage { get; set; }
    }
}
