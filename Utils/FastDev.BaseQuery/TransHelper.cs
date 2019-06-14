//-----------------------------------------------------------------------------------
// <copyright file="TransHelpercs.cs" company="EastWestWalk Enterprises">
// * copyright: (C) 2018 东走西走科技有限公司 版权所有。
// * version  : 1.0.0.0
// * author   : Administrator
// * fileName : TransHelpercs.cs
// * history  : created by Administrator 2018-08-03 下午 02:36:34
// </copyright>
// <summary>
//   FastDev.DbBase.TransHelpercs
// </summary>
//-----------------------------------------------------------------------------------

using FastDev.Configer;
using FastDev.DBFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDev.DbBase
{
    /// <summary>
    /// TransHelpercs
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class TransHelper : IDisposable
    {
        /// <summary>
        /// db链接
        /// </summary>
        private DBOperator _db;

        /// <summary>
        /// 当前事务链接
        /// </summary>
        /// <value>
        /// The database connection.
        /// </value>
        public DBOperator DbConn
        {
            get
            {
                return _db;
            }
        }

        /// <summary>
        /// 数据库工厂
        /// </summary>
        /// <exception cref="System.Exception">数据库连接未配置,无法正常连接数据库,请在配置文件appSettings节点下配置ConnString,可扩展配置ConnStringRead(只读实例)</exception>
        /// <returns>DBOperator.</returns>
        public TransHelper()
        {
            var configDbType = ConfigHelper.GetConfigToString("DataBaseType");
            if (string.IsNullOrWhiteSpace(configDbType))
            {
                configDbType = "MySql";
            }
            var _dbType = configDbType;
            var _connStr = ConfigHelper.GetConfigToString("ConnString");
            if (string.IsNullOrWhiteSpace(_connStr))
            {
                throw new Exception("数据库连接未配置,无法正常连接数据库,请在配置文件appSettings节点下配置ConnString,可扩展配置ConnStringRead(只读实例)");
            }
            _db = GetDBOperator(_dbType, _connStr);
            _db.Open();
            DbConn.BeginTrans();
        }

        /// <summary>
        /// 创建数据库工厂实例
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="connStr">连接字符串</param>
        /// <returns>
        /// 数据库操作实例
        /// </returns>
        /// <exception cref="System.Exception">未知的数据库类型：" + dbType</exception>
        private static DBOperator GetDBOperator(string dbType, string connStr)
        {
            switch (dbType.ToUpper())
            {
                case "MYSQL":
                    return new FastDev.DBFactory.Providers.Mysql(connStr);
                case "ORACLE":
                    return new FastDev.DBFactory.Providers.Oracle(connStr);
                case "SQLSERVER":
                    return new FastDev.DBFactory.Providers.SqlServer(connStr);
                case "POSTGRESQL":
                    return new FastDev.DBFactory.Providers.Postgresql(connStr);
                case "MYSQLDAPPER":
                    return new FastDev.DBFactory.Providers.MySqlDapper(connStr);
                default:
                    throw new Exception("未知的数据库类型：" + dbType);
            }
        }

        /// <summary>
        /// 释放
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Dispose()
        {
            DbConn.Close();
        }

        /// <summary>
        /// 事务提交
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
    }
}
