/*----------------------------------------------------------------
    // 文件功能描述：模块类，数据库操作基类，包含了数据库的常用操作，并实现了数据库操作的通用方法，而特性留给继承类实现
    // 依赖说明：无依赖，不要直接实例化，通过DBHelper来调用。
    // 异常处理：捕获异常但不处理。
    // 创建标识：qiaomu，QQ1304850320
    // 创建时间：2016-02-05
    // 修改标识：
    // 修改描述：
//----------------------------------------------------------------*/

using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System;
using FastDev.Common.Code;

namespace FastDev.DBFactory
{
    /// <summary>
    /// 数据库操作基类
    /// 文件功能描述：模块类，SqlServer数据库操作类，在这里实现了该数据库的相关特性
    /// 依赖说明：无依赖，不要直接实例化，通过DBHelper来调用具体的实例。
    /// 异常处理：捕获但不处理异常。
    /// </summary>
    public abstract class DBOperator
    {
        /// <summary>
        /// 命令执行时长（秒，默认为30）
        /// </summary>
        public int CommandTimeout = 60;

        /// <summary>
        /// SQL命令
        /// </summary>
        protected DbCommand comm;

        #region 打开/关闭数据库连接
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public abstract void Open();

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public abstract void Close();
        #endregion


        #region 事务操作
        /// <summary>
        /// 开始事务
        /// </summary>
        public abstract void BeginTrans();

        /// <summary>
        /// 执行事务
        /// </summary>
        public abstract void CommitTrans();

        /// <summary>
        /// 事务回滚
        /// </summary>
        public abstract void RollbackTrans();
        #endregion

        /// <summary>
        /// 创建一个命令
        /// </summary>
        /// <param name="command">SQL语句或命令</param>
        /// <returns></returns>
        protected abstract DbCommand CreateCommand(string command);

        /// <summary>
        /// 构造包含参数的SQL语句或命令
        /// </summary>
        /// <param name="command">SQL语句或命令</param>
        /// <param name="value">参数值列表</param>
        protected abstract DbCommand CreateCommand(string command, params object[] value);

        /// <summary>
        /// 生成参数列表
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<object> GetParamsList(params object[] value)
        {
            List<object> paramsList = new List<object>();
            foreach (object obj in value)
            {
                if (obj is IList<object>)
                {
                    IList<object> listTemp = obj as IList<object>;
                    for (int i = 0; i < listTemp.Count; i++)
                    {
                        paramsList.Add(listTemp[i]);
                    }
                }
                else
                {
                    paramsList.Add(obj);
                }
            }

            return paramsList;
        }

        #region 无参数调用
        /// <summary>
        /// 执行SQL语句，返回受影响记录条数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public int ExecuteNonQuery(string sql)
        {
            DbCommand comm = CreateCommand(sql);

            return comm.ExecuteNonQuery();
        }

        /// <summary>
        /// A2返回一个DataSet
        /// </summary>
        /// <param name="sql">SQL语句或命令</param>
        /// <returns>DataSet</returns>
        public abstract DataSet ExecuteDataSet(string sql);

        /// <summary>
        /// A3执行一条SQL语句，返回一个object
        /// </summary>
        /// <param name="sql">SQL语句或命令</param>
        /// <returns>object</returns>
        public object ExecuteScalar(string sql)
        {
            DbCommand comm = CreateCommand(sql);

            return comm.ExecuteScalar();
        }

        /// <summary>
        /// 执行一条SQL语句，返回一个DbDataReader
        /// </summary>
        /// <param name="sql">SQL语句或命令</param>
        /// <returns>DbDataReader</returns>
        public DbDataReader ExecuteReader(string sql)
        {
            DbCommand comm = CreateCommand(sql);

            return comm.ExecuteReader();
        }

