//-----------------------------------------------------------------------------------
// <copyright file="Fd_sys_operationlog.cs" company="Go Enterprises">
// * copyright: (C) 2018 www.codemain.cn
// * version  : 1.0.0.0
// * author   : meteor
// * fileName : Fd_sys_operationlog.cs
// * history  : created by meteor 2018-10-31 11:46:13
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
using DbLog = CJJ.Blog.Service.Logic.Fd_sys_operationlogLogic;
using System.Data;
using System.Threading;
using CJJ.Blog.Service.Repository.Comm;
using FastDev.Common.Extension;
using CJJ.Blog.Service.Models.View;
using FastDev.Configer;

namespace CJJ.Blog.Service.Logic
{
    /// <summary>
    /// Class Fd_sys_operationlogLogic.
    /// </summary>
    public class Fd_sys_operationlogLogic
    {

        /// <summary>
        /// 是否写操作日志
        /// </summary>
        private static bool IsWriteOpertionLog = ConfigHelper.GetConfigToBool("IsWriteOpertionLog");

        #region 查询

        /// <summary>
        /// Gets the Fd_sys_operationlog {TableNameComment} list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Fd_sys_operationlog> GetListPage(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            string orderby = "";
            if (dicwhere != null && dicwhere.ContainsKey(nameof(orderby)))
            {
                orderby = dicwhere[nameof(orderby)].ToString();
                dicwhere.Remove(nameof(orderby));
            }
            return Fd_sys_operationlogRepository.Instance.GetListPage<Fd_sys_operationlog>(limit, page, dicwhere, orderby).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns>FastJsonResult&lt;List&lt;Product&gt;&gt;.</returns>
        public static FastJsonResult<List<Fd_sys_operationlog>> GetJsonListPage(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Fd_sys_operationlogRepository.Instance.GetJsonListPage<Fd_sys_operationlog>(limit, page, dicwhere, orderby);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Fd_sys_operationlog&gt;.</returns>
        public static List<Fd_sys_operationlog> GetAllList()
        {
            return Fd_sys_operationlogRepository.Instance.GetList<Fd_sys_operationlog>().ToList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Fd_sys_operationlog&gt;.</returns>
        public static DataTable GetDataTable(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Fd_sys_operationlogRepository.Instance.GetDataTablePage<Fd_sys_operationlog>(limit, page, dicwhere);
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Fd_sys_operationlog&gt;.</returns>
        public static List<Fd_sys_operationlog> GetList(Dictionary<string, object> dicwhere)
        {
            return Fd_sys_operationlogRepository.Instance.GetList<Fd_sys_operationlog>(dicwhere).ToList();
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount(Dictionary<string, object> dicwhere = null)
        {
            return Fd_sys_operationlogRepository.Instance.GetCount<Fd_sys_operationlog>(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Fd_sys_operationlog GetModelByKID(int kID)
        {
            return Fd_sys_operationlogRepository.Instance.GetEntityByKey<Fd_sys_operationlog>(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Fd_sys_operationlog GetModelByWhere(Dictionary<string, object> dicwhere)
        {
            return Fd_sys_operationlogRepository.Instance.GetEntity<Fd_sys_operationlog>(dicwhere);
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
        public static List<Fd_sys_operationlog> GetListByInSelect(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Fd_sys_operationlogRepository.Instance.GetListByInSelect<Fd_sys_operationlog>(subTableName, mainTableFields, subTableName, mainDicWhere, subDicWhere, page, limit).ToList();
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
            return Fd_sys_operationlogRepository.Instance.GetCountByInSelect<Fd_sys_operationlog>(subTableName, mainTableFields, subTableName, mainDicWhere, subDicWhere);
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
            return Fd_sys_operationlogRepository.Instance.GetDataByGroup<Fd_sys_operationlog>(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Result.</returns>
        public static Result Add(Dictionary<string, object> dicwhere)
        {
            var ret = Fd_sys_operationlogRepository.Instance.Add<Fd_sys_operationlog>(dicwhere);

            return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Result.</returns>
        public static Result Add(Fd_sys_operationlog entity)
        {
            try
            {
                var ret = Fd_sys_operationlogRepository.Instance.Add<Fd_sys_operationlog>(entity);
                return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
            }
            catch (Exception ex)
            {
                FastDev.Log.LogHelper.WriteLog(ex, "Fd_sys_operationlogLogic.Add Entity异常");

                return new Result() { IsSucceed = false, Message = ex.Message };
            }
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Result.</returns>
        public static Result Adds(List<Fd_sys_operationlog> entity)
        {
            try
            {
                var ret = Fd_sys_operationlogRepository.Instance.Adds<Fd_sys_operationlog>(entity);
                return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
            }
            catch (Exception ex)
            {
                FastDev.Log.LogHelper.WriteLog(ex, "Fd_sys_operationlogLogic.Add Entity异常");

                return new Result() { IsSucceed = false, Message = ex.Message };
            }
        }


        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <returns></returns>
        public static Result Adds(List<Dictionary<string, object>> diclst)
        {
            try
            {
                var ret = Fd_sys_operationlogRepository.Instance.Adds<Fd_sys_operationlog>(diclst);
                return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
            }
            catch (Exception ex)
            {
                FastDev.Log.LogHelper.WriteLog(ex, "Fd_sys_operationlogLogic.Adds diclst异常");

                return new Result() { IsSucceed = false, Message = ex.Message };
            }
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicwhere.
        /// </summary>
        /// <param name="dicwhere">The dicwhere.</param>
        /// <param name="kID">The k identifier.</param>
        /// <returns>Result.</returns>
        public static Result Update(Dictionary<string, object> dicwhere, int kID)
        {
            var ret = Fd_sys_operationlogRepository.Instance.UpdateByKey<Fd_sys_operationlog>(dicwhere, kID);

            return new Result() { IsSucceed = ret > 0 };
        }

        /// <summary>
        /// Edits the specified dicwhere.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere(Dictionary<string, object> valuedata, Dictionary<string, object> dicwhere)
        {
            var ret = Fd_sys_operationlogRepository.Instance.Update<Fd_sys_operationlog>(valuedata, dicwhere);

            return new Result() { IsSucceed = ret > 0 };
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <returns></returns>
        public static Result UpdateNums(string fields, int addNums, Dictionary<string, object> whereKey)
        {
            var ret = Fd_sys_operationlogRepository.Instance.UpdateNums<Fd_sys_operationlog>(fields, addNums, whereKey);

            return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <returns>Result.</returns>
        public static Result Delete(string kid)
        {
            var ret = Fd_sys_operationlogRepository.Instance.DeleteByKeys(kid);
            return new Result() { IsSucceed = ret > 0 };
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="dicwhere">The keydata.</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere(Dictionary<string, object> dicwhere)
        {
            var ret = Fd_sys_operationlogRepository.Instance.Delete<Fd_sys_operationlog>(dicwhere);
            return new Result() { IsSucceed = ret > 0 };
        }
        #endregion

        #region 数据导出
        /// <summary>
        /// Exports the excel file.
        /// </summary>
        /// <param name="dicwhere">The dicwhere.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>System.String.</returns>
        public static Result ExportExcelFile(Dictionary<string, object> dicwhere, string fileFullName)
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

        #region 异步加日志

        /// <summary>
        /// 获取当前数据上一次的状态
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="keyValue">The key value.</param>
        /// <param name="keyFields">The key fields.</param>
        /// <returns></returns>
        public static string GetObjectLastState(string tableName, object keyValue, string keyFields)
        {
            var dic = new Dictionary<string, object>();
            dic.Add(nameof(Fd_sys_operationlog.TableName), tableName.ToLower());
            dic.Add(nameof(Fd_sys_operationlog.TablePriKeyValue), keyValue.ToString().Trim());
            dic.Add(nameof(Fd_sys_operationlog.TablePriKeyField), keyFields);

            var model = GetModelByWhere(dic);

            if (model == null)
                return "";
            else
                return model.ResResult;
        }

        /// <summary>
        /// 异步写日志 主要用于后台程序记录 1添加 2编辑 3修改 4常规日志
        /// </summary>
        /// <param name="tableName">日志表名 方法内会自动统一转小写</param>
        /// <param name="logContent">日志内容</param>
        /// <param name="kIDValue">主键字段对应的值 如 KID 的值</param>
        /// <param name="reqParams">请求的字典数据,仅用于日志展示</param>
        /// <param name="operLogType">操作类型</param>
        /// <param name="keyFields">主键字段名 默认KID</param>
        public static void WriteDbLog(string tableName, string logContent, object kIDValue, Dictionary<string, object> reqParams, OperLogType operLogType = OperLogType.常规日志, OpertionUser opertionUser = null, string keyFields = "KID")
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                if (IsWriteOpertionLog)
                {
                    #region 得到原始数据 日志表前一条记录

                    var oldlog = GetObjectLastState(tableName, kIDValue, keyFields);

                    var newlog = "";

                    using (CommonRepository db = new CommonRepository(tableName, keyFields))
                    {
                        var dr = db.GetRow($"{keyFields}='{kIDValue.ToString()}'");
                        newlog = dr.Table.ToDictionary().ToJsonString();
                    }

                    #endregion

                    #region 处理修改者信息
                    object updateUserId = "1", updateUserName = "系统用户", clientIpAddr = IPHelper.GetClientIP();
                    if (opertionUser != null)
                    {
                        updateUserId = opertionUser?.UserId;
                        updateUserName = opertionUser?.UserName;
                        clientIpAddr = opertionUser?.UserClientIp;
                    }
                    else
                    {
                        if (reqParams != null)
                        {
                            if (reqParams.ContainsKey("UpdateUserId"))
                            {
                                updateUserId = reqParams["UpdateUserId"];
                            }

                            if (reqParams.ContainsKey("UpdateUserName"))
                            {
                                updateUserName = reqParams["UpdateUserName"];
                            }

                            if (reqParams.ContainsKey("ClientIpAddr"))
                            {
                                clientIpAddr = reqParams["ClientIpAddr"];
                            }
                        }
                    }
                    #endregion

                    var dic = new Dictionary<string, object>();
                    dic.Add(nameof(Fd_sys_operationlog.TableName), tableName.ToLower().Trim());
                    dic.Add(nameof(Fd_sys_operationlog.TablePriKeyField), keyFields);
                    dic.Add(nameof(Fd_sys_operationlog.TablePriKeyValue), kIDValue);
                    dic.Add(nameof(Fd_sys_operationlog.CreateTime), DateTime.Now.ToStr());
                    dic.Add(nameof(Fd_sys_operationlog.LogContent), logContent);
                    dic.Add(nameof(Fd_sys_operationlog.CreateUserId), updateUserId);
                    dic.Add(nameof(Fd_sys_operationlog.CreateUserName), updateUserName);
                    dic.Add(nameof(Fd_sys_operationlog.IpAddr), clientIpAddr);
                    dic.Add(nameof(Fd_sys_operationlog.OperType), operLogType.GetHashCode());
                    dic.Add(nameof(Fd_sys_operationlog.ReqData), reqParams.IsNull() ? "" : reqParams.ToJsonString());
                    dic.Add(nameof(Fd_sys_operationlog.ResOldData), oldlog);
                    dic.Add(nameof(Fd_sys_operationlog.ResResult), newlog);

                    Add(dic);
                }
            }, null);
        }

        /// <summary>
        /// 异步写日志 主要用于后台程序记录 1添加 2编辑 3修改 4常规日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName">日志表名 方法内会自动统一转小写</param>
        /// <param name="logContent">日志内容</param>
        /// <param name="kIDValue">主键字段对应的值 如 KID 的值</param>
        /// <param name="reqParams">请求的对象 仅用于日志展示</param>
        /// <param name="opertionUser">操作用户</param>
        /// <param name="operLogType">枚举操作类型</param>
        /// <param name="keyFields">主键字段名 默认KID</param>
        public static void WriteDbLog<T>(string tableName, string logContent, object kIDValue, T reqParams, OpertionUser opertionUser, OperLogType operLogType = OperLogType.常规日志, string keyFields = "KID")
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                if (IsWriteOpertionLog)
                {

                    #region 得到原始数据 日志表前一条记录

                    var oldlog = GetObjectLastState(tableName, kIDValue, keyFields);

                    var newlog = "";

                    using (CommonRepository db = new CommonRepository(tableName, keyFields))
                    {
                        var dr = db.GetRow($"{keyFields}='{kIDValue.ToString()}'");
                        newlog = dr.Table.ToJsonString();
                    }

                    #endregion

                    var dic = new Dictionary<string, object>();
                    dic.Add(nameof(Fd_sys_operationlog.TableName), tableName.ToLower().Trim());
                    dic.Add(nameof(Fd_sys_operationlog.TablePriKeyField), keyFields);
                    dic.Add(nameof(Fd_sys_operationlog.TablePriKeyValue), kIDValue);
                    dic.Add(nameof(Fd_sys_operationlog.CreateTime), DateTime.Now.ToStr());
                    dic.Add(nameof(Fd_sys_operationlog.LogContent), logContent);
                    dic.Add(nameof(Fd_sys_operationlog.CreateUserId), opertionUser.IsNull() ? "1" : opertionUser.UserId);
                    dic.Add(nameof(Fd_sys_operationlog.CreateUserName), opertionUser.IsNull() ? "系统用户" : opertionUser.UserName);
                    dic.Add(nameof(Fd_sys_operationlog.IpAddr), (opertionUser.IsNull() ? IPHelper.GetClientIP() : opertionUser.UserClientIp));
                    dic.Add(nameof(Fd_sys_operationlog.OperType), operLogType.GetHashCode());
                    dic.Add(nameof(Fd_sys_operationlog.ReqData), reqParams.IsNull() ? "" : reqParams.ToJsonString());
                    dic.Add(nameof(Fd_sys_operationlog.ResOldData), oldlog);
                    dic.Add(nameof(Fd_sys_operationlog.ResResult), newlog);

                    Add(dic);
                }
            }, null);
        }

        #endregion

        /*BC47A26EB9A59406057DDDD62D0898F4*/
    }
}
