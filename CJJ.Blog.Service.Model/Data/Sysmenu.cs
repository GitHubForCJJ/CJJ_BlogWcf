//-----------------------------------------------------------------------------------
// <copyright file="Sysmenu.cs" company="Go Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : chenjianjun
// * fileName : Sysmenu.cs
// * history  : created by chenjianjun 2019-07-25 17:28:39
// </copyright>
//-----------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace CJJ.Blog.Service.Models.Data
{
    /// <summary>
    /// Sysmenu
    /// </summary>
    [DataContract]
    public class Sysmenu
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
		/// 菜单名称
		/// </summary>
		[DataMember]
		public string Menuname { get; set;}

		/// <summary>
		/// 菜单备注
		/// </summary>
		[DataMember]
		public string Menuremark { get; set;}

		/// <summary>
		/// 菜单连接
		/// </summary>
		[DataMember]
		public string MenuUrl { get; set;}

		/// <summary>
		/// 菜单icon
		/// </summary>
		[DataMember]
		public string Menuicon { get; set;}

		/// <summary>
		/// 菜单显示顺序
		/// </summary>
		[DataMember]
		public int Menusort { get; set;}

		/// <summary>
		/// 上级id
		/// </summary>
		[DataMember]
		public int Fatherid { get; set;}


        /*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
