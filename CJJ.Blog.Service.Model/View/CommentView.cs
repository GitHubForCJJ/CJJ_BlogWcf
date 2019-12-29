using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CJJ.Blog.Service.Model.Data;

namespace CJJ.Blog.Service.Model.View
{
    [DataContract]
    public class CommentView : Comment
    {
        /// <summary>
        /// 回复
        /// </summary>
        /// <value>
        /// The replys.
        /// </value>
        [DataMember]
        public List<Comment> Replys { get; set; }
    }
}
