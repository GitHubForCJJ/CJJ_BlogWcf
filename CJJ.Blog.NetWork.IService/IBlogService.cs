//-----------------------------------------------------------------------------------
// <copyright file="CJJ.BlogService.cs" company="Go Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : Administrator
// * fileName : CJJ.BlogService.cs
// * history  : created by chenjianjun 2019-06-14 15:52:46
// </copyright>
// <summary>
//   CJJ.Blog.NetWork.IService
// </summary>
//-----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FastDev.Common.Code;
using System.Threading.Tasks;
using System.Collections.Generic;
using CJJ.Blog.Service.Models.Data;
using FastDev.Http;
using System.Data;
using CJJ.Blog.Service.Models.View;
using CJJ.Blog.Service.Model.View;

namespace CJJ.Blog.NetWork.IService
{
    /// <summary>
    /// ICJJ.BlogService WCF服务契约接口层
    /// </summary>
    /// <seealso cref="CJJ.Blog.NetWork.IService.ICJJ.BlogService" />
     [ServiceContract]
	public interface IBlogService
    {        

		#region Bloginfo 操作

        #region 查询

        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        [OperationContract]
        List<BloginfoView> GetListPage_Bloginfo(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null);

		/// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        [OperationContract]
        FastJsonResult<List<Bloginfo>> GetJsonListPage_Bloginfo(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null);


        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Bloginfo&gt;.</returns>
        [OperationContract]
        List<Bloginfo> GetAllList_Bloginfo();

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Bloginfo&gt;.</returns>
        [OperationContract]
        List<Bloginfo> GetList_Bloginfo(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        int GetCount_Bloginfo(Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        BloginfoView GetModelByKID_Bloginfo(int kID);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Bloginfo GetModelByWhere_Bloginfo(Dictionary<string, object> dicwhere);

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataTable_Bloginfo(Dictionary<string, object> dicwhere, int page = 1, int limit = 10);

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
        [OperationContract]
        List<Bloginfo> GetListByInSelect_Bloginfo(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10);

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <returns></returns>
        [OperationContract]
        int GetCountByInSelect_Bloginfo(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere);

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataByGroup_Bloginfo(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10);

        #endregion

        #region 添加

       	/// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Add_Bloginfo(Dictionary<string, object> dicdata, OpertionUser opertionUser);
		
		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result Adds_Bloginfo(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntity_Bloginfo(Bloginfo entity, OpertionUser opertionUser);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntitys_Bloginfo(List<Bloginfo> entitys, OpertionUser opertionUser);
        #endregion

        #region 修改

        /// <summary>
        /// 根据主键修改对应字段值
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Update_Bloginfo(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser);

        /// <summary>
        /// 根据条件批量修改字段值
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result UpdateByWhere_Bloginfo(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser);

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result UpdateNums_Bloginfo(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser);

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Delete_Bloginfo(string kid, OpertionUser opertionUser);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result DeleteByWhere_Bloginfo(Dictionary<string, object> keydata, OpertionUser opertionUser);
        #endregion

		#region 数据导出
        /// <summary>
        ///// 数据导出
        ///// </summary>
        ///// <param name="keydata">The keydata.</param>
        ///// <param name="fileFullName">Full name of the file.</param>
        ///// <param name="opertionUser">操作者信息</param>
        ///// <returns>Result.</returns>
        //[OperationContract]
        //Result ExportExcelFile_Bloginfo(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser);

        #endregion

        #endregion

		#region Category 操作

        #region 查询

        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        [OperationContract]
        List<Category> GetListPage_Category(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null);

		/// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        [OperationContract]
        FastJsonResult<List<Category>> GetJsonListPage_Category(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null);


        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Category&gt;.</returns>
        [OperationContract]
        List<Category> GetAllList_Category();

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Category&gt;.</returns>
        [OperationContract]
        List<Category> GetList_Category(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        int GetCount_Category(Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Category GetModelByKID_Category(int kID);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Category GetModelByWhere_Category(Dictionary<string, object> dicwhere);

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataTable_Category(Dictionary<string, object> dicwhere, int page = 1, int limit = 10);

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
        [OperationContract]
        List<Category> GetListByInSelect_Category(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10);

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <returns></returns>
        [OperationContract]
        int GetCountByInSelect_Category(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere);

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataByGroup_Category(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10);

        #endregion

        #region 添加

       	/// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Add_Category(Dictionary<string, object> dicdata, OpertionUser opertionUser);
		
		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result Adds_Category(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntity_Category(Category entity, OpertionUser opertionUser);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntitys_Category(List<Category> entitys, OpertionUser opertionUser);
        #endregion

        #region 修改

        /// <summary>
        /// 根据主键修改对应字段值
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Update_Category(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser);

        /// <summary>
        /// 根据条件批量修改字段值
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result UpdateByWhere_Category(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser);

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result UpdateNums_Category(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser);

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Delete_Category(string kid, OpertionUser opertionUser);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result DeleteByWhere_Category(Dictionary<string, object> keydata, OpertionUser opertionUser);
        #endregion

		#region 数据导出
        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result ExportExcelFile_Category(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser);

        #endregion

        #endregion

		#region Categorypic 操作

        #region 查询

        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        [OperationContract]
        List<Categorypic> GetListPage_Categorypic(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null);

		/// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        [OperationContract]
        FastJsonResult<List<Categorypic>> GetJsonListPage_Categorypic(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null);


        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Categorypic&gt;.</returns>
        [OperationContract]
        List<Categorypic> GetAllList_Categorypic();

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Categorypic&gt;.</returns>
        [OperationContract]
        List<Categorypic> GetList_Categorypic(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        int GetCount_Categorypic(Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Categorypic GetModelByKID_Categorypic(int kID);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Categorypic GetModelByWhere_Categorypic(Dictionary<string, object> dicwhere);

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataTable_Categorypic(Dictionary<string, object> dicwhere, int page = 1, int limit = 10);

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
        [OperationContract]
        List<Categorypic> GetListByInSelect_Categorypic(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10);

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <returns></returns>
        [OperationContract]
        int GetCountByInSelect_Categorypic(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere);

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataByGroup_Categorypic(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10);

        #endregion

        #region 添加

       	/// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Add_Categorypic(Dictionary<string, object> dicdata, OpertionUser opertionUser);
		
		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result Adds_Categorypic(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntity_Categorypic(Categorypic entity, OpertionUser opertionUser);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntitys_Categorypic(List<Categorypic> entitys, OpertionUser opertionUser);
        #endregion

        #region 修改

        /// <summary>
        /// 根据主键修改对应字段值
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Update_Categorypic(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser);

        /// <summary>
        /// 根据条件批量修改字段值
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result UpdateByWhere_Categorypic(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser);

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result UpdateNums_Categorypic(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser);

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Delete_Categorypic(string kid, OpertionUser opertionUser);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result DeleteByWhere_Categorypic(Dictionary<string, object> keydata, OpertionUser opertionUser);
        #endregion

		#region 数据导出
        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result ExportExcelFile_Categorypic(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser);

        #endregion

        #endregion

		#region Checknum 操作

        #region 查询

        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        [OperationContract]
        List<Checknum> GetListPage_Checknum(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null);

		/// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        [OperationContract]
        FastJsonResult<List<Checknum>> GetJsonListPage_Checknum(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null);


        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Checknum&gt;.</returns>
        [OperationContract]
        List<Checknum> GetAllList_Checknum();

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Checknum&gt;.</returns>
        [OperationContract]
        List<Checknum> GetList_Checknum(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        int GetCount_Checknum(Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Checknum GetModelByKID_Checknum(int kID);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Checknum GetModelByWhere_Checknum(Dictionary<string, object> dicwhere);

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataTable_Checknum(Dictionary<string, object> dicwhere, int page = 1, int limit = 10);

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
        [OperationContract]
        List<Checknum> GetListByInSelect_Checknum(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10);

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <returns></returns>
        [OperationContract]
        int GetCountByInSelect_Checknum(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere);

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataByGroup_Checknum(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10);

        #endregion

        #region 添加

       	/// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Add_Checknum(Dictionary<string, object> dicdata, OpertionUser opertionUser);
		
		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result Adds_Checknum(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntity_Checknum(Checknum entity, OpertionUser opertionUser);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntitys_Checknum(List<Checknum> entitys, OpertionUser opertionUser);
        #endregion

        #region 修改

        /// <summary>
        /// 根据主键修改对应字段值
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Update_Checknum(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser);

        /// <summary>
        /// 根据条件批量修改字段值
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result UpdateByWhere_Checknum(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser);

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result UpdateNums_Checknum(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser);

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Delete_Checknum(string kid, OpertionUser opertionUser);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result DeleteByWhere_Checknum(Dictionary<string, object> keydata, OpertionUser opertionUser);
        #endregion

		#region 数据导出
        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result ExportExcelFile_Checknum(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser);

        #endregion

        #endregion

		#region Comments 操作

        #region 查询

        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        [OperationContract]
        List<Comments> GetListPage_Comments(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null);

		/// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        [OperationContract]
        FastJsonResult<List<Comments>> GetJsonListPage_Comments(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null);


        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Comments&gt;.</returns>
        [OperationContract]
        List<Comments> GetAllList_Comments();

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Comments&gt;.</returns>
        [OperationContract]
        List<Comments> GetList_Comments(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        int GetCount_Comments(Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Comments GetModelByKID_Comments(int kID);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Comments GetModelByWhere_Comments(Dictionary<string, object> dicwhere);

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataTable_Comments(Dictionary<string, object> dicwhere, int page = 1, int limit = 10);

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
        [OperationContract]
        List<Comments> GetListByInSelect_Comments(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10);

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <returns></returns>
        [OperationContract]
        int GetCountByInSelect_Comments(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere);

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataByGroup_Comments(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10);

        #endregion

        #region 添加

       	/// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Add_Comments(Dictionary<string, object> dicdata, OpertionUser opertionUser);
		
		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result Adds_Comments(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntity_Comments(Comments entity, OpertionUser opertionUser);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntitys_Comments(List<Comments> entitys, OpertionUser opertionUser);
        #endregion

        #region 修改

        /// <summary>
        /// 根据主键修改对应字段值
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Update_Comments(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser);

        /// <summary>
        /// 根据条件批量修改字段值
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result UpdateByWhere_Comments(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser);

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result UpdateNums_Comments(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser);

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Delete_Comments(string kid, OpertionUser opertionUser);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result DeleteByWhere_Comments(Dictionary<string, object> keydata, OpertionUser opertionUser);
        #endregion

		#region 数据导出
        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result ExportExcelFile_Comments(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser);

        #endregion

        #endregion

        #region Employee 操作

        #region 查询
        /// <summary>
        /// 密码登录
        /// </summary>
        /// <param name="useraccount"></param>
        /// <param name="userpsw"></param>
        /// <param name="ipaddress"></param>
        /// <param name="agent"></param>
        /// <param name="dns"></param>
        /// <returns></returns>
        [OperationContract]
        SysLoginUser EmployeePasswordLogin(string useraccount,string userpsw,string ipaddress,string agent,string dns);
        /// <summary>
        /// 手机登录
        /// </summary>
        /// <param name="useraccount"></param>
        /// <param name="ipaddress"></param>
        /// <param name="agent"></param>
        /// <param name="dns"></param>
        /// <returns></returns>
        [OperationContract]
        SysLoginUser EmployeeMobileLogin(string useraccount, string ipaddress, string agent, string dns);

        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        [OperationContract]
        List<Employee> GetListPage_Employee(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null);

		/// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        [OperationContract]
        FastJsonResult<List<Employee>> GetJsonListPage_Employee(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null);


        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Employee&gt;.</returns>
        [OperationContract]
        List<Employee> GetAllList_Employee();

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Employee&gt;.</returns>
        [OperationContract]
        List<Employee> GetList_Employee(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        int GetCount_Employee(Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Employee GetModelByKID_Employee(int kID);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Employee GetModelByWhere_Employee(Dictionary<string, object> dicwhere);

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataTable_Employee(Dictionary<string, object> dicwhere, int page = 1, int limit = 10);

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
        [OperationContract]
        List<Employee> GetListByInSelect_Employee(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10);

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <returns></returns>
        [OperationContract]
        int GetCountByInSelect_Employee(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere);

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataByGroup_Employee(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10);

        #endregion

        #region 添加
        /// <summary>
        /// 给员工授予角色
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result SetEmployeeRole(string empid,string roleids);

		
		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result Adds_Employee(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntity_Employee(Employee entity, OpertionUser opertionUser);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntitys_Employee(List<Employee> entitys, OpertionUser opertionUser);
        #endregion

        #region 修改

        /// <summary>
        /// 根据主键修改对应字段值
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Update_Employee(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser);

        /// <summary>
        /// 根据条件批量修改字段值
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result UpdateByWhere_Employee(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser);

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result UpdateNums_Employee(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser);

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Delete_Employee(string kid, OpertionUser opertionUser);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result DeleteByWhere_Employee(Dictionary<string, object> keydata, OpertionUser opertionUser);
        #endregion

		#region 数据导出
        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result ExportExcelFile_Employee(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser);

        #endregion

        #endregion

		#region Media 操作

        #region 查询

        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        [OperationContract]
        List<Media> GetListPage_Media(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null);

		/// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        [OperationContract]
        FastJsonResult<List<Media>> GetJsonListPage_Media(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null);


        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Media&gt;.</returns>
        [OperationContract]
        List<Media> GetAllList_Media();

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Media&gt;.</returns>
        [OperationContract]
        List<Media> GetList_Media(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        int GetCount_Media(Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Media GetModelByKID_Media(int kID);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Media GetModelByWhere_Media(Dictionary<string, object> dicwhere);

		 /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataTable_Media(Dictionary<string, object> dicwhere, int page = 1, int limit = 10);

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
        [OperationContract]
        List<Media> GetListByInSelect_Media(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10);

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <returns></returns>
        [OperationContract]
        int GetCountByInSelect_Media(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere);

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataByGroup_Media(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10);

        #endregion

        #region 添加

       	/// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Add_Media(Dictionary<string, object> dicdata, OpertionUser opertionUser);
		
		/// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result Adds_Media(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntity_Media(Media entity, OpertionUser opertionUser);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntitys_Media(List<Media> entitys, OpertionUser opertionUser);
        #endregion

        #region 修改

        /// <summary>
        /// 根据主键修改对应字段值
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Update_Media(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser);

        /// <summary>
        /// 根据条件批量修改字段值
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result UpdateByWhere_Media(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser);

		/// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result UpdateNums_Media(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser);

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Delete_Media(string kid, OpertionUser opertionUser);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result DeleteByWhere_Media(Dictionary<string, object> keydata, OpertionUser opertionUser);
        #endregion

		#region 数据导出
        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result ExportExcelFile_Media(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser);

        #endregion

        #endregion

        #region Blogcontent 操作

        #region 查询

        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        [OperationContract]
        List<Blogcontent> GetListPage_Blogcontent(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        [OperationContract]
        FastJsonResult<List<Blogcontent>> GetJsonListPage_Blogcontent(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null);


        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Blogcontent&gt;.</returns>
        [OperationContract]
        List<Blogcontent> GetAllList_Blogcontent();

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Blogcontent&gt;.</returns>
        [OperationContract]
        List<Blogcontent> GetList_Blogcontent(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        int GetCount_Blogcontent(Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Blogcontent GetModelByKID_Blogcontent(int kID);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Blogcontent GetModelByWhere_Blogcontent(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataTable_Blogcontent(Dictionary<string, object> dicwhere, int page = 1, int limit = 10);

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
        [OperationContract]
        List<Blogcontent> GetListByInSelect_Blogcontent(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10);

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <returns></returns>
        [OperationContract]
        int GetCountByInSelect_Blogcontent(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere);

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataByGroup_Blogcontent(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10);

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Add_Blogcontent(Dictionary<string, object> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result Adds_Blogcontent(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntity_Blogcontent(Blogcontent entity, OpertionUser opertionUser);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntitys_Blogcontent(List<Blogcontent> entitys, OpertionUser opertionUser);
        #endregion

        #region 修改

        /// <summary>
        /// 根据主键修改对应字段值
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Update_Blogcontent(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser);

        /// <summary>
        /// 根据条件批量修改字段值
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result UpdateByWhere_Blogcontent(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser);

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result UpdateNums_Blogcontent(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser);

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Delete_Blogcontent(string kid, OpertionUser opertionUser);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result DeleteByWhere_Blogcontent(Dictionary<string, object> keydata, OpertionUser opertionUser);
        #endregion

        #region 数据导出
        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result ExportExcelFile_Blogcontent(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser);

        #endregion

        #endregion

        #region Logintoken 操作

        #region 查询
        /// <summary>
        /// 根据token获取登录者
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [OperationContract]
        SysLoginUser GetSysLoginUserByToken(string token);

        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        [OperationContract]
        List<Logintoken> GetListPage_Logintoken(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        [OperationContract]
        FastJsonResult<List<Logintoken>> GetJsonListPage_Logintoken(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null);


        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Logintoken&gt;.</returns>
        [OperationContract]
        List<Logintoken> GetAllList_Logintoken();

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Logintoken&gt;.</returns>
        [OperationContract]
        List<Logintoken> GetList_Logintoken(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        int GetCount_Logintoken(Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Logintoken GetModelByKID_Logintoken(int kID);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Logintoken GetModelByWhere_Logintoken(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataTable_Logintoken(Dictionary<string, object> dicwhere, int page = 1, int limit = 10);

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
        [OperationContract]
        List<Logintoken> GetListByInSelect_Logintoken(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10);

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <returns></returns>
        [OperationContract]
        int GetCountByInSelect_Logintoken(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere);

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataByGroup_Logintoken(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10);

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Add_Logintoken(Dictionary<string, object> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result Adds_Logintoken(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntity_Logintoken(Logintoken entity, OpertionUser opertionUser);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntitys_Logintoken(List<Logintoken> entitys, OpertionUser opertionUser);
        #endregion

        #region 修改

        /// <summary>
        /// 根据主键修改对应字段值
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Update_Logintoken(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser);

        /// <summary>
        /// 根据条件批量修改字段值
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result UpdateByWhere_Logintoken(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser);

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result UpdateNums_Logintoken(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser);

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Delete_Logintoken(string kid, OpertionUser opertionUser);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result DeleteByWhere_Logintoken(Dictionary<string, object> keydata, OpertionUser opertionUser);
        #endregion

        #region 数据导出
        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result ExportExcelFile_Logintoken(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser);

        #endregion

        #endregion

        #region HotNew 操作

        #region 查询
        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        [OperationContract]
        List<HotNew> GetListPage_HotNew(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        [OperationContract]
        FastJsonResult<List<HotNew>> GetJsonListPage_HotNew(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null);


        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;HotNew&gt;.</returns>
        [OperationContract]
        List<HotNew> GetAllList_HotNew();

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;HotNew&gt;.</returns>
        [OperationContract]
        List<HotNew> GetList_HotNew(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        int GetCount_HotNew(Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        HotNew GetModelByKID_HotNew(int kID);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        HotNew GetModelByWhere_HotNew(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataTable_HotNew(Dictionary<string, object> dicwhere, int page = 1, int limit = 10);

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
        [OperationContract]
        List<HotNew> GetListByInSelect_HotNew(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10);

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <returns></returns>
        [OperationContract]
        int GetCountByInSelect_HotNew(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere);

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataByGroup_HotNew(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10);

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Add_HotNew(Dictionary<string, object> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result Adds_HotNew(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntity_HotNew(HotNew entity, OpertionUser opertionUser);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntitys_HotNew(List<HotNew> entitys, OpertionUser opertionUser);
        #endregion

        #region 修改

        /// <summary>
        /// 根据主键修改对应字段值
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Update_HotNew(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser);

        /// <summary>
        /// 根据条件批量修改字段值
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result UpdateByWhere_HotNew(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser);

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result UpdateNums_HotNew(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser);

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Delete_HotNew(string kid, OpertionUser opertionUser);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result DeleteByWhere_HotNew(Dictionary<string, object> keydata, OpertionUser opertionUser);
        #endregion

        #region 数据导出
        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result ExportExcelFile_HotNew(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser);

        #endregion

        #endregion

        #region Sysmenu 操作

        #region 查询
        /// <summary>
        /// 根据用户id获取可操作的menu
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        [OperationContract]
        List<Sysmenu> GetListByuserid_Sysmenu(int userid);

        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        [OperationContract]
        List<Sysmenu> GetListPage_Sysmenu(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        [OperationContract]
        FastJsonResult<List<Sysmenu>> GetJsonListPage_Sysmenu(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null);


        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sysmenu&gt;.</returns>
        [OperationContract]
        List<Sysmenu> GetAllList_Sysmenu();

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sysmenu&gt;.</returns>
        [OperationContract]
        List<Sysmenu> GetList_Sysmenu(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        int GetCount_Sysmenu(Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Sysmenu GetModelByKID_Sysmenu(int kID);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Sysmenu GetModelByWhere_Sysmenu(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataTable_Sysmenu(Dictionary<string, object> dicwhere, int page = 1, int limit = 10);

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
        [OperationContract]
        List<Sysmenu> GetListByInSelect_Sysmenu(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10);

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <returns></returns>
        [OperationContract]
        int GetCountByInSelect_Sysmenu(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere);

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataByGroup_Sysmenu(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10);

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Add_Sysmenu(Dictionary<string, object> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result Adds_Sysmenu(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntity_Sysmenu(Sysmenu entity, OpertionUser opertionUser);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntitys_Sysmenu(List<Sysmenu> entitys, OpertionUser opertionUser);
        #endregion

        #region 修改

        /// <summary>
        /// 根据主键修改对应字段值
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Update_Sysmenu(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser);

        /// <summary>
        /// 根据条件批量修改字段值
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result UpdateByWhere_Sysmenu(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser);

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result UpdateNums_Sysmenu(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser);

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Delete_Sysmenu(string kid, OpertionUser opertionUser);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result DeleteByWhere_Sysmenu(Dictionary<string, object> keydata, OpertionUser opertionUser);
        #endregion

        #region 数据导出
        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result ExportExcelFile_Sysmenu(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser);

        #endregion

        #endregion

        #region Sysrole 操作

        #region 查询

        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        [OperationContract]
        List<Sysrole> GetListPage_Sysrole(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        [OperationContract]
        FastJsonResult<List<Sysrole>> GetJsonListPage_Sysrole(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null);


        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sysrole&gt;.</returns>
        [OperationContract]
        List<Sysrole> GetAllList_Sysrole();

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sysrole&gt;.</returns>
        [OperationContract]
        List<Sysrole> GetList_Sysrole(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        int GetCount_Sysrole(Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Sysrole GetModelByKID_Sysrole(int kID);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Sysrole GetModelByWhere_Sysrole(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataTable_Sysrole(Dictionary<string, object> dicwhere, int page = 1, int limit = 10);

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
        [OperationContract]
        List<Sysrole> GetListByInSelect_Sysrole(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10);

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <returns></returns>
        [OperationContract]
        int GetCountByInSelect_Sysrole(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere);

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataByGroup_Sysrole(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10);

        #endregion

        #region 添加
        /// <summary>
        /// 给角色授予员工
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result SetRoleEmployees(string roleid, string userids);
        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Add_Sysrole(Dictionary<string, object> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result Adds_Sysrole(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntity_Sysrole(Sysrole entity, OpertionUser opertionUser);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntitys_Sysrole(List<Sysrole> entitys, OpertionUser opertionUser);
        #endregion

        #region 修改

        /// <summary>
        /// 根据主键修改对应字段值
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Update_Sysrole(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser);

        /// <summary>
        /// 根据条件批量修改字段值
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result UpdateByWhere_Sysrole(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser);

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result UpdateNums_Sysrole(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser);

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Delete_Sysrole(string kid, OpertionUser opertionUser);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result DeleteByWhere_Sysrole(Dictionary<string, object> keydata, OpertionUser opertionUser);
        #endregion

        #region 数据导出
        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result ExportExcelFile_Sysrole(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser);

        #endregion

        #endregion

        #region Sysuserrole 操作

        #region 查询
        /// <summary>
        /// Gets the menu list.
        /// </summary>根据角色id获取属于这个角色的所有员工
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        //[OperationContract]
        //List<Sysuserrole> GetListRoleEmployee(int roleid);


        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.Collections.Generic.List&lt;CJJ.Blog.Service.Models.Data.Sys_menu&gt;.</returns>
        [OperationContract]
        List<Sysuserrole> GetListPage_Sysuserrole(int page = 1, int limit = 10, Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Json格式的数据
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前也显示条数</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="dicwhere">查询条件</param>
        /// <returns></returns>
        [OperationContract]
        FastJsonResult<List<Sysuserrole>> GetJsonListPage_Sysuserrole(int page = 1, int limit = 10, string orderby = "", Dictionary<string, object> dicwhere = null);


        /// <summary>
        /// 不分页获取所有数据
        /// </summary>
        /// <returns>List&lt;Sysuserrole&gt;.</returns>
        [OperationContract]
        List<Sysuserrole> GetAllList_Sysuserrole();

        /// <summary>
        /// 按条件获取数据列表
        /// </summary>
        /// <param name="dicwhere">查询条件 字段名可以增加|b |s |l 等作为搜索条件</param>
        /// <returns>List&lt;Sysuserrole&gt;.</returns>
        [OperationContract]
        List<Sysuserrole> GetList_Sysuserrole(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        int GetCount_Sysuserrole(Dictionary<string, object> dicwhere = null);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Sysuserrole GetModelByKID_Sysuserrole(int kID);

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <param name="kID">The k identifier.</param>
        /// <returns>System.Int32.</returns>
        [OperationContract]
        Sysuserrole GetModelByWhere_Sysuserrole(Dictionary<string, object> dicwhere);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="dicwhere">条件查询</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataTable_Sysuserrole(Dictionary<string, object> dicwhere, int page = 1, int limit = 10);

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
        [OperationContract]
        List<Sysuserrole> GetListByInSelect_Sysuserrole(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10);

        /// <summary>
        /// 根据In子查询查询数据
        /// </summary>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <returns></returns>
        [OperationContract]
        int GetCountByInSelect_Sysuserrole(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere);

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetDataByGroup_Sysuserrole(List<string> groupByFields, Dictionary<string, object> dicWhere, int page = 1, int limit = 10);

        #endregion

        #region 添加

        /// <summary>
        /// 添加数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Add_Sysuserrole(Dictionary<string, object> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加多条数据 根据字典添加
        /// </summary>
        /// <param name="model">添加的字典实体</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result Adds_Sysuserrole(List<Dictionary<string, object>> dicdata, OpertionUser opertionUser);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntity_Sysuserrole(Sysuserrole entity, OpertionUser opertionUser);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result AddByEntitys_Sysuserrole(List<Sysuserrole> entitys, OpertionUser opertionUser);
        #endregion

        #region 修改

        /// <summary>
        /// 根据主键修改对应字段值
        /// </summary>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Update_Sysuserrole(Dictionary<string, object> dicdata, int kID, OpertionUser opertionUser);

        /// <summary>
        /// 根据条件批量修改字段值
        /// </summary>
        /// <param name="valuedata">The valuedata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result UpdateByWhere_Sysuserrole(Dictionary<string, object> valuedata, Dictionary<string, object> keydata, OpertionUser opertionUser);

        /// <summary>
        /// 修改次数
        /// </summary>
        /// <param name="fields">需要修改的字段</param>
        /// <param name="addNums">次数 负数表示减少 正数表示增加</param>
        /// <param name="whereKey">字典条件</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns></returns>
        [OperationContract]
        Result UpdateNums_Sysuserrole(string fields, int addNums, Dictionary<string, object> whereKey, OpertionUser opertionUser);

        #endregion

        #region 删除
        /// <summary>
        /// 删除数据,逗号连接多条
        /// </summary>
        /// <param name="kid">The kid.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result Delete_Sysuserrole(string kid, OpertionUser opertionUser);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result DeleteByWhere_Sysuserrole(Dictionary<string, object> keydata, OpertionUser opertionUser);
        #endregion

        #region 数据导出
        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="keydata">The keydata.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <param name="opertionUser">操作者信息</param>
        /// <returns>Result.</returns>
        [OperationContract]
        Result ExportExcelFile_Sysuserrole(Dictionary<string, object> keydata, string fileFullName, OpertionUser opertionUser);

        #endregion

        #endregion


        /*BC47A26EB9A59406057DDDD62D0898F4*/



    }
}
