using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntitiyLayer.Concrete;
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
    }
}
