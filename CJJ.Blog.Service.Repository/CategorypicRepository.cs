﻿//-----------------------------------------------------------------------------------
// <copyright file="Categorypic.cs" company="Go Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : chenjianjun
// * fileName : Categorypic.cs
// * history  : created by chenjianjun 2019-06-14 15:52:46
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
    /// Categorypic 仓储操作类
    /// </summary>
    /// <seealso cref="FastDev.DbBase.BaseQuery" />
	public class CategorypicRepository : BaseQuery
    {
        /// <summary>
        /// 单利实体操作对象
        /// </summary>
        public static CategorypicRepository Instance = new CategorypicRepository();

        /// <summary>
        /// 构造函数
        /// </summary>
        private CategorypicRepository()
        {
            this.IsAddIntoCache = true;
            this.TableName = "Categorypic";
            this.OrderbyFields = "KID DESC";
            this.KeyField = "KID";
        }

		/// <summary>
        /// 带事务执行的构造函数
        /// </summary>
        /// <param name="dbconn">The dbconn.</param>
        public CategorypicRepository(DBOperator dbConn)
        {
            this.IsAddIntoCache = false;
            this.TableName = "Categorypic";
            this.OrderbyFields = "KID DESC";
            this.KeyField = "KID";
            base.DbConn = dbConn;
        }

		/*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
