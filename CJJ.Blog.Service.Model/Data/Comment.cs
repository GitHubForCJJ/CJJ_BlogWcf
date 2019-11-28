using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CJJ.Blog.Service.Model.Data
{
    /// <summary>
    /// 评论表
    /// </summary>
    [DataContract]
    public class Comment
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

        /// <summary>
        /// 会员id
        /// </summary>
        [DataMember]
        public string Memberid { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        [DataMember]
        public string MemberName { get; set; }
        /// <summary>
        /// Blogid
        /// </summary>
        [DataMember]
        public string BlogNum { get; set; }
        /// <summary>
        /// 会话id
        /// </summary>
        [DataMember]
        public string Commentid { get; set; }
        /// <summary>
        /// 评论谁的id  为空指的是自己写的新评论  不为空则是 评论别人的评论
        /// </summary>
        [DataMember]
        public string ToMemberid { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [DataMember]
        public string Content { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [DataMember]
        public string Avatar { get; set; }
    }
}
