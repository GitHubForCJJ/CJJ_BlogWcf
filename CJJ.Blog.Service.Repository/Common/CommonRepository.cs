using FastDev.Common.Extension;
using FastDev.DbBase;
using FastDev.DBFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJJ.Blog.Service.Repository.Comm
{
    public class CommonRepository : BaseQuery, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonRepository" /> class.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="keyField">The key field.</param>
        public CommonRepository(string tableName, string keyField="KID")
        {
            this.IsAddIntoCache = true;
            this.TableName = tableName;
            this.OrderbyFields = keyField + " DESC";
            this.KeyField = keyField;
        }

        public void Dispose()
        {

        }
    }
}
