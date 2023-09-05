using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }


        public Model GetById(int id)
        {
            return _modelDal.GetByID(id);
        }

        public List<Model> GetListAll()
        {
            return _modelDal.GetList();
        }

        public void TAdd(Model t)
        {
            _modelDal.Insert(t);
        }

        public void TDelete(Model t)
        {
            _modelDal.Delete(t);
        }

        public void TUpdate(Model t)
        {
            _modelDal.Update(t);
        }

        public List<Model> GetListModelWithCategory()
        {
            return _modelDal.ListModelWithCategory();
        }

        public List<Model> GetListModelWithBrand()
        {
            return _modelDal.ListModelWithBrand();
        }

        public List<Model> GetListModelWithSeries()
        {
            return _modelDal.ListModelWithSeries();
        }

        public List<Model> LoadSeries(int id)
        {
            return _modelDal.LoadSer(id);
        }
    }
}
