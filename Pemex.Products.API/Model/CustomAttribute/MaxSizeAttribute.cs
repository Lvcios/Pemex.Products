using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pemex.Products.API.Model.CustomAttribute
{
    public class MaxSizeAttribute: ValidationAttribute
    {
        public int MaxSizeInKb { get; set; }
        public MaxSizeAttribute(int SizeInKb)
        {
            MaxSizeInKb = SizeInKb;
        }

        public override bool IsValid(object value)
        {
            var file = (IFormFile)value;
            return file.Length/1024 < MaxSizeInKb;
        }
    }
}
