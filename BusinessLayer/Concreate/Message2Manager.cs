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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _messageDal;
        public Message2Manager(IMessage2Dal messageDal)
        {
            _messageDal = messageDal;
        }
        public Message2 GetById(int id)
        {
            return _messageDal.GetByID(id);
        }

        public List<Message2> GetListAll()
        {
            return _messageDal.GetList();
        }

        public List<Message2> GetInboxListByUser(int id)
        {
            return _messageDal.GetListByUserForMsg(id);
        }

        public void TAdd(Message2 t)
        {
            _messageDal.Insert(t);
        }

        public void TDelete(Message2 t)
        {
            _messageDal.Delete(t);
        }

        public void TUpdate(Message2 t)
        {
            _messageDal.Update(t);
        }

        public Message2 GetInboxByUserID(int id)
        {
            return _messageDal.GetListByUserForMsgID(id);
        }
    }
}
