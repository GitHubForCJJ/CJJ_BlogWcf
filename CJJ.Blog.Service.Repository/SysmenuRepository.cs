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
using System.Linq;
using System.Text;
using FastDev.DbBase;
using FastDev.DBFactory;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CJJ.Blog.Service.Repository
{
    /// <summary>
    /// Sysmenu 仓储操作类
    /// </summary>
    /// <seealso cref="FastDev.DbBase.BaseQuery" />
	public class SysmenuRepository : BaseQuery
    {
        /// <summary>
        /// 单利实体操作对象
        /// </summary>
        public static SysmenuRepository Instance = new SysmenuRepository();

        /// <summary>
        /// 构造函数
        /// </summary>
        private SysmenuRepository()
        {
            this.IsAddIntoCache = true;
            this.TableName = "Sysmenu";
            this.OrderbyFields = "KID DESC";
            this.KeyField = "KID";
        }

		/// <summary>
        /// 带事务执行的构造函数
        /// </summary>
        /// <param name="dbconn">The dbconn.</param>
        public SysmenuRepository(DBOperator dbConn)
        {
            this.IsAddIntoCache = false;
            this.TableName = "Sysmenu";
            this.OrderbyFields = "KID DESC";
            this.KeyField = "KID";
            base.DbConn = dbConn;
        }

		/*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
