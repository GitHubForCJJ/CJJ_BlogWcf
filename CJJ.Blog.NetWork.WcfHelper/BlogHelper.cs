//-----------------------------------------------------------------------------------
// <copyright file="CJJ.BlogService.cs" company="Go Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : chenjianjun
// * fileName : CJJ.BlogService.cs
// * history  : created by chenjianjun 2019-06-14 15:52:46
// </copyright>
// <summary>
//   CJJ.Blog.NetWork.WcfHelper
// </summary>
//-----------------------------------------------------------------------------------

using FastDev.Common.Code;
using CJJ.Blog.NetWork.IService;
using CJJ.Blog.Service.Models.Data;
using FastDev.WCF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJJ.Blog.Service.Models.View;
using FastDev.Http;
using System.Data;

namespace CJJ.Blog.NetWork.WcfHelper
{
    /// <summary>
    /// CJJ.BlogHelper
    /// </summary>	
    public class BlogHelper
    {
        #region 构造函数

        /// <summary>
        /// 本地代理
        /// </summary>
        private static readonly IBlogService Client;

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static BlogHelper()
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WCFConfig/BlogService.config");
            Client = ServiceProxyFactory.Create<IBlogService>(configPath, "BlogServiceEndpoint");
        }
        #endregion
		

		#region Bloginfo 操作

        #region 查询

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Bloginfo> GetListPage_Bloginfo(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_Bloginfo(page, limit, dicwhere);
        }
		
