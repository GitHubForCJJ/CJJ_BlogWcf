﻿/*----------------------------------------------------------------
    // 文件功能描述：模块类，SqlServer数据库操作类，在这里实现了该数据库的相关特性
    // 依赖说明：无依赖，不要直接实例化，通过DBHelper来调用。
    // 异常处理：捕获但不处理异常。
    // 创建标识：qiaomu，QQ1304850320
    // 创建时间：2016-02-05
    // 修改标识：
    // 修改描述：
//----------------------------------------------------------------*/

using FastDev.Common.Code;
using FastDev.Common.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace FastDev.DBFactory.Providers
{
    /// <summary>
    /// SQLServer数据库操作实例
    /// 文件功能描述：模块类，SqlServer数据库操作类，在这里实现了该数据库的相关特性
    /// 依赖说明：无依赖，不要直接实例化，通过DBHelper来调用。
    /// 异常处理：捕获但不处理异常。
    /// </summary>
    public class SqlServer : DBOperator
    {
        private string _connString;
        private SqlConnection _conn;
        private SqlTransaction _trans;
        /// <summary>
        /// 当前是否在存储过程中
        /// </summary>
        protected bool _isInTransaction = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strConnection"></param>
        public SqlServer(string strConnection)
        {
            _connString = strConnection;
            _conn = new SqlConnection(strConnection);
        }

        #region 打开/关闭数据库连接
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public override void Open()
        {
            if (_conn != null && _conn.State != ConnectionState.Open)
            {
                try
                {
                    _conn = new SqlConnection(_connString);
                    this._conn.Open();
                }
                catch (Exception ee)
                {
                    throw new Exception("打开数据库连接失败。\r\n" + ee.ToString());
                }
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public override void Close()
        {
            if (_conn.State != ConnectionState.Closed)
            {
                try
                {
                    this._conn.Close();
                }
                catch (Exception ee)
                {
                    throw new Exception("关闭数据库连接失败。\r\n" + ee.ToString());
                }
            }
        }
        #endregion

        #region 事务操作
        /// <summary>
        /// 开始事务
        /// </summary>
        public override void BeginTrans()
        {
            if (_isInTransaction)
            {
                throw new Exception("当前事务尚未提交!");
            }

            _trans = _conn.BeginTransaction();
            _isInTransaction = true;
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        public override void CommitTrans()
        {
            _trans.Commit();
            _isInTransaction = false;
        }

        /// <summary>
        /// 事务回滚
        /// </summary>
        public override void RollbackTrans()
        {
            _trans.Rollback();
            _isInTransaction = false;
        }

        #endregion

        /// <summary>
        /// 创建一个命令
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        protected override DbCommand CreateCommand(string command)
        {
            SqlCommand comm = new SqlCommand();
            comm.Connection = _conn;
            comm.CommandText = command;

            return comm;
        }

        /// <summary>
        /// 构造包含参数的SQL语句或命令
        /// </summary>
        /// <param name="command">SQL语句或命令</param>
        /// <param name="value">参数值列表</param>
        protected override DbCommand CreateCommand(string command, params object[] value)
        {
            SqlCommand comm = new SqlCommand();
            comm.Connection = _conn;

            if (command.Trim().ToLower().StartsWith("insert "))
            {
                if (command.Trim().EndsWith(";"))
                {
                    command += " select @@Rowcount;";
                }
                else
                {
                    command += " ;select @@Rowcount;";
                }
            }

            comm.CommandText = command;

            if (value.Length > 0)
            {
                List<object> paramsList = GetParamsList(value);

                //SQL语句/命令中参数 用“?”符号占位
                string[] temp = command.Split('?');
                if (temp.Length - 1 != paramsList.Count)
                {
                    throw new Exception("参数数量不正确！");
                }

                for (int i = 0; i < paramsList.Count; i++)
                {
                    temp[i] = temp[i] + "@p" + (i + 1).ToString();
                    //判断是否为null
                    if (paramsList[i] == null)
                    {
                        comm.Parameters.AddWithValue("p" + (i + 1).ToString(), DBNull.Value);
                    }
                    else
                    {
                        comm.Parameters.AddWithValue("@p" + (i + 1).ToString(), paramsList[i]);//.ToString()
                    }
                }

                comm.CommandText = string.Join("", temp);
            }

            return comm;
        }

        #region 无参数调用
        /// <summary>
        /// A2返回一个DataSet
        /// </summary>
        /// <param name="sql">SQL语句或命令</param>
        /// <returns>DataSet</returns>
        public override DataSet ExecuteDataSet(string sql)
        {
            SqlCommand comm = (SqlCommand)CreateCommand(sql);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adapter.SelectCommand = comm;

            adapter.Fill(ds);
            return ds;
        }

        #endregion

        #region 带参数查询
        /// <summary>
        /// B2返回一个DataSet
        /// </summary>
        /// <param name="sql">SQL语句或命令</param>
        /// <param name="value">参数值列表</param>
        /// <returns>DataSet</returns>
        public override DataSet ExecuteDataSetParams(string sql, params object[] value)
        {
            SqlCommand comm = (SqlCommand)CreateCommand(sql, value);

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = comm;
            adapter.Fill(ds);
            return ds;
        }

        #endregion

        #region 分页查询

        /// <summary>
        /// 分页查询，返回DataTable
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="pageSize">页面大小（单页记录条数）</param>
        /// <param name="pageIndex">当前页码（页号从1开始）</param>
        /// <returns></returns>
        public override DataSet ExecuteDataSetPage(string sql, int pageSize, int pageIndex)
        {
            throw new Exception("等待实现");
            //return ExecuteDataSetPageParams(sql, pageSize, pageIndex);
        }

        /// <summary>
        /// 分页查询，返回DataTable 约定
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="pageSize">页面大小（单页记录条数）</param>
        /// <param name="pageIndex">当前页码（页号从1开始）</param>
        /// <param name="value">参数列表</param>
        /// <returns></returns>
        public override DataSet ExecuteDataSetPageParams(string sql, int pageSize, int pageIndex, params object[] value)
        {
            var sqlarr = sql.ToLower().Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var keyFields = sqlarr[sqlarr.Count - 2];

            var tableName = sqlarr[sqlarr.IndexOf("from") + 1];

            var condition = " and " + sql.ToLower().Trim().Split(new string[] { "where" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "order" }, StringSplitOptions.RemoveEmptyEntries)[0];

            var dt = ExecuteDataTablePageParams(tableName, "*", keyFields, "", "", pageSize, pageIndex, condition, value);

            return dt.DataSet;
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
        public override DataSet ExecuteDataSetPageByOrderByParams(string sql, int pageSize, int pageIndex, string orderby, params object[] value)
        {
            var sqlarr = sql.ToLower().Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var keyFields = sqlarr[sqlarr.Count - 2];

            var tableName = sqlarr[sqlarr.IndexOf("from") + 1];

            var sql_page = string.Format(@"select top {0} o.* from 
                        (select row_number() over({3}) as rownumber, * from(
                        {1}
                        ) as oo) as o where rownumber> {2}", pageSize, sql, (pageIndex - 1) * pageSize, orderby);

            var ds = ExecuteDataSetParams(sql_page, value);

            // ExecuteDataTablePageParams(tableName, "*", keyFields, "", orderby, pageSize, pageIndex, condition, value);
            return ds;

        }

        /// <summary>
        /// 分页查询，返回DataTable
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fields">要返回的字段列表，逗号分隔</param>
        /// <param name="keyField">主键字段名，如果是Oracle或Mysql可以为空（""）</param>
        /// <param name="groupBy">GROUP BY子句,不包含GROUP BY关键字</param>
        /// <param name="orderBy">Order By xxx desc  完整的排序字段，可以为空,为空默认主键降序，多个字段需用逗号分隔</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">当前页（页号从1开始）</param>
        /// <param name="condition">筛选条件，可以为空，不带"WHERE"关键字 都以And开头</param>
        /// <param name="value">参数列表</param>
        /// <returns>DataTable</returns>
        public override DataTable ExecuteDataTablePageParams(string tableName, string fields, string keyField, string groupBy, string orderBy, int pageSize, int pageIndex, string condition, params object[] value)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                if (condition.ToLower().StartsWith("where") == false)
                {
                    condition = "where 1=1 " + condition;
                }
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = " Order BY " + keyField + " DESC";
            }
            else
            {
                if (orderBy.ToLower().StartsWith("order") == false)
                {
                    orderBy = " order by " + orderBy;
                }
            }

            var sql = $"select {(fields.IsNull() ? "*" : fields)} from {tableName} {condition}";

            var sql_page = string.Format(@"select top {0} o.* from 
                        (select row_number() over({3}) as rownumber, * from(
                        {1}
                        ) as oo) as o where rownumber> {2}", pageSize, sql, (pageIndex - 1) * pageSize, orderBy);

            var ds = ExecuteDataSetParams(sql_page, value);

            return ds.Tables[0];
        }


        /// <summary>
        /// 分页查询，返回DataTable
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offSet">跳过的条数</param>
        /// <param name="value">参数列表</param>
        /// <returns>DataTable.</returns>
        public override DataTable ExecuteDataTablePageParamsWithLimit(string sql, int limit, int offSet, params object[] value)
        {
            throw new Exception("暂未实现");
        }

        #endregion

        #region 获取表的一些信息

        /// <summary>
        /// Gets the name of the database.
        /// </summary>
        /// <value>The name of the database.</value>
        public override string DataBaseName
        {
            get
            {
                return _conn.Database;
                //if (string.IsNullOrWhiteSpace(_connStr) == false)
                //{
                //    return _connStr.Trim().Split(';').FirstOrDefault(p => p.Contains("database")).Split('=')[1];
                //}
                //return string.Empty;
            }
        }


        /// <summary>
        /// 根据表名，获取字段列表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>表字段列表</returns>
        public override List<string> GetFieldsList(string tableName)
        {
            List<string> list = new List<string>();

            string sql = "SELECT * FROM " + tableName + " WHERE 1=0";
            DataTable dt = ExecuteDataTable(sql);
            if (dt != null)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    list.Add(col.ColumnName);
                }
            }

            return list;
        }

        /// <summary>
        /// 删除数据库表
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>System.String.</returns>
        public override Result DropTable(string tableName)
        {
            var sql = "DROP TABLE IF EXISTS " + tableName;
            ExecuteNonQuery(sql);
            return new Result() { IsSucceed = true, Message = "删除成功" };
        }


        /// <summary>
        /// 创建数据库表
        /// </summary>
        /// <param name="tableStr">The table string.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override Result CreateTable(TableStructure tableStr)
        {
            throw new Exception("暂未实现");
        }

        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>Result.</returns>
        public override bool IsExistTable(string tableName)
        {
            var sql = $"SELECT count(1) FROM information_schema.TABLES WHERE table_name ='{tableName}' and table_schema='{_conn.Database}';";
            return Convert.ToInt32(ExecuteScalar(sql)) > 0;
        }

        /// <summary>
        /// 根据时间获取表名 不包含视图
        /// </summary>
        /// <param name="tablePrefix">表名前缀</param>
        /// <param name="timeBegin">开始时间</param>
        /// <param name="timeEnd">结束时间</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public override List<string> GetTableNameByTime(string tablePrefix, DateTime timeBegin, DateTime timeEnd)
        {
            throw new Exception("暂未实现");
        }

        /// <summary>
        /// Gets the table view.
        /// </summary>
        /// <param name="dbName">Name of the database.</param>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        public override Dictionary<string, string> GetTableView(string dbName)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();

            var dt = ExecuteDataTable("select * from sysobjects where xtype in ('U','V') order by name asc");
            foreach (DataRow dr in dt.Rows)
            {
                ret.Add(dr["Name"].ToString(), "无");
            }
            return ret;
        }

        /// <summary>
        /// Gets the colume by table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>DataTable.</returns>
        public override DataTable GetColumeByTable(string tableName)
        {
            var sql = @"SELECT  COLUMN_NAME = a.name,       
        Column_Key = CASE WHEN EXISTS ( SELECT  1
                                FROM    sysobjects
                                WHERE   xtype='PK'
                                        AND name IN (
                                        SELECT  name
                                        FROM    sysindexes
                                        WHERE   indid IN (
                                                SELECT  indid
                                                FROM    sysindexkeys
                                                WHERE   id=a.id
                                                        AND colid=a.colid)) )
                  THEN 'PRI'
                  ELSE ''
             END,DATA_TYPE = b.name,
        ColuMN_Comment = ISNULL(g.[value],'')
FROM    syscolumns a
LEFT   JOIN systypes b
        ON a.xusertype=b.xusertype
INNER   JOIN sysobjects d
        ON a.id=d.id
           AND d.xtype='U'
           AND d.name<>'dtproperties'
LEFT   JOIN syscomments e
        ON a.cdefault=e.id
LEFT   JOIN sys.extended_properties g
        ON a.id=g.major_id
           AND a.colid=g.minor_id
LEFT   JOIN sys.extended_properties f
        ON d.id=f.major_id
           AND f.minor_id=0 where   d.name='" + tableName + "'ORDER   BY a.id,a.colorder;";

            return ExecuteDataTable(sql);
        }

        #endregion
    }
}
