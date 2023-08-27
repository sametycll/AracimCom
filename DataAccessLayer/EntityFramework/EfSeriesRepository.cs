using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntitiyLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfSeriesRepository : GenericRepository<Series>, ISeriesDal
    {
        public List<Series> ListBrandWithCategory()
        {
            using (var c = new Context())
            {
                return c.Seriess.Include(x => x.Brand.Category).ToList();
            }
        }

        public List<Series> GetListBrandForSeries()
        {
            using (var c = new Context())
            {
                return c.Seriess.Include(x => x.Brand).ToList();
            }
        }

        public List<Series> LoadBra(int id)
        {
            using (var c = new Context())
            {
                return c.Seriess.Where(x => x.BrandID == id).ToList();
            }
        }
    }
}
