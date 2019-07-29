
using CJJ.Blog.Service.Models.View;
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
        private List<zTreeModel> _listMenus=new List<zTreeModel>();
        private List<zTreeModel> _levelMenus=new List<zTreeModel>();
        /// <summary>
        /// 原始list,所有menu平铺到一层
        /// </summary>
        [DataMember]
        public List<zTreeModel> UserMenuList
        {
            get { return _listMenus; }
            set
            {
                _levelMenus = new List<zTreeModel>();
                _listMenus = value;
                if (value != null && value.Count > 0)
                {

                    var toplist = value.Where(x => x.pId == "0").ToList();
                    for (var i = 0; i < toplist.Count; i++)
                    {

                        var ztreemode = new zTreeModel
                        {
                            id = toplist[i].id,
                            pId = toplist[i].pId,
                            name = toplist[i].name,
                            ico = toplist[i].ico,
                            url = toplist[i].url,
                            open = toplist[i].open,
                            schecked = toplist[i].schecked,
                            sort = toplist[i].sort

                        };
                        ztreemode.subMenuLst = GetSubList(value, toplist[i].id);
                        _levelMenus.Add(ztreemode); ;
                    }
                }
            }
        }
        private static List<zTreeModel> GetSubList(List<zTreeModel> list, string pid)
        {
            var sublist = list.Where(x => x.pId == pid).ToList();
            var res = new List<zTreeModel>();
            if (sublist.Count > 0)
            {            
                for (var i = 0; i < sublist.Count(); i++)
                {
                    var ztreemode = new zTreeModel
                    {
                        id = sublist[i].id,
                        pId = sublist[i].pId,
                        name = sublist[i].name,
                        ico = sublist[i].ico,
                        url = sublist[i].url,
                        open = sublist[i].open,
                        schecked = sublist[i].schecked,
                        sort = sublist[i].sort

                    };
                    ztreemode.subMenuLst = GetSubList(list, sublist[i].id);
                    res.Add(ztreemode);
                }
            }
            
            return res;

        }

        /// <summary>
        /// 递归方式的menulist,有层次关系的menu
        /// </summary>
        [DataMember]
        public List<zTreeModel> UserLevelMenuList
        {
            get
            {
                return _levelMenus;
            }
        }
    }
}
