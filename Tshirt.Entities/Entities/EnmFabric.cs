using System;
using System.Collections.Generic;

#nullable disable

namespace Tshirt.Entities.Entities
{
    public partial class EnmFabric
    {
        public EnmFabric()
        {
            TshirtImages = new HashSet<TshirtImage>();
        }

        public int Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<TshirtImage> TshirtImages { get; set; }
    }
}
