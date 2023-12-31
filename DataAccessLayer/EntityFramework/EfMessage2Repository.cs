﻿using DataAccessLayer.Abstract;
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
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetListByUserForMsg(int id)
        {
            using(var c =new Context())
            {
                return c.Message2s.Include(x => x.SenderUser).Where(y => y.ReceiverID == id).ToList();
            }
        }

        public Message2 GetListByUserForMsgID(int id)
        {
            using (var c = new Context())
            {
                return c.Message2s.Include(x => x.SenderUser).Where(y => y.MessageID == id).FirstOrDefault();
            }
        }

        public List<Message2> ListMessageAllWithUsers()
        {
            using (var c = new Context())
            {
                return c.Message2s.Include(x => x.SenderUser).Include(z=>z.ReceiverUser).ToList();
            }
        }
    }
}