        /// <summary>
        /// 执行SQL语句，返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTable(string sql)
        {
            DataSet ds = ExecuteDataSet(sql);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 带参数查询
        /// <summary>
        /// B1执行一个语句不返回任何值
        /// </summary>
        /// <param name="sql">SQL语句或命令</param>
        /// <param name="value">参数值列表</param>
        /// <returns>受影响行数</returns>
        public int ExecuteNonQueryParams(string sql, params object[] value)
        {
            DbCommand comm = CreateCommand(sql, value);
            //有问题 Sql insertinto 没反应影响行数 导致莫法判断成功
            return comm.ExecuteNonQuery();
        }

        /// <summary>
        /// B2返回一个DataSet
        /// </summary>
        /// <param name="sql">SQL语句或命令</param>
        /// <param name="value">参数值列表</param>
        /// <returns>DataSet</returns>
        public abstract DataSet ExecuteDataSetParams(string sql, params object[] value);

        /// <summary>
        /// B3执行一条SQL语句，返回一个object
        /// </summary>
        /// <param name="sql">SQL语句或命令</param>
        /// <param name="value">参数值列表</param>
        /// <returns>object</returns>
        public object ExecuteScalarParams(string sql, params object[] value)
        {
            DbCommand comm = CreateCommand(sql, value);

            return comm.ExecuteScalar();
        }

        /// <summary>
        /// B4执行一条SQL语句，返回一个DbDataReader
        /// </summary>
        /// <param name="sql">SQL语句或命令</param>
        /// <param name="value">参数值列表</param>
        /// <returns>DbDataReader</returns>
        public DbDataReader ExecuteReaderParams(string sql, params object[] value)
        {
            var comm = CreateCommand(sql, value);

            return comm.ExecuteReader();
        }

        /// <summary>
        /// 执行SQL语句，返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句或命令（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <param name="value">参数值列表</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTableParams(string sql, params object[] value)
        {
            DataSet ds = ExecuteDataSetParams(sql, value);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 分页查询

        /// <summary>
        /// 分页查询，返回DataSet
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="pageSize">页面大小（单页记录条数）</param>
        /// <param name="pageIndex">当前页码（页号从1开始）</param>
        /// <returns></returns>
        public abstract DataSet ExecuteDataSetPage(string sql, int pageSize, int pageIndex);

        /// <summary>
        /// 分页查询，返回DataSet
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="pageSize">页面大小（单页记录条数）</param>
        /// <param name="pageIndex">当前页码（页号从1开始）</param>
        /// <param name="value">参数列表</param>
        /// <returns></returns>
        public abstract DataSet ExecuteDataSetPageParams(string sql, int pageSize, int pageIndex, params object[] value);

        /// <summary>
        /// 分页查询，返回DataSet
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="pageSize">页面大小（单页记录条数）</param>
        /// <param name="pageIndex">当前页码（页号从1开始）</param>
        /// <param name="orderby">order排序字段用于分页排序 兼容MSSQL</param>
        /// <param name="value">参数列表</param>
        /// <returns></returns>
        public abstract DataSet ExecuteDataSetPageByOrderByParams(string sql, int pageSize, int pageIndex, string orderby, params object[] value);

        /// <summary>
        /// 分页查询，返回DataTable
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="pageSize">页面大小（单页记录条数）</param>
        /// <param name="pageIndex">当前页码（页号从1开始）</param>
        /// <returns></returns>
        public DataTable ExecuteDataTablePage(string sql, int pageSize, int pageIndex)
        {
            DataSet ds = ExecuteDataSetPage(sql, pageSize, pageIndex);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 分页查询，返回DataTable
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="pageSize">页面大小（单页记录条数）</param>
        /// <param name="pageIndex">当前页码（页号从1开始）</param>
        /// <param name="value">参数列表</param>
        /// <returns></returns>
        public DataTable ExecuteDataTablePageParams(string sql, int pageSize, int pageIndex, params object[] value)
        {
            DataSet ds = ExecuteDataSetPageParams(sql, pageSize, pageIndex, value);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 分页查询，返回DataTable
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="pageSize">页面大小（单页记录条数）</param>
        /// <param name="pageIndex">当前页码（页号从1开始）</param>
        /// <param name="orderby">分页排序字段</param>
        /// <param name="value">参数列表</param>
        /// <returns></returns>
        public DataTable ExecuteDataTablePageParams(string sql, int pageSize, int pageIndex, string orderby, params object[] value)
        {
            DataSet ds = ExecuteDataSetPageByOrderByParams(sql, pageSize, pageIndex, orderby, value);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 分页查询，返回DataTable，该方法已经过时（为了照顾SQLServer2005以下版本）
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fields">要返回的字段列表，逗号分隔</param>
        /// <param name="keyField">主键字段名，如果是Oracle或Mysql可以为空（""）</param>
        /// <param name="groupBy">GROUP BY子句,不包含GROUP BY关键字</param>
        /// <param name="orderBy">排序字段，可以为空，多个字段需用逗号分隔</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">当前页（页号从1开始）</param>
        /// <param name="condition">筛选条件，可以为空，不带"WHERE"关键字</param>
        /// <param name="value">参数列表</param>
        /// <returns>DataTable</returns>
        public abstract DataTable ExecuteDataTablePageParams(string tableName, string fields, string keyField, string groupBy, string orderBy, int pageSize, int pageIndex, string condition, params object[] value);


        /// <summary>
        /// 分页查询，返回DataTable
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offSet">跳过的条数</param>
        /// <param name="value">参数列表</param>
        /// <returns>DataTable.</returns>
        public abstract DataTable ExecuteDataTablePageParamsWithLimit(string sql, int limit, int offSet, params object[] value);

        #endregion

        #region 获取表的一些信息

        /// <summary>
        /// 根据表名，获取字段列表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>表字段列表</returns>
        public abstract List<string> GetFieldsList(string tableName);

        #endregion

        #region 显示参数列表(多数情况下用于调试输出)
        /// <summary>
        /// 显示参数列表
        /// </summary>
        /// <param name="paramsList"></param>
        /// <returns></returns>
        public string ShowParamsList(List<object> paramsList)
        {
            StringBuilder sb = new StringBuilder();

            foreach (object obj in paramsList)
            {
                sb.Append(Convert.ToString(obj) + "\r\n");
            }

            return sb.ToString();
        }
        #endregion


        #region 数据库表 相关操作操作

        /// <summary>
        /// The data base name
        /// </summary>
        public abstract string DataBaseName
        {
            get;
        }

        /// <summary>
        /// 删除数据库表
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>System.String.</returns>
        public abstract Result DropTable(string tableName);

        /// <summary>
        /// 创建数据库表
        /// </summary>
        /// <param name="tableStr">The table string.</param>
        /// <returns>System.String.</returns>
        public abstract Result CreateTable(TableStructure tableStr);

        /// <summary>
        /// Gets the type of the col.
        /// </summary>
        /// <param name="TypeName">Name of the type.</param>
        /// <param name="Length">The length.</param>
        /// <returns>System.String.</returns>
        public string GetColType(string TypeName, int Length)
        {
            switch (TypeName.ToLower())
            {
                case "int":
                    return "int";
                case "datetime":
                    return "datetime";
                case "decimal":
                    return "decimal(19,2)";
                case "varchar":
                    return $"varchar({(Length == 0 ? 64 : Length)})";
                default:
                    if (Length == 0)
                    {
                        return TypeName;
                    }
                    else
                    {
                        return TypeName + $"({Length})";
                    }
            }
        }

        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>Result.</returns>
        public abstract bool IsExistTable(string tableName);

        /// <summary>
        /// 根据时间获取表名 不包含视图
        /// </summary>
        /// <param name="tablePrefix">表名前缀</param>
        /// <param name="timeBegin">开始时间</param>
        /// <param name="timeEnd">结束时间</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public abstract List<string> GetTableNameByTime(string tablePrefix, DateTime timeBegin, DateTime timeEnd);

        /// <summary>
        /// 获取当前数据库下的表和视图
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        public abstract Dictionary<string, string> GetTableView(string dbName);

        /// <summary>
        /// 根据表名查询表结构
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>DataTable.</returns>
        public abstract DataTable GetColumeByTable(string tableName);

        #endregion
    }
}