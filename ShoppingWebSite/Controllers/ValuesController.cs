using BLL;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingWebSite.Controllers
{

    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        public object GetData()
        {
            ProvinceServer bll = new ProvinceServer();
            return bll.GetData();
        }


        // POST api/values
        [HttpPost]
        public bool AddModel(ProvinceItem model)
        {
            ProvinceServer bll = new ProvinceServer();
            return bll.Add(model);
        }

        [HttpGet]
        public bool AddStr(string strQuery)
        {
            ProvinceItem model = new ProvinceItem();
            model = JsonConvert.DeserializeObject<ProvinceItem>(strQuery);
            ProvinceServer bll = new ProvinceServer();
            return bll.Add(model);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
