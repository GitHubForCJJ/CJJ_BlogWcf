using CJJ.Blog.Service.Models.Data;
using FastDev.Common.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CJJ.Blog.Service.Model.View
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class SysLoginUser : Result
    {
        [DataMember]
        public string Token { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        [DataMember]
        public string TokenExpiration { get; set; }
        /// <summary>
        /// 员工对象
        /// </summary>
        [DataMember]
        public Employee Model { get; set; }
        /// <summary>
        /// 用户权限列表
        /// </summary>
        [DataMember]
        public UserAuthorMenu UserAuthorMenu { get; set; }
    }
}
