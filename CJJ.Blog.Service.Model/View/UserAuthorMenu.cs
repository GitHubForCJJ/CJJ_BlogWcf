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
    public class UserAuthorMenu : Result
    {
        private List<zTreeModel> _listMenus;
        private List<zTreeModel> _levelMenus;
        /// <summary>
        /// 原始list,所有menu平铺到一层
        /// </summary>
        [DataMember]
        public List<zTreeModel> UserMenuList
        {
            get { return _listMenus; }
            set
            {
                _listMenus = value;
                if (value != null && value.Count > 0)
                {
                    var toplist = value.Where(x => x.pId == "0").ToList();
                    for (var i = 0; i < toplist.Count; i++)
                    {

                    }
                }
            }
        }
        public static List<zTreeModel> GetBuildList(List<zTreeModel> list, string pid)
        {
            var rootlist = list.Where(x => x.pId == pid).ToList();
            if (rootlist.Count > 0)
            {
                for (var i = 0; i < rootlist.Count(); i++)
                {
                    
                    rootlist[i].subMenuLst = GetBuildList(list, rootlist[i].pId);
                }
            }
            return rootlist;

        }

        /// <summary>
        /// 递归方式的menulist,有层次关系的menu
        /// </summary>
        [DataMember]
        public List<zTreeModel> UserLevelMenuList { get { return _levelMenus; } }
    }
}
