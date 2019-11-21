using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CountyServer
    {
        CountyDal dal = new CountyDal();
        public object GetData()
        {
            return dal.GetData();
        }

        public bool Add(CountyItem model)
        {
            return dal.Add(model);
        }
    }
}
