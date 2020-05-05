//-----------------------------------------------------------------------------------
// <copyright file="Comment.cs" company="Go Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : chenjianjun
// * fileName : Comment.cs
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
    /// Comment 仓储操作类
    /// </summary>
    /// <seealso cref="FastDev.DbBase.BaseQuery" />
	public class CommentRepository : BaseQuery
    {
        /// <summary>
        /// 单利实体操作对象
        /// </summary>
        public static CommentRepository Instance = new CommentRepository();

        /// <summary>
        /// 构造函数
        /// </summary>
        private CommentRepository()
        {
            this.IsAddIntoCache = true;
            this.TableName = "Comment";
            this.OrderbyFields = "KID DESC";
            this.KeyField = "KID";
        }

		/// <summary>
        /// 带事务执行的构造函数
        /// </summary>
        /// <param name="dbconn">The dbconn.</param>
        public CommentRepository(DBOperator dbConn)
        {
            this.IsAddIntoCache = false;
            this.TableName = "Comment";
            this.OrderbyFields = "KID DESC";
            this.KeyField = "KID";
            base.DbConn = dbConn;
        }
        /// <summary>
        /// 同步评论数据
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
                    string selsql = $"update bloginfo a ,(select count(*)as tcount,BlogNum from `comment` c where c.ToMemberid='' and c.IsDeleted=0 and c.BlogNum='{blognum}' ) b set a.Comments=b.tcount WHERE a.BlogNum=b.BlogNum and b.BlogNum = '{blognum}' and a.Comments<> b.tcount and a.IsDeleted = 0";
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
