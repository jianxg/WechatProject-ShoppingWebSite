using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WeChat
{
    /// <summary>
    /// 登录凭证校验 返回数据对象
    /// </summary>
    public class Code2SessionItem
    {
        public string Openid { get; set; }

        /// <summary>
        /// 会话session
        /// </summary>
        public string session_key { get; set; }

        /// <summary>
        /// 用户在开放平台的唯一标识符，在满足 UnionID 下发条件的情况下会返回，详见 UnionID 机制说明。
        /// </summary>
        public string unionid { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        public int errcode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string errmsg { get; set; }

        public DateTime CreateDate { get; set; }
        public string Creator { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Modifier { get; set; }
    }
}
