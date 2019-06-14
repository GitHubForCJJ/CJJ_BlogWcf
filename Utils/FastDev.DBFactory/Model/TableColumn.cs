//-----------------------------------------------------------------------------------
// <copyright file="TableColumn.cs" company="EastWestWalk Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : Administrator
// * fileName : TableColumn.cs
// * history  : created by Administrator 2018-06-20 下午 03:47:49
// </copyright>
// <summary>
//   FastDev.Service.Models.System.TableColumn
// </summary>
//-----------------------------------------------------------------------------------

using FastDev.DBFactory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FastDev.DBFactory
{
    /// <summary>
    /// 表列
    /// </summary>	
    public class TableColumn
    {
        /// <summary>
        /// 列名
        /// </summary>
        /// <value>The name of the col.</value>
        public string ColName { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        /// <value>The name of the col.</value>
        public string FieldType { get; set; }


        /// <summary>
        /// 长度
        /// </summary>
        /// <value>The name of the col.</value>
        public int DataLength { get; set; }


        /// <summary>
        /// 字段默认值
        /// </summary>
        /// <value>The name of the col.</value>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 是否为表主键 true 主键 false非主键
        /// </summary>
        /// <value>The name of the col.</value>
        public bool IsPriKey { get; set; }


        /// <summary>
        /// 是否为非空类型 true 可空 false非空
        /// </summary>
        /// <value>The name of the col.</value>
        public bool CanNull { get; set; }


        /// <summary>
        /// 针对int 是否为无符号 true无符号 false有符号
        /// </summary>
        /// <value>The name of the col.</value>
        public bool Unsigned { get; set; }

        /// <summary>
        /// 是否自增ID 针对Int 有效
        /// </summary>
        /// <value>The name of the col.</value>
        public bool IsAutoAdd { get; set; }

        /// <summary>
        /// 字段描述
        /// </summary>
        /// <value>The name of the col.</value>
        public string ColRemark { get; set; }
    }
}
