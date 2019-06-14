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
using System.Linq;
using System.Text;
using FastDev.DbBase;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CJJ.Blog.Service.Repository
{
    public class Fd_sys_operationlogRepository : BaseQuery
    {
        /// <summary>
        /// The instance
        /// </summary>
        public static Fd_sys_operationlogRepository Instance = new Fd_sys_operationlogRepository();

        /// <summary>
        /// Prevents a default instance of the <see cref="Fd_sys_operationlogRepository" /> class from being created.
        /// </summary>
        private Fd_sys_operationlogRepository()
        {
            this.IsAddIntoCache = true;
            this.TableName = "Fd_sys_operationlog";
            this.OrderbyFields = "KID DESC";
            this.KeyField = "KID";
        }

		/*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
