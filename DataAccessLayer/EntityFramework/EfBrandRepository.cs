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
    public class EfBrandRepository : GenericRepository<Brand>, IBrandDal
    {
        public List<Brand> GetListCategoryForBrand()
        {
            using (var c=new Context())
            {
                return c.Brands.Include(x=>x.Category).ToList();               
            }
        }

        public List<Brand> LoadCat(int id)
        {
            using (var c = new Context())
            {
                return c.Brands.Where(x => x.CategoryID == id).ToList();
            }
        }
    }
}
