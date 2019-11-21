using Common;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HomeAddressDal
    {
        public object GetHomeAddressData()
        {
            StringBuilder str = new StringBuilder();
            str.Append("select Code,Name from Province;select Code,Name from Town;select Code,Name from County;");
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.connectionString, CommandType.Text, str.ToString(), null);
            HomeAddressItem model = new HomeAddressItem();
            model.province_list = DataToEntityHelper<Model.ProvinceItem>.FillModel(ds.Tables[0]);
            model.city_list = DataToEntityHelper<Model.TownItem>.FillModel(ds.Tables[1]);
            model.county_list = DataToEntityHelper<Model.CountyItem>.FillModel(ds.Tables[2]);

            //SortedDictionary<object, object> obj = new SortedDictionary<object, object>();

            SortedList<string, object> obj = new SortedList<string, object>();
                
            Dictionary<int, string> dir1 = new Dictionary<int, string>();
            if (model.province_list.Count>0)
            {
                for (int i = 0; i < model.province_list.Count; i++)
                {
                    dir1.Add(model.province_list[i].Code, model.province_list[i].Name);
                }
            }
            obj.Add("province_list", dir1);

            Dictionary<int, string> dir2 = new Dictionary<int, string>();
            if (model.city_list.Count > 0)
            {
                for (int ij = 0; ij < model.city_list.Count; ij++)
                {
                    dir2.Add(model.city_list[ij].Code, model.city_list[ij].Name);
                }
            }

            obj.Add("city_list", dir2);

            Dictionary<int, string> dir3 = new Dictionary<int, string>();
            if (model.county_list.Count > 0)
            {
                for (int j = 0; j < model.county_list.Count; j++)
                {
                    dir3.Add(model.county_list[j].Code, model.county_list[j].Name);
                }
            }

            obj.Add("county_list", dir3);

            return obj;

        }

    }
}
