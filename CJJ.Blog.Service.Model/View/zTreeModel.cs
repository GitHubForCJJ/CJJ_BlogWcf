using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CJJ.Blog.Service.Model.View
{
    /// <summary>
    /// Class zTreeModel.
    /// </summary>
    [DataContract]
    public class zTreeModel
    {
        /// <summary>
        /// 当前节点Id
        /// </summary>
        /// <value>The title.</value>
        [DataMember]
        public string id { get; set; }

        /// <summary>
        /// 上级节点Id
        /// </summary>
        /// <value>The title.</value>
        [DataMember]
        public string pId { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        /// <value>The title.</value>
        [DataMember]
        public string name { get; set; }

        /// <summary>
        /// Url地址
        /// </summary>
        /// <value>The title.</value>
        [DataMember]
        public string url { get; set; }

        /// <summary>
        /// Ico图标
        /// </summary>
        /// <value>The title.</value>
        [DataMember]
        public string ico { get; set; }

        /// <summary>
        /// 排序 值越大越前
        /// </summary>
        /// <value>The title.</value>
        [DataMember]
        public int sort { get; set; }


        /// <summary>
        /// 是否展开 true 展开 false不展开
        /// </summary>
        /// <value>The title.</value>
        [DataMember]
        public bool open { get; set; }


        /// <summary>
        /// 是否勾选 true 展开 false不展开
        /// </summary>
        /// <value>The title.</value>
        [DataMember]
        public bool schecked { get; set; }

        /// <summary>
        /// 子菜单列表
        /// </summary>
        /// <value>
        /// The sub menu.
        /// </value>
        [DataMember]
        public List<zTreeModel> subMenuLst { get; set; }
    }
}
