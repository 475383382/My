using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.Core.Data
{
    /// <summary>
    /// 数据库连接工厂
    /// </summary>
    public class DbConnectionFactory
    {
        private DbConnectionFactory() { }

        /// <summary>
        /// 打开一个数据库连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection OpenConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return new SqlConnection(connectionString);
        }

        public static IDbConnection OpenConnection1()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["StatisticsDB"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}
