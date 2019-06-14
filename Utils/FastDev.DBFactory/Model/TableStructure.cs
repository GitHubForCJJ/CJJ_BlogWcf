//-----------------------------------------------------------------------------------
// <copyright file="TableStructure.cs" company="EastWestWalk Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : Administrator
// * fileName : TableStructure.cs
// * history  : created by Administrator 2018-06-20 下午 03:38:27
// </copyright>
// <summary>
//   FastDev.Service.Models.System.TableStructure
// </summary>
//-----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FastDev.DBFactory
{
    /// <summary>
    /// 数据库表结构模型
    /// </summary>	
    public class TableStructure
    {
        /// <summary>
        /// 表名
        /// </summary>
        /// <value>The name of the table.</value>
        public string TableName { get; set; }

        /// <summary>
        /// 表描述
        /// </summary>
        /// <value>The name of the table.</value>
        public string TableRemark { get; set; }

        /// <summary>
        /// 表列
        /// </summary>
        /// <value>The table columns.</value>
        public List<TableColumn> TableColumns { get; set; }
    }
}
