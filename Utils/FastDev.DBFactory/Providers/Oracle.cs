/*----------------------------------------------------------------
    // 文件功能描述：模块类，Oracle数据库操作类，在这里实现了该数据库的相关特性
    // 依赖说明：无依赖，不要直接实例化，通过DBHelper来调用。
    // 异常处理：捕获但不处理异常。
    // 创建标识：qiaomu，QQ1304850320
    // 创建时间：2016-02-05
    // 修改标识：
    // 修改描述：
//----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using FastDev.Common.Code;
using Oracle.ManagedDataAccess.Client;

namespace FastDev.DBFactory.Providers
{
    /// <summary>
    /// Oracle数据库实例
    /// 文件功能描述：模块类，SqlServer数据库操作类，在这里实现了该数据库的相关特性
    /// 依赖说明：无依赖，不要直接实例化，通过DBHelper来调用。
    /// 异常处理：捕获但不处理异常。
    /// </summary>
    public class Oracle : DBOperator
    {
        private string _connString;
        private OracleConnection _conn;
        private OracleTransaction _trans;
        /// <summary>
        /// 当前是否在存储过程中
        /// </summary>
        protected bool _isInTransaction = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strConnection"></param>
        public Oracle(string strConnection)
        {
            _connString = strConnection;
            _conn = new OracleConnection(strConnection);
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
                    _conn = new OracleConnection(_connString);
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
            OracleCommand comm = new OracleCommand();
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
            OracleCommand comm = new OracleCommand();
            comm.Connection = _conn;
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
                    temp[i] = temp[i] + ":p" + (i + 1).ToString();
                    //判断是否为null
                    if (paramsList[i] == null)
                    {
                        comm.Parameters.Add("p" + (i + 1).ToString(), DBNull.Value);
                    }
                    else
                    {
                        comm.Parameters.Add("p" + (i + 1).ToString(), paramsList[i]);//.ToString()
                    }
                }

                comm.CommandText = string.Join("", temp).Trim(';');
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
            OracleCommand comm = (OracleCommand)CreateCommand(sql);

            OracleDataAdapter adapter = new OracleDataAdapter();
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
            OracleCommand comm = (OracleCommand)CreateCommand(sql, value);

            DataSet ds = new DataSet();
            OracleDataAdapter adapter = new OracleDataAdapter();

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
            int startRow = pageSize * (pageIndex - 1) + 1;
            int endRow = startRow + pageSize - 1;
            string s = string.Format("SELECT * FROM (SELECT tpi.*, ROWNUM FROM ({0}) tpi WHERE ROWNUM <={1}) WHERE ROWNUM >={2}", sql, endRow, startRow);

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
            int startRow = pageSize * (pageIndex - 1) + 1;
            int endRow = startRow + pageSize - 1;
            string s = string.Format("SELECT * FROM (SELECT tpi.*, ROWNUM FROM ({0}) tpi WHERE ROWNUM <={1}) WHERE ROWNUM >={2}", sql, endRow, startRow);

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
            int startRow = pageSize * (pageIndex - 1) + 1;
            int endRow = startRow + pageSize - 1;
            string s = string.Format("SELECT * FROM (SELECT tpi.*, ROWNUM FROM ({0}) tpi WHERE ROWNUM <={1}) WHERE ROWNUM >={2} " + orderby, sql, endRow, startRow);

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
            pageIndex = Math.Max(1, pageIndex);

            string sql = "";
            int startRow = 0;
            int endRow = 0;

            startRow = pageSize * (pageIndex) + 1;
            endRow = startRow + pageSize - 1;
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

            sql = string.Format("SELECT * FROM (SELECT ROWNUM RN, TMPTB.* FROM (SELECT {0} FROM {1} {2} {3} {4}) TMPTB WHERE ROWNUM<={4}) WHERE RN>={5}", fields, tableName, condition, groupBy, orderBy, endRow, startRow);

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

            string sql = "SELECT COLUMN_NAME AS FIELD_NAME FROM USER_TAB_COLUMNS WHERE TABLE_NAME=?";

            sql = @"SELECT COL.CNAME AS FIELD_NAME, COL.*, M.COMMENTS
                            FROM COL INNER JOIN USER_COL_COMMENTS M ON COL.CNAME=M.COLUMN_NAME
                            WHERE TNAME=? AND TABLE_NAME=?";

            DataTable dt = ExecuteDataTableParams(sql, tableName, tableName);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(Convert.ToString(dr[0]));
                }
            }

            return list;
        }

        /// <summary>
        /// 删除数据库表
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override Result DropTable(string tableName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建数据库表
        /// </summary>
        /// <param name="tableStr">The table string.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override Result CreateTable(TableStructure tableStr)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>Result.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool IsExistTable(string tableName)
        {
            throw new NotImplementedException();
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
            throw new Exception("未实现,");

            //Dictionary<string, string> ret = new Dictionary<string, string>();

            //var dt = ExecuteDataTable("select t.table_name from user_tables t;");
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ret.Add(dr["Table_Name"].ToString(), dr["TABLE_COMMENT"].ToString());
            //}

            //return ret;
        }

        /// <summary>
        /// Gets the colume by table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>DataTable.</returns>
        public override DataTable GetColumeByTable(string tableName)
        {
            throw new Exception("未实现,");

            //return ExecuteDataTable($"SELECT COLUMN_NAME,DATA_TYPE ,Column_KEY ,COLUMN_COMMENT FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{_db.DataBaseName}'  AND TABLE_NAME = '{tableName}'; ");
        }

        #endregion
    }
}