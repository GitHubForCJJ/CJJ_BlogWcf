using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CJJ.Blog.Service.Models.View
{
    /// <summary>
    /// 操作日志模板
    /// </summary>
    [DataContract]
    public class OpertionUser
    {
        /// <summary>
        /// 操作者账户
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [DataMember]
        public string UserId { get; set; }

        /// <summary>
        /// 操作者姓名
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 操作者客户端Ip
        /// </summary>
        /// <value>
        /// The user client ip.
        /// </value>
        [DataMember]
        public string UserClientIp { get; set; }
    }
}
