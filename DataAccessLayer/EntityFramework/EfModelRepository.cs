using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntitiyLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfModelRepository:GenericRepository<Model>,IModelDal
    {
        public List<Model> ListModelWithCategory()
        {
            using (var c = new Context())
            {
                return c.Models.Include(x => x.Series.Brand.Category).ToList();
            }
        }

        public List<Model> ListModelWithBrand()
        {
            using (var c = new Context())
            {
                var y = c.Models.Include(x => x.Series.Brand).ToList();
                return y;
            }
        }

        public List<Model> ListModelWithSeries()
        {
            using (var c = new Context())
            {
                return c.Models.Include(x => x.Series).ToList();
            }
        }
        public List<Model> LoadSer(int id)
        {
            using (var c = new Context())
            {
                return c.Models.Where(x => x.SeriesID == id).ToList();
            }
        }


    }
}
