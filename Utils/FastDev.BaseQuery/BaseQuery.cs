/*----------------------------------------------------------------
    // 文件功能描述：模块类，数据库常用操作的抽象类，包含了对于单表的常见增、删、改、查及缓存操作
    // 依赖说明：Config、Log、DBHelper、CacheHelper
    // 异常处理：捕获异常，当出现异常时，会通过Log输出错误信息到日志文件。
    // 创建标识：qiaomu，QQ1304850320
    // 创建时间：2016-02-05
    // 修改标识：添加反射支持Model
    // 修改描述：
//----------------------------------------------------------------*/


using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using FastDev.DBFactory;
using FastDev.Cache;
using FastDev.Log;
using FastDev.Common.Code;
using System.Linq;
using FastDev.Configer;
using FastDev.Common.Extension;
using FastDev;

namespace FastDev.DbBase
{
    /// <summary>
    /// 表单查询基类（针对单表的增/删/改/查的操作）
    /// 文件功能描述：模块类，数据库常用操作的抽象类，包含了对于单表的常见增、删、改、查及缓存操作
    /// 依赖说明：Config、Log、DBHelper、CacheHelper
    /// 异常处理：捕获异常，当出现异常时，会通过Log输出错误信息到日志文件。
    /// </summary>
    public abstract class BaseQuery
    {
        #region 事务处理
        /// <summary>
        /// 是否在事务中 默认非事务
        /// </summary>
        private bool _inTrans = false;

        /// <summary>
        /// 数据工厂
        /// </summary>
        private DBOperator _db = null;

        /// <summary>
        /// 外部事务处理
        /// </summary>
        /// <value>
        /// The database connection.
        /// </value>
        protected DBOperator DbConn
        {
            get
            {
                return _db;
            }
            set
            {
                if (value == null) return;
                _inTrans = true;
                _db = value;
            }
        }

        #endregion

        #region 外部数据连接 支持长连接

        /// <summary>
        /// 外部连接 支持长连接使用
        /// </summary>
        public DBHelper ExternalDbHelper = null;

        #endregion

        /// <summary>
        /// 数据库中的表名
        /// </summary>
        protected string TableName = string.Empty;
        /// <summary>
        /// 查询项目名称
        /// </summary>
        protected string ItemName = string.Empty;
        /// <summary>
        /// 是否写入缓存
        /// </summary>
        protected bool IsAddIntoCache = false;
        /// <summary>
        /// 缓存键名
        /// </summary>
        /// <value>
        /// The cache key.
        /// </value>
        protected string CacheKey => "CacheKeyQuery" + TableName;

        /// <summary>
        /// 缓存有效时间（分钟）
        /// </summary>
        protected int CacheTimeOut = 30;

        /// <summary>
        /// 主键字段 用于取Model的时候 默认第一条排序
        /// </summary>
        protected string KeyField = "KID";
        /// <summary>
        /// 分组字段
        /// </summary>
        protected string GroupByFields = string.Empty;
        /// <summary>
        /// 排序字段
        /// </summary>
        protected string OrderbyFields = "KID DESC";


        /// <summary>
        /// The database type value
        /// </summary>
        private string _databaseTypeValue = "";
        /// <summary>
        /// The datebase connection value
        /// </summary>
        private string _datebaseConnValue = "";
        /// <summary>
        /// The datebase connection value read
        /// </summary>
        private string _datebaseConnValueRead = "";

        /// <summary>
        /// 数据库类型
        /// </summary>
        /// <value>
        /// The database type value.
        /// </value>
        private string DatabaseTypeValue
        {
            get
            {
                if (_databaseTypeValue.IsNull())
                {
                    var dbtype = ConfigHelper.GetConfigToString("DataBaseType");
                    if (dbtype.IsNull())
                    {
                        return "MySql";
                    }
                    else
                    {
                        return dbtype;
                    }
                }
                else
                {
                    return _databaseTypeValue;
                }
            }
            set
            {
                _databaseTypeValue = value;
            }
        }

        /// <summary>
        /// 数据库连接串串
        /// </summary>
        /// <value>
        /// The database connection value.
        /// </value>
        private string DatabaseConnValue
        {
            get
            {
                if (_datebaseConnValue.IsNull())
                {
                    return ConfigHelper.GetConfigToString("ConnString");
                }
                else
                {
                    return _datebaseConnValue;
                }
            }
            set
            {
                _datebaseConnValue = value;
            }
        }

        /// <summary>
        /// 数据库连接串串
        /// </summary>
        /// <value>
        /// The database connection value read.
        /// </value>
        private string DatabaseConnValueRead
        {
            get
            {
                if (_datebaseConnValueRead.IsNull())
                {
                    return DatabaseConnValue;
                }
                else
                {
                    return _datebaseConnValueRead;
                }
            }
            set
            {
                _datebaseConnValueRead = value;
            }
        }

        /// <summary>
        /// 默认配置文件里面的 数据库类型配置键名
        /// </summary>
        /// <value>
        /// The data base type key.
        /// </value>
        public string DataBaseTypeKey
        {
            set
            {
                if (value.IsNull())
                {
                    DatabaseTypeValue = "MYSQL";
                }
                else
                {
                    DatabaseTypeValue = ConfigHelper.GetConfigToString(value);
                }
            }
        }
        /// <summary>
        /// 默认配置文件里面的 数据库连接串配置键名
        /// </summary>
        /// <value>
        /// The data base connection key.
        /// </value>
        public string DataBaseConnKey
        {
            set
            {
                if (value.IsNull())
                {
                    DatabaseConnValue = ConfigHelper.GetConfigToString("ConnString");
                }
                else
                {
                    DatabaseConnValue = ConfigHelper.GetConfigToString(value);
                    DatabaseConnValueRead = ConfigHelper.GetConfigToString(value + "Read");
                }
            }
        }

        #region 添加

