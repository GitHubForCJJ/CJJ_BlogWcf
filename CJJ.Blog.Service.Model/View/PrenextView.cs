using FastDev.Common.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CJJ.Blog.Service.Model.View
{
    /// <summary>
    /// 上下篇
    /// </summary>
    [DataContract]
    public class PrenextView : Result
    {
        [DataMember]
        public PrenextViewItem PreBlog { get; set; }
        [DataMember]
        public PrenextViewItem NextBlog { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class PrenextViewItem
    {
        [DataMember]
        public int KID { get; set; }
        [DataMember]
        public string BlogNum { get; set; }
        [DataMember]
        public string Title { get; set; }

    }

}
