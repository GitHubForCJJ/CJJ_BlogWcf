//-----------------------------------------------------------------------------------
// <copyright file="HotNew.cs" company="Go Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : chenjianjun
// * fileName : HotNew.cs
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
using FastDev.Common.Extension;
using CJJ.Blog.Service.Models.View;
using DbLog = CJJ.Blog.Service.Logic.Fd_sys_operationlogLogic;

namespace CJJ.Blog.Service.Logic
{
    /// <summary>
    /// Class HotNew Logic.
    /// </summary>
    public class HotNewLogic
    {
        #region 查询

        /// <summary>
        /// Gets the HotNew {TableNameComment} list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;Jbst.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<HotNew> GetListPage(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            string orderby = "";
            if (dicwhere != null && dicwhere.ContainsKey(nameof(orderby)))
            {
                orderby = dicwhere[nameof(orderby)].ToString();
                dicwhere.Remove(nameof(orderby));
            }
            if (dicwhere == null)
            {
                dicwhere = new Dictionary<string, object>();
            }
            if (dicwhere.Keys.Contains(nameof(HotNew.IsDeleted)))
            {
                dicwhere[nameof(HotNew.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(HotNew.IsDeleted), 0);
            }
            return HotNewRepository.Instance.GetListPage<HotNew>(limit, page, dicwhere, orderby).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns>FastJsonResult&lt;List&lt;Product&gt;&gt;.</returns>
        public static FastJsonResult<List<HotNew>> GetJsonListPage(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            if (dicwhere == null)
            {
                dicwhere = new Dictionary<string, object>();
            }
            if (dicwhere.Keys.Contains(nameof(HotNew.IsDeleted)))
            {
                dicwhere[nameof(HotNew.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(HotNew.IsDeleted), 0);
            }
            return HotNewRepository.Instance.GetJsonListPage<HotNew>(limit, page, dicwhere, orderby);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;HotNew&gt;.</returns>
        public static List<HotNew> GetAllList()
        {
            var dic = new Dictionary<string, object>();
            dic.Add(nameof(HotNew.IsDeleted), 0);
            return HotNewRepository.Instance.GetList<HotNew>(dic).ToList();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;HotNew&gt;.</returns>
        public static DataTable GetDataTable(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            if (dicwhere.Keys.Contains(nameof(HotNew.IsDeleted)))
            {
                dicwhere[nameof(HotNew.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(HotNew.IsDeleted), 0);
            }
            return HotNewRepository.Instance.GetDataTablePage<HotNew>(limit, page, dicwhere);
        }

        /// <summary> 
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;HotNew&gt;.</returns>
        public static List<HotNew> GetList(Dictionary<string, object> dicwhere)
        {
            if (dicwhere.Keys.Contains(nameof(HotNew.IsDeleted)))
            {
                dicwhere[nameof(HotNew.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(HotNew.IsDeleted), 0);
            }
            return HotNewRepository.Instance.GetList<HotNew>(dicwhere).ToList();
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
            if (dicwhere.Keys.Contains(nameof(HotNew.IsDeleted)))
            {
                dicwhere[nameof(HotNew.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(HotNew.IsDeleted), 0);
            }
            return HotNewRepository.Instance.GetCount<HotNew>(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static HotNew GetModelByKID(int kID)
        {
            var model = HotNewRepository.Instance.GetEntityByKey<HotNew>(kID);
            if (model != null && model.IsDeleted == 0)
            {
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static HotNew GetModelByWhere(Dictionary<string, object> dicwhere)
        {
            if (dicwhere.Keys.Contains(nameof(HotNew.IsDeleted)))
            {
                dicwhere[nameof(HotNew.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(HotNew.IsDeleted), 0);
            }
            return HotNewRepository.Instance.GetEntity<HotNew>(dicwhere);
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
        public static List<HotNew> GetListByInSelect(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            if (mainDicWhere.Keys.Contains(nameof(HotNew.IsDeleted)))
            {
                mainDicWhere[nameof(HotNew.IsDeleted)] = 0;
            }
            else
            {
                mainDicWhere.Add(nameof(HotNew.IsDeleted), 0);
            }

            if (subDicWhere.Keys.Contains(nameof(HotNew.IsDeleted)))
            {
                subDicWhere[nameof(HotNew.IsDeleted)] = 0;
            }
            else
            {
                subDicWhere.Add(nameof(HotNew.IsDeleted), 0);
            }
            return HotNewRepository.Instance.GetListByInSelect<HotNew>(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit).ToList();
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
            if (mainDicWhere.Keys.Contains(nameof(HotNew.IsDeleted)))
            {
                mainDicWhere[nameof(HotNew.IsDeleted)] = 0;
            }
            else
            {
                mainDicWhere.Add(nameof(HotNew.IsDeleted), 0);
            }

            if (subDicWhere.Keys.Contains(nameof(HotNew.IsDeleted)))
            {
                subDicWhere[nameof(HotNew.IsDeleted)] = 0;
            }
            else
            {
                subDicWhere.Add(nameof(HotNew.IsDeleted), 0);
            }
            return HotNewRepository.Instance.GetCountByInSelect<HotNew>(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
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
            if (dicWhere.Keys.Contains(nameof(HotNew.IsDeleted)))
            {
                dicWhere[nameof(HotNew.IsDeleted)] = 0;
            }
            else
            {
                dicWhere.Add(nameof(HotNew.IsDeleted), 0);
            }
            return HotNewRepository.Instance.GetDataByGroup<HotNew>(groupByFields, dicWhere, page, limit);
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
            var ret = HotNewRepository.Instance.Add<HotNew>(dicwhere);

            DbLog.WriteDbLog(nameof(HotNew), "添加记录", ret, dicwhere.ToJsonString(), opertionUser, OperLogType.添加);

            return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add(HotNew entity, OpertionUser opertionUser)
        {
            try
            {
                var ret = HotNewRepository.Instance.Add<HotNew>(entity);

                DbLog.WriteDbLog(nameof(HotNew), "添加记录", ret, entity.ToJsonString(), opertionUser, OperLogType.添加);

                return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
            }
            catch (Exception ex)
            {
                FastDev.Log.LogHelper.WriteLog(ex, "HotNewLogic.Add Entity异常");

                return new Result() { IsSucceed = false, Message = ex.Message };
            }
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds(List<HotNew> entity, OpertionUser opertionUser)
        {
            try
            {
                var ret = HotNewRepository.Instance.Adds<HotNew>(entity);

                DbLog.WriteDbLog<List<HotNew>>(nameof(HotNew), "添加记录", ret, entity, opertionUser, OperLogType.添加);

                return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
            }
            catch (Exception ex)
            {
                FastDev.Log.LogHelper.WriteLog(ex, "HotNewLogic.Add Entity异常");

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
                var ret = HotNewRepository.Instance.Adds<HotNew>(diclst);

                DbLog.WriteDbLog<List<Dictionary<string, object>>>(nameof(HotNew), "添加记录", ret, diclst, opertionUser, OperLogType.添加);

                return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
            }
            catch (Exception ex)
            {
                FastDev.Log.LogHelper.WriteLog(ex, "HotNewLogic.Adds diclst异常");

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
            var ret = HotNewRepository.Instance.UpdateByKey<HotNew>(dicwhere, kID);

            DbLog.WriteDbLog(nameof(HotNew), "修改记录", kID, dicwhere, OperLogType.编辑, opertionUser);

            return new Result() { IsSucceed = ret > 0 };
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
            var ret = HotNewRepository.Instance.Update<HotNew>(valuedata, dicwhere);

            DbLog.WriteDbLog(nameof(HotNew), "批量修改记录", valuedata.ToJsonString(), valuedata, OperLogType.编辑, opertionUser);

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
            var ret = HotNewRepository.Instance.UpdateNums<HotNew>(fields, addNums, whereKey);

            DbLog.WriteDbLog(nameof(HotNew), "修改记录", whereKey.ToJsonString(), whereKey, OperLogType.编辑, opertionUser);

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
            deldic.Add(nameof(HotNew.IsDeleted), 1);

            var keydic = new Dictionary<string, object>();
            if (kid.IndexOf(",") > -1)
            {
                keydic.Add(nameof(HotNew.KID) + "|i", kid);
            }
            else
            {
                keydic.Add(nameof(HotNew.KID), kid);
            }
            var ret = HotNewRepository.Instance.Update<HotNew>(deldic, keydic);

            DbLog.WriteDbLog(nameof(HotNew), "删除记录", kid, null, OperLogType.删除, opertionUser);

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
            deldic.Add(nameof(HotNew.IsDeleted), 1);

            var ret = HotNewRepository.Instance.Update<HotNew>(deldic, dicwhere);

            DbLog.WriteDbLog(nameof(HotNew), "批量删除记录", dicwhere.ToJsonString(), dicwhere, OperLogType.删除, opertionUser);

            return new Result() { IsSucceed = ret > 0 };
        }
        #endregion

        #region 数据导出
        /// <summary>
        /// Exports the excel file.
        /// </summary>
        /// <param name="dicwhere">查询条件</param>
        /// <param name="fileFullName">文件名全路径</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>System.String.</returns>
        public static Result ExportExcelFile(Dictionary<string, object> dicwhere, string fileFullName, OpertionUser opertionUser)
        {
            Result ret = new Result();

            try
            {
                ret.IsSucceed = FastDev.ExcelHelper.Excel.OutputToExcel(GetDataTable(dicwhere, 0, 0), fileFullName);
            }
            catch (Exception ex)
            {
                ret.IsSucceed = false;
                ret.Message = ex.Message;
            }
            return ret;
        }
        #endregion

        /*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
