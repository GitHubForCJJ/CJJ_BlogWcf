//-----------------------------------------------------------------------------------
// <copyright file="Bloginfo.cs" company="Go Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : chenjianjun
// * fileName : Bloginfo.cs
// * history  : created by chenjianjun 2019-06-14 15:52:46
// </copyright>
//-----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Text;
using FastDev.Common.Code;
using System.Threading.Tasks;
using System.Collections.Generic;
using CJJ.Blog.Service.Repository;
using CJJ.Blog.Service.Models.Data;
using System.Data;
using DbLog = CJJ.Blog.Service.Logic.Fd_sys_operationlogLogic;
using FastDev.Common.Extension;
using CJJ.Blog.Service.Models.View;
using CJJ.Blog.Service.Model.View;

namespace CJJ.Blog.Service.Logic
{
    /// <summary>
    /// Class Bloginfo Logic.
    /// </summary>
    public class BloginfoLogic
    {
        #region 查询

        /// <summary>
        /// 查询博客 分页查询
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="iscontent">是否查询content</param>
        /// <returns>System.Collections.Generic.List&lt;Jbst.Service.Models.Data.Sys_menu&gt;.</returns>
        //public static List<BloginfoView> GetListPage(int page = 1, int limit = 10,bool iscontent=true,string orderby="", Dictionary<string, object> dicwhere = null)
        //{
        //    if (dicwhere == null)
        //    {
        //        dicwhere = new Dictionary<string, object>();
        //    }
        //    if (dicwhere.Keys.Contains(nameof(Bloginfo.IsDeleted)))
        //    {
        //        dicwhere[nameof(Bloginfo.IsDeleted)] = 0;
        //    }
        //    else
        //    {
        //        dicwhere.Add(nameof(Bloginfo.IsDeleted), 0);
        //    }
        //    return BloginfoRepository.Instance.GetListBlog(page, limit, dicwhere, orderby).ToList();
        //}

        /// <summary>
        /// 查询单个博客包括详情
        /// </summary>
        /// <param name="blogNum"></param>
        /// <returns></returns>
        public static BloginfoView GetModelByNum(string blogNum)
        {
            return BloginfoRepository.Instance.GetBlog(blogNum);
        }

        /// <summary>
        /// 根据博客编号和类型获取上下篇
        /// </summary>
        /// <param name="blogNum"></param>
        /// <param name="type">文章类型</param>
        /// <returns></returns>
        public static PrenextView GetPrenextBlog(string blogNum, int type)
        {
            if (string.IsNullOrEmpty(blogNum))
            {
                return new PrenextView { IsSucceed = false, Message = "参数不存在编号为空" };
            }
            return BloginfoRepository.Instance.GetPrenextBlog(blogNum, type);
        }

        /// <summary>
        /// Gets the Bloginfo {TableNameComment} list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;Jbst.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<BloginfoView> GetListPage(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return new List<BloginfoView>();
        }

