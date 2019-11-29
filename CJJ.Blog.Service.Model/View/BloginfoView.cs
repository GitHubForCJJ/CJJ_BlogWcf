using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CJJ.Blog.Service.Model.View
{
    /// <summary>
    /// 博客view
    /// </summary>
    [DataContract]
    public class BloginfoView
    {
        [DataMember]
        public int KID { get; set; }
        /// <summary>
        /// title
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DataMember]
        public string Type { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        [DataMember]
        public int IsTop { get; set; }

        /// <summary>
        /// 是否私密不显示
        /// </summary>
        [DataMember]
        public int IsPrivate { get; set; }

        /// <summary>
        /// 版本号，乐观锁
        /// </summary>
        [DataMember]
        public string Vesion { get; set; }

        /// <summary>
        /// 是否原创
        /// </summary>
        [DataMember]
        public int IsOriginal { get; set; }
        /// <summary>
        /// 是否原创
        /// </summary>
        [DataMember]
        public int Start { get; set; }
        /// <summary>
        /// 是否原创
        /// </summary>
        [DataMember]
        public int Comments { get; set; }
        /// <summary>
        /// 是否原创
        /// </summary>
        [DataMember]
        public int Views { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [DataMember]
        public string Content { get; set; }
    }
}
