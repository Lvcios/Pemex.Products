using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pemex.Products.API.Model.CustomAttribute
{
    public class ImageAttribute: ValidationAttribute
    {
        public string[] ValidImageMimeTypes = { "image/gif", "image/jpg", "image/jpeg", "image/image/svg+xml", "image/tiff", "image/bmp", "image/png" };
        public ImageAttribute()
        {
            
        }

        public override bool IsValid(object value)
        {
            var file = (IFormFile)value;
            return ValidImageMimeTypes.Any(m => m == file.ContentType);
        }
    }
}
