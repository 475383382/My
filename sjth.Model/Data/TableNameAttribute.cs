using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.Core.Data
{
    /// <summary>
    /// 数据库表名标识特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableNameAttribute : Attribute
    {
        public string TableName { get; set; }

        public TableNameAttribute(string tableName)
        {
            this.TableName = tableName;
        }
    }
}
