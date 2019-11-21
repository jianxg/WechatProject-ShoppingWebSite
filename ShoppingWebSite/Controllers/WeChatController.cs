using BLL.WeChat;
using Model.WeChat;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingWebSite.Controllers
{
    public class WeChatController : ApiController
    {
        [HttpGet]
        public object GetCode([FromUri]GetUserInfoItem model)
        {
            string serviceAddress = "https://api.weixin.qq.com/sns/jscode2session?appid=" + model.appid + "&secret="
                + model.sercet + "&js_code=" + model.js_code + "&grant_type=authorization_code";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "GET";
            request.ContentType = "text/html;charset=utf-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, System.Text.Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            Code2SessionItem ci = JsonConvert.DeserializeObject<Code2SessionItem>(retString);
            if (ci.Openid != null)
            {
                var obj = new
                {
                    Code = "10000",
                    Data = ci.Openid,
                    Success = true
                };
                Formatting microsoftDataFormatSettings = default(Formatting);

                //执行成功后保存openid信息
                Code2SessionServer bll = new Code2SessionServer();
                string Msg = string.Empty;
                if (!bll.Exists(ci.Openid,out Msg))
                {
                    bll.Add(ci, out Msg);
                }
                else
                {
                    bll.Update(ci, out Msg);
                }
                return JsonConvert.SerializeObject(obj, microsoftDataFormatSettings);
            }
            else
            {
                var obj = new
                {
                    Code = ci.errcode,
                    Data = ci.errmsg,
                    Success = false
                };
                Formatting microsoftDataFormatSettings = default(Formatting);
                return JsonConvert.SerializeObject(obj, microsoftDataFormatSettings);
            }
        }
    }
}
