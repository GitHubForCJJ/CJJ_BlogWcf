//-----------------------------------------------------------------------------------
// <copyright file="Logintoken.cs" company="Go Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : chenjianjun
// * fileName : Logintoken.cs
// * history  : created by chenjianjun 2019-06-27 15:21:32
// </copyright>
//-----------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace CJJ.Blog.Service.Models.Data
{
    /// <summary>
    /// Logintoken
    /// </summary>
    [DataContract]
    public class Logintoken
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
		/// 创建时间
		/// </summary>
		[DataMember]
		public DateTime CreateTime { get; set;}

		/// <summary>
		/// token
		/// </summary>
		[DataMember]
		public string Token { get; set;}

		/// <summary>
		/// Token有效期到期时间
		/// </summary>
		[DataMember]
		public string TokenExpiration { get; set;}

		/// <summary>
		/// 登录者id
		/// </summary>
		[DataMember]
		public string LoginUserId { get; set;}

		/// <summary>
		/// 登录人的账号
		/// </summary>
		[DataMember]
		public string LoginUserAccount { get; set;}

		/// <summary>
		/// 登录账户类型
		/// </summary>
		[DataMember]
		public int LoginUserType { get; set;}

		/// <summary>
		/// 登录设备ip
		/// </summary>
		[DataMember]
		public string IpAddr { get; set;}

		/// <summary>
		/// 登录平台
		/// </summary>
		[DataMember]
		public int PlatForm { get; set;}

		/// <summary>
		/// 是否退出登录0未退，1退出
		/// </summary>
		[DataMember]
		public int IsLogOut { get; set;}

		/// <summary>
		/// 登录结果
		/// </summary>
		[DataMember]
		public string LoginResult { get; set;}


        /*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
