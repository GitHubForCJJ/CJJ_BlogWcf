//-----------------------------------------------------------------------------------
// <copyright file="CJJ.BlogService.cs" company="Go Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : chenjianjun
// * fileName : CJJ.BlogService.cs
// * history  : created by chenjianjun 2019-06-14 15:52:46
// </copyright>
// <summary>
//   CJJ.Blog.Service.Service
// </summary>
//-----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJJ.Blog.Service.Logic;
using CJJ.Blog.NetWork.IService;
using CJJ.Blog.Service.Models.Data;
using FastDev.Common.Code;
using CJJ.Blog.Service.Models.View;
using FastDev.Http;
using System.Data;
using CJJ.Blog.Service.Model.View;
using CJJ.Blog.Service.Model.Data;

namespace CJJ.Blog.Service.Service
{
    /// <summary>
    /// CJJ.BlogService 接口实现层
    /// </summary>
    /// <seealso cref="CJJ.Blog.NetWork.IService.ICJJ.BlogService" />
    public class BlogService : IBlogService
    {

        #region Bloginfo操作

        #region 查询



        /// <summary>
        /// 查询单个博客包括详情
        /// </summary>
        /// <param name="blogNum"></param>
        /// <returns></returns>
        public BloginfoView GetModelByNum(string blogNum)
        {
            return BloginfoLogic.GetModelByNum(blogNum);
        }

