using sjth.Common;
using sjth.Core;
using sjth.Core.Data;
using sjth.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace sjth.DAO
{
    public partial class BaseDAO <T> where T : BaseEntity, new()
    {
        protected LogHelper Logger = new LogHelper();
        /// <summary>
        /// 插入实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>受影响的行数</returns>
        public int Insert(T entity)
        {
            string sql = string.Empty;
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                sql = string.Format("INSERT INTO [{0}]({1}) VALUES({2})",
                   TableName(entity),
                   FieldNames(entity),
                   FieldNames(entity, true));

                return Run(conn => conn.Execute(sql, entity));
            }
            catch (Exception e)
            {
                Logger.writeInfos("-----------public int Insert(T entity)-----------\r\n" + sql + "\r\n" + e.Message + "\r\n");

                return 0;
            }
        }

        /// <summary>
        /// 插入实体，返回插入成功后自动增长Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="insertedId">成功后自动增长Id</param>
        /// <param name="entity"></param>
        public void Insert(out int insertedId, T entity)
        {
            string sql = string.Empty;
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                sql = string.Format("INSERT INTO [{0}]({1}) VALUES({2}) SELECT @@IDENTITY",
                    TableName(entity),
                    FieldNames(entity),
                    FieldNames(entity, true));

                insertedId = Run(conn =>
                {
                    return conn.ExecuteScalar<int>(sql, entity);
                });
            }
            catch (Exception e)
            {
                insertedId = 0;
                Logger.writeInfos("----------- public void Insert(out int insertedId, T entity)-----------\r\n" + sql + "\r\n" + e.Message + "\r\n");
            }

        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>受影响的行数</returns>
        public int Delete(T entity)
        {
            string sql = string.Empty;
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                sql = string.Format("DELETE FROM [{0}] WHERE id = @id", TableName(entity));

                return Run(conn => conn.Execute(sql, new { id = entity.id }));
            }
            catch (Exception e)
            {

                Logger.writeInfos("-----------public int Delete(T entity)-----------\r\n" + sql + "\r\n" + e.Message + "\r\n");
                return 0;
            }
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>受影响的行数</returns>
        public int Update(T entity)
        {
            string sql = string.Empty;
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                sql = string.Format("UPDATE [{0}] SET {1} WHERE Id = @Id", TableName(entity), UpdateSetString(entity));

                return Run(conn => conn.Execute(sql, entity));
            }
            catch (Exception e)
            {

                Logger.writeInfos("-----------public int Update(T entity)-----------\r\n" + sql + "\r\n" + e.Message + "\r\n");
                return 0;
            }
        }

        /// <summary>
        /// 根据Id获取对应的实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">实体Id</param>
        /// <returns></returns>
        public T GetById(int id)
        {
            string sql = string.Empty;
            try
            {
                sql = string.Format("SELECT Id,{1} FROM [{0}] WHERE Id = @id",
               TableName<T>(),
               FieldNames(typeof(T)));

                return Run(conn => conn.Query<T>(sql, new { id = id }).FirstOrDefault());
            }
            catch (Exception e)
            {

                Logger.writeInfos("-----------public T GetById(int id)-----------\r\n" + sql + "\r\n" + e.Message + "\r\n");
                return null;
            }
        }
        /// <summary>
        /// 根据where条件，查出符合条件第一行数据
        /// </summary>
        /// <param name="where">where条件，两端不用带空格，比如：name='lmh'</param>
        /// <returns>符合条件的第一条数据</returns>
        public T FindOne(string where)
        {
            string strSql = string.Empty;
            try
            {
                strSql = string.Format("SELECT id,{1} FROM [{0}] ",
                TableName<T>(),
                FieldNames(typeof(T)));
                if (!string.IsNullOrEmpty(where))
                    strSql = strSql + " where " + where;
                return Run(conn => conn.Query<T>(strSql).FirstOrDefault());
            }
            catch (Exception e)
            {

                Logger.writeInfos("-----------public T FindOne(string where)-----------\r\n" + strSql + "\r\n" + e.Message + "\r\n");
                return null;
            }
        }
        /// <summary>
        /// 获取所有的实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetAll()
        {
            string sql = string.Empty;
            try
            {
                sql = string.Format("SELECT id,{1} FROM [{0}]",
               TableName<T>(),
               FieldNames(typeof(T)));

                return Run(conn => conn.Query<T>(sql).ToList());
            }
            catch (Exception e)
            {

                Logger.writeInfos("-----------public List<T> GetAll()-----------\r\n" + sql + "\r\n" + e.Message + "\r\n");
                return null;
            }

        }

        /// <summary>
        /// 获取所有的实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">where条件，两端不用带空格，比如：name='lmh'</param>
        /// <returns></returns>
        public List<T> GetAll(string where)
        {
            string sql = string.Empty;
            try
            {
                sql = string.Format("SELECT id,{1} FROM [{0}]",
               TableName<T>(),
               FieldNames(typeof(T)));
                if (!string.IsNullOrEmpty(where))
                    sql = sql + " where " + where;
                return Run(conn => conn.Query<T>(sql).ToList());
            }
            catch (Exception e)
            {

                Logger.writeInfos("-----------public List<T> GetAll()-----------\r\n" + sql + "\r\n" + e.Message + "\r\n");
                return null;
            }

        }
        /// <summary>
        /// 根据sql返回ilist
        /// </summary>
        /// <param name="sql">sql 语名</param>
        /// <returns></returns>
        public IList<W> ConvertToListBySql<W>(string sql) where W : class,new()
        {
            try
            {
                return Run(conn => conn.Query<W>(sql).ToList());
            }
            catch (Exception e)
            {

                Logger.writeInfos("-----------public IList<W> ConvertToListBySql<W>(string sql) where W : class,new() -----------\r\n" + sql + "\r\n" + e.Message + "\r\n");
                return null;
            }

        }

        /// <summary>
        /// 根据sql返回ilist
        /// </summary>
        /// <param name="sql">sql 语名</param>
        /// <returns></returns>
        public IList<T> ConvertToListBySql(string sql)
        {
            try
            {
                return Run(conn => conn.Query<T>(sql).ToList());
            }
            catch (Exception e)
            {

                Logger.writeInfos("-----------IList<T> ConvertToListBySql(string sql) -----------\r\n" + sql + "\r\n" + e.Message + "\r\n");
                return null;
            }

        }

        /// <summary>
        ///  获取简单分页数据，默认按照Id升序排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="totalCount">总记录数</param>
        /// <param name="pageNumber">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="condition">查询条件</param>
        /// <param name="param">查询参数</param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public List<T> GetPage(out int totalCount, int pageNumber = 1, int pageSize = 20, string condition = null, object param = null, SortParameters sort = null)
        {
            string sql4list = string.Empty;
            try
            {
                string subsql4sort = "ORDER BY [id]";
                if (sort != null && sort.Count > 0)
                {
                    List<string> list = new List<string>();
                    foreach (var item in sort)
                        list.Add(string.Format(" [{0}] {1}", item.Field, item.Direction == SortDirection.ASC ? "ASC" : "DESC"));

                    subsql4sort = string.Format("ORDER BY {0}", string.Join(",", list));
                }

                sql4list = @"   SELECT id,{0} 
                                FROM (
	                                SELECT ROW_NUMBER() OVER({5}) AS ROW_NUM,{0},id FROM [{1}] WHERE 1 = 1 {4}
                                )AS TEMP
                                WHERE TEMP.ROW_NUM BETWEEN {2} AND {3}";
                string sql4count = string.Format("SELECT COUNT(1) FROM {0} WHERE 1 = 1 {1}", TableName<T>(), condition);

                int beginIndex = (pageNumber - 1) * pageSize + 1;
                int endIndex = pageNumber * pageSize;

                sql4list = string.Format(sql4list, FieldNames(typeof(T)), TableName<T>(), beginIndex, endIndex, condition, subsql4sort);
                totalCount = Run(conn => Convert.ToInt32(conn.ExecuteScalar(sql4count, param)));
                return Run(conn => conn.Query<T>(sql4list, param).ToList());
            }
            catch (Exception e)
            {
                Logger.writeInfos("-----------public List<T> GetPage(out int totalCount, int pageNumber = 1, int pageSize = 20, string condition = null, object param = null, SortParameters sort = null)-----------\r\n" + sql4list + "\r\n" + e.Message + "\r\n");
                totalCount = 0;
                return null;
            }
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public int GetCount()
        {
            string sql = string.Empty;
            try
            {
                sql = string.Format("SELECT COUNT(1) FROM [{0}]", TableName<T>());

                return Run(conn => conn.ExecuteScalar<int>(sql));
            }
            catch (Exception e)
            {
                Logger.writeInfos("----------- public int GetCount()-----------\r\n" + sql + "\r\n" + e.Message + "\r\n");

                return 0;
            }

        }

        #region Utilities Methods

        private string FieldNames(BaseEntity entity, bool isParameter = false)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var type = entity.GetType();
            return FieldNames(type, isParameter);
        }

        private string FieldNames(Type type, bool isParameter = false)
        {
            List<string> names = new List<string>();
            var props = type.GetProperties();
            foreach (var item in props)
            {
                if (item.Name == "id") continue;
                names.Add(isParameter ? "@" + item.Name : "[" + item.Name + "]");
            }

            return string.Join(",", names);
        }

        private string UpdateSetString(BaseEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var type = entity.GetType();
            List<string> groups = new List<string>();
            var props = type.GetProperties();
            foreach (var item in props)
            {
                if (item.Name == "id") continue;
                groups.Add(string.Format("[{0}]=@{0}", item.Name));
            }

            return string.Join(",", groups);
        }

        private string TableName(BaseEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            return TableName(entity.GetType());
        }

        private string TableName<T>()
        {
            return TableName(typeof(T));
        }

        private string TableName(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            var attributes = type.GetCustomAttributes(typeof(TableNameAttribute), false);
            if (attributes.Length < 1)
                return type.Name;

            var tableNameAttribute = attributes[0] as TableNameAttribute;
            if (tableNameAttribute != null)
                return tableNameAttribute.TableName;

            return type.Name;
        }

        private T Run<T>(Func<IDbConnection, T> acquire)
        {
            using (var conn = DbConnectionFactory.OpenConnection())
            {
                return acquire(conn);
            }
        }

        #endregion
    }
}
