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
    public class HomeAddressController : ApiController
    {
        public object GetHomeAddressData()
        {
            HomeAddressServer bll = new HomeAddressServer();
            //string resultStr = JsonConvert.SerializeObject(bll.GetHomeAddressData());
            return bll.GetHomeAddressData();
        }


        //public object GetData()
        //{
        //    ProvinceServer bll = new ProvinceServer();
        //    return bll.GetData();
        //}


        //// POST api/values
        //[HttpPost]
        //public bool AddModel(ProvinceItem model)
        //{ 
        //    ProvinceServer bll = new ProvinceServer();
        //    return bll.Add(model);
        //}
    }
}
