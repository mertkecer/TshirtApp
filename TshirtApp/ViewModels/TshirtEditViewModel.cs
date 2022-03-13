using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tshirt.API.ViewModels
{
    public class TshirtEditViewModel
    {
        public int TshirtId { get; set; }
        public string Name { get; set; }
        public List<TshirtImageViewModel> TshirtImages { get; set; }
        public List<EnumViewModel> Colors { get; set; }
        public List<EnumViewModel> Fabrics { get; set; }
    }
}
