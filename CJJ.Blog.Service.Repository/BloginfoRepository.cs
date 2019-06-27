﻿//-----------------------------------------------------------------------------------
// <copyright file="Bloginfo.cs" company="Go Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : chenjianjun
// * fileName : Bloginfo.cs
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
using CJJ.Blog.Service.Model.View;

namespace CJJ.Blog.Service.Repository
{
    /// <summary>
    /// Bloginfo 仓储操作类
    /// </summary>
    /// <seealso cref="FastDev.DbBase.BaseQuery" />
	public class BloginfoRepository : BaseQuery
    {
        /// <summary>
        /// 单利实体操作对象
        /// </summary>
        public static BloginfoRepository Instance = new BloginfoRepository();

        /// <summary>
        /// 构造函数
        /// </summary>
        private BloginfoRepository()
        {
            this.IsAddIntoCache = true;
            this.TableName = "Bloginfo";
            this.OrderbyFields = "KID DESC";
            this.KeyField = "KID";
        }

		/// <summary>
        /// 带事务执行的构造函数
        /// </summary>
        /// <param name="dbconn">The dbconn.</param>
        public BloginfoRepository(DBOperator dbConn)
        {
            this.IsAddIntoCache = false;
            this.TableName = "Bloginfo";
            this.OrderbyFields = "KID DESC";
            this.KeyField = "KID";
            base.DbConn = dbConn;
        }

        public List<BloginfoView> GetListBlog(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null,string orderby="")
        {
            var list = new List<BloginfoView>();
            try
            {
                using (var db = new DBHelper())
                {
                    var sql = $"select a.*,b.Content from bloginfo a,blogcontent b where a.kid=b.BloginfoId limit ? offset ? ";
                    var par = new object[] { limit, (page - 1) * limit };
                    var data = db.ExecuteDataTable(sql, par);
                    list = ToEntityList<BloginfoView>(data)?.ToList();
                }
            }
            catch(Exception ex)
            {

            }

            return list;
        }

		/*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
