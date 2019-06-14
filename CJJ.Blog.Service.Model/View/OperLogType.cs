using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJJ.Blog.Service.Models.View
{
    /// <summary>
    /// 日志类型,1添加 2编辑 3删除 4常规日志
    /// </summary>
    public enum OperLogType
    {
        /// <summary>
        /// </summary>
        添加 = 1,
        /// <summary>
        /// </summary>
        编辑 = 2,
        /// <summary>
        /// </summary>
        删除 = 3,
        /// <summary>
        /// </summary>
        常规日志 = 4
    }
}
