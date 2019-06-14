/*----------------------------------------------------------------
    // 文件功能描述：模块类，MySql数据库操作类，在这里实现了该数据库的相关特性
    // 依赖说明：无依赖，不要直接实例化，通过DBHelper来调用。
    // 异常处理：捕获异常，但不处理
    // 创建标识：qiaomu，QQ1304850320
    // 创建时间：2016-02-05
    // 修改标识：
    // 修改描述：
//----------------------------------------------------------------*/

using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Collections.Generic;
using FastDev.Common.Code;
using System.Text;
using FastDev.Common.Extension;
using System.Linq;
using FastDev.Configer;
using System.Data.SqlClient;
using Dapper;
using static Dapper.SqlMapper;

namespace FastDev.DBFactory.Providers
{
    /// <summary>
    /// Mysql数据库实例
    /// 文件功能描述：模块类，SqlServer数据库操作类，在这里实现了该数据库的相关特性
    /// 依赖说明：无依赖，不要直接实例化，通过DBHelper来调用。
    /// 异常处理：捕获但不处理异常。
    /// </summary>
    /// <seealso cref="FastDev.DBFactory.DBOperator" />
    public class MySqlDapper : DBOperator
    {
        private string _connString;
        private MySqlConnection _conn;
        private MySqlTransaction _trans;
        /// <summary>
        /// 当前是否在存储过程中
        /// </summary>
        protected bool _isInTransaction = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strConnection"></param>
        public MySqlDapper(string strConnection)
        {
            _connString = strConnection;
            _conn = new MySqlConnection(strConnection);
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
                    _conn = new MySqlConnection(_connString);
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
                    this?._conn?.Close();
                }
                catch (Exception ee)
                {
                    Console.WriteLine("关闭数据库连接失败。\r\n" + ee.ToString());
                    //throw new Exception("关闭数据库连接失败。\r\n" + ee.ToString());
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
            MySqlCommand comm = new MySqlCommand();
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
            MySqlCommand comm = new MySqlCommand();
            comm.Connection = _conn;

            if (command.Trim().ToLower().StartsWith("insert "))
            {
                if (command.Trim().EndsWith(";"))
                {
                    command += "SELECT LAST_INSERT_ID();";
                }
                else
                {
                    command += ";SELECT LAST_INSERT_ID();";
                }
            }

            comm.CommandText = command;
            comm.CommandType = CommandType.Text;

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
                        comm.Parameters.AddWithValue("p" + (i + 1).ToString(), "0");
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
            ////using (MySqlCommand comm = (MySqlCommand)CreateCommand(sql))
            ////{
            MySqlCommand comm = (MySqlCommand)CreateCommand(sql);
            //MySqlDataAdapter adapter = new MySqlDataAdapter();
            //DataSet ds = new DataSet();
            //adapter.SelectCommand = comm;

            //adapter.Fill(ds);
            //return ds;
            ////}
            ////MySqlCommand comm = (MySqlCommand)CreateCommand(sql);
            
            
            //Dapper
            var conn = new MySqlConnection(ConfigHelper.GetConfigToString("ConnString"));
            if (conn.State != ConnectionState.Closed) throw new InvalidOperationException("should be closed!");

            DataTable dt = new DataTable();
            dt.Load(conn.ExecuteReader(comm.CommandText));

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

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
            #region 注释 测试 Dapper
            MySqlCommand comm = (MySqlCommand)CreateCommand(sql, value);

            //var ret = comm.ExecuteReader();
            //using (IDataReader dr = ((MySqlCommand)CreateCommand(sql, value)).ExecuteReader())
            //{
            //    DataSet ds = new DataSet();
            //    ds.Load(dr, LoadOption.Upsert, "table1");
            //    return ds;
            //}

            //DataSet ds = new DataSet();
            //MySqlDataAdapter adapter = new MySqlDataAdapter();
            //adapter.SelectCommand = comm;
            //adapter.Fill(ds);
            //return ds;
            #endregion

            //Dapper
            var conn = new MySqlConnection(ConfigHelper.GetConfigToString("ConnString"));
            if (conn.State != ConnectionState.Closed) throw new InvalidOperationException("should be closed!");

            DataTable dt = new DataTable();
            //dt.Load(conn.ExecuteReader(comm.CommandText, value));

            dt.Load(comm.ExecuteReader());

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

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
            string s = string.Format(sql + " LIMIT {0} OFFSET {1}", pageSize, (pageIndex - 1) * pageSize);
            return ExecuteDataSet(s);
        }

        /// <summary>
        /// 分页查询，返回DataTable
        /// </summary>
        /// <param name="sql">除去分页之外的SQL语句</param>
        /// <param name="pageSize">页面大小（单页记录条数）</param>
        /// <param name="pageIndex">当前页码（页号从1开始）</param>
        /// <param name="value">参数列表</param>
        /// <returns></returns>
        public override DataSet ExecuteDataSetPageParams(string sql, int pageSize, int pageIndex, params object[] value)
        {
            string s = string.Format(sql + " LIMIT {0} OFFSET {1}", pageSize, (pageIndex - 1) * pageSize);
            return ExecuteDataSetParams(s, value);
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
            string s = string.Format(sql + orderby + " LIMIT {0} OFFSET {1}", pageSize, (pageIndex - 1) * pageSize);
            return ExecuteDataSetParams(s, value);
        }

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
        public override DataTable ExecuteDataTablePageParams(string tableName, string fields, string keyField, string groupBy, string orderBy, int pageSize, int pageIndex, string condition, params object[] value)
        {
            if (pageIndex > 0)
            {
                pageIndex = pageIndex - 1;
            }

            long offset = pageIndex * pageSize;
            if (!string.IsNullOrEmpty(condition))
            {
                condition = " WHERE " + condition + " ";
            }
            if (!string.IsNullOrEmpty(groupBy))
            {
                groupBy = " GROUP BY " + groupBy + " ";
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                orderBy = " ORDER BY " + orderBy + " ";
            }

            string sql = string.Format("SELECT {0} FROM {1} {2} {3} {4} LIMIT {5} OFFSET {6}", fields, tableName, condition, groupBy, orderBy, pageSize, offset);

            return ExecuteDataTableParams(sql, value);
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
            string s = string.Format(sql + " LIMIT {0} OFFSET {1}", limit, offSet);
            return ExecuteDataSetParams(s, value).Tables[0];
        }

