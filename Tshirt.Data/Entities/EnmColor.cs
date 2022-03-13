using System;
using System.Collections.Generic;

#nullable disable

namespace Tshirt.Data.Entities
{
    public partial class EnmColor
    {
        public EnmColor()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
