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
using CJJ.Blog.Service.Model.View;
using CJJ.Blog.Service.Model.Data;

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
        /// 查询单个博客包括详情
        /// </summary>
        /// <param name="blogNum"></param>
        /// <returns></returns>
        public static BloginfoView GetModelByNum(string blogNum)
        {
            return Client.GetModelByNum(blogNum);
        }

        /// <summary>
        /// 根据博客编号和类型获取上下篇
        /// </summary>
        /// <param name="blogNum"></param>
        /// <param name="type">文章类型</param>
        /// <returns></returns>
        public static PrenextView GetPrenextBlog(string blogNum, int type)
        {
            return Client.GetPrenextBlog(blogNum, type);
        }

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<BloginfoView> GetListPage_Bloginfo(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
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
        public static BloginfoView GetModelByKID_Bloginfo(int kID)
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

        #region Member 操作

        #region 查询
        /// <summary>
        /// 会员登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MemberAuthModel MemberLogin(string account, string password, string type, string ipaddress, string agent, string dns)
        {
            return Client.MemberLogin(account, password, type, ipaddress, agent, dns);
        }

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Member> GetListPage_Member(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_Member(page, limit, dicwhere);
        }
		
		/// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<Member>> GetJsonListPage_Member(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_Member(page,limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Member> GetAllList_Member()
        {
            return Client.GetAllList_Member();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Member> GetList_Member(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_Member(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_Member(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_Member(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Member GetModelByKID_Member(int kID)
        {
            return Client.GetModelByKID_Member(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Member GetModelByWhere_Member(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_Member(dicwhere);
        }

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Member(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_Member(dicwhere, page, limit);
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
        public static List<Member> GetListByInSelect_Member(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_Member(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_Member(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_Member(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_Member(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_Member(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_Member(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_Member(dicdata, opertionUser);
        }

		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_Member(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_Member(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_Member(Member entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_Member(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_Member(List<Member> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_Member(entitys, opertionUser);
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
        public static Result Update_Member(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_Member(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_Member(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_Member(valuedata, keydata, opertionUser);
        }

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_Member(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_Member(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_Member(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_Member(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_Member(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_Member(keydata, opertionUser);
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
        public static Result ExportExcelFile_Member(Dictionary<string, object> keydata,string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_Member(keydata,fileFullName, opertionUser);
        }
        #endregion

        #endregion

		#region Comment 操作

        #region 查询

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Comment> GetListPage_Comment(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_Comment(page, limit, dicwhere);
        }
		
		/// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<Comment>> GetJsonListPage_Comment(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_Comment(page,limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Comment> GetAllList_Comment()
        {
            return Client.GetAllList_Comment();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<CommentView> GetList_Comment(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_Comment(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_Comment(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_Comment(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Comment GetModelByKID_Comment(int kID)
        {
            return Client.GetModelByKID_Comment(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Comment GetModelByWhere_Comment(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_Comment(dicwhere);
        }

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Comment(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_Comment(dicwhere, page, limit);
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
        public static List<Comment> GetListByInSelect_Comment(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_Comment(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_Comment(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_Comment(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_Comment(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_Comment(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_Comment(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_Comment(dicdata, opertionUser);
        }

		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_Comment(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_Comment(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_Comment(Comment entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_Comment(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_Comment(List<Comment> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_Comment(entitys, opertionUser);
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
        public static Result Update_Comment(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_Comment(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_Comment(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_Comment(valuedata, keydata, opertionUser);
        }

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_Comment(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_Comment(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_Comment(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_Comment(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_Comment(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_Comment(keydata, opertionUser);
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
        public static Result ExportExcelFile_Comment(Dictionary<string, object> keydata,string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_Comment(keydata,fileFullName, opertionUser);
        }
        #endregion

        #endregion

        #region Employee 操作

        #region 查询


        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="token">Token值</param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="agent">浏览器标识</param>
        /// <param name="dns">dns标识</param>
        /// <returns>Fd_Sys_LoginUser.</returns>
        public static SysLoginUser GetUserInfoByToken(string token, string ipAddress, string agent, string dns)
        {
            return Client.GetUserInfoByToken(token, ipAddress, agent, dns);
        }
        /// <summary>
        /// 密码登录
        /// </summary>
        /// <param name="useraccount"></param>
        /// <param name="userpsw"></param>
        /// <param name="ipaddress"></param>
        /// <param name="agent"></param>
        /// <param name="dns"></param>
        /// <returns></returns>
        public static SysLoginUser EmployeePasswordLogin(string useraccount, string userpsw, string ipaddress, string agent, string dns)
        {
            return Client.EmployeePasswordLogin(useraccount, userpsw, ipaddress, agent, dns);
        }
        /// <summary>
        /// 手机登录
        /// </summary>
        /// <param name="useraccount"></param>
        /// <param name="ipaddress"></param>
        /// <param name="agent"></param>
        /// <param name="dns"></param>
        /// <returns></returns>
        public static SysLoginUser EmployeeMobileLogin(string useraccount, string ipaddress, string agent, string dns)
        {
            return Client.EmployeeMobileLogin(useraccount, ipaddress, agent, dns);
        }

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
        /// 给员工授予角色
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result SetEmployeeRole(string empid, string roleids)
        {
            return Client.SetEmployeeRole(empid, roleids);
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

        #region Blogcontent 操作

        #region 查询

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Blogcontent> GetListPage_Blogcontent(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_Blogcontent(page, limit, dicwhere);
        }

        /// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<Blogcontent>> GetJsonListPage_Blogcontent(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_Blogcontent(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Blogcontent> GetAllList_Blogcontent()
        {
            return Client.GetAllList_Blogcontent();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Blogcontent> GetList_Blogcontent(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_Blogcontent(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_Blogcontent(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_Blogcontent(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Blogcontent GetModelByKID_Blogcontent(int kID)
        {
            return Client.GetModelByKID_Blogcontent(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Blogcontent GetModelByWhere_Blogcontent(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_Blogcontent(dicwhere);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Blogcontent(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_Blogcontent(dicwhere, page, limit);
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
        public static List<Blogcontent> GetListByInSelect_Blogcontent(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_Blogcontent(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_Blogcontent(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_Blogcontent(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_Blogcontent(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_Blogcontent(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_Blogcontent(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_Blogcontent(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_Blogcontent(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_Blogcontent(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_Blogcontent(Blogcontent entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_Blogcontent(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_Blogcontent(List<Blogcontent> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_Blogcontent(entitys, opertionUser);
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
        public static Result Update_Blogcontent(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_Blogcontent(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_Blogcontent(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_Blogcontent(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_Blogcontent(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_Blogcontent(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_Blogcontent(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_Blogcontent(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_Blogcontent(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_Blogcontent(keydata, opertionUser);
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
        public static Result ExportExcelFile_Blogcontent(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_Blogcontent(keydata, fileFullName, opertionUser);
        }
        #endregion

        #endregion

        #region Logintoken 操作

        #region 查询
        /// <summary>
        /// 根据token获取sysuser
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static SysLoginUser GetSysLoginUserByToken(string token)
        {
            return Client.GetSysLoginUserByToken(token);
        }
        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Logintoken> GetListPage_Logintoken(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_Logintoken(page, limit, dicwhere);
        }

        /// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<Logintoken>> GetJsonListPage_Logintoken(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_Logintoken(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Logintoken> GetAllList_Logintoken()
        {
            return Client.GetAllList_Logintoken();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Logintoken> GetList_Logintoken(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_Logintoken(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_Logintoken(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_Logintoken(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Logintoken GetModelByKID_Logintoken(int kID)
        {
            return Client.GetModelByKID_Logintoken(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Logintoken GetModelByWhere_Logintoken(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_Logintoken(dicwhere);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Logintoken(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_Logintoken(dicwhere, page, limit);
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
        public static List<Logintoken> GetListByInSelect_Logintoken(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_Logintoken(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_Logintoken(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_Logintoken(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_Logintoken(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_Logintoken(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_Logintoken(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_Logintoken(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_Logintoken(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_Logintoken(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_Logintoken(Logintoken entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_Logintoken(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_Logintoken(List<Logintoken> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_Logintoken(entitys, opertionUser);
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
        public static Result Update_Logintoken(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_Logintoken(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_Logintoken(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_Logintoken(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_Logintoken(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_Logintoken(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_Logintoken(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_Logintoken(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_Logintoken(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_Logintoken(keydata, opertionUser);
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
        public static Result ExportExcelFile_Logintoken(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_Logintoken(keydata, fileFullName, opertionUser);
        }
        #endregion

        #endregion

        #region Hotnew 操作

        #region 查询

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<HotNew> GetListPage_HotNew(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_HotNew(page, limit, dicwhere);
        }

        /// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<HotNew>> GetJsonListPage_HotNew(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_HotNew(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<HotNew> GetAllList_HotNew()
        {
            return Client.GetAllList_HotNew();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<HotNew> GetList_HotNew(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_HotNew(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_HotNew(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_HotNew(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static HotNew GetModelByKID_HotNew(int kID)
        {
            return Client.GetModelByKID_HotNew(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static HotNew GetModelByWhere_HotNew(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_HotNew(dicwhere);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_HotNew(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_HotNew(dicwhere, page, limit);
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
        public static List<HotNew> GetListByInSelect_HotNew(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_HotNew(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_HotNew(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_HotNew(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_HotNew(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_HotNew(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_HotNew(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_HotNew(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_HotNew(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_HotNew(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_HotNew(HotNew entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_HotNew(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_HotNew(List<HotNew> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_HotNew(entitys, opertionUser);
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
        public static Result Update_HotNew(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_HotNew(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_HotNew(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_HotNew(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_HotNew(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_HotNew(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_HotNew(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_HotNew(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_HotNew(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_HotNew(keydata, opertionUser);
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
        public static Result ExportExcelFile_HotNew(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_HotNew(keydata, fileFullName, opertionUser);
        }
        #endregion

        #endregion

        #region Sysmenu 操作

        #region 查询


        /// <summary>
        /// 不分页获取权限内的所有数据, 根据账户得到对应渠道管理员的所有权限,才能给下级分配权限
        /// </summary>
        /// <param name="userId">当前登陆用户的Id</param>
        /// <param name="userType">用户类型 0员工 1会员</param>
        /// <returns>
        /// List&lt;Sys_role&gt;.
        /// </returns>
        public static List<Sysmenu> GetListByUserId_Sysmenu(int userId, int userType)
        {
            return Client.GetListByUserId_Sysmenu(userId, userType);
        }
        /// <summary>
        /// 根据userid获取可操作的menu
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static List<Sysmenu> GetListByuserid_Sysmenu(int userid)
        {
            return Client.GetListByuserid_Sysmenu(userid);
        }
        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Sysmenu> GetListPage_Sysmenu(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_Sysmenu(page, limit, dicwhere);
        }

        /// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<Sysmenu>> GetJsonListPage_Sysmenu(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_Sysmenu(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Sysmenu> GetAllList_Sysmenu()
        {
            return Client.GetAllList_Sysmenu();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Sysmenu> GetList_Sysmenu(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_Sysmenu(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_Sysmenu(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_Sysmenu(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Sysmenu GetModelByKID_Sysmenu(int kID)
        {
            return Client.GetModelByKID_Sysmenu(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Sysmenu GetModelByWhere_Sysmenu(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_Sysmenu(dicwhere);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Sysmenu(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_Sysmenu(dicwhere, page, limit);
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
        public static List<Sysmenu> GetListByInSelect_Sysmenu(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_Sysmenu(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_Sysmenu(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_Sysmenu(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_Sysmenu(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_Sysmenu(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_Sysmenu(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_Sysmenu(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_Sysmenu(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_Sysmenu(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_Sysmenu(Sysmenu entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_Sysmenu(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_Sysmenu(List<Sysmenu> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_Sysmenu(entitys, opertionUser);
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
        public static Result Update_Sysmenu(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_Sysmenu(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_Sysmenu(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_Sysmenu(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_Sysmenu(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_Sysmenu(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_Sysmenu(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_Sysmenu(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_Sysmenu(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_Sysmenu(keydata, opertionUser);
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
        public static Result ExportExcelFile_Sysmenu(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_Sysmenu(keydata, fileFullName, opertionUser);
        }
        #endregion

        #endregion

        #region Sysrole 操作

        #region 查询

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Sysrole> GetListPage_Sysrole(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_Sysrole(page, limit, dicwhere);
        }

        /// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<Sysrole>> GetJsonListPage_Sysrole(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_Sysrole(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Sysrole> GetAllList_Sysrole()
        {
            return Client.GetAllList_Sysrole();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Sysrole> GetList_Sysrole(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_Sysrole(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_Sysrole(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_Sysrole(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Sysrole GetModelByKID_Sysrole(int kID)
        {
            return Client.GetModelByKID_Sysrole(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Sysrole GetModelByWhere_Sysrole(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_Sysrole(dicwhere);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Sysrole(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_Sysrole(dicwhere, page, limit);
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
        public static List<Sysrole> GetListByInSelect_Sysrole(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_Sysrole(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_Sysrole(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_Sysrole(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_Sysrole(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_Sysrole(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加
        /// <summary>
        /// 给角色赋员工
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result SetRoleEmployees(string roleid, string userids)
        {
            return Client.SetRoleEmployees(roleid, userids);
        }
        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_Sysrole(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_Sysrole(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_Sysrole(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_Sysrole(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_Sysrole(Sysrole entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_Sysrole(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_Sysrole(List<Sysrole> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_Sysrole(entitys, opertionUser);
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
        public static Result Update_Sysrole(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_Sysrole(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_Sysrole(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_Sysrole(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_Sysrole(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_Sysrole(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_Sysrole(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_Sysrole(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_Sysrole(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_Sysrole(keydata, opertionUser);
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
        public static Result ExportExcelFile_Sysrole(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_Sysrole(keydata, fileFullName, opertionUser);
        }
        #endregion

        #endregion

        #region Sysuserrole 操作

        #region 查询

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<Sysuserrole> GetListPage_Sysuserrole(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_Sysuserrole(page, limit, dicwhere);
        }

        /// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<Sysuserrole>> GetJsonListPage_Sysuserrole(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_Sysuserrole(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Sysuserrole> GetAllList_Sysuserrole()
        {
            return Client.GetAllList_Sysuserrole();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<Sysuserrole> GetList_Sysuserrole(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_Sysuserrole(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_Sysuserrole(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_Sysuserrole(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Sysuserrole GetModelByKID_Sysuserrole(int kID)
        {
            return Client.GetModelByKID_Sysuserrole(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static Sysuserrole GetModelByWhere_Sysuserrole(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_Sysuserrole(dicwhere);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_Sysuserrole(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_Sysuserrole(dicwhere, page, limit);
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
        public static List<Sysuserrole> GetListByInSelect_Sysuserrole(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_Sysuserrole(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_Sysuserrole(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_Sysuserrole(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_Sysuserrole(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_Sysuserrole(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_Sysuserrole(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_Sysuserrole(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_Sysuserrole(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_Sysuserrole(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_Sysuserrole(Sysuserrole entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_Sysuserrole(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_Sysuserrole(List<Sysuserrole> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_Sysuserrole(entitys, opertionUser);
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
        public static Result Update_Sysuserrole(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_Sysuserrole(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_Sysuserrole(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_Sysuserrole(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_Sysuserrole(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_Sysuserrole(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_Sysuserrole(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_Sysuserrole(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_Sysuserrole(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_Sysuserrole(keydata, opertionUser);
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
        public static Result ExportExcelFile_Sysuserrole(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_Sysuserrole(keydata, fileFullName, opertionUser);
        }
        #endregion

        #endregion

        #region WxUser 操作

        #region 查询

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<WxUser> GetListPage_WxUser(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_WxUser(page, limit, dicwhere);
        }

        /// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<WxUser>> GetJsonListPage_WxUser(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_WxUser(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<WxUser> GetAllList_WxUser()
        {
            return Client.GetAllList_WxUser();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<WxUser> GetList_WxUser(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_WxUser(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_WxUser(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_WxUser(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static WxUser GetModelByKID_WxUser(int kID)
        {
            return Client.GetModelByKID_WxUser(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static WxUser GetModelByWhere_WxUser(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_WxUser(dicwhere);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_WxUser(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_WxUser(dicwhere, page, limit);
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
        public static List<WxUser> GetListByInSelect_WxUser(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_WxUser(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_WxUser(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_WxUser(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_WxUser(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_WxUser(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_WxUser(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_WxUser(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_WxUser(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_WxUser(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_WxUser(WxUser entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_WxUser(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_WxUser(List<WxUser> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_WxUser(entitys, opertionUser);
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
        public static Result Update_WxUser(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_WxUser(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_WxUser(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_WxUser(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_WxUser(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_WxUser(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_WxUser(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_WxUser(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_WxUser(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_WxUser(keydata, opertionUser);
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
        public static Result ExportExcelFile_WxUser(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_WxUser(keydata, fileFullName, opertionUser);
        }
        #endregion

        #endregion

        #region ArticlePraise 操作

        #region 查询

        /// <summary>
        /// Gets the menu list. 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;FastDev.Service.Models.Data.Sys_menu&gt;.</returns>
        public static List<ArticlePraise> GetListPage_ArticlePraise(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null)
        {
            return Client.GetListPage_ArticlePraise(page, limit, dicwhere);
        }

        /// <summary>
        /// 获取Json格式的数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        public static FastJsonResult<List<ArticlePraise>> GetJsonListPage_ArticlePraise(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null)
        {
            return Client.GetJsonListPage_ArticlePraise(page, limit, orderby, dicwhere);
        }

        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<ArticlePraise> GetAllList_ArticlePraise()
        {
            return Client.GetAllList_ArticlePraise();
        }

        /// <summary>
        /// 按条件获取数据列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sys_role&gt;.</returns>
        public static List<ArticlePraise> GetList_ArticlePraise(Dictionary<string, object> dicwhere)
        {
            return Client.GetList_ArticlePraise(dicwhere);
        }

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GetCount_ArticlePraise(Dictionary<string, object> dicwhere = null)
        {
            return Client.GetCount_ArticlePraise(dicwhere);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static ArticlePraise GetModelByKID_ArticlePraise(int kID)
        {
            return Client.GetModelByKID_ArticlePraise(kID);
        }

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        public static ArticlePraise GetModelByWhere_ArticlePraise(Dictionary<string, object> dicwhere)
        {
            return Client.GetModelByWhere_ArticlePraise(dicwhere);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        public static DataTable GetDataTable_ArticlePraise(Dictionary<string, object> dicwhere, int page = 1, int limit = 10)
        {
            return Client.GetDataTable_ArticlePraise(dicwhere, page, limit);
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
        public static List<ArticlePraise> GetListByInSelect_ArticlePraise(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10)
        {
            return Client.GetListByInSelect_ArticlePraise(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere, page, limit);
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
        public static int GetCountByInSelect_ArticlePraise(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere)
        {
            return Client.GetCountByInSelect_ArticlePraise(subTableName, mainTableFields, subTableFields, mainDicWhere, subDicWhere);
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public static DataTable GetDataByGroup_ArticlePraise(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10)
        {
            return Client.GetDataByGroup_ArticlePraise(groupByFields, dicWhere, page, limit);
        }

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Add_ArticlePraise(Dictionary<string, object> dicdata, OpertionUser opertionUser)
        {
            return Client.Add_ArticlePraise(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Adds_ArticlePraise(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser)
        {
            return Client.Adds_ArticlePraise(dicdata, opertionUser);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntity_ArticlePraise(ArticlePraise entity, OpertionUser opertionUser)
        {
            return Client.AddByEntity_ArticlePraise(entity, opertionUser);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result AddByEntitys_ArticlePraise(List<ArticlePraise> entitys, OpertionUser opertionUser)
        {
            return Client.AddByEntitys_ArticlePraise(entitys, opertionUser);
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
        public static Result Update_ArticlePraise(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser)
        {
            return Client.Update_ArticlePraise(dicdata, kID, opertionUser);
        }

        /// <summary>
        /// Edits the specified dicdata.
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result UpdateByWhere_ArticlePraise(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.UpdateByWhere_ArticlePraise(valuedata, keydata, opertionUser);
        }

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        public static Result UpdateNums_ArticlePraise(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser)
        {
            return Client.UpdateNums_ArticlePraise(fields, addNums, whereKey, opertionUser);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result Delete_ArticlePraise(string kid, OpertionUser opertionUser)
        {
            return Client.Delete_ArticlePraise(kid, opertionUser);
        }

        /// <summary>
        /// Deletes the specified kid.
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        public static Result DeleteByWhere_ArticlePraise(Dictionary<string, object> keydata, OpertionUser opertionUser)
        {
            return Client.DeleteByWhere_ArticlePraise(keydata, opertionUser);
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
        public static Result ExportExcelFile_ArticlePraise(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser)
        {
            return Client.ExportExcelFile_ArticlePraise(keydata, fileFullName, opertionUser);
        }
        #endregion

        #endregion

        /*BC47A26EB9A59406057DDDD62D0898F4*/


    }
}

