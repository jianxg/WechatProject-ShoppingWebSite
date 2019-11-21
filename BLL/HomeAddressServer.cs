using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HomeAddressServer
    {
        HomeAddressDal dal = new HomeAddressDal();
        public object GetHomeAddressData()
        {
            return dal.GetHomeAddressData();
        }
    }
}
