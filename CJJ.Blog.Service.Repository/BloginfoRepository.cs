//-----------------------------------------------------------------------------------
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
using FastDev.Log;
using FastDev;

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

        public BloginfoView GetBlog(string blogNum)
        {
            var bloginfoView = new BloginfoView();
            try
            {
                using (var db = new DBHelper())
                {

                    var sql = $"select a.*,b.Content from bloginfo a join blogcontent b  on  a.BlogNum=b.BloginfoNum where a.BlogNum='{blogNum}' and a.IsDeleted=0 ";

                    var data = db.ExecuteDataTable(sql);
                    bloginfoView = ToEntity<BloginfoView>(data);
                }
            }
            catch (Exception ex)
            {

            }

            return bloginfoView;
        }

        //public List<BloginfoView> GetListBlog(int page = 1, int limit = 10, bool iscontent = true, string orderby = "", Dictionary<string, object> dicwhere = null)
        //{
        //    try
        //    {
        //        var values = new List<object>();
        //        var sqlwhere = "";
        //        if (dicwhere != null)
        //        {
        //            sqlwhere = SqlHelper.GetSqlByDic(dicwhere, out values);
        //        }
        //        if (iscontent)
        //        {

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteLog(ex, "BloginfoRepository/GetListBlog");
        //    }
        //}

        //private string Getwherebydic(Dictionary<string, object> dic, out List<object> values)
        //{
        //    var sqlwhere = string.Empty;

        //    StringBuilder sub = new StringBuilder();
        //    foreach (KeyValuePair<string, object> item in dic)
        //    {
        //        sub.AppendFormat($" '{item.Key}'= ? and ");
        //        values.Add(item.Value);
        //    }

        //}

        /*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
