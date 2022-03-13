using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tshirt.API.ViewModels
{
    public class TshirtImageViewModel
    {
        public int Id { get; set; }
        public int TshirtId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int ColorId { get; set; }
        public int FabricId { get; set; }

    }
}
