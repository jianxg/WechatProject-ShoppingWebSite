using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 服务返回的结果集
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResult<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public string Code { get; set; }

        public T Result { get; set; }
    }
}
