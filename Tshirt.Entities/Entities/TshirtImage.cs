using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Tshirt.Entities.Entities
{
    public partial class TshirtImage
    {
        public int Id { get; set; }
        public int TshirtId { get; set; }
        public int ColorId { get; set; }
        public int FabricId { get; set; }
        public string ImagePath { get; set; }

        public virtual EnmColor Color { get; set; }
        public virtual EnmFabric Fabric { get; set; }
        public virtual Tshirt Tshirt { get; set; }
    }
}