        /// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns>FastJsonResult&lt;List&lt;Product&gt;&gt;.</returns>
        public static FastJsonResult<List<Bloginfo>> GetJsonListPage(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            if (dicwhere == null)
            {
                dicwhere = new Dictionary<string, object>();
            }
            if (dicwhere.Keys.Contains(nameof(Bloginfo.IsDeleted)))
            {
                dicwhere[nameof(Bloginfo.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(Bloginfo.IsDeleted), 0);
            }
            var a = BloginfoRepository.Instance.GetJsonListPage<Bloginfo>(limit, page, dicwhere, orderby);
            return a;
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Bloginfo&gt;.</returns>
        public static List<Bloginfo> GetAllList()
        {
            var dic = new Dictionary<string, object>();
            dic.Add(nameof(Bloginfo.IsDeleted), 0);
            return BloginfoRepository.Instance.GetList<Bloginfo>(dic).ToList();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Bloginfo&gt;.</returns>
        public static DataTable GetDataTable(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            if (dicwhere.Keys.Contains(nameof(Bloginfo.IsDeleted)))
            {
                dicwhere[nameof(Bloginfo.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(Bloginfo.IsDeleted), 0);
            }
            return BloginfoRepository.Instance.GetDataTablePage<Bloginfo>(limit, page, dicwhere);
        }

        /// <summary> 
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Bloginfo&gt;.</returns>
        public static List<Bloginfo> GetList(Dictionary<string, object> dicwhere)
        {
            if (dicwhere.Keys.Contains(nameof(Bloginfo.IsDeleted)))
            {
                dicwhere[nameof(Bloginfo.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(Bloginfo.IsDeleted), 0);
            }
            return BloginfoRepository.Instance.GetList<Bloginfo>(dicwhere).ToList();
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount(Dictionary<string, object> dicwhere = null)
        {
            if (dicwhere == null)
            {
                dicwhere = new Dictionary<string, object>();
            }
            if (dicwhere.Keys.Contains(nameof(Bloginfo.IsDeleted)))
            {
                dicwhere[nameof(Bloginfo.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(Bloginfo.IsDeleted), 0);
            }
            return BloginfoRepository.Instance.GetCount<Bloginfo>(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static BloginfoView GetModelByKID(int kID)
        {
            return new BloginfoView();
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Bloginfo GetModelByWhere(Dictionary<string, object> dicwhere)
        {
            if (dicwhere.Keys.Contains(nameof(Bloginfo.IsDeleted)))
            {
                dicwhere[nameof(Bloginfo.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(Bloginfo.IsDeleted), 0);
            }
            return BloginfoRepository.Instance.GetEntity<Bloginfo>(dicwhere);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public static List<Bloginfo> GetListByInSelect(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            if (mainDicWhere.Keys.Contains(nameof(Bloginfo.IsDeleted)))
            {
                mainDicWhere[nameof(Bloginfo.IsDeleted)] = 0;
            }
            else
            {
                mainDicWhere.Add(nameof(Bloginfo.IsDeleted), 0);
            }

            if (subDicWhere.Keys.Contains(nameof(Bloginfo.IsDeleted)))
            {
                subDicWhere[nameof(Bloginfo.IsDeleted)] = 0;
            }
            else
            {
                subDicWhere.Add(nameof(Bloginfo.IsDeleted), 0);
            }
            return BloginfoRepository.Instance.GetListByInSelect<Bloginfo>(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit).ToList();
        }


        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <returns></returns>
        public static int GetCountByInSelect(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            if (mainDicWhere.Keys.Contains(nameof(Bloginfo.IsDeleted)))
            {
                mainDicWhere[nameof(Bloginfo.IsDeleted)] = 0;
            }
            else
            {
                mainDicWhere.Add(nameof(Bloginfo.IsDeleted), 0);
            }

            if (subDicWhere.Keys.Contains(nameof(Bloginfo.IsDeleted)))
            {
                subDicWhere[nameof(Bloginfo.IsDeleted)] = 0;
            }
            else
            {
                subDicWhere.Add(nameof(Bloginfo.IsDeleted), 0);
            }
            return BloginfoRepository.Instance.GetCountByInSelect<Bloginfo>(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            if (dicWhere.Keys.Contains(nameof(Bloginfo.IsDeleted)))
            {
                dicWhere[nameof(Bloginfo.IsDeleted)] = 0;
            }
            else
            {
                dicWhere.Add(nameof(Bloginfo.IsDeleted), 0);
            }
            return BloginfoRepository.Instance.GetDataByGroup<Bloginfo>(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add(Dictionary<string, object> dicwhere, OpertionUser opertionUser)
        {
            var res = new Result() { IsSucceed = false };

            if (!dicwhere.ContainsKey(nameof(Blogcontent.Content)))
            {
                return new Result { IsSucceed = false };
            }
            var ret = BloginfoRepository.Instance.Add<Bloginfo>(dicwhere);
            if (ret > 0)
            {
                var content = BlogcontentRepository.Instance.Add<Blogcontent>(new Dictionary<string, object>() {
                {nameof(Blogcontent.BloginfoNum),dicwhere[nameof(Blogcontent.BloginfoNum)] },
                {nameof(Blogcontent.Content),dicwhere[nameof(Blogcontent.Content)] },
                {nameof(Blogcontent.CreateUserId),dicwhere[nameof(Blogcontent.CreateUserId)] },
                {nameof(Blogcontent.CreateUserName),dicwhere[nameof(Blogcontent.CreateUserName)] }

            });
                if (content <= 0)
                {
                    return new Result { IsSucceed = false, Message = "部分添加失败" };
                }
                res.IsSucceed = true;
            }

            DbLog.WriteDbLog(nameof(Bloginfo), "添加记录", ret, dicwhere.ToJsonString(), opertionUser, OperLogType.添加);

            return res;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add(Bloginfo entity, OpertionUser opertionUser)
        {
            try
            {
                var ret = BloginfoRepository.Instance.Add<Bloginfo>(entity);

                DbLog.WriteDbLog(nameof(Bloginfo), "添加记录", ret, entity.ToJsonString(), opertionUser, OperLogType.添加);

                return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
            }
            catch (Exception ex)
            {
                FastDev.Log.LogHelper.WriteLog(ex, "BloginfoLogic.Add Entity异常");

                return new Result() { IsSucceed = false, Message = ex.Message };
            }
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds(List<Bloginfo> entity, OpertionUser opertionUser)
        {
            try
            {
                var ret = BloginfoRepository.Instance.Adds<Bloginfo>(entity);

                DbLog.WriteDbLog<List<Bloginfo>>(nameof(Bloginfo), "添加记录", ret, entity, opertionUser, OperLogType.添加);

                return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
            }
            catch (Exception ex)
            {
                FastDev.Log.LogHelper.WriteLog(ex, "BloginfoLogic.Add Entity异常");

                return new Result() { IsSucceed = false, Message = ex.Message };
            }
        }


        /// <summary>
        /// 根据字典添加多条数据
        /// </summary>
        /// <param name="diclst">The diclst.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result Adds(List<Dictionary<string, object>> diclst, OpertionUser opertionUser)
        {
            try
            {
                var ret = BloginfoRepository.Instance.Adds<Bloginfo>(diclst);

                DbLog.WriteDbLog<List<Dictionary<string, object>>>(nameof(Bloginfo), "添加记录", ret, diclst, opertionUser, OperLogType.添加);

                return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
            }
            catch (Exception ex)
            {
                FastDev.Log.LogHelper.WriteLog(ex, "BloginfoLogic.Adds diclst异常");

                return new Result() { IsSucceed = false, Message = ex.Message };
            }
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicwhere.
        /// </summary>
        /// <param name="dicwhere">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Update(Dictionary<string, object> dicwhere, int kID, OpertionUser opertionUser)
        {
            var res = new Result() { IsSucceed = false };
            var ret = BloginfoRepository.Instance.UpdateByKey<Bloginfo>(dicwhere, kID);
            if (ret > 0)
            {
                var cont = "";
                if (dicwhere.ContainsKey(nameof(Blogcontent.Content)))
                {
                    cont = dicwhere[nameof(Blogcontent.Content)].ToString();
                }
                var t = BlogcontentRepository.Instance.UpdateByKey<Blogcontent>(dicwhere, kID);
                res.IsSucceed = t > 0;
            }

            DbLog.WriteDbLog(nameof(Bloginfo), "修改记录", kID, dicwhere, OperLogType.编辑, opertionUser);

            return res;
        }

        /// <summary>
        /// Edits the specified dicwhere.
        /// </summary>
        /// <param name="valuedata">修改的值</param>
        /// <param name="dicwhere">修改条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere(Dictionary<string, object> valuedata, Dictionary<string, object> dicwhere, OpertionUser opertionUser)
        {
            var ret = BloginfoRepository.Instance.Update<Bloginfo>(valuedata, dicwhere);

            DbLog.WriteDbLog(nameof(Bloginfo), "批量修改记录", valuedata.ToJsonString(), valuedata, OperLogType.编辑, opertionUser);

            return new Result() { IsSucceed = ret > 0 };
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            var ret = BloginfoRepository.Instance.UpdateNums<Bloginfo>(fields, addNums, whereKey);

            DbLog.WriteDbLog(nameof(Bloginfo), "修改记录", whereKey.ToJsonString(), whereKey, OperLogType.编辑, opertionUser);

            return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete(string kid, OpertionUser opertionUser)
        {
            var deldic = new Dictionary<string, object>();
            deldic.Add(nameof(Bloginfo.IsDeleted), 1);

            var keydic = new Dictionary<string, object>();
            if (kid.IndexOf(",") > -1)
            {
                keydic.Add(nameof(Bloginfo.KID) + "|i", kid);
            }
            else
            {
                keydic.Add(nameof(Bloginfo.KID), kid);
            }
            var ret = BloginfoRepository.Instance.Update<Bloginfo>(deldic, keydic);

            DbLog.WriteDbLog(nameof(Bloginfo), "删除记录", kid, null, OperLogType.删除, opertionUser);

            return new Result() { IsSucceed = ret > 0 };
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="dicwhere">删除条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere(Dictionary<string, object> dicwhere, OpertionUser opertionUser)
        {
            var deldic = new Dictionary<string, object>();
            deldic.Add(nameof(Bloginfo.IsDeleted), 1);

            var ret = BloginfoRepository.Instance.Update<Bloginfo>(deldic, dicwhere);

            DbLog.WriteDbLog(nameof(Bloginfo), "批量删除记录", dicwhere.ToJsonString(), dicwhere, OperLogType.删除, opertionUser);

            return new Result() { IsSucceed = ret > 0 };
        }
        #endregion


        /*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
