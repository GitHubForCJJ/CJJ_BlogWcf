using CJJ.Blog.Service.Model.View;
using CJJ.Blog.Service.Models.Data;
using FastDev.Common.Code;
using FastDev.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJJ.Blog.Service.Logic.Common
{
    public class Comlogic
    {
        /// <summary>
        /// 更根据用户id获取用户menu
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static UserAuthorMenu GetMenulistByUserid(int userid)
        {
            var UserAuthorMenu = new UserAuthorMenu() { UserMenuList = new List<zTreeModel>() };
            try
            {
                //所有的menus
                var allmenus = SysmenuLogic.GetAllList();
                if (userid <= 0)
                {
                    UserAuthorMenu.IsSucceed = false;
                    UserAuthorMenu.Message = "主键值不存在";
                    return UserAuthorMenu;
                }
                //1是超管
                if (userid == 1)
                {
                    foreach (var item in allmenus)
                    {
                        UserAuthorMenu.UserMenuList.Add(new zTreeModel
                        {
                            id = item.KID.ToString(),
                            pId = item.Fatherid.ToString(),
                            name = item.Menuname,
                            ico = item.Menuicon,
                            url = item.MenuUrl,
                            sort = item.Menusort,
                            open = true,
                            schecked = false,
                            subMenuLst = new List<zTreeModel>()
                        });
                    }
                }
                else
                {
                    var userrole = SysuserroleLogic.GetList(new Dictionary<string, object>() {
                         { nameof(Sysuserrole.Userid),userid}
                    });
                    if (userrole.Count <= 0)
                    {
                        return new UserAuthorMenu() { Message = "暂无可用角色", IsSucceed = false };
                    }
                    else
                    {
                        var roleids = string.Join(",", userrole.Select(x => x.Roleid));
                        var roles = SysroleLogic.GetList(new Dictionary<string, object>()
                        {
                            {$"{nameof(Sysrole.KID)}|i",roleids }
                        });
                        var menulists = string.Join(",", roles.Select(x => x.MenuList));
                        var menuids = menulists.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var item in menuids)
                        {
                            var menu = allmenus.FirstOrDefault(x => x.KID == item.Toint());
                            if (menu != null)
                            {
                                UserAuthorMenu.UserMenuList.Add(new zTreeModel
                                {
                                    id = menu.KID.ToString(),
                                    pId = menu.Fatherid.ToString(),
                                    name = menu.Menuname,
                                    ico = menu.Menuicon,
                                    url = menu.MenuUrl,
                                    sort = menu.Menusort,
                                    open = true,
                                    schecked = false,
                                    subMenuLst = new List<zTreeModel>()
                                });
                            }
                        }
                    }
                }
                if (UserAuthorMenu.UserMenuList.Count > 0)
                {

                    UserAuthorMenu.IsSucceed = true;
                    UserAuthorMenu.Message = "获取菜单权限成功";
                }
                else
                {
                    UserAuthorMenu.IsSucceed = false;
                    UserAuthorMenu.Message = "获取菜单权限失败";
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex, "");
                UserAuthorMenu.IsSucceed = false;
                UserAuthorMenu.Message = "获取菜单权限出错";
            }

            return UserAuthorMenu;

        }
    }
}
