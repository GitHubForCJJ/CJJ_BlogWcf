//-----------------------------------------------------------------------------------
// <copyright file="ArticlePraise.cs" company="Go Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : chenjianjun
// * fileName : ArticlePraise.cs
// * history  : created by chenjianjun 2019-06-27 15:21:33
// </copyright>
//-----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Text;
using FastDev.DbBase;
using FastDev.DBFactory;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CJJ.Blog.Service.Repository
{
    /// <summary>
    /// ArticlePraise 仓储操作类
    /// </summary>
    /// <seealso cref="FastDev.DbBase.BaseQuery" />
	public class AccessRepository : BaseQuery
    {
        /// <summary>
        /// 单利实体操作对象
        /// </summary>
        public static AccessRepository Instance = new AccessRepository();

        /// <summary>
        /// 构造函数
        /// </summary>
        private AccessRepository()
        {
            this.IsAddIntoCache = true;
            this.TableName = "Access";
            this.OrderbyFields = "KID DESC";
            this.KeyField = "KID";
        }

		/// <summary>
        /// 带事务执行的构造函数
        /// </summary>
        /// <param name="dbconn">The dbconn.</param>
        public AccessRepository(DBOperator dbConn)
        {
            this.IsAddIntoCache = false;
            this.TableName = "Access";
            this.OrderbyFields = "KID DESC";
            this.KeyField = "KID";
            base.DbConn = dbConn;
        }

		/*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
