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
    public class ManagerManager : IManagerService
    {
        IManagerDal _managerDal;
        public ManagerManager(IManagerDal managerDal)
        {
            _managerDal = managerDal;
        }

        public Manager GetById(int id)
        {
            return _managerDal.GetByID(id);
        }

        public List<Manager> GetListAll()
        {
            return _managerDal.GetList();
        }

        public void TAdd(Manager t)
        {
            _managerDal.Insert(t);
        }

        public void TDelete(Manager t)
        {
            _managerDal.Delete(t);
        }

        public void TUpdate(Manager t)
        {
            _managerDal.Update(t);
        }
    }
}
