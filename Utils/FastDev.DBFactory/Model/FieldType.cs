//-----------------------------------------------------------------------------------
// <copyright file="FieldType.cs" company="EastWestWalk Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : Administrator
// * fileName : FieldType.cs
// * history  : created by Administrator 2018-06-29 上午 09:31:48
// </copyright>
// <summary>
//   FastDev.DBFactory.Model.FieldType
// </summary>
//-----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDev.DBFactory.Model
{
    /// <summary>
    /// FieldType
    /// </summary>
    public enum FieldType
    {
        /// <summary>
        /// The 整形 int
        /// </summary>
        整形Int = 1,

        /// <summary>
        /// The 字符串
        /// </summary>
        字符串 = 2,

        /// <summary>
        /// The 时间
        /// </summary>
        时间 = 3,
    }
}
