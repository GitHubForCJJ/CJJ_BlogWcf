using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CJJ.Blog.Service.Model.View
{
    [DataContract]
    public class Sysmenuview
    {

        /// <summary>
        /// 编号,数据库自增本表唯一
        /// </summary>
        [DataMember]
        public int KID { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [DataMember]
        public string Menuname { get; set; }

        /// <summary>
        /// 菜单连接
        /// </summary>
        [DataMember]
        public string MenuUrl { get; set; }
        /// <summary>
        /// 菜单icon
        /// </summary>
        [DataMember]
        public string Menuicon { get; set; }

        /// <summary>
        /// 菜单显示顺序
        /// </summary>
        [DataMember]
        public int Menusort { get; set; }

        /// <summary>
        /// 上级id
        /// </summary>
        [DataMember]
        public int Fatherid { get; set; }
    }
}
