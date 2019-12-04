using CJJ.Blog.Service.Model.Data;
using FastDev.Common.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CJJ.Blog.Service.Model.View
{
    [DataContract]
    public class MemberAuthModel : Result
    {
        [DataMember]
        public Member MemberInfo { get; set; }
        [DataMember]
        public string Token { get; set; }
    }
}
