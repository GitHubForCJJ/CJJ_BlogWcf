
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
        private List<zTreeModel> _lstzTree;
        private List<zTreeModel> _lstzTreeByLevel;
        /// <summary>
        /// 用户菜单列表 所有菜单平铺到一层
        /// </summary>
        /// <value>The menu list.</value>
        [DataMember]
        public List<zTreeModel> UserMenuList
        {
            get
            {
                return _lstzTree;
            }
            set
            {
                _lstzTree = value;

                _lstzTreeByLevel = new List<zTreeModel>();

                if (_lstzTree != null && _lstzTree.Count() > 0)
                {
                    foreach (var item in _lstzTree.Where(p => p.pId == "0"))
                    {
                        var model = new zTreeModel()
                        {
                            id = item.id,
                            pId = item.pId,
                            name = item.name,
                            url = item.url,
                            sort = item.sort,
                            ico = item.ico,
                            open = item.open,
                            subMenuLst = GetMenuByNode(item.id, _lstzTree)
                        };
                        _lstzTreeByLevel.Add(model);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the menu by node.
        /// </summary>
        /// <param name="pId">The p identifier.</param>
        /// <param name="_allmenu">The allmenu.</param>
        /// <returns></returns>
        private List<zTreeModel> GetMenuByNode(string pId, List<zTreeModel> _allmenu)
        {
            var sub = _allmenu.Where(p => p.pId == pId).OrderByDescending(t => t.sort);
            if (sub.Count() == 0)
            {
                return new List<zTreeModel>();
            }
            else
            {
                var ret = new List<zTreeModel>();
                foreach (var item in sub)
                {
                    var model = new zTreeModel()
                    {
                        id = item.id,
                        pId = item.pId,
                        name = item.name,
                        url = item.url,
                        sort = item.sort,
                        ico = item.ico,
                        open = item.open,
                        subMenuLst = GetMenuByNode(item.id, _allmenu)
                    };
                    ret.Add(model);
                }
                return ret;
            }
        }

        /// <summary>
        /// 用户菜单列表 递归嵌套方式呈现
        /// </summary>
        /// <value>
        /// The menu list.
        /// </value>
        [DataMember]
        public List<zTreeModel> UserMenuByLevel
        {
            get
            {
                return _lstzTreeByLevel;
            }
        }



        //private List<zTreeModel> _listMenus = null;
        //private List<zTreeModel> _levelMenus = null;
        ///// <summary>
        ///// 原始list,所有menu平铺到一层
        ///// </summary>
        //[DataMember]
        //public List<zTreeModel> UserMenuList
        //{
        //    get { return _listMenus; }
        //    set
        //    {

        //        _listMenus = value;
        //        _levelMenus = new List<zTreeModel>();
        //        if (value != null && value.Count > 0)
        //        {
        //            var toplist = value.Where(x => x.pId == "0").ToList();
        //            for (var i = 0; i < toplist.Count; i++)
        //            {
        //                var ztreemode = new zTreeModel
        //                {
        //                    id = toplist[i].id,
        //                    pId = toplist[i].pId,
        //                    name = toplist[i].name,
        //                    ico = toplist[i].ico,
        //                    url = toplist[i].url,
        //                    open = toplist[i].open,
        //                    schecked = toplist[i].schecked,
        //                    sort = toplist[i].sort

        //                };
        //                ztreemode.subMenuLst = GetSubList(value, toplist[i].id);
        //                _levelMenus.Add(ztreemode);
        //            }
        //        }
        //    }
        //}
        //private static List<zTreeModel> GetSubList(List<zTreeModel> list, string pid)
        //{
        //    var sublist = list.Where(x => x.pId == pid).ToList();
        //    var res = new List<zTreeModel>();
        //    if (sublist.Count > 0)
        //    {
        //        for (var i = 0; i < sublist.Count(); i++)
        //        {
        //            var ztreemode = new zTreeModel
        //            {
        //                id = sublist[i].id,
        //                pId = sublist[i].pId,
        //                name = sublist[i].name,
        //                ico = sublist[i].ico,
        //                url = sublist[i].url,
        //                open = sublist[i].open,
        //                schecked = sublist[i].schecked,
        //                sort = sublist[i].sort

        //            };
        //            ztreemode.subMenuLst = GetSubList(list, sublist[i].id);
        //            res.Add(ztreemode);
        //        }
        //    }

        //    return res;

        //}

        ///// <summary>
        ///// 递归方式的menulist,有层次关系的menu
        ///// </summary>
        //[DataMember]
        //public List<zTreeModel> UserLevelMenuList
        //{
        //    get
        //    {
        //        return _levelMenus;
        //    }
        //}
    }
}
