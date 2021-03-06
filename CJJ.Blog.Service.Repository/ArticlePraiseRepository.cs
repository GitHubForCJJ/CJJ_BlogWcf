﻿//-----------------------------------------------------------------------------------
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
using FastDev.Common.Code;
using CJJ.Blog.Service.Model.Data;

namespace CJJ.Blog.Service.Repository
{
    /// <summary>
    /// ArticlePraise 仓储操作类
    /// </summary>
    /// <seealso cref="FastDev.DbBase.BaseQuery" />
	public class ArticlePraiseRepository : BaseQuery
    {
        /// <summary>
        /// 单利实体操作对象
        /// </summary>
        public static ArticlePraiseRepository Instance = new ArticlePraiseRepository();

        /// <summary>
        /// 构造函数
        /// </summary>
        private ArticlePraiseRepository()
        {
            this.IsAddIntoCache = true;
            this.TableName = "ArticlePraise";
            this.OrderbyFields = "KID DESC";
            this.KeyField = "KID";
        }

        /// <summary>
        /// 带事务执行的构造函数
        /// </summary>
        /// <param name="dbconn">The dbconn.</param>
        public ArticlePraiseRepository(DBOperator dbConn)
        {
            this.IsAddIntoCache = false;
            this.TableName = "ArticlePraise";
            this.OrderbyFields = "KID DESC";
            this.KeyField = "KID";
            base.DbConn = dbConn;
        }
        /// <summary>
        /// 同步点赞数据
        /// </summary>
        /// <param name="blognum">The blognum.</param>
        /// <param name="memid">The memid.</param>
        /// <param name="isadd">if set to <c>true</c> [isadd].</param>
        /// <returns></returns>
        public static void UpdateBloginfo(string blognum)
        {
            try
            {
                using (DBHelper db = new DBHelper())
                {
                    string selsql = $"update bloginfo a ,(SELECT COUNT(1) as tcount,t.blognum FROM articlepraise t WHERE t.BlogNum='{blognum}' and t.IsDeleted=0 ) b SET a.Start = b.tcount where  a.start <> b.tcount and a.BlogNum = '{blognum}' and a.IsDeleted = 0";
                    var cun = db.ExecuteNonQuery(selsql);
                }
            }
            catch (Exception ex)
            {

            }

        }

        /*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
