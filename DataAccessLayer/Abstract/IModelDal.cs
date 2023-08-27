using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IModelDal : IGenericDal<Model>
    {
        public List<Model> ListModelWithCategory();
        public List<Model> ListModelWithBrand();
        public List<Model> ListModelWithSeries();

    }
}
