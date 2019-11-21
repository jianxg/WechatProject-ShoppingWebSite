using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HomeAddressItem
    {
        public List<ProvinceItem> province_list { get; set; }

        public List<TownItem> city_list { get; set; }

        public List<CountyItem> county_list { get; set; }
    }
}
