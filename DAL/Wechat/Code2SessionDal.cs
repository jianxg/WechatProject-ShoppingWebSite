using Common;
using Model.WeChat;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Wechat
{
    public class Code2SessionDal
    {

        public bool Exists(string openid,out string Msg)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append(" select count(*) from Basic_WechatAccountInfo wai where wai.Openid=@openid ");
                SqlParameter[] parameters =
                {
                new SqlParameter("@Openid",SqlDbType.NVarChar,50)
            };
                parameters[0].Value = openid;
                Msg = "执行成功";
                return SqlHelper.Exists(str.ToString(), parameters);
            }
            catch (Exception ex)
            {
                Msg = ex.Message.ToString();
                return false;
            }

        }

        public bool Add(Code2SessionItem model, out string Msg)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("INSERT INTO [dbo].[Basic_WechatAccountInfo]([Openid],[session_key],[unionid],[CreateDate]=getdate(),[Creator],[UpdateDate]=getdate(),[Modifier])");
                str.Append("VALUES");
                str.Append("(@Openid,@session_key,@unionid,@CreateDate,@Creator,@UpdateDate,@Modifier)");
                SqlParameter[] parameters =
               {
                new SqlParameter("@Openid",SqlDbType.NVarChar,50),
                new SqlParameter("@session_key",SqlDbType.NVarChar,50),
                new SqlParameter("@unionid",SqlDbType.NVarChar,50),
                new SqlParameter("@Creator",SqlDbType.NVarChar,50),
                new SqlParameter("@Modifier",SqlDbType.NVarChar,50)
                };
                parameters[0].Value = model.Openid;
                parameters[1].Value = model.session_key;
                parameters[2].Value = model.unionid == null ? "" : model.unionid;
                parameters[3].Value = "system";
                parameters[4].Value = "system";

                int rows = SqlHelper.ExecteNonQuery(CommandType.Text, str.ToString(), parameters);

                bool bl = rows > 0 ? true : false;

                Msg = rows > 0 ? "执行成功" : "执行失败";

                return bl;
            }
            catch (Exception ex)
            {
                Msg = ex.Message.ToString();
                return false;
            }
        }

        /// <summary>
        /// 更新seesion_key
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public bool Update(Code2SessionItem model, out string Msg)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("update Basic_WechatAccountInfo set session_key=@session_key,UpdateDate=getdate() where openid=@openid ");
                SqlParameter[] parameters =
                               {
                new SqlParameter("@session_key",SqlDbType.NVarChar,50),
                new SqlParameter("@openid",SqlDbType.NVarChar,50),
                };
                parameters[0].Value = model.session_key;
                parameters[1].Value = model.Openid;

                int rows = SqlHelper.ExecteNonQuery(CommandType.Text, str.ToString(), parameters);

                Msg = rows > 0 ? "执行成功" : "执行失败";
                bool bl = rows > 0 ? true : false;
                return bl;
            }
            catch (Exception ex)
            {
                Msg = ex.Message.ToString();
                return false;
            }
        }

    }
}
