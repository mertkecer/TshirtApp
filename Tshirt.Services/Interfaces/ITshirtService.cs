using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tshirt.Entities.Entities;

namespace Tshirt.Services.Interfaces
{
    public interface ITshirtService
    {
        IEnumerable<Tshirt.Entities.Entities.Tshirt> GetAll();
        Tshirt.Entities.Entities.Tshirt GetTshirtById(int id);
        List<TshirtImage> GetTshirtImagesById(int id);
        Tshirt.Entities.Entities.TshirtImage GetTshirtImageById(int id);
        void DeleteImage(int id);
        void AddImage(TshirtImage tshirtImage);
        IEnumerable<EnmColor> GetEnmColors();
        IEnumerable<EnmFabric> GetEnmFabrics();
    }
}
