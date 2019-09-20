using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CJJ.Blog.Service.Models.Data
{
    /// <summary>
    /// 微信用户
    /// </summary>
    [DataContract]
    public class WxUser
    {
        /// <summary>
        /// 编号,数据库自增本表唯一
        /// </summary>
        [DataMember]
        public int KID { get; set; }

        /// <summary>
        /// 状态,0正常数据 1已禁用
        /// </summary>
        [DataMember]
        public int States { get; set; }

        /// <summary>
        /// 删除,0未删除 1已删除
        /// </summary>
        [DataMember]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 添加用户
        /// </summary>
        [DataMember]
        public string CreateUserId { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        [DataMember]
        public string CreateUserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改用户Id
        /// </summary>
        [DataMember]
        public string UpdateUserId { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        [DataMember]
        public string UpdateUserName { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 扩展1,
        /// </summary>
        [DataMember]
        public int Extend1 { get; set; }

        /// <summary>
        /// 扩展2,
        /// </summary>
        [DataMember]
        public int Extend2 { get; set; }

        /// <summary>
        /// 扩展3,
        /// </summary>
        [DataMember]
        public int Extend3 { get; set; }

        /// <summary>
        /// 扩展4,
        /// </summary>
        [DataMember]
        public string Extend4 { get; set; }

        /// <summary>
        /// 扩展5,
        /// </summary>
        [DataMember]
        public string Extend5 { get; set; }

        /// <summary>
        /// 扩展6,
        /// </summary>
        [DataMember]
        public string Extend6 { get; set; }

        [DataMember]
        public string Openid { get; set; }
        [DataMember]
        public string NickName { get; set; }
        [DataMember]
        public string Sex { get; set; }
        /// <summary>
        /// 用户个人资料填写的省份
        /// </summary>
        [DataMember]
        public string Province { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Country { get; set; }
        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空。若用户更换头像，原有头像URL将失效。
        /// </summary>
        [DataMember]
        public string HeadImgUrl { get; set; }
        /// <summary>
        /// 用户特权信息，json 数组，如微信沃卡用户为（chinaunicom
        /// </summary>
        [DataMember]
        public string Privilege { get; set; }
        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。
        /// </summary>
        [DataMember]
        public string Unionid { get; set; }
    }
}
