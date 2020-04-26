
using CJJ.Blog.Service.Model.Data;
using CJJ.Blog.Service.Models.Data;
using FastDev.Common.Code;
using System.Runtime.Serialization;

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
        /// 员工对象
        /// </summary>
        [DataMember]
        public Member MemberModel { get; set; }
        /// <summary>
        /// 用户权限列表
        /// </summary>
        [DataMember]
        public UserAuthorMenu UserAuthorMenu { get; set; }
        /// <summary>
        /// 是否加盟
        /// </summary>
        [DataMember]
        public bool DataIsEncrypt { get; set; }
    }
}
