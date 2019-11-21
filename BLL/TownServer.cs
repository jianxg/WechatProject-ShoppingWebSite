using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TownServer
    {
        TownDal dal = new TownDal();
        public object GetData()
        {
            return dal.GetData();
        }

        public bool Add(TownItem model)
        {
            return dal.Add(model);
        }

    }
}