        /// <summary>
        /// 根据博客编号和类型获取上下篇
        /// </summary>
        /// <param name="blogNum"></param>
        /// <param name="type">文章类型</param>
        /// <returns></returns>
        public PrenextView GetPrenextBlog(string blogNum, int type)
        {
            return BloginfoLogic.GetPrenextBlog(blogNum, type);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="limit">当前页条数</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public List<BloginfoView> GetListPage_Bloginfo(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return BloginfoLogic.GetListPage(page, limit, dicwhere).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public FastJsonResult<List<Bloginfo>> GetJsonListPage_Bloginfo(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return BloginfoLogic.GetJsonListPage(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Bloginfo> GetAllList_Bloginfo()
        {
            return BloginfoLogic.GetAllList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Bloginfo> GetList_Bloginfo(Dictionary<string, object> dicwhere)
        {
            return BloginfoLogic.GetList(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount_Bloginfo(Dictionary<string, object> dicwhere = null)
        {
            return BloginfoLogic.GetCount(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public BloginfoView GetModelByKID_Bloginfo(int kID)
        {
            return BloginfoLogic.GetModelByKID(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Bloginfo GetModelByWhere_Bloginfo(Dictionary<string, object> dicwhere)
        {
            return BloginfoLogic.GetModelByWhere(dicwhere);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public DataTable GetDataTable_Bloginfo(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return BloginfoLogic.GetDataTable(dicwhere, page, limit);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public List<Bloginfo> GetListByInSelect_Bloginfo(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return BloginfoLogic.GetListByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public int GetCountByInSelect_Bloginfo(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return BloginfoLogic.GetCountByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup_Bloginfo(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return BloginfoLogic.GetDataByGroup(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Add_Bloginfo(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return BloginfoLogic.Add(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result Adds_Bloginfo(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return BloginfoLogic.Adds(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntity_Bloginfo(Bloginfo entity, OpertionUser opertionUser)
        {
            return BloginfoLogic.Add(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntitys_Bloginfo(List<Bloginfo> entitys, OpertionUser opertionUser)
        {
            return BloginfoLogic.Adds(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Update_Bloginfo(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return BloginfoLogic.Update(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">修改值</param>
        /// <param name="keydata">编辑的Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result UpdateByWhere_Bloginfo(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return BloginfoLogic.UpdateByWhere(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result UpdateNums_Bloginfo(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return BloginfoLogic.UpdateNums(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Delete_Bloginfo(string kid, OpertionUser opertionUser)
        {
            return BloginfoLogic.Delete(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result DeleteByWhere_Bloginfo(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return BloginfoLogic.DeleteByWhere(keydata, opertionUser);
        }
        #endregion

        //#region 数据导出

        //      /// <summary>
        //      /// Exports the excel file_ product.
        //      /// </summary>
        //      /// <param name="keydata">查询条件</param>
        //      /// <param name="fileFullName">文件名全路径</param>
        ///// <param name="opertionUser">操作者信息</param>
        //      /// <returns>FastDev.Common.Code.Result.</returns>
        //      public Result ExportExcelFile_Bloginfo(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        //      {
        //          return BloginfoLogic.ExportExcelFile(keydata, fileFullName, opertionUser);
        //      }

        //      #endregion

        #endregion

        #region Category操作

        #region 查询

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="limit">当前页条数</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public List<Category> GetListPage_Category(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return CategoryLogic.GetListPage(page, limit, dicwhere).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public FastJsonResult<List<Category>> GetJsonListPage_Category(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return CategoryLogic.GetJsonListPage(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Category> GetAllList_Category()
        {
            return CategoryLogic.GetAllList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Category> GetList_Category(Dictionary<string, object> dicwhere)
        {
            return CategoryLogic.GetList(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount_Category(Dictionary<string, object> dicwhere = null)
        {
            return CategoryLogic.GetCount(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Category GetModelByKID_Category(int kID)
        {
            return CategoryLogic.GetModelByKID(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Category GetModelByWhere_Category(Dictionary<string, object> dicwhere)
        {
            return CategoryLogic.GetModelByWhere(dicwhere);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public DataTable GetDataTable_Category(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return CategoryLogic.GetDataTable(dicwhere, page, limit);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public List<Category> GetListByInSelect_Category(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return CategoryLogic.GetListByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public int GetCountByInSelect_Category(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return CategoryLogic.GetCountByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup_Category(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return CategoryLogic.GetDataByGroup(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Add_Category(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return CategoryLogic.Add(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result Adds_Category(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return CategoryLogic.Adds(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntity_Category(Category entity, OpertionUser opertionUser)
        {
            return CategoryLogic.Add(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntitys_Category(List<Category> entitys, OpertionUser opertionUser)
        {
            return CategoryLogic.Adds(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Update_Category(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return CategoryLogic.Update(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">修改值</param>
        /// <param name="keydata">编辑的Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result UpdateByWhere_Category(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return CategoryLogic.UpdateByWhere(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result UpdateNums_Category(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return CategoryLogic.UpdateNums(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Delete_Category(string kid, OpertionUser opertionUser)
        {
            return CategoryLogic.Delete(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result DeleteByWhere_Category(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return CategoryLogic.DeleteByWhere(keydata, opertionUser);
        }
        #endregion

        #region 数据导出

        /// <summary>
        /// Exports the excel file_ product.
        /// </summary>
        /// <param name="keydata">查询条件</param>
        /// <param name="fileFullName">文件名全路径</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>FastDev.Common.Code.Result.</returns>
        public Result ExportExcelFile_Category(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return CategoryLogic.ExportExcelFile(keydata, fileFullName, opertionUser);
        }

        #endregion

        #endregion

        #region Categorypic操作

        #region 查询

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="limit">当前页条数</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public List<Categorypic> GetListPage_Categorypic(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return CategorypicLogic.GetListPage(page, limit, dicwhere).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public FastJsonResult<List<Categorypic>> GetJsonListPage_Categorypic(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return CategorypicLogic.GetJsonListPage(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Categorypic> GetAllList_Categorypic()
        {
            return CategorypicLogic.GetAllList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Categorypic> GetList_Categorypic(Dictionary<string, object> dicwhere)
        {
            return CategorypicLogic.GetList(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount_Categorypic(Dictionary<string, object> dicwhere = null)
        {
            return CategorypicLogic.GetCount(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Categorypic GetModelByKID_Categorypic(int kID)
        {
            return CategorypicLogic.GetModelByKID(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Categorypic GetModelByWhere_Categorypic(Dictionary<string, object> dicwhere)
        {
            return CategorypicLogic.GetModelByWhere(dicwhere);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public DataTable GetDataTable_Categorypic(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return CategorypicLogic.GetDataTable(dicwhere, page, limit);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public List<Categorypic> GetListByInSelect_Categorypic(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return CategorypicLogic.GetListByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public int GetCountByInSelect_Categorypic(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return CategorypicLogic.GetCountByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup_Categorypic(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return CategorypicLogic.GetDataByGroup(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Add_Categorypic(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return CategorypicLogic.Add(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result Adds_Categorypic(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return CategorypicLogic.Adds(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntity_Categorypic(Categorypic entity, OpertionUser opertionUser)
        {
            return CategorypicLogic.Add(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntitys_Categorypic(List<Categorypic> entitys, OpertionUser opertionUser)
        {
            return CategorypicLogic.Adds(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Update_Categorypic(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return CategorypicLogic.Update(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">修改值</param>
        /// <param name="keydata">编辑的Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result UpdateByWhere_Categorypic(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return CategorypicLogic.UpdateByWhere(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result UpdateNums_Categorypic(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return CategorypicLogic.UpdateNums(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Delete_Categorypic(string kid, OpertionUser opertionUser)
        {
            return CategorypicLogic.Delete(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result DeleteByWhere_Categorypic(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return CategorypicLogic.DeleteByWhere(keydata, opertionUser);
        }
        #endregion

        #region 数据导出

        /// <summary>
        /// Exports the excel file_ product.
        /// </summary>
        /// <param name="keydata">查询条件</param>
        /// <param name="fileFullName">文件名全路径</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>FastDev.Common.Code.Result.</returns>
        public Result ExportExcelFile_Categorypic(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return CategorypicLogic.ExportExcelFile(keydata, fileFullName, opertionUser);
        }

        #endregion

        #endregion

        #region Member操作

        #region 查询

        /// <summary>
        /// 会员登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public MemberAuthModel MemberLogin(string account, string password, string type, string ipaddress, string agent, string dns)
        {
            return MemberLogic.MemberLogin(account, password, type, ipaddress, agent, dns);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="limit">当前页条数</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public List<Member> GetListPage_Member(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return MemberLogic.GetListPage(page, limit, dicwhere).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public FastJsonResult<List<Member>> GetJsonListPage_Member(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return MemberLogic.GetJsonListPage(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Member> GetAllList_Member()
        {
            return MemberLogic.GetAllList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Member> GetList_Member(Dictionary<string, object> dicwhere)
        {
            return MemberLogic.GetList(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount_Member(Dictionary<string, object> dicwhere = null)
        {
            return MemberLogic.GetCount(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Member GetModelByKID_Member(int kID)
        {
            return MemberLogic.GetModelByKID(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Member GetModelByWhere_Member(Dictionary<string, object> dicwhere)
        {
            return MemberLogic.GetModelByWhere(dicwhere);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public DataTable GetDataTable_Member(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return MemberLogic.GetDataTable(dicwhere, page, limit);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public List<Member> GetListByInSelect_Member(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return MemberLogic.GetListByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public int GetCountByInSelect_Member(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return MemberLogic.GetCountByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup_Member(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return MemberLogic.GetDataByGroup(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Add_Member(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return MemberLogic.Add(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result Adds_Member(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return MemberLogic.Adds(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntity_Member(Member entity, OpertionUser opertionUser)
        {
            return MemberLogic.Add(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntitys_Member(List<Member> entitys, OpertionUser opertionUser)
        {
            return MemberLogic.Adds(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Update_Member(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return MemberLogic.Update(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">修改值</param>
        /// <param name="keydata">编辑的Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result UpdateByWhere_Member(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return MemberLogic.UpdateByWhere(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result UpdateNums_Member(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return MemberLogic.UpdateNums(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Delete_Member(string kid, OpertionUser opertionUser)
        {
            return MemberLogic.Delete(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result DeleteByWhere_Member(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return MemberLogic.DeleteByWhere(keydata, opertionUser);
        }
        #endregion

        #region 数据导出

        /// <summary>
        /// Exports the excel file_ product.
        /// </summary>
        /// <param name="keydata">查询条件</param>
        /// <param name="fileFullName">文件名全路径</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>FastDev.Common.Code.Result.</returns>
        public Result ExportExcelFile_Member(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return MemberLogic.ExportExcelFile(keydata, fileFullName, opertionUser);
        }

        #endregion

        #endregion

        #region Comment操作

        #region 查询

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="limit">当前页条数</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public List<Comment> GetListPage_Comment(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return CommentLogic.GetListPage(page, limit, dicwhere).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public FastJsonResult<List<Comment>> GetJsonListPage_Comment(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return CommentLogic.GetJsonListPage(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Comment> GetAllList_Comment()
        {
            return CommentLogic.GetAllList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<CommentView> GetList_Comment(Dictionary<string, object> dicwhere)
        {
            return CommentLogic.GetList(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount_Comment(Dictionary<string, object> dicwhere = null)
        {
            return CommentLogic.GetCount(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Comment GetModelByKID_Comment(int kID)
        {
            return CommentLogic.GetModelByKID(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Comment GetModelByWhere_Comment(Dictionary<string, object> dicwhere)
        {
            return CommentLogic.GetModelByWhere(dicwhere);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public DataTable GetDataTable_Comment(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return CommentLogic.GetDataTable(dicwhere, page, limit);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public List<Comment> GetListByInSelect_Comment(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return CommentLogic.GetListByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public int GetCountByInSelect_Comment(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return CommentLogic.GetCountByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup_Comment(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return CommentLogic.GetDataByGroup(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Add_Comment(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return CommentLogic.Add(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result Adds_Comment(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return CommentLogic.Adds(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntity_Comment(Comment entity, OpertionUser opertionUser)
        {
            return CommentLogic.Add(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntitys_Comment(List<Comment> entitys, OpertionUser opertionUser)
        {
            return CommentLogic.Adds(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Update_Comment(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return CommentLogic.Update(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">修改值</param>
        /// <param name="keydata">编辑的Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result UpdateByWhere_Comment(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return CommentLogic.UpdateByWhere(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result UpdateNums_Comment(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return CommentLogic.UpdateNums(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Delete_Comment(string kid, OpertionUser opertionUser)
        {
            return CommentLogic.Delete(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result DeleteByWhere_Comment(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return CommentLogic.DeleteByWhere(keydata, opertionUser);
        }
        #endregion

        #region 数据导出

        /// <summary>
        /// Exports the excel file_ product.
        /// </summary>
        /// <param name="keydata">查询条件</param>
        /// <param name="fileFullName">文件名全路径</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>FastDev.Common.Code.Result.</returns>
        public Result ExportExcelFile_Comment(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return CommentLogic.ExportExcelFile(keydata, fileFullName, opertionUser);
        }

        #endregion

        #endregion

        #region Employee操作

        #region 查询
        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="token">Token值</param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="agent">浏览器标识</param>
        /// <param name="dns">dns标识</param>
        /// <returns>Fd_Sys_LoginUser.</returns>
        public SysLoginUser GetUserInfoByToken(string token, string ipAddress, string agent, string dns)
        {
            return EmployeeLogic.GetUserInfoByToken(token, ipAddress, agent, dns);
        }

        public SysLoginUser EmployeePasswordLogin(string useraccount, string userpsw, string ipaddress, string agent, string dns)
        {
            var a = EmployeeLogic.EmployeePasswordLogin(useraccount, userpsw, ipaddress, agent, dns);
            return a;
        }
        public SysLoginUser EmployeeMobileLogin(string useraccount, string ipaddress, string agent, string dns)
        {
            return EmployeeLogic.EmployeeMobileLogin(useraccount, ipaddress, agent, dns);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="limit">当前页条数</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public List<Employee> GetListPage_Employee(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return EmployeeLogic.GetListPage(page, limit, dicwhere).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public FastJsonResult<List<Employee>> GetJsonListPage_Employee(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return EmployeeLogic.GetJsonListPage(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Employee> GetAllList_Employee()
        {
            return EmployeeLogic.GetAllList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Employee> GetList_Employee(Dictionary<string, object> dicwhere)
        {
            return EmployeeLogic.GetList(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount_Employee(Dictionary<string, object> dicwhere = null)
        {
            return EmployeeLogic.GetCount(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Employee GetModelByKID_Employee(int kID)
        {
            return EmployeeLogic.GetModelByKID(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Employee GetModelByWhere_Employee(Dictionary<string, object> dicwhere)
        {
            return EmployeeLogic.GetModelByWhere(dicwhere);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public DataTable GetDataTable_Employee(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return EmployeeLogic.GetDataTable(dicwhere, page, limit);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public List<Employee> GetListByInSelect_Employee(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return EmployeeLogic.GetListByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public int GetCountByInSelect_Employee(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return EmployeeLogic.GetCountByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup_Employee(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return EmployeeLogic.GetDataByGroup(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加


        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result SetEmployeeRole(string empid, string roleids)
        {
            return EmployeeLogic.SetEmployeeRole(empid, roleids);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result Adds_Employee(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return EmployeeLogic.Adds(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntity_Employee(Employee entity, OpertionUser opertionUser)
        {
            return EmployeeLogic.Add(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntitys_Employee(List<Employee> entitys, OpertionUser opertionUser)
        {
            return EmployeeLogic.Adds(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Update_Employee(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return EmployeeLogic.Update(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">修改值</param>
        /// <param name="keydata">编辑的Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result UpdateByWhere_Employee(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return EmployeeLogic.UpdateByWhere(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result UpdateNums_Employee(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return EmployeeLogic.UpdateNums(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Delete_Employee(string kid, OpertionUser opertionUser)
        {
            return EmployeeLogic.Delete(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result DeleteByWhere_Employee(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return EmployeeLogic.DeleteByWhere(keydata, opertionUser);
        }
        #endregion

        #region 数据导出

        /// <summary>
        /// Exports the excel file_ product.
        /// </summary>
        /// <param name="keydata">查询条件</param>
        /// <param name="fileFullName">文件名全路径</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>FastDev.Common.Code.Result.</returns>
        public Result ExportExcelFile_Employee(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return EmployeeLogic.ExportExcelFile(keydata, fileFullName, opertionUser);
        }

        #endregion

        #endregion

        #region Media操作

        #region 查询

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="limit">当前页条数</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public List<Media> GetListPage_Media(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return MediaLogic.GetListPage(page, limit, dicwhere).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public FastJsonResult<List<Media>> GetJsonListPage_Media(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return MediaLogic.GetJsonListPage(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Media> GetAllList_Media()
        {
            return MediaLogic.GetAllList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Media> GetList_Media(Dictionary<string, object> dicwhere)
        {
            return MediaLogic.GetList(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount_Media(Dictionary<string, object> dicwhere = null)
        {
            return MediaLogic.GetCount(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Media GetModelByKID_Media(int kID)
        {
            return MediaLogic.GetModelByKID(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Media GetModelByWhere_Media(Dictionary<string, object> dicwhere)
        {
            return MediaLogic.GetModelByWhere(dicwhere);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public DataTable GetDataTable_Media(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return MediaLogic.GetDataTable(dicwhere, page, limit);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public List<Media> GetListByInSelect_Media(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return MediaLogic.GetListByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public int GetCountByInSelect_Media(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return MediaLogic.GetCountByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup_Media(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return MediaLogic.GetDataByGroup(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Add_Media(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return MediaLogic.Add(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result Adds_Media(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return MediaLogic.Adds(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntity_Media(Media entity, OpertionUser opertionUser)
        {
            return MediaLogic.Add(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntitys_Media(List<Media> entitys, OpertionUser opertionUser)
        {
            return MediaLogic.Adds(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Update_Media(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return MediaLogic.Update(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">修改值</param>
        /// <param name="keydata">编辑的Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result UpdateByWhere_Media(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return MediaLogic.UpdateByWhere(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result UpdateNums_Media(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return MediaLogic.UpdateNums(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Delete_Media(string kid, OpertionUser opertionUser)
        {
            return MediaLogic.Delete(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result DeleteByWhere_Media(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return MediaLogic.DeleteByWhere(keydata, opertionUser);
        }
        #endregion

        #region 数据导出

        /// <summary>
        /// Exports the excel file_ product.
        /// </summary>
        /// <param name="keydata">查询条件</param>
        /// <param name="fileFullName">文件名全路径</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>FastDev.Common.Code.Result.</returns>
        public Result ExportExcelFile_Media(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return MediaLogic.ExportExcelFile(keydata, fileFullName, opertionUser);
        }

        #endregion

        #endregion


        #region Blogcontent操作

        #region 查询

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="limit">当前页条数</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public List<Blogcontent> GetListPage_Blogcontent(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return BlogcontentLogic.GetListPage(page, limit, dicwhere).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public FastJsonResult<List<Blogcontent>> GetJsonListPage_Blogcontent(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return BlogcontentLogic.GetJsonListPage(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Blogcontent> GetAllList_Blogcontent()
        {
            return BlogcontentLogic.GetAllList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Blogcontent> GetList_Blogcontent(Dictionary<string, object> dicwhere)
        {
            return BlogcontentLogic.GetList(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount_Blogcontent(Dictionary<string, object> dicwhere = null)
        {
            return BlogcontentLogic.GetCount(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Blogcontent GetModelByKID_Blogcontent(int kID)
        {
            return BlogcontentLogic.GetModelByKID(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Blogcontent GetModelByWhere_Blogcontent(Dictionary<string, object> dicwhere)
        {
            return BlogcontentLogic.GetModelByWhere(dicwhere);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public DataTable GetDataTable_Blogcontent(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return BlogcontentLogic.GetDataTable(dicwhere, page, limit);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public List<Blogcontent> GetListByInSelect_Blogcontent(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return BlogcontentLogic.GetListByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public int GetCountByInSelect_Blogcontent(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return BlogcontentLogic.GetCountByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup_Blogcontent(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return BlogcontentLogic.GetDataByGroup(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Add_Blogcontent(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return BlogcontentLogic.Add(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result Adds_Blogcontent(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return BlogcontentLogic.Adds(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntity_Blogcontent(Blogcontent entity, OpertionUser opertionUser)
        {
            return BlogcontentLogic.Add(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntitys_Blogcontent(List<Blogcontent> entitys, OpertionUser opertionUser)
        {
            return BlogcontentLogic.Adds(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Update_Blogcontent(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return BlogcontentLogic.Update(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">修改值</param>
        /// <param name="keydata">编辑的Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result UpdateByWhere_Blogcontent(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return BlogcontentLogic.UpdateByWhere(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result UpdateNums_Blogcontent(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return BlogcontentLogic.UpdateNums(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Delete_Blogcontent(string kid, OpertionUser opertionUser)
        {
            return BlogcontentLogic.Delete(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result DeleteByWhere_Blogcontent(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return BlogcontentLogic.DeleteByWhere(keydata, opertionUser);
        }
        #endregion

        #region 数据导出

        /// <summary>
        /// Exports the excel file_ product.
        /// </summary>
        /// <param name="keydata">查询条件</param>
        /// <param name="fileFullName">文件名全路径</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>FastDev.Common.Code.Result.</returns>
        public Result ExportExcelFile_Blogcontent(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return BlogcontentLogic.ExportExcelFile(keydata, fileFullName, opertionUser);
        }

        #endregion

        #endregion

        #region Logintoken操作

        #region 查询

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public SysLoginUser GetSysLoginUserByToken(string token)
        {
            return LogintokenLogic.GetSysLoginUserByToken(token);
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="limit">当前页条数</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public List<Logintoken> GetListPage_Logintoken(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return LogintokenLogic.GetListPage(page, limit, dicwhere).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public FastJsonResult<List<Logintoken>> GetJsonListPage_Logintoken(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return LogintokenLogic.GetJsonListPage(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Logintoken> GetAllList_Logintoken()
        {
            return LogintokenLogic.GetAllList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Logintoken> GetList_Logintoken(Dictionary<string, object> dicwhere)
        {
            return LogintokenLogic.GetList(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount_Logintoken(Dictionary<string, object> dicwhere = null)
        {
            return LogintokenLogic.GetCount(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Logintoken GetModelByKID_Logintoken(int kID)
        {
            return LogintokenLogic.GetModelByKID(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Logintoken GetModelByWhere_Logintoken(Dictionary<string, object> dicwhere)
        {
            return LogintokenLogic.GetModelByWhere(dicwhere);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public DataTable GetDataTable_Logintoken(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return LogintokenLogic.GetDataTable(dicwhere, page, limit);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public List<Logintoken> GetListByInSelect_Logintoken(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return LogintokenLogic.GetListByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public int GetCountByInSelect_Logintoken(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return LogintokenLogic.GetCountByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup_Logintoken(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return LogintokenLogic.GetDataByGroup(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Add_Logintoken(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return LogintokenLogic.Add(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result Adds_Logintoken(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return LogintokenLogic.Adds(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntity_Logintoken(Logintoken entity, OpertionUser opertionUser)
        {
            return LogintokenLogic.Add(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntitys_Logintoken(List<Logintoken> entitys, OpertionUser opertionUser)
        {
            return LogintokenLogic.Adds(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Update_Logintoken(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return LogintokenLogic.Update(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">修改值</param>
        /// <param name="keydata">编辑的Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result UpdateByWhere_Logintoken(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return LogintokenLogic.UpdateByWhere(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result UpdateNums_Logintoken(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return LogintokenLogic.UpdateNums(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Delete_Logintoken(string kid, OpertionUser opertionUser)
        {
            return LogintokenLogic.Delete(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result DeleteByWhere_Logintoken(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return LogintokenLogic.DeleteByWhere(keydata, opertionUser);
        }
        #endregion

        #region 数据导出

        /// <summary>
        /// Exports the excel file_ product.
        /// </summary>
        /// <param name="keydata">查询条件</param>
        /// <param name="fileFullName">文件名全路径</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>FastDev.Common.Code.Result.</returns>
        public Result ExportExcelFile_Logintoken(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return LogintokenLogic.ExportExcelFile(keydata, fileFullName, opertionUser);
        }

        #endregion

        #endregion

        #region HotNew操作

        #region 查询

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="limit">当前页条数</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public List<HotNew> GetListPage_HotNew(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return HotNewLogic.GetListPage(page, limit, dicwhere).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public FastJsonResult<List<HotNew>> GetJsonListPage_HotNew(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return HotNewLogic.GetJsonListPage(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<HotNew> GetAllList_HotNew()
        {
            return HotNewLogic.GetAllList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<HotNew> GetList_HotNew(Dictionary<string, object> dicwhere)
        {
            return HotNewLogic.GetList(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount_HotNew(Dictionary<string, object> dicwhere = null)
        {
            return HotNewLogic.GetCount(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public HotNew GetModelByKID_HotNew(int kID)
        {
            return HotNewLogic.GetModelByKID(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public HotNew GetModelByWhere_HotNew(Dictionary<string, object> dicwhere)
        {
            return HotNewLogic.GetModelByWhere(dicwhere);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public DataTable GetDataTable_HotNew(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return HotNewLogic.GetDataTable(dicwhere, page, limit);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public List<HotNew> GetListByInSelect_HotNew(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return HotNewLogic.GetListByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public int GetCountByInSelect_HotNew(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return HotNewLogic.GetCountByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup_HotNew(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return HotNewLogic.GetDataByGroup(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Add_HotNew(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return HotNewLogic.Add(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result Adds_HotNew(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return HotNewLogic.Adds(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntity_HotNew(HotNew entity, OpertionUser opertionUser)
        {
            return HotNewLogic.Add(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntitys_HotNew(List<HotNew> entitys, OpertionUser opertionUser)
        {
            return HotNewLogic.Adds(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Update_HotNew(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return HotNewLogic.Update(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">修改值</param>
        /// <param name="keydata">编辑的Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result UpdateByWhere_HotNew(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return HotNewLogic.UpdateByWhere(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result UpdateNums_HotNew(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return HotNewLogic.UpdateNums(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Delete_HotNew(string kid, OpertionUser opertionUser)
        {
            return HotNewLogic.Delete(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result DeleteByWhere_HotNew(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return HotNewLogic.DeleteByWhere(keydata, opertionUser);
        }
        #endregion

        #region 数据导出

        /// <summary>
        /// Exports the excel file_ product.
        /// </summary>
        /// <param name="keydata">查询条件</param>
        /// <param name="fileFullName">文件名全路径</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>FastDev.Common.Code.Result.</returns>
        public Result ExportExcelFile_HotNew(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return HotNewLogic.ExportExcelFile(keydata, fileFullName, opertionUser);
        }

        #endregion

        #endregion

        #region Sysmenu操作

        #region 查询


        /// <summary>
        /// 不分页获取权限内的所有数据, 根据账户得到对应渠道管理员的所有权限,才能给下级分配权限
        /// </summary>
        /// <param name="userId">当前登陆用户的Id</param>
        /// <param name="userType">用户类型 0员工 1会员</param>
        /// <returns>
        /// List&lt;Sys_role&gt;.
        /// </returns>
        public List<Sysmenu> GetListByUserId_Sysmenu(int userId, int userType)
        {
            return SysmenuLogic.GetListByUserId_Sysmenu(userId, userType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<Sysmenu> GetListByuserid_Sysmenu(int userid)
        {
            return SysmenuLogic.GetListByuserid_Sysmenu(userid);
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="limit">当前页条数</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public List<Sysmenu> GetListPage_Sysmenu(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return SysmenuLogic.GetListPage(page, limit, dicwhere).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public FastJsonResult<List<Sysmenu>> GetJsonListPage_Sysmenu(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return SysmenuLogic.GetJsonListPage(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Sysmenu> GetAllList_Sysmenu()
        {
            return SysmenuLogic.GetAllList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Sysmenu> GetList_Sysmenu(Dictionary<string, object> dicwhere)
        {
            return SysmenuLogic.GetList(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount_Sysmenu(Dictionary<string, object> dicwhere = null)
        {
            return SysmenuLogic.GetCount(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Sysmenu GetModelByKID_Sysmenu(int kID)
        {
            return SysmenuLogic.GetModelByKID(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Sysmenu GetModelByWhere_Sysmenu(Dictionary<string, object> dicwhere)
        {
            return SysmenuLogic.GetModelByWhere(dicwhere);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public DataTable GetDataTable_Sysmenu(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return SysmenuLogic.GetDataTable(dicwhere, page, limit);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public List<Sysmenu> GetListByInSelect_Sysmenu(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return SysmenuLogic.GetListByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public int GetCountByInSelect_Sysmenu(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return SysmenuLogic.GetCountByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup_Sysmenu(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return SysmenuLogic.GetDataByGroup(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Add_Sysmenu(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return SysmenuLogic.Add(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result Adds_Sysmenu(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return SysmenuLogic.Adds(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntity_Sysmenu(Sysmenu entity, OpertionUser opertionUser)
        {
            return SysmenuLogic.Add(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntitys_Sysmenu(List<Sysmenu> entitys, OpertionUser opertionUser)
        {
            return SysmenuLogic.Adds(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Update_Sysmenu(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return SysmenuLogic.Update(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">修改值</param>
        /// <param name="keydata">编辑的Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result UpdateByWhere_Sysmenu(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return SysmenuLogic.UpdateByWhere(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result UpdateNums_Sysmenu(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return SysmenuLogic.UpdateNums(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Delete_Sysmenu(string kid, OpertionUser opertionUser)
        {
            return SysmenuLogic.Delete(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result DeleteByWhere_Sysmenu(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return SysmenuLogic.DeleteByWhere(keydata, opertionUser);
        }
        #endregion

        #region 数据导出

        /// <summary>
        /// Exports the excel file_ product.
        /// </summary>
        /// <param name="keydata">查询条件</param>
        /// <param name="fileFullName">文件名全路径</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>FastDev.Common.Code.Result.</returns>
        public Result ExportExcelFile_Sysmenu(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return SysmenuLogic.ExportExcelFile(keydata, fileFullName, opertionUser);
        }

        #endregion

        #endregion

        #region Sysrole操作

        #region 查询

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="limit">当前页条数</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public List<Sysrole> GetListPage_Sysrole(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return SysroleLogic.GetListPage(page, limit, dicwhere).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public FastJsonResult<List<Sysrole>> GetJsonListPage_Sysrole(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return SysroleLogic.GetJsonListPage(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Sysrole> GetAllList_Sysrole()
        {
            return SysroleLogic.GetAllList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Sysrole> GetList_Sysrole(Dictionary<string, object> dicwhere)
        {
            return SysroleLogic.GetList(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount_Sysrole(Dictionary<string, object> dicwhere = null)
        {
            return SysroleLogic.GetCount(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Sysrole GetModelByKID_Sysrole(int kID)
        {
            return SysroleLogic.GetModelByKID(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Sysrole GetModelByWhere_Sysrole(Dictionary<string, object> dicwhere)
        {
            return SysroleLogic.GetModelByWhere(dicwhere);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public DataTable GetDataTable_Sysrole(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return SysroleLogic.GetDataTable(dicwhere, page, limit);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public List<Sysrole> GetListByInSelect_Sysrole(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return SysroleLogic.GetListByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public int GetCountByInSelect_Sysrole(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return SysroleLogic.GetCountByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup_Sysrole(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return SysroleLogic.GetDataByGroup(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加
        public Result SetRoleMenus(string roleid, string menuids)
        {
            return SysroleLogic.SetRoleMenus(roleid, menuids);
        }
        public Result SetRoleEmployees(string roleid, string userids)
        {
            return SysroleLogic.SetRoleEmployees(roleid, userids);
        }
        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Add_Sysrole(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return SysroleLogic.Add(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result Adds_Sysrole(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return SysroleLogic.Adds(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntity_Sysrole(Sysrole entity, OpertionUser opertionUser)
        {
            return SysroleLogic.Add(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntitys_Sysrole(List<Sysrole> entitys, OpertionUser opertionUser)
        {
            return SysroleLogic.Adds(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Update_Sysrole(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return SysroleLogic.Update(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">修改值</param>
        /// <param name="keydata">编辑的Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result UpdateByWhere_Sysrole(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return SysroleLogic.UpdateByWhere(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result UpdateNums_Sysrole(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return SysroleLogic.UpdateNums(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Delete_Sysrole(string kid, OpertionUser opertionUser)
        {
            return SysroleLogic.Delete(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result DeleteByWhere_Sysrole(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return SysroleLogic.DeleteByWhere(keydata, opertionUser);
        }
        #endregion

        #region 数据导出

        /// <summary>
        /// Exports the excel file_ product.
        /// </summary>
        /// <param name="keydata">查询条件</param>
        /// <param name="fileFullName">文件名全路径</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>FastDev.Common.Code.Result.</returns>
        public Result ExportExcelFile_Sysrole(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return SysroleLogic.ExportExcelFile(keydata, fileFullName, opertionUser);
        }

        #endregion

        #endregion

        #region Sysuserrole操作

        #region 查询

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="limit">当前页条数</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public List<Sysuserrole> GetListPage_Sysuserrole(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return SysuserroleLogic.GetListPage(page, limit, dicwhere).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public FastJsonResult<List<Sysuserrole>> GetJsonListPage_Sysuserrole(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return SysuserroleLogic.GetJsonListPage(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Sysuserrole> GetAllList_Sysuserrole()
        {
            return SysuserroleLogic.GetAllList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<Sysuserrole> GetList_Sysuserrole(Dictionary<string, object> dicwhere)
        {
            return SysuserroleLogic.GetList(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount_Sysuserrole(Dictionary<string, object> dicwhere = null)
        {
            return SysuserroleLogic.GetCount(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Sysuserrole GetModelByKID_Sysuserrole(int kID)
        {
            return SysuserroleLogic.GetModelByKID(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public Sysuserrole GetModelByWhere_Sysuserrole(Dictionary<string, object> dicwhere)
        {
            return SysuserroleLogic.GetModelByWhere(dicwhere);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public DataTable GetDataTable_Sysuserrole(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return SysuserroleLogic.GetDataTable(dicwhere, page, limit);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public List<Sysuserrole> GetListByInSelect_Sysuserrole(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return SysuserroleLogic.GetListByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public int GetCountByInSelect_Sysuserrole(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return SysuserroleLogic.GetCountByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup_Sysuserrole(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return SysuserroleLogic.GetDataByGroup(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Add_Sysuserrole(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return SysuserroleLogic.Add(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result Adds_Sysuserrole(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return SysuserroleLogic.Adds(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntity_Sysuserrole(Sysuserrole entity, OpertionUser opertionUser)
        {
            return SysuserroleLogic.Add(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntitys_Sysuserrole(List<Sysuserrole> entitys, OpertionUser opertionUser)
        {
            return SysuserroleLogic.Adds(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Update_Sysuserrole(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return SysuserroleLogic.Update(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">修改值</param>
        /// <param name="keydata">编辑的Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result UpdateByWhere_Sysuserrole(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return SysuserroleLogic.UpdateByWhere(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result UpdateNums_Sysuserrole(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return SysuserroleLogic.UpdateNums(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Delete_Sysuserrole(string kid, OpertionUser opertionUser)
        {
            return SysuserroleLogic.Delete(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result DeleteByWhere_Sysuserrole(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return SysuserroleLogic.DeleteByWhere(keydata, opertionUser);
        }
        #endregion

        #region 数据导出

        /// <summary>
        /// Exports the excel file_ product.
        /// </summary>
        /// <param name="keydata">查询条件</param>
        /// <param name="fileFullName">文件名全路径</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>FastDev.Common.Code.Result.</returns>
        public Result ExportExcelFile_Sysuserrole(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return SysuserroleLogic.ExportExcelFile(keydata, fileFullName, opertionUser);
        }

        #endregion

        #endregion

        #region WxUser操作

        #region 查询

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="limit">当前页条数</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public List<WxUser> GetListPage_WxUser(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return WxUserLogic.GetListPage(page, limit, dicwhere).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public FastJsonResult<List<WxUser>> GetJsonListPage_WxUser(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return WxUserLogic.GetJsonListPage(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<WxUser> GetAllList_WxUser()
        {
            return WxUserLogic.GetAllList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<WxUser> GetList_WxUser(Dictionary<string, object> dicwhere)
        {
            return WxUserLogic.GetList(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount_WxUser(Dictionary<string, object> dicwhere = null)
        {
            return WxUserLogic.GetCount(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public WxUser GetModelByKID_WxUser(int kID)
        {
            return WxUserLogic.GetModelByKID(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public WxUser GetModelByWhere_WxUser(Dictionary<string, object> dicwhere)
        {
            return WxUserLogic.GetModelByWhere(dicwhere);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public DataTable GetDataTable_WxUser(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return WxUserLogic.GetDataTable(dicwhere, page, limit);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public List<WxUser> GetListByInSelect_WxUser(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return WxUserLogic.GetListByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public int GetCountByInSelect_WxUser(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return WxUserLogic.GetCountByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup_WxUser(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return WxUserLogic.GetDataByGroup(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Add_WxUser(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return WxUserLogic.Add(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result Adds_WxUser(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return WxUserLogic.Adds(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntity_WxUser(WxUser entity, OpertionUser opertionUser)
        {
            return WxUserLogic.Add(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntitys_WxUser(List<WxUser> entitys, OpertionUser opertionUser)
        {
            return WxUserLogic.Adds(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Update_WxUser(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return WxUserLogic.Update(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">修改值</param>
        /// <param name="keydata">编辑的Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result UpdateByWhere_WxUser(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return WxUserLogic.UpdateByWhere(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result UpdateNums_WxUser(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return WxUserLogic.UpdateNums(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Delete_WxUser(string kid, OpertionUser opertionUser)
        {
            return WxUserLogic.Delete(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result DeleteByWhere_WxUser(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return WxUserLogic.DeleteByWhere(keydata, opertionUser);
        }
        #endregion

        #region 数据导出

        /// <summary>
        /// Exports the excel file_ product.
        /// </summary>
        /// <param name="keydata">查询条件</param>
        /// <param name="fileFullName">文件名全路径</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>FastDev.Common.Code.Result.</returns>
        public Result ExportExcelFile_WxUser(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return WxUserLogic.ExportExcelFile(keydata, fileFullName, opertionUser);
        }

        #endregion

        #endregion

        #region ArticlePraise操作

        #region 查询

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="limit">当前页条数</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public List<ArticlePraise> GetListPage_ArticlePraise(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return ArticlePraiseLogic.GetListPage(page, limit, dicwhere).ToList();
        }

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public FastJsonResult<List<ArticlePraise>> GetJsonListPage_ArticlePraise(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return ArticlePraiseLogic.GetJsonListPage(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<ArticlePraise> GetAllList_ArticlePraise()
        {
            return ArticlePraiseLogic.GetAllList();
        }

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public List<ArticlePraise> GetList_ArticlePraise(Dictionary<string, object> dicwhere)
        {
            return ArticlePraiseLogic.GetList(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetCount_ArticlePraise(Dictionary<string, object> dicwhere = null)
        {
            return ArticlePraiseLogic.GetCount(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public ArticlePraise GetModelByKID_ArticlePraise(int kID)
        {
            return ArticlePraiseLogic.GetModelByKID(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public ArticlePraise GetModelByWhere_ArticlePraise(Dictionary<string, object> dicwhere)
        {
            return ArticlePraiseLogic.GetModelByWhere(dicwhere);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public DataTable GetDataTable_ArticlePraise(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return ArticlePraiseLogic.GetDataTable(dicwhere, page, limit);
        }

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public List<ArticlePraise> GetListByInSelect_ArticlePraise(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return ArticlePraiseLogic.GetListByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public int GetCountByInSelect_ArticlePraise(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return ArticlePraiseLogic.GetCountByInSelect(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup_ArticlePraise(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return ArticlePraiseLogic.GetDataByGroup(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Add_ArticlePraise(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return ArticlePraiseLogic.Add(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="dicdata">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result Adds_ArticlePraise(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return ArticlePraiseLogic.Adds(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntity_ArticlePraise(ArticlePraise entity, OpertionUser opertionUser)
        {
            return ArticlePraiseLogic.Add(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
		/// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result AddByEntitys_ArticlePraise(List<ArticlePraise> entitys, OpertionUser opertionUser)
        {
            return ArticlePraiseLogic.Adds(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">修改条件</param>
        /// <param name="kID">当前数据主键KID</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Update_ArticlePraise(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return ArticlePraiseLogic.Update(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">修改值</param>
        /// <param name="keydata">编辑的Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result UpdateByWhere_ArticlePraise(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return ArticlePraiseLogic.UpdateByWhere(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public Result UpdateNums_ArticlePraise(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return ArticlePraiseLogic.UpdateNums(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">主键ID,多个逗号连接</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result Delete_ArticlePraise(string kid, OpertionUser opertionUser)
        {
            return ArticlePraiseLogic.Delete(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">Where条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public Result DeleteByWhere_ArticlePraise(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return ArticlePraiseLogic.DeleteByWhere(keydata, opertionUser);
        }
        #endregion

        #region 数据导出

        /// <summary>
        /// Exports the excel file_ product.
        /// </summary>
        /// <param name="keydata">查询条件</param>
        /// <param name="fileFullName">文件名全路径</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>FastDev.Common.Code.Result.</returns>
        public Result ExportExcelFile_ArticlePraise(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return ArticlePraiseLogic.ExportExcelFile(keydata, fileFullName, opertionUser);
        }

        #endregion

        #endregion

        /*BC47A26EB9A59406057DDDD62D0898F4*/



    }
}
