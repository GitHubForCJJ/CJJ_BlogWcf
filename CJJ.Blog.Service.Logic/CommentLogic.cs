﻿//-----------------------------------------------------------------------------------
// <copyright file="Comments.cs" company="Go Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : chenjianjun
// * fileName : Comments.cs
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
using DbLog = CJJ.Blog.Service.Logic.Fd_sys_operationlogLogic;
using System.Data;
using FastDev.Common.Extension;
using CJJ.Blog.Service.Models.View;
using CJJ.Blog.Service.Model.Data;
using CJJ.Blog.Service.Model.View;

namespace CJJ.Blog.Service.Logic
{
    /// <summary>
    /// Class Comments Logic.
    /// </summary>
    public class CommentLogic
    {
        #region 查询

        /// <summary>
        /// Gets the Comment {TableNameComment} list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;Jbst.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Comment> GetListPage(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
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
            if (dicwhere.Keys.Contains(nameof(Comment.IsDeleted)))
            {
                dicwhere[nameof(Comment.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(Comment.IsDeleted), 0);
            }
            return CommentRepository.Instance.GetListPage<Comment>(limit, page, dicwhere, orderby).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns>FastJsonResult&lt;List&lt;Product&gt;&gt;.</returns>
        public static FastJsonResult<List<Comment>> GetJsonListPage(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            if (dicwhere == null)
            {
                dicwhere = new Dictionary<string, object>();
            }
            if (dicwhere.Keys.Contains(nameof(Comment.IsDeleted)))
            {
                dicwhere[nameof(Comment.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(Comment.IsDeleted), 0);
            }
            var ret= CommentRepository.Instance.GetJsonListPage<Comment>(limit, page, dicwhere, orderby);
            if (ret != null && ret.code.Toint() == 0 && ret.data.Count > 0)
            {
                string blognums = string.Join(",", ret.data.Select(x => x.BlogNum).Distinct());
                List<Bloginfo> blogs = BloginfoLogic.GetList(new Dictionary<string, object>()
                {
                  {$"{nameof(Bloginfo.BlogNum)}|i",blognums },
                });
                ret.data.ForEach((item) =>
                {
                    item.Extend4 = blogs.FirstOrDefault(x => x.BlogNum == item.BlogNum)?.Title;
                });
            }
            return ret;
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Comment&gt;.</returns>
        public static List<Comment> GetAllList()
        {
            var dic = new Dictionary<string, object>();
            dic.Add(nameof(Comment.IsDeleted), 0);
            return CommentRepository.Instance.GetList<Comment>(dic).ToList();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Comment&gt;.</returns>
        public static DataTable GetDataTable(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            if (dicwhere.Keys.Contains(nameof(Comment.IsDeleted)))
            {
                dicwhere[nameof(Comment.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(Comment.IsDeleted), 0);
            }
            return CommentRepository.Instance.GetDataTablePage<Comment>(limit, page, dicwhere);
        }

        /// <summary> 
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Comment&gt;.</returns>
        public static List<CommentView> GetList(Dictionary<string, object> dicwhere)
        {
            var res = new List<CommentView>();
            if (dicwhere.Keys.Contains(nameof(Comment.IsDeleted)))
            {
                dicwhere[nameof(Comment.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(Comment.IsDeleted), 0);
            }
            var list = CommentRepository.Instance.GetList<Comment>(dicwhere).ToList();
            if (list != null && list.Count > 0)
            {
                var sessionids = list.GroupBy(x => x.Commentid).Select(x => x.Key).Distinct().ToList();
                sessionids.ForEach((item) =>
                {
                    var sessionList = list.Where(x => x.Commentid == item)?.OrderByDescending(x=>x.CreateTime)?.ToList();
                    var mainSession = sessionList.Last();
                    var replys = sessionList.Where(x => x.KID != mainSession.KID)?.ToList()?? null;
                    res.Add(new CommentView()
                    {
                        KID = mainSession.KID,
                        CreateTime = mainSession.CreateTime,
                        Memberid = mainSession.Memberid,
                        MemberName = mainSession.MemberName,
                        BlogNum = mainSession.BlogNum,
                        Commentid = mainSession.Commentid,
                        ToMemberid = mainSession.ToMemberid,
                        Content = mainSession.Content,
                        Avatar = mainSession.Avatar,
                        Replys = replys
                    });
                });
            }

            return res?.OrderByDescending(x=>x.CreateTime)?.ToList();

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
            if (dicwhere.Keys.Contains(nameof(Comment.IsDeleted)))
            {
                dicwhere[nameof(Comment.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(Comment.IsDeleted), 0);
            }
            return CommentRepository.Instance.GetCount<Comment>(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Comment GetModelByKID(int kID)
        {
            var model = CommentRepository.Instance.GetEntityByKey<Comment>(kID);
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
        public static Comment GetModelByWhere(Dictionary<string, object> dicwhere)
        {
            if (dicwhere.Keys.Contains(nameof(Comment.IsDeleted)))
            {
                dicwhere[nameof(Comment.IsDeleted)] = 0;
            }
            else
            {
                dicwhere.Add(nameof(Comment.IsDeleted), 0);
            }
            return CommentRepository.Instance.GetEntity<Comment>(dicwhere);
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
        public static List<Comment> GetListByInSelect(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            if (mainDicWhere.Keys.Contains(nameof(Comment.IsDeleted)))
            {
                mainDicWhere[nameof(Comment.IsDeleted)] = 0;
            }
            else
            {
                mainDicWhere.Add(nameof(Comment.IsDeleted), 0);
            }

            if (subDicWhere.Keys.Contains(nameof(Comment.IsDeleted)))
            {
                subDicWhere[nameof(Comment.IsDeleted)] = 0;
            }
            else
            {
                subDicWhere.Add(nameof(Comment.IsDeleted), 0);
            }
            return CommentRepository.Instance.GetListByInSelect<Comment>(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit).ToList();
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
            if (mainDicWhere.Keys.Contains(nameof(Comment.IsDeleted)))
            {
                mainDicWhere[nameof(Comment.IsDeleted)] = 0;
            }
            else
            {
                mainDicWhere.Add(nameof(Comment.IsDeleted), 0);
            }

            if (subDicWhere.Keys.Contains(nameof(Comment.IsDeleted)))
            {
                subDicWhere[nameof(Comment.IsDeleted)] = 0;
            }
            else
            {
                subDicWhere.Add(nameof(Comment.IsDeleted), 0);
            }
            return CommentRepository.Instance.GetCountByInSelect<Comment>(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
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
            if (dicWhere.Keys.Contains(nameof(Comment.IsDeleted)))
            {
                dicWhere[nameof(Comment.IsDeleted)] = 0;
            }
            else
            {
                dicWhere.Add(nameof(Comment.IsDeleted), 0);
            }
            return CommentRepository.Instance.GetDataByGroup<Comment>(groupByFields, dicWhere, page, limit);
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
            var ret = CommentRepository.Instance.Add<Comment>(dicwhere);

            DbLog.WriteDbLog(nameof(Comment), "添加记录", ret, dicwhere.ToJsonString(), opertionUser, OperLogType.添加);
            Task.Run(() =>
            {
                if (ret > 0)
                {
                    CommentRepository.UpdateBloginfo(dicwhere[nameof(Comment.BlogNum)].ToString());
                }
            });

            return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add(Comment entity, OpertionUser opertionUser)
        {
            try
            {
                var ret = CommentRepository.Instance.Add<Comment>(entity);

                DbLog.WriteDbLog(nameof(Comment), "添加记录", ret, entity.ToJsonString(), opertionUser, OperLogType.添加);

                return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
            }
            catch (Exception ex)
            {
                FastDev.Log.LogHelper.WriteLog(ex, "CommentLogic.Add Entity异常");

                return new Result() { IsSucceed = false, Message = ex.Message };
            }
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds(List<Comment> entity, OpertionUser opertionUser)
        {
            try
            {
                var ret = CommentRepository.Instance.Adds<Comment>(entity);

                DbLog.WriteDbLog<List<Comment>>(nameof(Comment), "添加记录", ret, entity, opertionUser, OperLogType.添加);

                return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
            }
            catch (Exception ex)
            {
                FastDev.Log.LogHelper.WriteLog(ex, "CommentLogic.Add Entity异常");

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
                var ret = CommentRepository.Instance.Adds<Comment>(diclst);

                DbLog.WriteDbLog<List<Dictionary<string, object>>>(nameof(Comment), "添加记录", ret, diclst, opertionUser, OperLogType.添加);

                return new Result() { IsSucceed = ret > 0, Message = ret.ToString() };
            }
            catch (Exception ex)
            {
                FastDev.Log.LogHelper.WriteLog(ex, "CommentLogic.Adds diclst异常");

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
            var ret = CommentRepository.Instance.UpdateByKey<Comment>(dicwhere, kID);

            DbLog.WriteDbLog(nameof(Comment), "修改记录", kID, dicwhere, OperLogType.编辑, opertionUser);

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
            var ret = CommentRepository.Instance.Update<Comment>(valuedata, dicwhere);

            DbLog.WriteDbLog(nameof(Comment), "批量修改记录", valuedata.ToJsonString(), valuedata, OperLogType.编辑, opertionUser);

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
            var ret = CommentRepository.Instance.UpdateNums<Comment>(fields, addNums, whereKey);

            DbLog.WriteDbLog(nameof(Comment), "修改记录", whereKey.ToJsonString(), whereKey, OperLogType.编辑, opertionUser);

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
            deldic.Add(nameof(Comment.IsDeleted), 1);

            var keydic = new Dictionary<string, object>();
            if (kid.IndexOf(",") > -1)
            {
                keydic.Add(nameof(Comment.KID) + "|i", kid);
            }
            else
            {
                keydic.Add(nameof(Comment.KID), kid);
            }
            var ret = CommentRepository.Instance.Update<Comment>(deldic, keydic);

            DbLog.WriteDbLog(nameof(Comment), "删除记录", kid, null, OperLogType.删除, opertionUser);

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
            deldic.Add(nameof(Comment.IsDeleted), 1);

            var ret = CommentRepository.Instance.Update<Comment>(deldic, dicwhere);

            DbLog.WriteDbLog(nameof(Comment), "批量删除记录", dicwhere.ToJsonString(), dicwhere, OperLogType.删除, opertionUser);

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