		/// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<Bloginfo>> GetJsonListPage_Bloginfo(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_Bloginfo(page,limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Bloginfo> GetAllList_Bloginfo()
        {
            return Client.GetAllList_Bloginfo();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Bloginfo> GetList_Bloginfo(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_Bloginfo(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_Bloginfo(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_Bloginfo(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Bloginfo GetModelByKID_Bloginfo(int kID)
        {
            return Client.GetModelByKID_Bloginfo(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Bloginfo GetModelByWhere_Bloginfo(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_Bloginfo(dicwhere);
        }

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Bloginfo(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_Bloginfo(dicwhere, page, limit);
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
        public static List<Bloginfo> GetListByInSelect_Bloginfo(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_Bloginfo(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_Bloginfo(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_Bloginfo(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_Bloginfo(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_Bloginfo(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_Bloginfo(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_Bloginfo(dicdata, opertionUser);
        }

		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_Bloginfo(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_Bloginfo(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_Bloginfo(Bloginfo entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_Bloginfo(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_Bloginfo(List<Bloginfo> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_Bloginfo(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Update_Bloginfo(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_Bloginfo(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_Bloginfo(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_Bloginfo(valuedata, keydata, opertionUser);
        }

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_Bloginfo(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_Bloginfo(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_Bloginfo(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_Bloginfo(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_Bloginfo(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_Bloginfo(keydata, opertionUser);
        }
        #endregion

		#region 数据导出

        #endregion

        #endregion

		#region Category 操作

        #region 查询

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Category> GetListPage_Category(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_Category(page, limit, dicwhere);
        }
		
		/// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<Category>> GetJsonListPage_Category(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_Category(page,limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Category> GetAllList_Category()
        {
            return Client.GetAllList_Category();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Category> GetList_Category(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_Category(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_Category(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_Category(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Category GetModelByKID_Category(int kID)
        {
            return Client.GetModelByKID_Category(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Category GetModelByWhere_Category(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_Category(dicwhere);
        }

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Category(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_Category(dicwhere, page, limit);
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
        public static List<Category> GetListByInSelect_Category(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_Category(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_Category(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_Category(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_Category(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_Category(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_Category(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_Category(dicdata, opertionUser);
        }

		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_Category(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_Category(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_Category(Category entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_Category(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_Category(List<Category> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_Category(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Update_Category(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_Category(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_Category(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_Category(valuedata, keydata, opertionUser);
        }

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_Category(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_Category(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_Category(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_Category(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_Category(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_Category(keydata, opertionUser);
        }
        #endregion

		#region 数据导出
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result ExportExcelFile_Category(Dictionary<string, object> keydata,string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_Category(keydata,fileFullName, opertionUser);
        }
        #endregion

        #endregion

		#region Categorypic 操作

        #region 查询

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Categorypic> GetListPage_Categorypic(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_Categorypic(page, limit, dicwhere);
        }
		
		/// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<Categorypic>> GetJsonListPage_Categorypic(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_Categorypic(page,limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Categorypic> GetAllList_Categorypic()
        {
            return Client.GetAllList_Categorypic();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Categorypic> GetList_Categorypic(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_Categorypic(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_Categorypic(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_Categorypic(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Categorypic GetModelByKID_Categorypic(int kID)
        {
            return Client.GetModelByKID_Categorypic(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Categorypic GetModelByWhere_Categorypic(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_Categorypic(dicwhere);
        }

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Categorypic(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_Categorypic(dicwhere, page, limit);
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
        public static List<Categorypic> GetListByInSelect_Categorypic(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_Categorypic(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_Categorypic(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_Categorypic(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_Categorypic(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_Categorypic(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_Categorypic(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_Categorypic(dicdata, opertionUser);
        }

		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_Categorypic(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_Categorypic(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_Categorypic(Categorypic entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_Categorypic(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_Categorypic(List<Categorypic> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_Categorypic(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Update_Categorypic(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_Categorypic(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_Categorypic(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_Categorypic(valuedata, keydata, opertionUser);
        }

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_Categorypic(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_Categorypic(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_Categorypic(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_Categorypic(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_Categorypic(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_Categorypic(keydata, opertionUser);
        }
        #endregion

		#region 数据导出
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result ExportExcelFile_Categorypic(Dictionary<string, object> keydata,string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_Categorypic(keydata,fileFullName, opertionUser);
        }
        #endregion

        #endregion

		#region Checknum 操作

        #region 查询

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Checknum> GetListPage_Checknum(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_Checknum(page, limit, dicwhere);
        }
		
		/// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<Checknum>> GetJsonListPage_Checknum(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_Checknum(page,limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Checknum> GetAllList_Checknum()
        {
            return Client.GetAllList_Checknum();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Checknum> GetList_Checknum(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_Checknum(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_Checknum(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_Checknum(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Checknum GetModelByKID_Checknum(int kID)
        {
            return Client.GetModelByKID_Checknum(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Checknum GetModelByWhere_Checknum(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_Checknum(dicwhere);
        }

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Checknum(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_Checknum(dicwhere, page, limit);
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
        public static List<Checknum> GetListByInSelect_Checknum(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_Checknum(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_Checknum(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_Checknum(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_Checknum(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_Checknum(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_Checknum(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_Checknum(dicdata, opertionUser);
        }

		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_Checknum(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_Checknum(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_Checknum(Checknum entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_Checknum(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_Checknum(List<Checknum> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_Checknum(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Update_Checknum(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_Checknum(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_Checknum(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_Checknum(valuedata, keydata, opertionUser);
        }

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_Checknum(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_Checknum(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_Checknum(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_Checknum(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_Checknum(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_Checknum(keydata, opertionUser);
        }
        #endregion

		#region 数据导出
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result ExportExcelFile_Checknum(Dictionary<string, object> keydata,string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_Checknum(keydata,fileFullName, opertionUser);
        }
        #endregion

        #endregion

		#region Comments 操作

        #region 查询

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Comments> GetListPage_Comments(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_Comments(page, limit, dicwhere);
        }
		
		/// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<Comments>> GetJsonListPage_Comments(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_Comments(page,limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Comments> GetAllList_Comments()
        {
            return Client.GetAllList_Comments();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Comments> GetList_Comments(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_Comments(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_Comments(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_Comments(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Comments GetModelByKID_Comments(int kID)
        {
            return Client.GetModelByKID_Comments(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Comments GetModelByWhere_Comments(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_Comments(dicwhere);
        }

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Comments(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_Comments(dicwhere, page, limit);
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
        public static List<Comments> GetListByInSelect_Comments(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_Comments(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_Comments(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_Comments(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_Comments(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_Comments(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_Comments(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_Comments(dicdata, opertionUser);
        }

		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_Comments(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_Comments(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_Comments(Comments entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_Comments(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_Comments(List<Comments> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_Comments(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Update_Comments(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_Comments(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_Comments(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_Comments(valuedata, keydata, opertionUser);
        }

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_Comments(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_Comments(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_Comments(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_Comments(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_Comments(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_Comments(keydata, opertionUser);
        }
        #endregion

		#region 数据导出
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result ExportExcelFile_Comments(Dictionary<string, object> keydata,string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_Comments(keydata,fileFullName, opertionUser);
        }
        #endregion

        #endregion

		#region Employee 操作

        #region 查询

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Employee> GetListPage_Employee(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_Employee(page, limit, dicwhere);
        }
		
		/// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<Employee>> GetJsonListPage_Employee(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_Employee(page,limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Employee> GetAllList_Employee()
        {
            return Client.GetAllList_Employee();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Employee> GetList_Employee(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_Employee(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_Employee(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_Employee(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Employee GetModelByKID_Employee(int kID)
        {
            return Client.GetModelByKID_Employee(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Employee GetModelByWhere_Employee(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_Employee(dicwhere);
        }

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Employee(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_Employee(dicwhere, page, limit);
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
        public static List<Employee> GetListByInSelect_Employee(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_Employee(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_Employee(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_Employee(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_Employee(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_Employee(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_Employee(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_Employee(dicdata, opertionUser);
        }

		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_Employee(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_Employee(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_Employee(Employee entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_Employee(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_Employee(List<Employee> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_Employee(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Update_Employee(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_Employee(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_Employee(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_Employee(valuedata, keydata, opertionUser);
        }

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_Employee(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_Employee(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_Employee(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_Employee(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_Employee(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_Employee(keydata, opertionUser);
        }
        #endregion

		#region 数据导出
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result ExportExcelFile_Employee(Dictionary<string, object> keydata,string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_Employee(keydata,fileFullName, opertionUser);
        }
        #endregion

        #endregion

		#region Media 操作

        #region 查询

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Media> GetListPage_Media(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_Media(page, limit, dicwhere);
        }
		
		/// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<Media>> GetJsonListPage_Media(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_Media(page,limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Media> GetAllList_Media()
        {
            return Client.GetAllList_Media();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Media> GetList_Media(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_Media(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_Media(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_Media(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Media GetModelByKID_Media(int kID)
        {
            return Client.GetModelByKID_Media(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Media GetModelByWhere_Media(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_Media(dicwhere);
        }

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Media(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_Media(dicwhere, page, limit);
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
        public static List<Media> GetListByInSelect_Media(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_Media(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_Media(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_Media(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_Media(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_Media(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_Media(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_Media(dicdata, opertionUser);
        }

		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_Media(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_Media(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_Media(Media entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_Media(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_Media(List<Media> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_Media(entitys, opertionUser);
        }
        #endregion

        #region 修改

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Update_Media(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_Media(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_Media(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_Media(valuedata, keydata, opertionUser);
        }

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_Media(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_Media(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_Media(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_Media(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_Media(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_Media(keydata, opertionUser);
        }
        #endregion

		#region 数据导出
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result ExportExcelFile_Media(Dictionary<string, object> keydata,string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_Media(keydata,fileFullName, opertionUser);
        }
        #endregion

        #endregion

/*BC47A26EB9A59406057DDDD62D0898F4*/


    }
}

