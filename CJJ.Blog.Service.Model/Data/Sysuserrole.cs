//-----------------------------------------------------------------------------------
// <copyright file="Sysuserrole.cs" company="Go Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : chenjianjun
// * fileName : Sysuserrole.cs
// * history  : created by chenjianjun 2019-07-25 17:28:39
// </copyright>
//-----------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace CJJ.Blog.Service.Models.Data
{
    /// <summary>
    /// Sysuserrole
    /// </summary>
    [DataContract]
    public class Sysuserrole
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
		/// 用户id
		/// </summary>
		[DataMember]
		public string Userid { get; set;}

		/// <summary>
		/// 角色id
		/// </summary>
		[DataMember]
		public string Roleid { get; set;}

		/// <summary>
		/// 0员工，1是会员
		/// </summary>
		[DataMember]
		public int UserType { get; set;}


        /*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
