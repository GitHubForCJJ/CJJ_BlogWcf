//-----------------------------------------------------------------------------------
// <copyright file="Bloginfo.cs" company="Go Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : chenjianjun
// * fileName : Bloginfo.cs
// * history  : created by chenjianjun 2019-06-14 15:52:46
// </copyright>
//-----------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace CJJ.Blog.Service.Models.Data
{
    /// <summary>
    /// Bloginfo
    /// </summary>
    [DataContract]
    public class Bloginfo
    {
        
		/// <summary>
		/// 编号,数据库自增本表唯一
		/// </summary>
		[DataMember]
		public int KID { get; set;}

		/// <summary>
		/// 状态,0正常数据 1已禁用
		/// </summary>
		[DataMember]
		public int States { get; set;}

		/// <summary>
		/// 删除,0未删除 1已删除
		/// </summary>
		[DataMember]
		public int IsDeleted { get; set;}

		/// <summary>
		/// 添加用户
		/// </summary>
		[DataMember]
		public string CreateUserId { get; set;}

		/// <summary>
		/// 创建者
		/// </summary>
		[DataMember]
		public string CreateUserName { get; set;}

		/// <summary>
		/// 创建时间
		/// </summary>
		[DataMember]
		public DateTime CreateTime { get; set;}

		/// <summary>
		/// 修改用户Id
		/// </summary>
		[DataMember]
		public string UpdateUserId { get; set;}

		/// <summary>
		/// 修改者
		/// </summary>
		[DataMember]
		public string UpdateUserName { get; set;}

		/// <summary>
		/// 更新时间
		/// </summary>
		[DataMember]
		public DateTime UpdateTime { get; set;}

		/// <summary>
		/// 扩展1,
		/// </summary>
		[DataMember]
		public int Extend1 { get; set;}

		/// <summary>
		/// 扩展2,
		/// </summary>
		[DataMember]
		public int Extend2 { get; set;}

		/// <summary>
		/// 扩展3,
		/// </summary>
		[DataMember]
		public int Extend3 { get; set;}

		/// <summary>
		/// 扩展4,
		/// </summary>
		[DataMember]
		public string Extend4 { get; set;}

		/// <summary>
		/// 扩展5,
		/// </summary>
		[DataMember]
		public string Extend5 { get; set;}

		/// <summary>
		/// 扩展6,
		/// </summary>
		[DataMember]
		public string Extend6 { get; set;}

		/// <summary>
		/// 短标题
		/// </summary>
		[DataMember]
		public string Title { get; set;}
        /// <summary>
        /// 长标题
        /// </summary>
        [DataMember]
        public string DetailTitle { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DataMember]
		public int Type { get; set;}

		/// <summary>
		/// 是否置顶
		/// </summary>
		[DataMember]
		public int IsTop { get; set;}

		/// <summary>
		/// 是否私密不显示
		/// </summary>
		[DataMember]
		public int IsPrivate { get; set;}

		/// <summary>
		/// 版本号，乐观锁
		/// </summary>
		[DataMember]
		public string Vesion { get; set;}

		/// <summary>
		/// 是否原创
		/// </summary>
		[DataMember]
		public int IsOriginal { get; set;}
        /// <summary>
        /// blog图片
        /// </summary>
        [DataMember]
        public string Blogimg { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [DataMember]
        public string Sorc { get; set; }


        /*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
