using DAL.Wechat;
using Model.WeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.WeChat
{
    public class Code2SessionServer
    {
        Code2SessionDal dal = new Code2SessionDal();

        public bool Add(Code2SessionItem model,out string Msg)
        {
            return dal.Add(model, out Msg); 
        }

        public bool Exists(string openid, out string Msg)
        {
            return dal.Exists(openid,out Msg);
        }

        public bool Update(Code2SessionItem model, out string Msg)
        {
            return dal.Update(model, out Msg);
        }
    }
}