        #endregion

        #region 获取表的一些信息

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
            StringBuilder sb = new StringBuilder();

            sb.AppendMsgLine($"CREATE TABLE {_conn.Database}.{tableStr.TableName}(  ");
            foreach (var item in tableStr.TableColumns)
            {
                var colType = GetColType(item.FieldType, item.DataLength);
                sb.AppendSpaceLine(1, $"`{item.ColName}` {colType} {(item.Unsigned ? "UNSIGNED" : "")} {(!item.CanNull ? "NOT NULL" : "")} {GetDefaultValue(item.DefaultValue, colType, item.ColName)} {(item.IsAutoAdd ? "AUTO_INCREMENT" : "")} COMMENT '{item.ColRemark}',");
            }
            string priKey = "";
            foreach (var item in tableStr.TableColumns.Where(p => p.IsPriKey))
            {
                priKey += item.ColName + ",";
            }
            if (!string.IsNullOrWhiteSpace(priKey))
            {
                sb.AppendSpaceLine(1, "PRIMARY KEY (" + priKey.Trim(',') + ")");
            }
            sb.AppendMsgLine(")");

            sb.AppendMsgLine($"COMMENT='{tableStr.TableRemark}';");

            var ret = ExecuteNonQuery(sb.ToString());

            return new Result() { IsSucceed = ret > 0, Message = "创建成功" };
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
        /// Gets the default value.
        /// </summary>
        /// <param name="defalueValue">The defalue value.</param>
        /// <param name="colType">Type of the col.</param>
        /// <param name="colName">Name of the col.</param>
        /// <returns>System.String.</returns>
        private string GetDefaultValue(string defalueValue, string colType, string colName)
        {
            if (colName.ToLower() == "kid")
            {
                return "";
            }

            if (defalueValue.IsNullOrSpace())
            {
                if (colType.StartsWith("int"))
                    return "DEFAULT 0";
                else if (colType.StartsWith("decimal"))
                    return "DEFAULT 0";
                else if (colType.StartsWith("tinyint"))
                    return "DEFAULT 0";
                else if (colType.StartsWith("datetime"))
                    //return "DEFAULT CURRENT_TIMESTAMP";//mysql老版本不支持
                    return "DEFAULT '1970-01-01 08:00:00'";
                else if (colType.StartsWith("timestamp"))
                    return "DEFAULT CURRENT_TIMESTAMP";
                else if (colType.StartsWith("varchar"))
                    return "DEFAULT ''";
                else if (colType.StartsWith("text"))
                    return "";
            }
            else
            {
                if (colType.StartsWith("int"))
                    return "DEFAULT " + defalueValue;
                else if (colType.StartsWith("decimal"))
                    return "DEFAULT " + defalueValue;
                else if (colType.StartsWith("tinyint"))
                    return "DEFAULT " + defalueValue;
                else if (colType.StartsWith("datetime"))
                    return $"DEFAULT '{defalueValue}'";
                else if (colType.StartsWith("timestamp"))
                    return "DEFAULT CURRENT_TIMESTAMP";
                else if (colType.StartsWith("varchar"))
                    return $"DEFAULT '{defalueValue}'";
            }
            return $"DEFAULT '{defalueValue}'";
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
            List<string> retlist = new List<string>();

            string tableBeginName = $"{tablePrefix}_{timeBegin.ToString("yyyyMM")}";
            string tableEndName = $"{tablePrefix}_{timeEnd.ToString("yyyyMM")}";

            string strSql = $"SELECT table_Name FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='{DataBaseName}' AND TABLE_TYPE IN( 'BASE TABLE','VIEW' ) AND table_Name>='{tableBeginName}' AND table_Name<='{tableEndName}' AND  LENGTH(table_Name)={tableBeginName.Length} ORDER BY TABLE_NAME DESC";

            var dt = ExecuteDataTable(strSql);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    retlist.Add(dr["table_Name"].ToString());
                }
            }
            return retlist;
        }

        /// <summary>
        /// Gets the table view.
        /// </summary>
        /// <param name="dbName">Name of the database.</param>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        public override Dictionary<string, string> GetTableView(string dbName)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();

            var dt = ExecuteDataTable("SELECT * FROM information_schema.tables WHERE table_schema='" + dbName + "' AND table_type IN ('base table','View');");
            foreach (DataRow dr in dt.Rows)
            {
                ret.Add(dr["Table_Name"].ToString(), dr["TABLE_COMMENT"].ToString());
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
            return ExecuteDataTable($"SELECT COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,COLUMN_DEFAULT,Column_KEY ,COLUMN_COMMENT  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{DataBaseName}'  AND TABLE_NAME = '{tableName}'; ");
        }

        #endregion

    }
}