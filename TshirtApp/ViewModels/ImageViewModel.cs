using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tshirt.API.ViewModels
{
    public class ImageViewModel
    {
        public int TshirtId { get; set; }
        public int ColorId { get; set; }
        public int FabricId { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }

    }
}
