using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tshirt.API.ViewModels
{
    public class TshirtListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfColor { get; set; }
        public int NumberOfFabric { get; set; }
        public int NumberOfImage { get; set; }
    }
}
