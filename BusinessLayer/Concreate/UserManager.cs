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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal= userDal;

        }


        public User GetById(int id)
        {
            return _userDal.GetByID(id);
        }

        public List<User> GetListAll()
        {
            return _userDal.GetList();
        }

        public void TAdd(User t)
        {
            _userDal.Insert(t);
        }

        public void TDelete(User t)
        {
            _userDal.Delete(t);
        }

        public void TUpdate(User t)
        {
            _userDal.Update(t);
        }
    }
}
