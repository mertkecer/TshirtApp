using System;
using System.Collections.Generic;

#nullable disable

namespace Tshirt.Entities.Entities
{
    public partial class Tshirt
    {
        public Tshirt()
        {
            TshirtImages = new HashSet<TshirtImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TshirtImage> TshirtImages { get; set; }
    }
}
