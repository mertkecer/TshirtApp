using System;
using System.Collections.Generic;

#nullable disable

namespace Tshirt.Data.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ColorId { get; set; }
        public int? FabricId { get; set; }

        public virtual EnmColor Color { get; set; }
        public virtual EnmFabric Fabric { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
