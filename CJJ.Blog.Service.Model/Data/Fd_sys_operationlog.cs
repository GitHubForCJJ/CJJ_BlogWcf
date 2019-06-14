//-----------------------------------------------------------------------------------
// <copyright file="Fd_sys_operationlog.cs" company="Go Enterprises">
// * copyright: (C) 2018 www.codemain.cn
// * version  : 1.0.0.0
// * author   : meteor
// * fileName : Fd_sys_operationlog.cs
// * history  : created by meteor 2018-10-19 16:52:42
// </copyright>
//-----------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace CJJ.Blog.Service.Models.Data
{
    /// <summary>
    /// Fd_sys_operationlog
    /// </summary>
    [DataContract]
    public class Fd_sys_operationlog
    {
        
		/// <summary>
		/// 序号,ID自增编号,本表唯一
		/// </summary>
		[DataMember]
		public int KID { get; set;}

		/// <summary>
		/// 数据状态,0启用 1禁用
		/// </summary>
		[DataMember]
		public int States { get; set;}

		/// <summary>
		/// 状态,0未删除 1已删除
		/// </summary>
		[DataMember]
		public int Deleted { get; set;}

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
		/// 数据对象,可以存储表名
		/// </summary>
		[DataMember]
		public string TableName { get; set;}

		/// <summary>
		/// 对象主键,操作对象的主键字段名称 默认KID
		/// </summary>
		[DataMember]
		public string TablePriKeyField { get; set;}

		/// <summary>
		/// 主键值,操作对象数据的值
		/// </summary>
		[DataMember]
		public string TablePriKeyValue { get; set;}

		/// <summary>
		/// 操作者IP地址
		/// </summary>
		[DataMember]
		public string IpAddr { get; set;}

		/// <summary>
		/// 请求数据,方便查看对象 可以为Json对象
		/// </summary>
		[DataMember]
		public string ReqData { get; set;}


        /// <summary>
        /// 操作前数据内容,Json对象
        /// </summary>
        [DataMember]
        public string ResOldData { get; set; }

        /// <summary>
        /// 操作后数据结果,Json对象,操作前后 数据记录
        /// </summary>
        [DataMember]
		public string ResResult { get; set;}

        /// <summary>
        /// 日志类型,1添加 2编辑 3修改 4常规日志
        /// </summary>
        [DataMember]
		public int OperType { get; set;}

		/// <summary>
		/// 操作结果,0成功 1失败 
		/// </summary>
		[DataMember]
		public int OperResult { get; set;}

		/// <summary>
		/// 日志内容
		/// </summary>
		[DataMember]
		public string LogContent { get; set;}


        /*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
