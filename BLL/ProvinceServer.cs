using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProvinceServer
    {
        ProvinceDal dal = new ProvinceDal();
        public object GetData()
        {
            return dal.GetData();
        }

        public bool Add(ProvinceItem model)
        {
            return dal.Add(model);
        }

    }
}
