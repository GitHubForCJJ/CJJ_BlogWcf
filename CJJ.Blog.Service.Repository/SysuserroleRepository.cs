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
using System.Linq;
using System.Text;
using FastDev.DbBase;
using FastDev.DBFactory;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CJJ.Blog.Service.Repository
{
    /// <summary>
    /// Sysuserrole 仓储操作类
    /// </summary>
    /// <seealso cref="FastDev.DbBase.BaseQuery" />
	public class SysuserroleRepository : BaseQuery
    {
        /// <summary>
        /// 单利实体操作对象
        /// </summary>
        public static SysuserroleRepository Instance = new SysuserroleRepository();

        /// <summary>
        /// 构造函数
        /// </summary>
        private SysuserroleRepository()
        {
            this.IsAddIntoCache = true;
            this.TableName = "Sysuserrole";
            this.OrderbyFields = "KID DESC";
            this.KeyField = "KID";
        }

		/// <summary>
        /// 带事务执行的构造函数
        /// </summary>
        /// <param name="dbconn">The dbconn.</param>
        public SysuserroleRepository(DBOperator dbConn)
        {
            this.IsAddIntoCache = false;
            this.TableName = "Sysuserrole";
            this.OrderbyFields = "KID DESC";
            this.KeyField = "KID";
            base.DbConn = dbConn;
        }

		/*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
