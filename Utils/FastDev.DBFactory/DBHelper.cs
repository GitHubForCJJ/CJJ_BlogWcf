/*----------------------------------------------------------------
    // 文件功能描述：公共类，数据库操作类，通过本类可以快速方便地进行常用数据库操作，而不必关心数据库特性
    // 依赖说明：通过Config获取数据库配置信息，配置文件中需要配置：DataBaseType和ConnString两个配置项
    // 异常处理：捕获但不会处理异常。
    // 创建标识：qiaomu，QQ1304850320
    // 创建时间：2016-02-05
    // 修改标识：
    // 修改描述：
//----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Data;
using FastDev.Configer;
using FastDev.Common.Code;
using System.Linq;
using FastDev.Log;

namespace FastDev.DBFactory
{
    /// <summary>
    /// 数据库操作类，支持多数据库
    /// 文件功能描述：公共类，数据库操作类，通过本类可以快速方便地进行常用数据库操作，而不必关心数据库特性
    /// 依赖说明：通过Config获取数据库配置信息，配置文件中需要配置：DataBaseType和ConnString两个配置项
    /// 异常处理：捕获但不会处理异常。
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class DBHelper : IDisposable
    {

        #region 清理资源
        /// <summary>
        /// 释放标记
        /// </summary>
        private bool _disposed;

        #endregion

        private string _dbType;
        private string _connStr;
        private DBOperator _db;
        /// <summary>
        /// 配置文件中数据库类型定义的键名
        /// </summary>
        protected string ConfigKeyForDataBaseType = "DataBaseType";

        /// <summary>
        /// 常规数据库实例 配置文件中数据库连接字符串的键名
        /// </summary>
        public string WriteConn = "ConnString";
        /// <summary>
        /// 只读数据库实例 配置文件中数据库连接字符串的键名
        /// </summary>
        public string ReadConn = "ConnStringRead";

        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DbType { get { return _dbType; } }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnStr { get { return _connStr; } }

        /// <summary>
        /// 构造函数,数据库类型及连接字符串会读取默认配置项DataBaseType、ConnString
        /// </summary>
        public DBHelper()
        {
            var configDbType = ConfigHelper.GetConfigToString(ConfigKeyForDataBaseType);
            if (string.IsNullOrWhiteSpace(configDbType))
            {
                configDbType = "MySql";
            }
            _dbType = configDbType;
            _connStr = ConfigHelper.GetConfigToString(WriteConn);
            if (string.IsNullOrWhiteSpace(_connStr))
            {
                throw new Exception("数据库连接未配置,无法正常连接数据库,请在配置文件appSettings节点下配置ConnString,可扩展配置ConnStringRead(只读实例)");
            }
            _db = GetDBOperator(_dbType, _connStr);
            _db.Open();
        }


        /// <summary>
        /// 构造函数,数据库类型及连接字符串会读取默认配置项DataBaseType、ConnString
        /// </summary>
        public DBHelper(DBOperator _trandb)
        {
            if (_trandb != null)
            {
                _db = _trandb;
            }
            else
            {
                var configDbType = ConfigHelper.GetConfigToString(ConfigKeyForDataBaseType);
                if (string.IsNullOrWhiteSpace(configDbType))
                {
                    configDbType = "MySql";
                }
                _dbType = configDbType;
                _connStr = ConfigHelper.GetConfigToString(WriteConn);
                if (string.IsNullOrWhiteSpace(_connStr))
                {
                    throw new Exception("数据库连接未配置,无法正常连接数据库,请在配置文件appSettings节点下配置ConnString,可扩展配置ConnStringRead(只读实例)");
                }
                _db = GetDBOperator(_dbType, _connStr);
                _db.Open();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHelper" /> class.
        /// </summary>
        /// <param name="ReadOnly">if set to <c>true</c> [read only].</param>
        public DBHelper(bool ReadOnly)
        {
            var configDbType = ConfigHelper.GetConfigToString(ConfigKeyForDataBaseType);
            if (string.IsNullOrWhiteSpace(configDbType))
            {
                configDbType = "MySql";
            }
            _dbType = configDbType;
            if (ReadOnly)
            {
                _connStr = ConfigHelper.GetConfigToString(ReadConn);
            }

            if (string.IsNullOrWhiteSpace(_connStr))
            {
                _connStr = ConfigHelper.GetConfigToString(WriteConn);
            }
            if (string.IsNullOrWhiteSpace(_connStr))
            {
                throw new Exception("数据库连接未配置,无法正常连接数据库,请在配置文件appSettings节点下配置ConnString,可扩展配置ConnStringRead(只读实例)");
            }
            _db = GetDBOperator(_dbType, _connStr);
            _db.Open();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHelper" /> class.
        /// </summary>
        /// <param name="ReadOnly">if set to <c>true</c> [read only].</param>
        /// <param name="dbType">Type of the database.</param>
        /// <param name="connStr">The connection string.</param>
        /// <exception cref="System.Exception">数据库连接未配置,无法正常连接数据库,请在配置文件appSettings节点下配置ConnString,可扩展配置ConnStringRead(只读实例)</exception>
        public DBHelper(bool ReadOnly, string dbType, string connStr)
        {
            _dbType = dbType;
            _connStr = connStr;
            if (ReadOnly)
            {
                _connStr = ConfigHelper.GetConfigToString(ReadConn);
            }

            if (string.IsNullOrWhiteSpace(_connStr))
            {
                _connStr = ConfigHelper.GetConfigToString(WriteConn);
            }
            if (string.IsNullOrWhiteSpace(_connStr))
            {
                throw new Exception("数据库连接未配置,无法正常连接数据库,请在配置文件appSettings节点下配置ConnString,可扩展配置ConnStringRead(只读实例)");
            }
            _db = GetDBOperator(_dbType, _connStr);
            _db.Open();
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbType">数据库类型（MYSQL/ORACLE/SQLSERVER/POSTGRESQL）</param>
        /// <param name="connStr">连接字符串</param>
        public DBHelper(string dbType, string connStr)
        {
            _dbType = dbType;
            _connStr = connStr;
            if (string.IsNullOrWhiteSpace(_connStr))
            {
                throw new Exception("数据库连接未配置,无法正常连接数据库,请在配置文件appSettings节点下配置ConnString,可扩展配置ConnStringRead(只读实例)");
            }
            _db = GetDBOperator(dbType, connStr);
            _db.Open();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connStr">连接字符串</param>
        public DBHelper(string connStr)
        {
            var configDbType = ConfigHelper.GetConfigToString(ConfigKeyForDataBaseType);
            if (string.IsNullOrWhiteSpace(configDbType))
            {
                configDbType = "MySql";
            }
            _dbType = configDbType;
            _connStr = connStr;
            _db = GetDBOperator(_dbType, connStr);
            _db.Open();
        }

        /// <summary>
        /// 析构函数 为了防止忘记显式的调用Dispose方法
        /// </summary>
        ~DBHelper()
        {
            //_db.Close();
            //必须为false
            Dispose(false);
        }

        /// <summary>
        /// 非密封类可重写的Dispose方法，方便子类继承时可重写
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _db.Close();
            }

            _disposed = true;
        }

        /// <summary>
        /// 显示关闭连接
        /// </summary>
        public void Dispose()
        {
            //_db.Close();


            //必须为true
            Dispose(true);
            //通知垃圾回收器不再调用终结器
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            _db.Close();
        }

        #region 轻工厂制造数据库实例

        /// <summary>
        /// 创建数据库工厂实例
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="connStr">连接字符串</param>
        /// <returns>数据库操作实例</returns>
        private static DBOperator GetDBOperator(string dbType, string connStr)
        {
            switch (dbType.ToUpper())
            {
                case "MYSQL":
                    return new Providers.Mysql(connStr);
                case "ORACLE":
                    return new Providers.Oracle(connStr);
                case "SQLSERVER":
                    return new Providers.SqlServer(connStr);
                case "POSTGRESQL":
                    return new Providers.Postgresql(connStr);
                case "MYSQLDAPPER":
                    return new Providers.MySqlDapper(connStr);
                default:
                    throw new Exception("未知的数据库类型：" + dbType);
            }
        }
        #endregion

        #region 事务操作
        /// <summary>
        /// 开始事务操作
        /// </summary>
        public void BeginTrans()
        {
            _db.BeginTrans();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTrans()
        {
            _db.CommitTrans();
        }

        /// <summary>
        /// 事务回滚
        /// </summary>
        public void RollbackTrans()
        {
            _db.RollbackTrans();
        }

        #endregion


        #region ExecuteNonQuery

        /// <summary>
        /// 执行SQL语句，返回受影响记录条数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                return _db.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception($"查询失败！\r\nSQL语句为：{sql}。\r\n{ex.ToString()}");
            }
        }

        /// <summary>
        /// 执行SQL语句，返回受影响记录条数
        /// </summary>
        /// <param name="sql">SQL语句或命令（参数用问号?占位。为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <param name="value">参数值列表</param>
        /// <returns>受影响记录条数</returns>
        public int ExecuteNonQuery(string sql, params object[] value)
        {
            try
            {
                return _db.ExecuteNonQueryParams(sql, value);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\n数据库：{0}。\r\nSQL语句：{1}。\r\n参数列表{2}。\r\n{3}", DbType, sql, _db.ShowParamsList(_db.GetParamsList(value)), ex.ToString()));
            }
        }


        /// <summary>
        /// 执行SQL语句，返回受影响记录条数
        /// </summary>
        /// <param name="sql">SQL语句或命令（参数用问号?占位。为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <param name="value">参数值列表</param>
        /// <returns>受影响记录条数</returns>
        public int ExecuteNonQueryParams(string sql, params object[] value)
        {
            try
            {
                return _db.ExecuteNonQueryParams(sql, value);
            }
            catch (Exception ex)
            {
                throw new Exception($"查询失败！\r\n数据库：{DbType}。\r\nSQL语句：{sql}。\r\n参数列表{_db.ShowParamsList(_db.GetParamsList(value))}。\r\n{ex.ToString()}");
            }
        }

        #endregion

        #region ExecuteScalar

        /// <summary>
        /// 执行一条SQL语句，返回第一行第一列object
        /// </summary>
        /// <param name="sql">SQL语句（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <returns>object</returns>
        public object ExecuteScalar(string sql)
        {
            try
            {
                return _db.ExecuteScalar(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\nSQL语句为：{0}。\r\n{1}", sql, ex.ToString()));
            }
        }

        /// <summary>
        /// 执行一条SQL语句，返回第一行第一列int
        /// </summary>
        /// <param name="sql">SQL语句（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <returns>int</returns>
        public int ExecuteScalarInt(string sql)
        {
            object obj = ExecuteScalar(sql);
            if (obj is DBNull)
            {
                return 0;
            }
            try
            {
                return Convert.ToInt32(obj);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 执行一条SQL语句，返回第一行第一列string
        /// </summary>
        /// <param name="sql">SQL语句（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <returns>string</returns>
        public string ExecuteScalarString(string sql)
        {
            object obj = ExecuteScalar(sql);
            if (obj is DBNull)
            {
                return string.Empty;
            }
            try
            {
                return Convert.ToString(obj);
            }
            catch
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// 执行一条SQL语句，返回一个object
        /// </summary>
        /// <param name="sql">SQL语句或命令（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <param name="value">参数值列表</param>
        /// <returns>object</returns>
        public object ExecuteScalar(string sql, params object[] value)
        {
            try
            {
                return _db.ExecuteScalarParams(sql, value);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\n数据库：{0}。\r\nSQL语句：{1}。\r\n参数列表{2}。\r\n{3}", DbType, sql, _db.ShowParamsList(_db.GetParamsList(value)), ex.ToString()));
            }
        }

        /// <summary>
        /// 执行一条SQL语句，返回一个int
        /// </summary>
        /// <param name="sql">SQL语句或命令（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <param name="value">参数值列表</param>
        /// <returns>int</returns>
        public int ExecuteScalarInt(string sql, params object[] value)
        {
            object obj = ExecuteScalarParams(sql, value);
            if (obj is DBNull)
            {
                return 0;
            }
            try
            {
                return Convert.ToInt32(obj);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 执行一条SQL语句，返回一个string
        /// </summary>
        /// <param name="sql">SQL语句或命令（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <param name="value">参数值列表</param>
        /// <returns>string</returns>
        public string ExecuteScalarString(string sql, params object[] value)
        {
            object obj = ExecuteScalarParams(sql, value);
            if (obj is DBNull)
            {
                return string.Empty;
            }
            try
            {
                return Convert.ToString(obj);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 执行一条SQL语句，返回一个object
        /// </summary>
        /// <param name="sql">SQL语句或命令（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <param name="value">参数值列表</param>
        /// <returns>object</returns>
        public object ExecuteScalarParams(string sql, params object[] value)
        {
            try
            {
                return _db.ExecuteScalarParams(sql, value);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\n数据库：{0}。\r\nSQL语句：{1}。\r\n参数列表{2}。\r\n{3}", DbType, sql, _db.ShowParamsList(_db.GetParamsList(value)), ex.ToString()));
            }
        }

        /// <summary>
        /// 执行一条SQL语句，返回一个int
        /// </summary>
        /// <param name="sql">SQL语句或命令（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <param name="value">参数值列表</param>
        /// <returns>int</returns>
        public int ExecuteScalarIntParams(string sql, params object[] value)
        {
            object obj = ExecuteScalarParams(sql, value);
            if (obj is DBNull)
            {
                return 0;
            }
            try
            {
                return Convert.ToInt32(obj);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 执行一条SQL语句，返回一个string
        /// </summary>
        /// <param name="sql">SQL语句或命令（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <param name="value">参数值列表</param>
        /// <returns>string</returns>
        public string ExecuteScalarStringParams(string sql, params object[] value)
        {
            object obj = ExecuteScalarParams(sql, value);
            if (obj is DBNull)
            {
                return string.Empty;
            }
            try
            {
                return Convert.ToString(obj);
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion

        #region ExecuteDataRow

        /// <summary>
        /// 执行SQL语句，返回DataRow
        /// </summary>
        /// <param name="sql">SQL语句（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <returns>DataRow</returns>
        public DataRow ExecuteDataRow(string sql)
        {
            try
            {
                DataTable dt = ExecuteDataTable(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\nSQL语句为：{0}。\r\n{1}", sql, ex.ToString()));
            }
        }

        /// <summary>
        /// 执行SQL语句，返回DataRow
        /// </summary>
        /// <param name="sql">SQL语句或命令（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <param name="value">参数值列表</param>
        /// <returns>DataRow</returns>
        public DataRow ExecuteDataRow(string sql, params object[] value)
        {
            try
            {
                DataTable dt = ExecuteDataTableParams(sql, value);
                if (dt != null && dt.Rows.Count != 0)
                {
                    return dt.Rows[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\n数据库：{0}。\r\nSQL语句：{1}。\r\n参数列表{2}。\r\n{3}", DbType, sql, _db.GetParamsList(value), ex.ToString()));
            }
        }

        /// <summary>
        /// 执行SQL语句，返回DataRow
        /// </summary>
        /// <param name="sql">SQL语句或命令（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <param name="value">参数值列表</param>
        /// <returns>DataRow</returns>
        public DataRow ExecuteDataRowParams(string sql, params object[] value)
        {
            try
            {
                DataTable dt = ExecuteDataTablePage(sql, 1, 1, value);
                //DataTable dt = ExecuteDataTableParams(sql, value);
                if (dt != null && dt.Rows.Count != 0)
                {
                    return dt.Rows[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\n数据库：{0}。\r\nSQL语句：{1}。\r\n参数列表{2}。\r\n{3}", DbType, sql, _db.GetParamsList(value), ex.ToString()));
            }
        }

        #endregion

        #region ExecuteDataTable

        /// <summary>
        /// 执行SQL语句，返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <param name="value">The value.</param>
        /// <returns>DataTable</returns>
        /// <exception cref="Exception"></exception>
        public DataTable ExecuteDataTable(string sql, params object[] value)
        {
            try
            {
                if (value.Length > 0)
                {
                    return ExecuteDataTableParams(sql, value);
                }
                else
                {
                    return _db.ExecuteDataTable(sql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"查询失败！\r\nSQL语句为：{sql}。\r\n{ex.ToString()}");
            }
        }

        /// <summary>
        /// 执行SQL语句，返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句或命令（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <param name="value">参数值列表</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTableParams(string sql, params object[] value)
        {
            try
            {
                return _db.ExecuteDataTableParams(sql, value);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"查询失败！\r\n数据库：{DbType}。\r\nSQL语句：{sql}。\r\n参数列表{_db.ShowParamsList(_db.GetParamsList(value))}。\r\n{ex.ToString()}");
            }
        }

        #endregion

        #region ExecuteDataSet

        /// <summary>
        /// 执行SQL语句，返回DataSet
        /// </summary>
        /// <param name="sql">SQL语句（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <returns>DataTable</returns>
        public DataSet ExecuteDataSet(string sql)
        {
            try
            {
                return _db.ExecuteDataSet(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\nSQL语句为：{0}。\r\n{1}", sql, ex.ToString()));
            }
        }
        /// <summary>
        /// 执行SQL语句，返回DataSet
        /// </summary>
        /// <param name="sql">SQL语句或命令（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <param name="value">参数值列表</param>
        /// <returns>DataTable</returns>
        public DataSet ExecuteDataSet(string sql, params object[] value)
        {
            try
            {
                return _db.ExecuteDataSetParams(sql, value);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"查询失败！\r\n数据库：{DbType}。\r\nSQL语句：{sql}。\r\n参数列表{_db.ShowParamsList(_db.GetParamsList(value))}。\r\n{ex.ToString()}");
            }
        }

        /// <summary>
        /// 执行SQL语句，返回DataSet
        /// </summary>
        /// <param name="sql">SQL语句或命令（为了Oracle上能够使用，表的别名前不要加AS）</param>
        /// <param name="value">参数值列表</param>
        /// <returns>DataTable</returns>
        public DataSet ExecuteDataSetParams(string sql, params object[] value)
        {
            try
            {
                return _db.ExecuteDataSetParams(sql, value);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\n数据库：{0}。\r\nSQL语句：{1}。\r\n参数列表{2}。\r\n{3}", DbType, sql, _db.ShowParamsList(_db.GetParamsList(value)), ex.ToString()));
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
        public DataSet ExecuteDataSetPage(string sql, int pageSize, int pageIndex)
        {
            try
            {
                return _db.ExecuteDataSetPage(sql, pageSize, pageIndex);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\n数据库：{0}。\r\nSQL语句：{1}。\r\n{2}", DbType, sql, ex.ToString()));
            }
        }

        /// <summary>
        /// 分页查询，返回DataSet
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="pageSize">页面大小（单页记录条数）</param>
        /// <param name="pageIndex">当前页码（页号从1开始）</param>
        /// <param name="value">参数列表</param>
        /// <returns></returns>
        public DataSet ExecuteDataSetPage(string sql, int pageSize, int pageIndex, params object[] value)
        {
            try
            {
                return _db.ExecuteDataSetPageParams(sql, pageSize, pageIndex, value);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\n数据库：{0}。\r\nSQL语句：{1}。\r\n参数列表{2}。\r\n{3}", DbType, sql, _db.ShowParamsList(_db.GetParamsList(value)), ex.ToString()));
            }
        }


        /// <summary>
        /// 分页查询，返回DataSet
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="pageSize">页面大小（单页记录条数）</param>
        /// <param name="pageIndex">当前页码（页号从1开始）</param>
        /// <param name="orderby">order排序字段用于分页排序 兼容MSSQL</param>
        /// <param name="value">参数列表</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public DataSet ExecuteDataSetPageByOrderByParams(string sql, int pageSize, int pageIndex, string orderby, params object[] value)
        {
            try
            {
                return _db.ExecuteDataSetPageByOrderByParams(sql, pageSize, pageIndex, orderby, value);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\n数据库：{0}。\r\nSQL语句：{1}。\r\n参数列表{2}。\r\n{3}", DbType, sql, _db.ShowParamsList(_db.GetParamsList(value)), ex.ToString()));
            }
        }

        /// <summary>
        /// 分页查询，返回DataSet
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="pageSize">页面大小（单页记录条数）</param>
        /// <param name="pageIndex">当前页码（页号从1开始）</param>
        /// <param name="value">参数列表</param>
        /// <returns></returns>
        public DataSet ExecuteDataSetPageParams(string sql, int pageSize, int pageIndex, params object[] value)
        {
            try
            {
                return _db.ExecuteDataSetPageParams(sql, pageSize, pageIndex, value);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\n数据库：{0}。\r\nSQL语句：{1}。\r\n参数列表{2}。\r\n{3}", DbType, sql, _db.ShowParamsList(_db.GetParamsList(value)), ex.ToString()));
            }
        }

        /// <summary>
        /// 分页查询，返回DataTable
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="pageSize">页面大小（单页记录条数）</param>
        /// <param name="pageIndex">当前页码（页号从1开始）</param>
        /// <returns></returns>
        public DataTable ExecuteDataTablePage(string sql, int pageSize, int pageIndex)
        {
            try
            {
                return _db.ExecuteDataTablePage(sql, pageSize, pageIndex);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\n数据库：{0}。\r\nSQL语句：{1}。\r\n{2}", DbType, sql, ex.ToString()));
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
        public DataTable ExecuteDataTablePage(string sql, int pageSize, int pageIndex, params object[] value)
        {
            try
            {
                return _db.ExecuteDataTablePageParams(sql, pageSize, pageIndex, value);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\n数据库：{0}。\r\nSQL语句：{1}。\r\n参数列表{2}。\r\n{3}", DbType, sql, _db.ShowParamsList(_db.GetParamsList(value)), ex.ToString()));
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
            try
            {
                return _db.ExecuteDataTablePageParams(sql, pageSize, pageIndex, value);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\n数据库：{0}。\r\nSQL语句：{1}。\r\n参数列表{2}。\r\n{3}", DbType, sql, _db.ShowParamsList(_db.GetParamsList(value)), ex.ToString()));
            }
        }

        /// <summary>
        /// 分页查询，返回DataTable
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offSet">跳过的条数</param>
        /// <param name="value">参数列表</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable ExecuteDataTablePageParamsWithLimit(string sql, int limit, int offSet, params object[] value)
        {
            try
            {
                return _db.ExecuteDataTablePageParamsWithLimit(sql, limit, offSet, value);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("查询失败！\r\n数据库：{0}。\r\nSQL语句：{1}。\r\n参数列表{2}。\r\n{3}", DbType, sql, _db.ShowParamsList(_db.GetParamsList(value)), ex.ToString()));
            }
        }

        #endregion

        #region ExecuteDataTablePage


        /// <summary>
        /// 分页查询，返回DataTable，该方法已经过时（为了照顾SQLServer2005以下版本）
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fields">要返回的字段列表，逗号分隔</param>
        /// <param name="keyField">主键字段名，如果是Oracle或Mysql可以为空（""）</param>
        /// <param name="orderBy">排序字段，可以为空，多个字段需用逗号分隔</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">当前页（页号从1开始）</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTablePage(string tableName, string fields, string keyField, string orderBy, int pageSize, int pageIndex)
        {
            string gropBy = string.Empty;
            string condition = string.Empty;
            return _db.ExecuteDataTablePageParams(tableName, fields, keyField, gropBy, orderBy, pageSize, pageIndex, condition);
        }

        #endregion

        #region ExecuteDataTablePageParams

        /// <summary>
        /// 分页查询，返回DataTable
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
        public DataTable ExecuteDataTablePageParams(string tableName, string fields, string keyField, string groupBy, string orderBy, int pageSize, int pageIndex, string condition, params object[] value)
        {
            return _db.ExecuteDataTablePageParams(tableName, fields, keyField, groupBy, orderBy, pageSize, pageIndex, condition, value);
        }

        #endregion

        #region 获取表信息
        /// <summary>
        /// 根据表名，获取字段列表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>表字段列表</returns>
        public List<string> GetFieldsList(string tableName)
        {
            try
            {
                return _db.GetFieldsList(tableName);
            }
            catch (Exception ex)
            {
                throw new Exception("获取表" + tableName + "的字段列表出错!" + ex.Message);
            }
        }

        /// <summary>
        /// 判断表某字段值是否重复
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="keyField">主键字段名</param>
        /// <param name="keyValue">主键值</param>
        /// <returns>bool</returns>
        public bool IsDuplicate(string tableName, string fieldName, string value, string keyField, string keyValue)
        {
            string sql = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} != ? AND {2} = ?", tableName, keyField, fieldName);
            byte ret = Convert.ToByte(ExecuteScalarParams(sql, keyValue, value));
            return ret > 0 ? true : false;
        }

        /// <summary>
        /// 判断表某字段是否重复
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="oldValue">如果是修改，则为旧值；如果是添加，则为string.Empty</param>
        /// <param name="newValue">新值</param>
        /// <returns>bool</returns>
        public bool IsDuplicate(string tableName, string fieldName, string oldValue, string newValue)
        {
            if (oldValue == newValue)
            {
                return false;
            }
            string sql = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = ?", tableName, fieldName);
            byte ret = Convert.ToByte(ExecuteScalarParams(sql, newValue));
            return ret > 0 ? true : false;
        }

        /// <summary>
        /// 判断表某字段是否重复
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="oldValue">如果是修改，则为旧值；如果是添加，则为string.Empty</param>
        /// <param name="newValue">新值</param>
        /// <param name="conditions">The conditions.</param>
        /// <returns>bool</returns>
        public bool IsDuplicate(string tableName, string fieldName, string oldValue, string newValue, string[] conditions)
        {
            if (oldValue == newValue)
            {
                return false;
            }
            string conondition = string.Empty;
            foreach (string c in conditions)
            {
                conondition += " AND " + c;
            }

            string sql = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = ? {2}", tableName, fieldName, conondition);
            byte ret = Convert.ToByte(ExecuteScalarParams(sql, newValue));
            return ret > 0 ? true : false;
        }

        /// <summary>
        /// 判断表某字段是否重复
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="condition">判断条件（不带关键词WHERE）</param>
        /// <returns>bool</returns>
        public bool IsDuplicate(string tableName, string condition)
        {
            string sql = string.Format("SELECT COUNT(*) FROM {0} WHERE {1}", tableName, condition);
            byte ret = Convert.ToByte(ExecuteScalar(sql));
            return ret > 0 ? true : false;
        }

        /// <summary>
        /// 根据时间获取表名 不包含视图
        /// </summary>
        /// <param name="tablePrefix">表名前缀</param>
        /// <param name="timeBegin">开始时间</param>
        /// <param name="timeEnd">结束时间</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public List<string> GetTableNameByTime(string tablePrefix, DateTime timeBegin, DateTime timeEnd)
        {
            return _db.GetTableNameByTime(tablePrefix, timeBegin, timeEnd);
        }

        #endregion

        #region 数据库相关操作

        ///// <summary>
        ///// 数据库连接的数据库名
        ///// </summary>
        ///// <value>The name of the database.</value>
        //public string DbName
        //{
        //    get
        //    {
        //        return _db.DataBaseName;

        //    }
        //}

        /// <summary>
        /// 创建数据库表
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>Result.</returns>
        /// <exception cref="System.Exception">创建表 + tableStr.TableName + 出错! + ex.Message</exception>
        public Result DropTable(string tableName)
        {
            try
            {
                return _db.DropTable(tableName);
            }
            catch (Exception ex)
            {
                throw new Exception("删除表" + tableName + "出错!" + ex.Message);
            }
        }

        /// <summary>
        /// 创建数据库表
        /// </summary>
        /// <param name="tableStr">The table string.</param>
        /// <returns>Result.</returns>
        public Result CreateTable(TableStructure tableStr)
        {
            try
            {
                return _db.CreateTable(tableStr);
            }
            catch (Exception ex)
            {
                throw new Exception("创建表" + tableStr.TableName + "出错!" + ex.Message);
            }
        }

        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns><c>true</c> if [is exist table] [the specified table name]; otherwise, <c>false</c>.</returns>
        public bool IsExistTable(string tableName)
        {
            try
            {
                return _db.IsExistTable(tableName);
            }
            catch (Exception ex)
            {
                throw new Exception("判断表是否存在IsExistTable出错!" + ex.Message);
            }
        }

        /// <summary>
        /// 获取当前数据库下的表和视图
        /// </summary>
        /// <param name="dbName">Name of the database.</param>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        public Dictionary<string, string> GetTableView(string dbName)
        {
            //Dictionary<string, string> ret = new Dictionary<string, string>();

            //var dt = _db.ExecuteDataTable("SELECT * FROM information_schema.tables WHERE table_schema='" + dbName + "' AND table_type IN ('base table','View');");
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ret.Add(dr["Table_Name"].ToString(), dr["TABLE_COMMENT"].ToString());
            //}

            //return ret;
            return _db.GetTableView(dbName);
        }

        /// <summary>
        /// Gets the colume by table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>DataTable.</returns>
        public DataTable GetColumeByTable(string tableName)
        {
            return _db.GetColumeByTable(tableName);

            //return _db.ExecuteDataTable($"SELECT COLUMN_NAME,DATA_TYPE ,Column_KEY ,COLUMN_COMMENT FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{_db.DataBaseName}'  AND TABLE_NAME = '{tableName}'; ");
        }

        #endregion
    }
}