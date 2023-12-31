﻿using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ISeriesDal : IGenericDal<Series>
    {
        List<Series> GetListBrandForSeries();
        List<Series> ListBrandWithCategory();

        public List<Series> LoadBra(int id);


    }
}