        /// <summary>
        /// 添加记录 返回当前添加的数据的主键值
        /// </summary>
        /// <param name="fieldList">字段列表</param>
        /// <param name="valueList">值列表</param>
        /// <returns></returns>
        public int Add(List<string> fieldList, List<object> valueList)
        {
            if (fieldList.Count < 1 || fieldList.Count != valueList.Count)
            {
                return 0;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + TableName + " (");
            sb.Append(string.Join(",", fieldList.ToArray()) + " ) VALUES (?");
            for (byte i = 1; i < fieldList.Count; i++)
            {
                sb.Append(", ?");
            }
            sb.Append(");");

            //此代码是MySql特有属性,不支持其他数据库,数据库工厂
            if (DatabaseTypeValue.ToUpper() == "MYSQL")
            {
                sb.Append("SELECT LAST_INSERT_ID();");
            }

            int row = 0;
            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                row = dbHelper.ExecuteScalarIntParams(sb.ToString(), valueList);
                if (row > 0 && IsAddIntoCache)
                {
                    CacheHelper.Remove(CacheKey);
                }
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        row = ExternalDbHelper.ExecuteScalarIntParams(sb.ToString(), valueList);
                        if (row > 0 && IsAddIntoCache)
                        {
                            CacheHelper.Remove(CacheKey);
                        }
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValue))
                        {
                            row = dbHelper.ExecuteScalarIntParams(sb.ToString(), valueList);
                            if (row > 0 && IsAddIntoCache)
                            {
                                CacheHelper.Remove(CacheKey);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "添加记录到表" + TableName + "出错");
                    throw ex;
                }
            }

            return row;
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="fieldValue">字段值列表</param>
        /// <returns>
        /// 返回成功条数
        /// </returns>
        public int Add(Dictionary<string, object> fieldValue)
        {
            if (fieldValue.Count == 0)
            {
                return 0;
            }
            else
            {
                List<string> fieldList = new List<string>();
                List<object> valueList = new List<object>();
                foreach (var item in fieldValue)
                {
                    fieldList.Add(item.Key);
                    valueList.Add(item.Value);
                }
                return Add(fieldList, valueList);
            }
        }

        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <param name="fieldValuelst">The field valuelst.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public int Adds(List<Dictionary<string, object>> fieldValuelst)
        {
            if (fieldValuelst.Count == 0)
            {
                return 0;
            }
            else
            {
                int row = 0;
                if (_inTrans)
                {
                    var dbHelper = new DBHelper(DbConn);
                    foreach (var item in fieldValuelst)
                    {
                        if (item.Count() == 0)
                        {
                            continue;
                        }
                        StringBuilder sb = new StringBuilder();
                        List<string> lst = new List<string>();
                        List<object> lstvalue = new List<object>();
                        foreach (var column in item)
                        {
                            lst.Add(column.Key);
                            lstvalue.Add(column.Value);
                        }

                        sb.Append("INSERT INTO " + TableName + " (");
                        sb.Append(string.Join(",", lst.ToArray()) + " ) VALUES (?");
                        for (byte i = 1; i < lstvalue.Count; i++)
                        {
                            sb.Append(", ?");
                        }
                        sb.Append(");");

                        row += dbHelper.ExecuteNonQueryParams(sb.ToString(), lstvalue);
                    }
                }
                else
                {
                    if (ExternalDbHelper != null)
                    {
                        foreach (var item in fieldValuelst)
                        {
                            if (item.Count() == 0)
                            {
                                continue;
                            }

                            StringBuilder sb = new StringBuilder();

                            List<string> lst = new List<string>();
                            List<object> lstvalue = new List<object>();
                            foreach (var column in item)
                            {
                                lst.Add(column.Key);
                                lstvalue.Add(column.Value);
                            }

                            sb.Append("INSERT INTO " + TableName + " (");
                            sb.Append(string.Join(",", lst.ToArray()) + " ) VALUES (?");
                            for (byte i = 1; i < lstvalue.Count; i++)
                            {
                                sb.Append(", ?");
                            }
                            sb.Append(");");

                            row += ExternalDbHelper.ExecuteNonQueryParams(sb.ToString(), lstvalue);
                        }
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValue))
                        {
                            foreach (var item in fieldValuelst)
                            {
                                if (item.Count() == 0)
                                {
                                    continue;
                                }

                                StringBuilder sb = new StringBuilder();

                                List<string> lst = new List<string>();
                                List<object> lstvalue = new List<object>();
                                foreach (var column in item)
                                {
                                    lst.Add(column.Key);
                                    lstvalue.Add(column.Value);
                                }

                                sb.Append("INSERT INTO " + TableName + " (");
                                sb.Append(string.Join(",", lst.ToArray()) + " ) VALUES (?");
                                for (byte i = 1; i < lstvalue.Count; i++)
                                {
                                    sb.Append(", ?");
                                }
                                sb.Append(");");

                                row += dbHelper.ExecuteNonQueryParams(sb.ToString(), lstvalue);
                            }
                        }
                    }
                }
                return row;
            }
        }


        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldValuelst">The field valuelst.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public int Adds<T>(List<Dictionary<string, object>> fieldValuelst) where T : new()
        {
            var lstdic = new List<Dictionary<string, object>>();

            foreach (var item in fieldValuelst)
            {
                var keyValues = item.ToDictionary(p => p.Key.ToLower(), p => p.Value);
                var dic = new Dictionary<string, object>();
                T t = new T();
                foreach (var field in t.GetType().GetProperties())
                {
                    if (keyValues.ContainsKey(field.Name.ToLower()))
                    {
                        if (keyValues[field.Name.ToLower()].IsNull())
                        {
                            var v = field.GetValue(t, null);
                            if (v == null && field.PropertyType == typeof(string))
                            {
                                v = "";
                            }
                            else if (v == null && field.PropertyType == typeof(int))
                            {
                                v = 0;
                            }

                            dic.Add(field.Name, v);
                        }
                        else
                        {
                            dic.Add(field.Name, keyValues[field.Name.ToLower()]);
                        }
                    }
                    else if (field.Name.ToLower() == "createtime")
                    {
                        dic.Add(field.Name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                }
                lstdic.Add(dic);
            }
            return Adds(lstdic);
        }


        /// <summary>
        /// 添加记录
        /// </summary>
        /// <typeparam name="T">待添加的模型类型  此类型变量必须和数据库字段一一对应</typeparam>
        /// <param name="item">模型实例</param>
        /// <returns>
        /// 返回成功条数
        /// </returns>
        public int Add<T>(T item)
        {
            return Add(ToDictionary(item));
        }

        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public int Adds<T>(List<T> items)
        {
            List<Dictionary<string, object>> diclst = new List<Dictionary<string, object>>();
            foreach (var item in items)
            {
                diclst.Add(ToDictionary(item));
            }
            return Adds(diclst);
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValues">The key values.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public int Add<T>(Dictionary<string, object> keyValues) where T : new()
        {
            keyValues = keyValues.ToDictionary(p => p.Key.ToLower(), p => p.Value);
            var dic = new Dictionary<string, object>();
            T t = new T();
            foreach (var field in t.GetType().GetProperties())
            {
                if (keyValues.ContainsKey(field.Name.ToLower()))
                {
                    dic.Add(field.Name, keyValues[field.Name.ToLower()]);
                }
                else if (field.Name.ToLower() == "createtime")
                {
                    dic.Add(field.Name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }

            return Add(dic);
        }

        #endregion

        #region 修改

        /// <summary>
        /// 根据主键更新记录
        /// </summary>
        /// <param name="fieldList">要修改的字段列表</param>
        /// <param name="valueList">要修改的值列表</param>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public int UpdateByKey(List<string> fieldList, List<object> valueList, object keyValue)
        {
            return Update(fieldList, valueList, KeyField + "=?", keyValue);
        }

        /// <summary>
        /// 根据主键更新记录
        /// </summary>
        /// <param name="fieldValue">要修改的字段值列表</param>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public int UpdateByKey(Dictionary<string, object> fieldValue, object keyValue)
        {
            if (fieldValue.Count == 0)
            {
                return 0;
            }
            else
            {
                List<string> fieldList = new List<string>();
                List<object> valueList = new List<object>();
                foreach (var item in fieldValue)
                {
                    //忽略主键
                    if (item.Key.ToLower() == this.KeyField.ToLower())
                    {
                        continue;
                    }

                    fieldList.Add(item.Key);
                    valueList.Add(item.Value);
                }
                return UpdateByKey(fieldList, valueList, keyValue);
            }
        }


        /// <summary>
        /// 根据主键更新记录 此方法会修改模型对对应的所有字段,调用时请注意
        /// </summary>
        /// <typeparam name="T">要修改的类型 此类型变量必须和数据库字段一一对应</typeparam>
        /// <param name="item">要修改的类型 实例</param>
        /// <param name="keyValue">主键值</param>
        /// <returns>
        /// 返回成功条数
        /// </returns>
        public int UpdateByKey<T>(T item, object keyValue)
        {
            return UpdateByKey(ToDictionary(item), keyValue);
        }

        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="fieldList">要修改的字段列表</param>
        /// <param name="valueList">要修改的值列表</param>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public int Update(List<string> fieldList, List<object> valueList, string where, params object[] values)
        {
            if (fieldList.Count < 1 || fieldList.Count != valueList.Count)
            {
                return 0;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE " + TableName + " SET ");
            sb.Append(string.Join("=?,", fieldList.ToArray()) + "=?");
            if (!string.IsNullOrWhiteSpace(where))
            {
                sb.Append(" WHERE " + where);
            }

            if (values != null)
            {
                foreach (var item in values)
                {
                    valueList.Add(item);
                }
            }

            int row = 0;
            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                row = dbHelper.ExecuteNonQueryParams(sb.ToString(), valueList.ToArray());
                if (row > 0 && IsAddIntoCache)
                {
                    CacheHelper.Remove(CacheKey);
                }
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        row = ExternalDbHelper.ExecuteNonQueryParams(sb.ToString(), valueList.ToArray());
                        if (row > 0 && IsAddIntoCache)
                        {
                            CacheHelper.Remove(CacheKey);
                        }
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValue))
                        {
                            row = dbHelper.ExecuteNonQueryParams(sb.ToString(), valueList.ToArray());
                            if (row > 0 && IsAddIntoCache)
                            {
                                CacheHelper.Remove(CacheKey);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "修改表" + TableName + "记录出错");
                }
            }

            return row;
        }


        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="fieldValue">要修改的字段值列表</param>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public int Update(Dictionary<string, object> fieldValue, string where, params object[] values)
        {
            if (fieldValue.Count == 0)
            {
                return 0;
            }
            else
            {
                List<string> fieldList = new List<string>();
                List<object> valueList = new List<object>();
                foreach (var item in fieldValue)
                {
                    fieldList.Add(item.Key);
                    valueList.Add(item.Value);
                }
                return Update(fieldList, valueList, where, values);
            }
        }


        /// <summary>
        /// Updates the specified field value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="where">The where.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public int Update<T>(Dictionary<string, object> fieldValue, string where, params object[] values) where T : new()
        {
            if (fieldValue.Count == 0)
            {
                return 0;
            }
            else
            {
                List<string> fieldList = new List<string>();
                List<object> valueList = new List<object>();

                fieldValue = fieldValue.ToDictionary(p => p.Key.ToLower(), p => p.Value);
                var dic = new Dictionary<string, object>();
                T t = new T();
                foreach (var field in t.GetType().GetProperties())
                {
                    if (fieldValue.ContainsKey(field.Name.ToLower()))
                    {
                        dic.Add(field.Name, fieldValue[field.Name.ToLower()]);
                    }
                    else if (field.Name.ToLower() == "updatetime")
                    {
                        dic.Add(field.Name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else if (field.Name.ToLower() == "updatetime")
                    {
                        dic.Add(field.Name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                }

                foreach (var item in dic)
                {
                    fieldList.Add(item.Key);
                    valueList.Add(item.Value);
                }
                return Update(fieldList, valueList, where, values);
            }
        }

        /// <summary>
        /// 修改记录
        /// </summary>
        /// <typeparam name="T">待修改模型</typeparam>
        /// <param name="item">待修改模型 实例</param>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="values">参数</param>
        /// <returns>
        /// 返回成功条数
        /// </returns>
        public int Update<T>(T item, string where, params object[] values)
        {
            return Update(ToDictionary(item), where, values);
        }

        /// <summary>
        /// Updates the specified dicdata.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="valuedata">The dicdata.</param>
        /// <param name="keydata">The keydata.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public int Update<T>(Dictionary<string, object> valuedata, Dictionary<string, object> keydata) where T : new()
        {
            List<object> values = new List<object>();

            var sbwhere = GetWhereByDic<T>(keydata, ref values);

            return Update<T>(valuedata, sbwhere, values.ToArray());
        }

        /// <summary>
        /// Updates the specified dicdata.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dicdata">The dicdata.</param>
        /// <param name="kID">The k identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public int UpdateByKey<T>(Dictionary<string, object> dicdata, object kID) where T : new()
        {
            dicdata = dicdata.ToDictionary(p => p.Key.ToLower(), p => p.Value);
            var dic = new Dictionary<string, object>();
            T t = new T();
            foreach (var field in t.GetType().GetProperties())
            {
                if (dicdata.ContainsKey(field.Name.ToLower()))
                {
                    dic.Add(field.Name, dicdata[field.Name.ToLower()]);
                }
                else if (field.Name.ToLower() == "updatetime")
                {
                    dic.Add(field.Name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }
            return UpdateByKey(dic, kID);
        }


        /// <summary>
        /// 更新数字 累计减少是方式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fields">字段名</param>
        /// <param name="addNums">更新的数值 可以为负数 负数表示减少</param>
        /// <param name="whereKey">字典条件Key</param>
        /// <returns></returns>
        public int UpdateNums<T>(string fields, int addNums, Dictionary<string, object> whereKey) where T : new()
        {
            if (string.IsNullOrEmpty(fields) || addNums == 0 || fields.Contains(",") || fields.Contains("\"") || fields.Contains("--"))
            {
                return 0;
            }

            var sb = new StringBuilder();
            sb.Append("UPDATE " + TableName + " SET ");
            sb.Append($" {fields}={fields}+{addNums} ");

            var values = new List<object>();

            var sbwhere = GetWhereByDic<T>(whereKey, ref values);

            if (!string.IsNullOrWhiteSpace(sbwhere))
            {
                sb.Append(" WHERE " + sbwhere);
            }

            int row = 0;
            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                row = dbHelper.ExecuteNonQueryParams(sb.ToString(), values.ToArray());
                if (row > 0 && IsAddIntoCache)
                {
                    CacheHelper.Remove(CacheKey);
                }
            }
            else
            {
                try
                {
                    using (var dbHelper = new DBHelper())
                    {
                        row = dbHelper.ExecuteNonQueryParams(sb.ToString(), values.ToArray());
                        if (row > 0 && IsAddIntoCache)
                        {
                            CacheHelper.Remove(CacheKey);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "修改表" + TableName + "记录出错");
                }
            }

            return row;
        }

        #endregion

        #region 删除记录

        /// <summary>
        /// 根据主键删除记录
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public int DeleteByKey(object keyValue)
        {
            return Delete(KeyField + "=?", keyValue);
        }

        /// <summary>
        /// 根据限定条件删除记录
        /// </summary>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public int Delete(string where, params object[] values)
        {
            int row = 0;
            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                row = dbHelper.ExecuteNonQueryParams("DELETE FROM " + TableName + " WHERE " + where, values);
                if (row > 0 && IsAddIntoCache)
                {
                    CacheHelper.Remove(CacheKey);
                }
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        row = ExternalDbHelper.ExecuteNonQueryParams("DELETE FROM " + TableName + " WHERE " + where, values);
                        if (row > 0 && IsAddIntoCache)
                        {
                            CacheHelper.Remove(CacheKey);
                        }
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValue))
                        {
                            row = dbHelper.ExecuteNonQueryParams("DELETE FROM " + TableName + " WHERE " + where, values);
                            if (row > 0 && IsAddIntoCache)
                            {
                                CacheHelper.Remove(CacheKey);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "删除表" + TableName + "记录出错");
                }
            }
            return row;
        }

        /// <summary>
        /// Deletes the specified keydata.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keydata">The keydata.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public int Delete<T>(Dictionary<string, object> keydata) where T : new()
        {
            List<object> values = new List<object>();

            var sbwhere = GetWhereByDic<T>(keydata, ref values);

            return Delete(sbwhere, values.ToArray());
        }

        /// <summary>
        /// 批量删除数据 根据主键删除
        /// </summary>
        /// <param name="kidlst">The kid.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public int DeleteByKeys(List<int> kidlst)
        {
            return Delete($"KID in({string.Join(",", kidlst)})");
        }

        /// <summary>
        /// 批量删除数据 根据主键删除
        /// </summary>
        /// <param name="kids">The kid.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public int DeleteByKeys(string kids)
        {
            var lst = new List<int>();
            int id = 0;
            foreach (var item in kids.Split(','))
            {
                if (int.TryParse(item, out id))
                {
                    lst.Add(id);
                }
            }
            if (lst.Count == 0)
                return 0;
            return Delete($"KID in({string.Join(",", lst)})");
        }

        #endregion

        #region 查询 读数据

        #region Get获取函数值Max Sum GroupBy 多表关联复杂查询等
        /// <summary>
        /// 查询最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxID()
        {
            string sql = "SELECT MAX(" + KeyField + ") FROM " + TableName;

            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                return Convert.ToInt32(dbHelper.ExecuteScalarInt(sql));
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        return Convert.ToInt32(ExternalDbHelper.ExecuteScalarInt(sql));
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            return Convert.ToInt32(dbHelper.ExecuteScalarInt(sql));
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "读取表" + TableName + "最大ID出错");
                }
            }
            return 0;
        }

        /// <summary>
        /// 获取记录总和
        /// </summary>
        /// <param name="fileds">The fileds.</param>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="values">参数</param>
        /// <returns>
        /// System.Decimal.
        /// </returns>
        public decimal GetSum(string fileds, string where, params object[] values)
        {
            string sql = "SELECT sum(" + fileds + ") FROM " + TableName + " WHERE " + where;

            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                return Convert.ToDecimal(dbHelper.ExecuteScalarIntParams(sql, values));
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        return Convert.ToDecimal(ExternalDbHelper.ExecuteScalarIntParams(sql, values));
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            return Convert.ToDecimal(dbHelper.ExecuteScalarIntParams(sql, values));
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "读取表" + TableName + "记录条数出错");
                }
            }


            return 0;
        }



        /// <summary>
        /// 根据In子查询查询数据 主dic包含 orderby 可以处理排序 值 字段 fields desc
        /// </summary>
        /// <typeparam name="T1">主表</typeparam>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public IList<T1> GetListByInSelect<T1>(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere, int page = 1, int limit = 10) where T1 : new()
        {
            List<object> mainvalues = new List<object>();


            var selectfields = "*";
            if (mainDicWhere != null && mainDicWhere.ContainsKey("selectfields"))
            {
                selectfields = mainDicWhere["selectfields"].ToString();
                mainDicWhere.Remove("selectfields");
            }

            var orderby = "";
            if (mainDicWhere.ContainsKey("orderby"))
            {
                orderby = mainDicWhere["orderby"].ToString().Trim();
                mainDicWhere.Remove("orderby");
            }

            var mainwhere = GetWhereByDic<T1>(mainDicWhere, ref mainvalues);

            List<object> subvalues = new List<object>();
            var subwhere = GetWhereByDic(subDicWhere, ref subvalues);

            #region 组装sql语句
            var sql = $"select {selectfields} from {TableName} Where {mainTableFields} in (select {subTableFields} from {subTableName} ";

            if (subwhere.IsNull() == false)
            {
                sql += $" where {subwhere} ";
            }
            sql += " )";

            if (mainwhere.IsNull() == false)
            {
                sql += $" and {mainwhere} ";
                subvalues.AddRange(mainvalues.ToArray());
            }
            #endregion

            #region 处理orderby排序
            if (!string.IsNullOrWhiteSpace(orderby))
            {
                sql += " order by " + orderby;
            }
            #endregion

            #region 查询数据
            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                return ToEntityList<T1>(dbHelper.ExecuteDataTablePageParams(sql, limit, page, subvalues.ToArray()));
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        return ToEntityList<T1>(ExternalDbHelper.ExecuteDataTablePageParams(sql, limit, page, subvalues.ToArray()));
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            return ToEntityList<T1>(dbHelper.ExecuteDataTablePageParams(sql, limit, page, subvalues.ToArray()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "分页查询表" + TableName + "记录出错");
                    throw ex;
                }
            }
            #endregion
        }

        /// <summary>
        /// 根据In子查询查询数据 主dic包含 orderby Key时 自动处理排序 值格式 fields desc
        /// 关联字典说明 第一个Key为主表字段 第二个Key为 子表.字段 第三个为查询条件字典
        /// </summary>
        /// <typeparam name="T1">主表</typeparam>
        /// <param name="relationFields">3层字典 第一层Key主表关联字段  第二层Key子表关联字段 格式[表名.字段名] Value为查询条件字典</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public IList<T1> GetListByInRelationTable<T1>(Dictionary<string, Dictionary<string, Dictionary<string, object>>> relationFields, Dictionary<string, object> mainDicWhere, int page = 1, int limit = 10) where T1 : new()
        {
            List<object> mainvalues = new List<object>();

            #region 处理orderby

            var selectfields = "*";
            if (mainDicWhere != null && mainDicWhere.ContainsKey("selectfields"))
            {
                selectfields = mainDicWhere["selectfields"].ToString();
                mainDicWhere.Remove("selectfields");
            }

            var orderby = "";
            if (mainDicWhere.ContainsKey("orderby"))
            {
                orderby = mainDicWhere["orderby"].ToString().Trim();

                mainDicWhere.Remove("orderby");
            }
            #endregion

            var mainwhere = GetWhereByDic<T1>(mainDicWhere, ref mainvalues);

            StringBuilder sbsql = new StringBuilder();
            sbsql.Append($"select {selectfields} from {TableName} Where ");

            bool isfirst = true;

            List<object> queryParams = new List<object>();

            foreach (var item in relationFields)
            {
                var mainFields = item.Key;

                foreach (var sub in item.Value)
                {
                    var ary = sub.Key.Split('.');
                    if (ary.Length == 2)
                    {
                        var subtablename = ary[0];

                        var subtablefields = ary[1];

                        var subwheredic = sub.Value;

                        var subvalues = new List<object>();
                        var subwhere = GetWhereByDic(subwheredic, ref subvalues);

                        if (subwhere.IsNull() == false)
                        {
                            subwhere = " where " + subwhere;
                            queryParams.AddRange(subvalues.ToArray());
                        }

                        sbsql.Append(isfirst ? "" : " AND ");
                        sbsql.Append($" {mainFields} in (select {subtablefields} from {subtablename} {subwhere}) ");

                        isfirst = false;
                    }
                }
            }

            #region 处理orderby排序
            if (!string.IsNullOrWhiteSpace(orderby))
            {
                sbsql.Append(" order by " + orderby);
            }
            #endregion

            #region 查询数据
            var sql = sbsql.ToString();
            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                return ToEntityList<T1>(dbHelper.ExecuteDataTablePageParams(sql, limit, page, queryParams.ToArray()));
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        return ToEntityList<T1>(ExternalDbHelper.ExecuteDataTablePageParams(sql, limit, page, queryParams.ToArray()));
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            return ToEntityList<T1>(dbHelper.ExecuteDataTablePageParams(sql, limit, page, queryParams.ToArray()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "分页查询表" + TableName + "记录出错");
                    throw ex;
                }
            }
            #endregion
        }

        /// <summary>
        /// 根据In子查询查询数据 主dic包含 orderby Key时 自动处理排序 值格式 fields desc
        /// 关联字典说明 第一个Key为主表字段 第二个Key为 子表.字段 第三个为查询条件字典
        /// </summary>
        /// <typeparam name="T1">主表</typeparam>
        /// <param name="retFields">查询结果字段 如果有重名 自行业务逻辑加表名获得,可以传一个值 *</param>
        /// <param name="relationFields">3层字典 第一层Key主表关联字段  第二层Key子表关联字段 格式[表名.字段名] Value为查询条件字典</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="page">当前页数</param>
        /// <param name="limit">当前页显示的数据条数</param>
        /// <returns></returns>
        public DataTable GetDataTableByInRelationTable<T1>(List<string> retFields, Dictionary<string, Dictionary<string, Dictionary<string, object>>> relationFields, Dictionary<string, object> mainDicWhere, int page = 1, int limit = 10) where T1 : new()
        {
            if (retFields == null)
            {
                retFields = new List<string>() { "*" };
            }
            List<object> mainvalues = new List<object>();

            #region 处理orderby
            var orderby = "";
            if (mainDicWhere.ContainsKey("orderby"))
            {
                orderby = mainDicWhere["orderby"].ToString().Trim();

                mainDicWhere.Remove("orderby");
            }
            #endregion

            var mainwhere = GetWhereByDic<T1>(mainDicWhere, ref mainvalues);

            StringBuilder sbsql = new StringBuilder();
            sbsql.Append($"select {string.Join(",", retFields)} from {TableName} Where ");

            bool isfirst = true;

            List<object> queryParams = new List<object>();

            foreach (var item in relationFields)
            {
                var mainFields = item.Key;

                foreach (var sub in item.Value)
                {
                    var ary = sub.Key.Split('.');
                    if (ary.Length == 2)
                    {
                        var subtablename = ary[0];

                        var subtablefields = ary[1];

                        var subwheredic = sub.Value;

                        var subvalues = new List<object>();
                        var subwhere = GetWhereByDic(subwheredic, ref subvalues);

                        if (subwhere.IsNull() == false)
                        {
                            subwhere = " where " + subwhere;
                            queryParams.AddRange(subvalues.ToArray());
                        }

                        sbsql.Append(isfirst ? "" : " AND ");
                        sbsql.Append($" {mainFields} in (select {subtablefields} from {subtablename} {subwhere}) ");

                        isfirst = false;
                    }
                }
            }

            #region 处理orderby排序
            if (!string.IsNullOrWhiteSpace(orderby))
            {
                sbsql.Append(" order by " + orderby);
            }
            #endregion

            #region 查询数据
            var sql = sbsql.ToString();
            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                return dbHelper.ExecuteDataTablePageParams(sql, limit, page, queryParams.ToArray());
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        return ExternalDbHelper.ExecuteDataTablePageParams(sql, limit, page, queryParams.ToArray());
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            return dbHelper.ExecuteDataTablePageParams(sql, limit, page, queryParams.ToArray());
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "分页查询表" + TableName + "记录出错");
                    throw ex;
                }
            }
            #endregion
        }

        /// <summary>
        /// 根据Where条件Group查询数据,返回的列只比对Groupby的字段多一列,coun(1) As GroupCnt 目前只支持MySql
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="groupByFields">分组字段</param>
        /// <param name="dicWhere">查询条件</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">当前条数</param>
        /// <returns></returns>
        public DataTable GetDataByGroup<T>(List<string> groupByFields, Dictionary<string, object> dicWhere, int page, int limit) where T : new()
        {
            List<object> mainvalues = new List<object>();
            var mainwhere = GetWhereByDic<T>(dicWhere, ref mainvalues);

            var fields = string.Join(",", groupByFields);

            var sql = $"select {fields},count(1) As GroupCnt from {TableName} ";

            if (mainwhere.IsNull() == false)
            {
                sql += $" where {mainwhere} ";
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in groupByFields)
            {
                if (item.Trim().Contains(' ') == false)
                {
                    sb.Append(item + ",");
                }
            }

            sql += " GROUP BY " + sb.ToString().Trim(',');

            sql += " Order By GroupCnt desc ";

            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                return dbHelper.ExecuteDataTablePageParams(sql, limit, page, mainvalues.ToArray());
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        return ExternalDbHelper.ExecuteDataTablePageParams(sql, limit, page, mainvalues.ToArray());
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            return dbHelper.ExecuteDataTablePageParams(sql, limit, page, mainvalues.ToArray());
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "分页查询表" + TableName + "记录出错");
                    throw ex;
                }
            }
        }

        #endregion

        #region GetTable 数据查询

        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <returns></returns>
        protected DataTable GetTableFromCache()
        {
            if (IsAddIntoCache)
            {
                object obj = CacheHelper.Get(CacheKey);
                if (obj != null)
                {
                    return (DataTable)obj;
                }
            }

            return null;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable()
        {
            DataTable dt = null;
            if (IsAddIntoCache)
            {
                dt = GetTableFromCache();
            }
            if (dt != null)
            {
                return dt;
            }
            dt = GetTable("1=1");
            if (dt != null && IsAddIntoCache)
            {
                CacheHelper.Add(CacheKey, dt, CacheTimeOut);
            }

            return dt;
        }

        /// <summary>
        /// 获取列表 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <param name="fieldValues">The field values.</param>
        /// <returns></returns>
        public DataTable GetTable(Dictionary<string, object> fieldValues)
        {
            List<object> values = new List<object>();

            var sbwhere = GetWhereByDic(fieldValues, ref values);

            #region 处理字典里面的返回字段和排序
            var selectfields = "*";
            if (fieldValues != null && fieldValues.ContainsKey("selectfields"))
            {
                selectfields = fieldValues["selectfields"].ToString();
                fieldValues.Remove("selectfields");
            }
            string orderby = "";
            if (fieldValues != null && fieldValues.ContainsKey(nameof(orderby)))
            {
                orderby = fieldValues[nameof(orderby)].ToString();
                fieldValues.Remove(nameof(orderby));
            }
            #endregion

            DataTable dt = null;
            if (IsAddIntoCache)
            {
                dt = GetTableFromCache();
            }
            if (dt != null)
            {
                return dt;
            }
            dt = GetTable(sbwhere, orderby, selectfields, values.ToArray());

            if (dt != null && IsAddIntoCache)
            {
                CacheHelper.Add(CacheKey, dt, CacheTimeOut);
            }

            return dt;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public DataTable GetTable(string where, params object[] values)
        {
            DataTable dt = null;
            string sql = "SELECT * FROM " + TableName + " WHERE " + where + " ORDER BY " + OrderbyFields;

            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                dt = dbHelper.ExecuteDataTableParams(sql, values);
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        dt = ExternalDbHelper.ExecuteDataTableParams(sql, values);
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            dt = dbHelper.ExecuteDataTableParams(sql, values);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "读取表" + TableName + "数据出错");
                }
            }
            return dt;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="orderFields">The order fields.</param>
        /// <param name="values">参数</param>
        /// <returns>
        /// DataTable.
        /// </returns>
        public DataTable GetTable(string where, string orderFields, params object[] values)
        {
            DataTable dt = null;
            string sql = "SELECT * FROM " + TableName + " WHERE " + where + " ORDER BY " + orderFields;

            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                dt = dbHelper.ExecuteDataTableParams(sql, values);
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        dt = ExternalDbHelper.ExecuteDataTableParams(sql, values);
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            dt = dbHelper.ExecuteDataTableParams(sql, values);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "读取表" + TableName + "数据出错");
                }
            }
            return dt;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="orderFields">The order fields.</param>
        /// <param name="selectFields">The select fields.</param>
        /// <param name="values">参数</param>
        /// <returns>
        /// DataTable.
        /// </returns>
        public DataTable GetTable(string where, string orderFields, string selectFields, params object[] values)
        {
            DataTable dt = null;
            string sql = "SELECT " + selectFields + " FROM " + TableName + " WHERE " + where + " ORDER BY " + (string.IsNullOrWhiteSpace(orderFields) ? OrderbyFields : orderFields);

            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                dt = dbHelper.ExecuteDataTableParams(sql, values);
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        dt = ExternalDbHelper.ExecuteDataTableParams(sql, values);
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            dt = dbHelper.ExecuteDataTableParams(sql, values);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "读取表" + TableName + "数据出错");
                }
            }
            return dt;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public DataTable GetTablePage(int pageSize, int pageIndex)
        {
            if (pageSize == 0 || pageIndex == 0)
            {
                return GetTable();
            }
            else
            {
                return GetTablePage(pageSize, pageIndex, "", "*");
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="orderFields">The order fields.</param>
        /// <returns>
        /// DataTable.
        /// </returns>
        public DataTable GetTablePage(int pageSize, int pageIndex, string orderFields)
        {
            return GetTablePage(pageSize, pageIndex, orderFields, "*");
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="orderFields">The order fields.</param>
        /// <param name="selectFields">The select fields.</param>
        /// <returns>
        /// DataTable.
        /// </returns>
        public DataTable GetTablePage(int pageSize, int pageIndex, string orderFields, string selectFields)
        {
            return GetTablePage(pageSize, pageIndex, "1=1", orderFields, selectFields);
        }

        /// <summary>
        /// 获取查询数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="fieldValues">The field values.</param>
        /// <returns>
        /// System.Data.DataTable.
        /// </returns>
        public DataTable GetDataTablePage<T>(int pageSize, int pageIndex, Dictionary<string, object> fieldValues) where T : new()
        {
            List<object> values = new List<object>();

            var sbwhere = GetWhereByDic<T>(fieldValues, ref values);

            #region 处理字典里面的返回字段和排序
            var selectfields = "*";
            if (fieldValues != null && fieldValues.ContainsKey("selectfields"))
            {
                selectfields = fieldValues["selectfields"].ToString();
                fieldValues.Remove("selectfields");
            }
            string orderby = "";
            if (fieldValues != null && fieldValues.ContainsKey(nameof(orderby)))
            {
                orderby = fieldValues[nameof(orderby)].ToString();
                fieldValues.Remove(nameof(orderby));
            }
            #endregion

            if (sbwhere.Length == 0)
            {
                return GetTablePage(pageSize, pageIndex, orderby, selectfields);
            }
            else
            {
                return GetTablePage(pageSize, pageIndex, sbwhere.ToString(), orderby, selectfields, values.ToArray());
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="orderFields">排序字段</param>
        /// <param name="values">参数</param>
        /// <returns>
        /// DataTable.
        /// </returns>
        public DataTable GetTablePage(int pageSize, int pageIndex, string where, string orderFields, params object[] values)
        {
            return GetTablePage(pageSize, pageIndex, where, orderFields, "*", values);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="orderfields">排序字段 不包含orderby</param>
        /// <param name="selectFields">查询返回的字段</param>
        /// <param name="values">参数</param>
        /// <returns>
        /// DataTable.
        /// </returns>
        public DataTable GetTablePage(int pageSize, int pageIndex, string where, string orderfields, string selectFields, params object[] values)
        {
            #region 处理OrderBy

            string orderby = "";
            if (!string.IsNullOrWhiteSpace(orderfields))
            {
                orderby = " Order By " + orderfields;
            }
            else
            {
                orderby = " ORDER BY " + OrderbyFields;
            }
            where += orderby;

            var sql = "SELECT " + selectFields + " FROM " + TableName + " WHERE " + where;
            #endregion

            if (_inTrans)
            {
                #region 事务执行
                var dbHelper = new DBHelper(DbConn);
                if (pageSize == 0 || pageIndex == 0)
                {
                    return dbHelper.ExecuteDataTable(sql, values);
                }
                else
                {
                    return dbHelper.ExecuteDataTablePageParams(sql, pageSize, pageIndex, values);
                }
                #endregion
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        #region 长连接
                        if (pageSize == 0 || pageIndex == 0)
                        {
                            return ExternalDbHelper.ExecuteDataTable(sql, values);
                        }
                        else
                        {
                            return ExternalDbHelper.ExecuteDataTablePageParams(sql, pageSize, pageIndex, values);
                        }
                        #endregion
                    }
                    else
                    {
                        #region 正常执行
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            if (pageSize == 0 || pageIndex == 0)
                            {
                                return dbHelper.ExecuteDataTable(sql, values);
                            }
                            else
                            {
                                return dbHelper.ExecuteDataTablePageParams(sql, pageSize, pageIndex, values);
                            }
                        }
                        #endregion

                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "分页查询表" + TableName + "数据出错");
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public DataTable GetTablePage(int pageSize, int pageIndex, string where, params object[] values)
        {
            return GetTablePage(pageSize, pageIndex, where, "", "*", values);
        }

        #endregion

        #region GetRow 数据查询
        /// <summary>
        /// 根据限定条件查询一条记录
        /// 2018-10-24 增加主键排序第一条 兼容查询出来数据多 默认取值问题
        /// </summary>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public DataRow GetRow(string where, params object[] values)
        {
            string sql = "SELECT * FROM " + TableName + " WHERE " + where;

            if (KeyField.IsNull() == false)
            {
                sql = sql + " order by " + KeyField + " desc ";
            }

            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                return dbHelper.ExecuteDataRowParams(sql, values);
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        return ExternalDbHelper.ExecuteDataRowParams(sql, values);
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            return dbHelper.ExecuteDataRowParams(sql, values);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "分页查询表" + TableName + "记录出错");
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 根据限定条件查询一条记录
        /// 2018-10-24 增加主键排序第一条 兼容查询出来数据多 默认取值问题
        /// </summary>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <returns></returns>
        public DataRow GetRow(Dictionary<string, object> where)
        {
            List<object> values = new List<object>();

            var sbwhere = GetWhereByDic(where, ref values);

            string sql = "SELECT * FROM " + TableName + " WHERE " + where;

            if (KeyField.IsNull() == false)
            {
                sql = sql + " order by " + KeyField + " desc ";
            }

            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                return dbHelper.ExecuteDataRowParams(sql, values.ToArray());
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        return ExternalDbHelper.ExecuteDataRowParams(sql, values.ToArray());
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            return dbHelper.ExecuteDataRowParams(sql, values.ToArray());
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "分页查询表" + TableName + "记录出错");
                    throw ex;
                }
            }
        }


        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataRow GetRowByKey(object keyValue)
        {
            string sql = "SELECT * FROM " + TableName + " WHERE " + KeyField + "=?";
            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                return dbHelper.ExecuteDataRow(sql, keyValue);
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        return ExternalDbHelper.ExecuteDataRow(sql, keyValue);
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            return dbHelper.ExecuteDataRow(sql, keyValue);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "读取表" + ItemName + "键为[" + keyValue + "]行出错");
                    throw ex;
                }
            }

        }
        #endregion

        #region GetList 数据查询
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public IList<T> GetList<T>(string where, params object[] values) where T : new()
        {
            return ToEntityList<T>(GetTable(where, values));
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="orderFields">The order fields.</param>
        /// <param name="values">参数</param>
        /// <returns>
        /// IList&lt;T&gt;.
        /// </returns>
        public IList<T> GetList<T>(string where, string orderFields, params object[] values) where T : new()
        {
            return ToEntityList<T>(GetTable(where, orderFields, values));
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        public IList<T> GetList<T>() where T : new()
        {
            return ToEntityList<T>(GetTable());
        }

        /// <summary>
        /// 查询数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldValues">The field values.</param>
        /// <returns>
        /// IList&lt;T&gt;.
        /// </returns>
        public IList<T> GetList<T>(Dictionary<string, object> fieldValues) where T : new()
        {
            List<object> values = new List<object>();

            var sbwhere = GetWhereByDic<T>(fieldValues, ref values);

            #region 处理字典里面的返回字段和排序
            var selectfields = "*";
            if (fieldValues != null && fieldValues.ContainsKey("selectfields"))
            {
                selectfields = fieldValues["selectfields"].ToString();
                fieldValues.Remove("selectfields");
            }
            string orderby = "";
            if (fieldValues != null && fieldValues.ContainsKey(nameof(orderby)))
            {
                orderby = fieldValues[nameof(orderby)].ToString();
                fieldValues.Remove(nameof(orderby));
            }
            #endregion

            if (sbwhere.Length == 0)
            {
                return ToEntityList<T>(GetTable("1=1", orderby, selectfields));
            }
            else
            {
                return ToEntityList<T>(GetTable(sbwhere, orderby, selectfields, values.ToArray()));
            }
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="orderFields">The order fields.</param>
        /// <returns>
        /// IList&lt;T&gt;.
        /// </returns>
        public IList<T> GetList<T>(string orderFields) where T : new()
        {
            return ToEntityList<T>(GetTable("1=1", orderFields));
        }

        /// <summary>
        /// 根据页面获取分页列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public IList<T> GetListPage<T>(int pageSize, int pageIndex) where T : new()
        {
            return ToEntityList<T>(GetTablePage(pageSize, pageIndex));
        }

        /// <summary>
        /// 根据页面获取分页列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="values">参数</param>
        /// <returns>
        /// IList&lt;T&gt;.
        /// </returns>
        public IList<T> GetListPage<T>(int pageSize, int pageIndex, string where, params object[] values) where T : new()
        {
            return ToEntityList<T>(GetTablePage(pageSize, pageIndex, where, values));
        }

        /// <summary>
        /// 根据页面获取分页列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="orderFields">The order fields.</param>
        /// <param name="selectFields">The select fields.</param>
        /// <param name="values">参数</param>
        /// <returns>
        /// IList&lt;T&gt;.
        /// </returns>
        public IList<T> GetListPage<T>(int pageSize, int pageIndex, string where, string orderFields, string selectFields, params object[] values) where T : new()
        {
            return ToEntityList<T>(GetTablePage(pageSize, pageIndex, where, orderFields, selectFields, values));
        }

        /// <summary>
        /// 获取数据列表 查询数据条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="limit">每页条数</param>
        /// <param name="page">当前页码 从1开始</param>
        /// <param name="fieldValues">Key Field|[b|s|e|bl|el|l] 分别表示 大于|小于|等于|前like|后like|like 不包含默认等于</param>
        /// <returns>
        /// IList&lt;T&gt;.
        /// </returns>
        public IList<T> GetListPage<T>(int limit, int page, Dictionary<string, object> fieldValues) where T : new()
        {
            List<object> values = new List<object>();

            var sbwhere = GetWhereByDic<T>(fieldValues, ref values);

            #region 处理字典里面的返回字段和排序
            var selectfields = "*";
            if (fieldValues != null && fieldValues.ContainsKey("selectfields"))
            {
                selectfields = fieldValues["selectfields"].ToString();
                fieldValues.Remove("selectfields");
            }
            string orderby = "";
            if (fieldValues != null && fieldValues.ContainsKey(nameof(orderby)))
            {
                orderby = fieldValues[nameof(orderby)].ToString();
                fieldValues.Remove(nameof(orderby));
            }
            #endregion

            if (sbwhere.Length == 0)
            {
                return ToEntityList<T>(GetTablePage(limit, page, orderby, selectfields));
            }
            else
            {
                return ToEntityList<T>(GetTablePage(limit, page, sbwhere.ToString(), orderby, selectfields, values.ToArray()));
            }
        }


        /// <summary>
        /// 查询数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="limit">当前页显示多少条</param>
        /// <param name="page">当前第几页 从1开始</param>
        /// <param name="fieldValues">查询条件</param>
        /// <param name="orderby">排序字段 orderby为"",则处理字典的值</param>
        /// <returns>
        /// IList&lt;T&gt;.
        /// </returns>
        public IList<T> GetListPage<T>(int limit, int page, Dictionary<string, object> fieldValues, string orderby) where T : new()
        {
            List<object> values = new List<object>();

            var sbwhere = GetWhereByDic<T>(fieldValues, ref values);

            #region 处理字典里面的返回字段和排序
            var selectfields = "*";
            if (fieldValues != null && fieldValues.ContainsKey("selectfields"))
            {
                selectfields = fieldValues["selectfields"].ToString();
                fieldValues.Remove("selectfields");
            }
            if (string.IsNullOrEmpty(orderby) && fieldValues != null && fieldValues.ContainsKey(nameof(orderby)))
            {
                orderby = fieldValues[nameof(orderby)].ToString();
                fieldValues.Remove(nameof(orderby));
            }
            #endregion

            if (sbwhere.Length == 0)
            {
                return ToEntityList<T>(GetTablePage(limit, page, orderby, selectfields));
            }
            else
            {
                return ToEntityList<T>(GetTablePage(limit, page, sbwhere.ToString(), orderby, selectfields, values.ToArray()));
            }
        }


        /// <summary>
        /// 查询数据 条件字典Key可以取固定值 selectfields orderby 框架将自动处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="limit">当前页显示条数</param>
        /// <param name="page">当前第几页 从1 开始</param>
        /// <param name="fieldValues">查询数据条件</param>
        /// <param name="orderby">排序字段 为""时处理字典值</param>
        /// <returns>
        /// FastJsonResult.
        /// </returns>
        public FastJsonResult<List<T>> GetJsonListPage<T>(int limit, int page, Dictionary<string, object> fieldValues, string orderby) where T : new()
        {
            var ret = new FastJsonResult<List<T>>();

            List<object> values = new List<object>();

            var sbwhere = GetWhereByDic<T>(fieldValues, ref values);

            try
            {
                #region 处理字典里面的返回字段和排序
                var selectfields = "*";
                if (fieldValues != null && fieldValues.ContainsKey("selectfields"))
                {
                    selectfields = fieldValues["selectfields"].ToString();
                    fieldValues.Remove("selectfields");
                }
                if (string.IsNullOrEmpty(orderby) && fieldValues != null && fieldValues.ContainsKey(nameof(orderby)))
                {
                    orderby = fieldValues[nameof(orderby)].ToString();
                    fieldValues.Remove(nameof(orderby));
                }
                #endregion

                if (sbwhere.Length == 0)
                {
                    ret.data = ToEntityList<T>(GetTablePage(limit, page, orderby, selectfields)).ToList();
                }
                else
                {
                    ret.data = ToEntityList<T>(GetTablePage(limit, page, sbwhere.ToString(), orderby, selectfields, values.ToArray())).ToList();
                }
                ret.count = GetCount<T>(fieldValues);

                ret.code = 0;

                ret.msg = "数据查询成功";
            }
            catch (Exception ex)
            {
                ret.code = 400;
                ret.msg = ex.Message;
            }
            return ret;
        }




        #endregion

        #region Get T 数据查询
        /// <summary>
        /// 根据限定条件查询一条记录 返回结果所有字段
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public T GetEntity<T>(string where, params object[] values) where T : new()
        {
            return ToEntity<T>(GetRow(where, values));
        }


        /// <summary>
        /// 根据限定条件查询一条记录 返回结果所有字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldValues">The field values.</param>
        /// <returns>
        /// T.
        /// </returns>
        public T GetEntity<T>(Dictionary<string, object> fieldValues) where T : new()
        {
            List<object> values = new List<object>();

            var sbwhere = GetWhereByDic<T>(fieldValues, ref values);

            return ToEntity<T>(GetRow(sbwhere, values.ToArray()));
        }

        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public T GetEntityByKey<T>(object keyValue) where T : new()
        {
            return ToEntity<T>(GetRowByKey(keyValue));
        }
        #endregion

        #region Get指定字段的Value值
        /// <summary>
        /// 根据键值获取记录某一字段值
        /// </summary>
        /// <param name="keyValue">The key value.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public object GetValueByKey(object keyValue, string fieldName)
        {
            DataRow dr = GetRowByKey(keyValue);
            if (dr != null)
            {
                return dr[fieldName];
            }

            return null;
        }

        /// <summary>
        /// 根据键值获取记录某一字段值
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="fieldName">要获取的字段名</param>
        /// <returns></returns>
        public string GetStringValueByKey(object keyValue, string fieldName)
        {
            DataRow dr = GetRowByKey(keyValue);
            if (dr != null)
            {
                return Convert.ToString(dr[fieldName]);
            }

            return string.Empty;
        }

        /// <summary>
        /// 根据键值获取记录某一字段值
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="fieldName">要获取的字段名</param>
        /// <returns></returns>
        public int GetIntValueByKey(object keyValue, string fieldName)
        {
            DataRow dr = GetRowByKey(keyValue);
            if (dr != null)
            {
                return Convert.ToInt32(dr[fieldName]);
            }

            return 0;
        }

        /// <summary>
        /// 根据键值获取记录某一字段值
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="fieldName">要获取的字段名</param>
        /// <returns></returns>
        public long GetLongValueByKey(object keyValue, string fieldName)
        {
            DataRow dr = GetRowByKey(keyValue);
            if (dr != null)
            {
                return Convert.ToInt64(dr[fieldName]);
            }

            return 0;
        }

        /// <summary>
        /// 根据键值获取记录某一字段值
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="fieldName">要获取的字段名</param>
        /// <returns></returns>
        public byte GetByteValueByKey(object keyValue, string fieldName)
        {
            DataRow dr = GetRowByKey(keyValue);
            if (dr != null)
            {
                return Convert.ToByte(dr[fieldName]);
            }

            return 0;
        }

        /// <summary>
        /// 根据键值获取记录某一字段值
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="fieldName">要获取的字段名</param>
        /// <returns></returns>
        public bool GetBoolValueByKey(object keyValue, string fieldName)
        {
            DataRow dr = GetRowByKey(keyValue);
            if (dr != null)
            {
                return Convert.ToInt32(dr[fieldName]) != 0;
            }

            return false;
        }
        #endregion

        #region GetCount读取数据

        /// <summary>
        /// 获取记录条数
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return GetCount("1=1");
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldValues">The field values.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public int GetCount<T>(Dictionary<string, object> fieldValues) where T : new()
        {
            List<object> values = new List<object>();

            var sbwhere = GetWhereByDic<T>(fieldValues, ref values);

            if (sbwhere.Length == 0)
            {
                return GetCount();
            }
            else
            {
                return GetCount(sbwhere, values.ToArray());
            }
        }


        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <param name="fieldValues">The field values.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public int GetCount(Dictionary<string, object> fieldValues)
        {
            List<object> values = new List<object>();

            var sbwhere = GetWhereByDic(fieldValues, ref values);

            if (sbwhere.Length == 0)
            {
                return GetCount();
            }
            else
            {
                return GetCount(sbwhere, values.ToArray());
            }
        }

        /// <summary>
        /// 获取记录条数
        /// </summary>
        /// <param name="where">where子句，不带关键字，参数用问号占位</param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public int GetCount(string where, params object[] values)
        {
            string sql = "SELECT COUNT(*) FROM " + TableName + " WHERE " + where;

            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                return Convert.ToInt32(dbHelper.ExecuteScalarIntParams(sql, values));
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        return Convert.ToInt32(ExternalDbHelper.ExecuteScalarIntParams(sql, values));
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            return Convert.ToInt32(dbHelper.ExecuteScalarIntParams(sql, values));
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "读取表" + TableName + "记录条数出错");
                }

            }

            return 0;
        }

        /// <summary>
        /// 根据In子查询查询数据 主dic包含 orderby 可以处理排序 值 字段 fields desc
        /// </summary>
        /// <typeparam name="T1">主表</typeparam>
        /// <param name="subTableName">子表表名</param>
        /// <param name="mainTableFields">主表 in 的字段名</param>
        /// <param name="subTableFields">子表查询字段</param>
        /// <param name="mainDicWhere">主表的Where条件</param>
        /// <param name="subDicWhere">子表的Where条件</param>
        /// <returns></returns>
        public int GetCountByInSelect<T1>(string subTableName, string mainTableFields, string subTableFields, Dictionary<string, object> mainDicWhere, Dictionary<string, object> subDicWhere) where T1 : new()
        {
            List<object> mainvalues = new List<object>();

            var orderby = "";
            if (mainDicWhere.ContainsKey("orderby"))
            {
                orderby = mainDicWhere["orderby"].ToString().Trim();

                mainDicWhere.Remove("orderby");
            }

            var mainwhere = GetWhereByDic<T1>(mainDicWhere, ref mainvalues);

            List<object> subvalues = new List<object>();
            var subwhere = GetWhereByDic(subDicWhere, ref subvalues);

            var sql = $"select count(1) from {TableName} Where {mainTableFields} in (select {subTableFields} from {subTableName} ";

            if (subwhere.IsNull() == false)
            {
                sql += $" where {subwhere} ";
            }
            sql += " )";

            if (mainwhere.IsNull() == false)
            {
                sql += $" and {mainwhere} ";
                subvalues.AddRange(mainvalues.ToArray());
            }

            #region 处理orderby排序
            if (!string.IsNullOrWhiteSpace(orderby))
            {
                sql += " order by " + orderby;
            }
            #endregion

            #region 查询数据
            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                return dbHelper.ExecuteScalarIntParams(sql, subvalues);
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        return ExternalDbHelper.ExecuteScalarIntParams(sql, subvalues.ToArray());
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            return dbHelper.ExecuteScalarIntParams(sql, subvalues.ToArray());
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "分页查询表" + TableName + "记录出错");
                    throw ex;
                }
            }
            #endregion
        }

        #endregion

        #endregion

        #region 验证数据唯一性

        /// <summary>
        /// 检测字段值是否重复
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="fieldName">重复验证的字段名</param>
        /// <param name="value">重复验证的字段值</param>
        /// <returns>
        ///   <c>true</c> if the specified key value is duplicate; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDuplicate(object keyValue, string fieldName, string value)
        {
            string sql = "SELECT COUNT(*) FROM " + TableName + " WHERE " + KeyField + "<>? AND " + fieldName + "=?";
            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                return Convert.ToInt32(dbHelper.ExecuteScalarIntParams(sql, keyValue, value)) > 0;
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        return Convert.ToInt32(ExternalDbHelper.ExecuteScalarIntParams(sql, keyValue, value)) > 0;
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            return Convert.ToInt32(dbHelper.ExecuteScalarIntParams(sql, keyValue, value)) > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "验证表" + TableName + "值重复性出错");
                    throw ex;
                }
            }
        }



        /// <summary>
        /// 检测字段值是否重复
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">重复验证的字段值</param>
        /// <returns>
        ///   <c>true</c> if the specified field is exist; otherwise, <c>false</c>.
        /// </returns>
        public bool IsExist(string field, string value)
        {
            string sql = "SELECT COUNT(*) FROM " + TableName + " WHERE " + field + "=?";
            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                return Convert.ToInt32(dbHelper.ExecuteScalarIntParams(sql, value)) > 0;
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        return Convert.ToInt32(ExternalDbHelper.ExecuteScalarIntParams(sql, value)) > 0;
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            return Convert.ToInt32(dbHelper.ExecuteScalarIntParams(sql, value)) > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "验证表" + TableName + "值重复性出错");
                    throw ex;
                }
            }

        }

        /// <summary>
        /// 检测字段值是否重复
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>
        ///   <c>true</c> if the specified where is exist; otherwise, <c>false</c>.
        /// </returns>
        public bool IsExist(Dictionary<string, object> where)
        {
            string sqlwhere = string.Empty;
            foreach (var item in where)
            {
                sqlwhere += (sqlwhere.Length == 0 ? " WHERE " : " AND ") + " " + item.Key + "=" + "'" + item.Value + "'";
            }
            string sql = "SELECT COUNT(*) FROM " + TableName + " " + sqlwhere;

            if (_inTrans)
            {
                var dbHelper = new DBHelper(DbConn);
                return Convert.ToInt32(dbHelper.ExecuteScalarInt(sql)) > 0;
            }
            else
            {
                try
                {
                    if (ExternalDbHelper != null)
                    {
                        return Convert.ToInt32(ExternalDbHelper.ExecuteScalarInt(sql)) > 0;
                    }
                    else
                    {
                        using (DBHelper dbHelper = new DBHelper(DatabaseTypeValue, DatabaseConnValueRead))
                        {
                            return Convert.ToInt32(dbHelper.ExecuteScalarInt(sql)) > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex, "验证表" + TableName + "值重复性出错");
                    throw ex;
                }
            }
        }

        #endregion

        #region 类型转换

        /// <summary>
        /// 根据模型反射得到字典
        /// </summary>
        /// <typeparam name="T">模型</typeparam>
        /// <param name="item">模型实例</param>
        /// <returns>
        /// 返回字典,Key:string Value:object
        /// </returns>
        public Dictionary<string, object> ToDictionary<T>(T item)
        {
            Dictionary<string, object> retdic = new Dictionary<string, object>();

            try
            {
                foreach (var p in item.GetType().GetProperties())
                {
                    var v = p.GetValue(item, null);
                    if (v == null && p.PropertyType == typeof(string))
                    {
                        v = "";
                    }
                    else if (v == null && p.PropertyType == typeof(int))
                    {
                        v = 0;
                    }
                    retdic.Add(p.Name, v);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex, "验证表" + TableName + "值重复性出错");
                throw ex;
            }
            return retdic;
        }

        /// <summary>
        /// 根据模型 反射得到字段,从DataTable里面转换得到ListModel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public IList<T> ToEntityList<T>(DataTable dt) where T : new()
        {
            //return ToEntity<T>(dt);

            if (dt == null)
            {
                return null;
            }

            IList<T> list = new List<T>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToEntity<T>(dr));
            }

            return list;
        }

        /// <summary>
        /// 根据模型 反射得到字段,从DataRow反射得到实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="dr">一行记录</param>
        /// <returns></returns>
        public T ToEntity<T>(DataRow dr) where T : new()
        {
            if (dr == null)
            {
                return default(T);
            }

            T t = new T();

            try
            {
                foreach (var pi in t.GetType().GetProperties())
                {
                    if (!pi.CanWrite)
                    {
                        continue;
                    }

                    if (!dr.Table.Columns.Contains(pi.Name))
                    {
                        continue;
                    }

                    object value = dr[pi.Name];
                    if (value != DBNull.Value)
                    {
                        //pi.SetValue(t, value, null);
                        pi.SetValue(t, ConvertExtension.ConvertHelper(value, pi.PropertyType), null);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex, "DataRow转换为：" + TableName + " Entity数据出错");
                throw ex;
            }
            return t;
        }

        /// <summary>
        /// 根据模型 反射得到字段,从DataRow反射得到实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="dt">The dt.</param>
        /// <returns>
        /// T.
        /// </returns>
        public T ToEntity<T>(DataTable dt) where T : new()
        {
            var t = new T();
            if (dt.Rows.Count <= 0)
            {
                return t;
            }

            try
            {
                foreach (DataColumn column in dt.Columns)
                {
                    // 当前列名&属性名
                    string columnName = column.ColumnName;
                    PropertyInfo pro = typeof(T).GetProperty(columnName);
                    if (pro == null)
                    {
                        continue;
                    }

                    if (!pro.CanWrite)
                    {
                        continue;
                    }

                    pro.SetValue(t, ConvertExtension.ConvertHelper(dt.Rows[0][columnName], pro.PropertyType), null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return t;
        }


        /// <summary>
        /// 字典转换为Sql语句条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldValues">The field values.</param>
        /// <param name="values">The values.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        private string GetWhereByDic<T>(Dictionary<string, object> fieldValues, ref List<object> values) where T : new()
        {
            return SqlHelper.GetSqlByDic<T>(fieldValues, out values);
        }

        /// <summary>
        /// 字典转换为Sql语句条件
        /// </summary>
        /// <param name="fieldValues">The field values.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        private string GetWhereByDic(Dictionary<string, object> fieldValues, ref List<object> values)
        {
            return SqlHelper.GetSqlByDic(fieldValues, out values);
        }

        #endregion

        #region 动态表查询

        /// <summary>
        /// Gets the table name by dic.
        /// </summary>
        /// <param name="tablePrefix">The table prefix.</param>
        /// <param name="fieldValues">The field values.</param>
        /// <returns>
        /// List&lt;System.String&gt;.
        /// </returns>
        private List<string> GetTableNameByDic(string tablePrefix, Dictionary<string, object> fieldValues)
        {
            DateTime timeBegin = DateTime.Now;
            DateTime timeEnd = DateTime.Now;

            fieldValues = fieldValues.ToDictionary(p => p.Key.ToLower(), k => k.Value);
            //查询字段是否包含开始时间
            bool diciscontactbegin = false;
            var dic = new Dictionary<string, object>();
            foreach (var item in fieldValues)
            {
                var key = item.Key.ToLower();
                if (key.StartsWith("createtime|b"))
                {
                    timeBegin = DateTime.Parse(item.Value.ToString());
                    diciscontactbegin = true;
                }
                else if (key.StartsWith("createtime|s"))
                {
                    timeEnd = DateTime.Parse(item.Value.ToString());
                }
            }

            #region 兼容业务Bug进行处理 orderid查询动态表问题
            //业务传了orderid没有传createtime|b createtime|s 默认只能查当月数据
            if (!diciscontactbegin)
            {
                if (fieldValues.ContainsKey("orderid"))
                {
                    var orderid = fieldValues["orderid"].ToString();
                    return new List<string>() { tablePrefix + "_" + orderid.Substring(0, 6) };
                }
            }

            #endregion

            using (var db = new DBHelper(true))
            {
                return db.GetTableNameByTime(tablePrefix, timeBegin, timeEnd);
            }
        }

        /// <summary>
        /// 验证查询时间 用于动态表查询数据的时候获取表名 时间的键值为 CreateTime|b 大于 CreateTime|s 小于
        /// </summary>
        /// <param name="dic">字典列表</param>
        /// <returns>
        ///   <c>true</c> if XXXX, <c>false</c> otherwise.
        /// </returns>
        /// <exception cref="System.Exception">查询条件未包含相关时间字段CreateTime和逻辑运算符</exception>
        private bool ValidQueryTime(Dictionary<string, object> dic)
        {
            if (dic.ContainsKey("CreateTime|b") && dic.ContainsKey("CreateTime|s"))
            {
                return true;
            }
            else if (dic.ContainsKey("CreateTime|b") && dic.ContainsKey("CreateTime|se"))
            {
                return true;
            }
            else if (dic.ContainsKey("CreateTime|be") && dic.ContainsKey("CreateTime|s"))
            {
                return true;
            }
            else if (dic.ContainsKey("CreateTime|be") && dic.ContainsKey("CreateTime|se"))
            {
                return true;
            }
            else
            {
                throw new Exception("查询条件未包含相关时间字段CreateTime和逻辑运算符");
            }
        }

        /// <summary>
        /// Gets the list page with dynamic.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tablePrefix">The table prefix.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="page">The page.</param>
        /// <param name="fieldValues">The field values.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns>
        /// System.Collections.Generic.IList&lt;T&gt;.
        /// </returns>
        public IList<T> GetListPageWithDynamic<T>(string tablePrefix, int limit, int page, Dictionary<string, object> fieldValues, string orderBy) where T : new()
        {
            var retlist = new List<T>();

            var tableNameLst = GetTableNameByDic(tablePrefix, fieldValues);

            if (tableNameLst.Count() == 0)
            {
                return retlist;
            }

            #region 获取字典里面的返回字段内容
            var selectfields = "*";
            if (fieldValues != null && fieldValues.ContainsKey("selectfields"))
            {
                selectfields = fieldValues["selectfields"].ToString();
                fieldValues.Remove("selectfields");
            }
            #endregion


            List<object> values = new List<object>();

            var sbwhere = GetWhereByDic<T>(fieldValues, ref values);

            #region 数据查询
            int rowCnt = 0;
            using (var db = new DBHelper(true))
            {
                foreach (var item in tableNameLst)
                {
                    if (retlist.Count() < limit)
                    {
                        var sql = "SELECT " + selectfields + " FROM " + item + " WHERE " + sbwhere + (string.IsNullOrEmpty(orderBy) ? (" ORDER BY " + OrderbyFields) : (" ORDER BY " + orderBy));

                        var offset = (page - 1) * limit - rowCnt;

                        var dt = db.ExecuteDataTablePageParamsWithLimit(sql, limit, offset < 0 ? 0 : offset, values.ToArray());

                        retlist.AddRange(ToEntityList<T>(dt));
                    }
                    else
                    {
                        break;
                    }
                    rowCnt += db.ExecuteScalarIntParams("SELECT COUNT(*) FROM " + item + " WHERE " + sbwhere, values.ToArray());
                }
            }
            retlist = retlist.Take(limit).ToList();
            #endregion

            return retlist;
        }

        /// <summary>
        /// 获取动态表数据 条件必须包含查询时间CreateTime和逻辑关系
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="tablePrefix">表前缀</param>
        /// <param name="limit">条数</param>
        /// <param name="page">当前页码</param>
        /// <param name="fieldValues">查询条件</param>
        /// <param name="orderBy">排序字段</param>
        /// <returns>
        /// FastDev.Common.Code.FastJsonResult&lt;System.Collections.Generic.List&lt;T&gt;&gt;.
        /// </returns>
        public FastJsonResult<List<T>> GetJsonListPageByDynamic<T>(string tablePrefix, int limit, int page, Dictionary<string, object> fieldValues, string orderBy) where T : new()
        {
            #region 验证条件
            var ret = new FastJsonResult<List<T>>() { data = new List<T>() };

            var tableNameLst = GetTableNameByDic(tablePrefix, fieldValues);

            if (tableNameLst.Count() == 0)
            {
                return ret;
            }
            #endregion

            #region 解析Dic条件为字符串
            List<object> values = new List<object>();
            var sbwhere = GetWhereByDic<T>(fieldValues, ref values);
            #endregion

            #region 获取字典里面的返回字段内容
            var selectfields = "*";
            if (fieldValues != null && fieldValues.ContainsKey("selectfields"))
            {
                selectfields = fieldValues["selectfields"].ToString();
                fieldValues.Remove("selectfields");
            }
            #endregion

            try
            {
                #region 数据查询
                int rowCnt = 0;
                using (var db = new DBHelper(true))
                {
                    foreach (var item in tableNameLst)
                    {
                        if (ret.data.Count() < limit)
                        {
                            var sql = "SELECT " + selectfields + " FROM " + item + " WHERE " + sbwhere + (string.IsNullOrEmpty(orderBy) ? (" ORDER BY " + OrderbyFields) : (" ORDER BY " + orderBy));

                            var offset = (page - 1) * limit - rowCnt;

                            var dt = db.ExecuteDataTablePageParamsWithLimit(sql, limit, offset < 0 ? 0 : offset, values.ToArray());

                            ret.data.AddRange(ToEntityList<T>(dt));
                        }
                        rowCnt += db.ExecuteScalarIntParams("SELECT COUNT(*) FROM " + item + " WHERE " + sbwhere, values.ToArray());
                    }
                }
                ret.count = rowCnt;
                ret.data = ret.data.Take(limit).ToList();
                ret.code = 0;
                ret.msg = "数据获取成功";
                #endregion
            }
            catch (Exception ex)
            {
                ret.code = 400;
                ret.msg = ex.Message;
                ret.data = null;
            }
            return ret;
        }


        /// <summary>
        /// 读取动态表Count
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="tablePrefix">表前缀</param>
        /// <param name="fieldValues">查询条件</param>
        /// <returns></returns>
        public Result<int> CountByDynamic<T>(string tablePrefix, Dictionary<string, object> fieldValues) where T : new()
        {
            #region 验证条件

            var tableNameLst = GetTableNameByDic(tablePrefix, fieldValues);

            if (tableNameLst.Count() == 0)
            {
                return new Result<int>() { Data = 0, Message = "时间范围内无数据表" };
            }
            #endregion

            #region 解析Dic条件为字符串
            List<object> values = new List<object>();
            var sbwhere = GetWhereByDic<T>(fieldValues, ref values);
            #endregion

            try
            {
                #region 数据查询
                int rowCnt = 0;
                using (var db = new DBHelper(true))
                {
                    foreach (var item in tableNameLst)
                    {
                        rowCnt += db.ExecuteScalarIntParams("SELECT COUNT(*) FROM " + item + " WHERE " + sbwhere, values.ToArray());
                    }
                }
                return new Result<int>() { IsSucceed = true, Data = rowCnt, Message = "查询成功" };
                #endregion
            }
            catch (Exception ex)
            {
                return new Result<int>() { Data = 0, Message = ex.Message };
            }
        }

        #endregion

        #region 其他逻辑 Base内部已修改成调用 SqlHelper,兼容其他 Repository 使用了的,所以保留下来
        /// <summary>
        /// Gets the check logic.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        public static string[] GetCheckLogic(string fieldName)
        {
            return SqlHelper.GetLogic(fieldName);
            //if (fieldName.IndexOf('|') > 0)
            //{
            //    var ary = fieldName.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            //    if (ary.Length == 2)
            //    {
            //        //b|s|e|bl|el|l|ne|i
            //        switch (ary[1].ToLower())
            //        {
            //            case "b":
            //                ary[1] = ">";
            //                break;
            //            case "be":
            //                ary[1] = ">=";
            //                break;
            //            case "s":
            //                ary[1] = "<";
            //                break;
            //            case "se":
            //                ary[1] = "<=";
            //                break;
            //            case "e":
            //                ary[1] = "=";
            //                break;
            //            case "bl":
            //                ary[1] = "like";
            //                break;
            //            case "el":
            //                ary[1] = "like";
            //                break;
            //            case "l":
            //                ary[1] = "like";
            //                break;
            //            case "ne":
            //                ary[1] = "<>";
            //                break;
            //            case "i":
            //                ary[1] = "in";
            //                break;
            //        }
            //        return ary;
            //    }
            //}
            //return new string[] { fieldName, "=" };
        }
        #endregion
    }
}