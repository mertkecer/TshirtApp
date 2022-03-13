using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tshirt.Entities.Context;
using Tshirt.Entities.Entities;
using Tshirt.Services.Interfaces;

namespace Tshirt.Services.Classes
{
    public class TshirtService : ITshirtService
    {
        private TshirtDbContext dbContext;

        public TshirtService(TshirtDbContext DbContext)
        {
            dbContext = DbContext;
        }
        public void AddImage(TshirtImage tshirtImage)
        {
            dbContext.Add(tshirtImage);
            dbContext.SaveChanges();
        }

        public void DeleteImage(int id)
        {
            var entity = GetTshirtImageById(id);
            dbContext.Set<Tshirt.Entities.Entities.TshirtImage>().Remove(entity);
            dbContext.SaveChanges();
        }

        public IEnumerable<Tshirt.Entities.Entities.Tshirt> GetAll()
        {
            return dbContext.Tshirts.Include("TshirtImages").ToList();
        }

        public Tshirt.Entities.Entities.Tshirt GetTshirtById(int id)
        {
            var result = dbContext.Tshirts.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }

        public TshirtImage GetTshirtImageById(int id)
        {
            return dbContext.Set<Tshirt.Entities.Entities.TshirtImage>().Find(id);
        }

        public IEnumerable<EnmColor> GetEnmColors()
        {
            var result = dbContext.EnmColors.ToList().OrderBy(x => x.Id);
            return result;
        }

        public IEnumerable<EnmFabric> GetEnmFabrics()
        {
            var result = dbContext.EnmFabrics.ToList().OrderBy(x => x.Id);
            return result;
        }

        public List<TshirtImage> GetTshirtImagesById(int id)
        {
            var result = dbContext.TshirtImages.Include("Tshirt").Where(x => x.TshirtId == id).Include(x => x.Color).Include(x => x.Fabric).ToList();
            return result;
        }
    }
}
