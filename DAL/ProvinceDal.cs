using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProvinceDal
    {
        public object GetData()
        {
            StringBuilder str = new StringBuilder();
            str.Append("select code,name from Province");
            DataTable ds= SqlHelper.ExecuteDataSet(SqlHelper.connectionString, CommandType.Text,str.ToString(), null).Tables[0];
            return ds;
        }

        public bool Add(ProvinceItem model)
        {
            StringBuilder str = new StringBuilder();
            str.Append("insert into Province values(@code,@name)");
            SqlParameter[] parameters =
            {
                new SqlParameter("@code",SqlDbType.NVarChar,50),
                new SqlParameter("@name",SqlDbType.NVarChar,50)
            };
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Name;
            int returnCount= int.Parse(SqlHelper.ExecteNonQuery(CommandType.Text, str.ToString(), parameters).ToString());
            if (returnCount>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
