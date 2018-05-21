using sjth.Core;
using sjth.DAO;
using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yhkj.Core;

namespace sjth.BLL
{
    public class Base2DAOManager<T> where T : BaseEntity, new()
    {
        BaseDAO<T> _iBaseManager = new BaseDAO<T>();
       
        private const string NEWS_ID = "{1}.Id.{0}";
        private const string NEWS_PAGE = "{3}.Page.{0}.{1}.{2}";
        private const string NEWS_CATEGORY_ALL = "{0}.All";
        /// <summary>
        /// 插入实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>受影响的行数</returns>
        public int Insert(T entity)
        {
            
            return _iBaseManager.Insert(entity);
        }

        /// <summary>
        /// 插入实体，返回插入成功后自动增长Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="insertedId">成功后自动增长Id</param>
        /// <param name="entity"></param>
        public void Insert(out int insertedId, T entity)
        {
          
            _iBaseManager.Insert(out insertedId, entity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>受影响的行数</returns>
        public int Delete(T entity)
        {
          
            return _iBaseManager.Delete(entity);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>受影响的行数</returns>
        public int Update(T entity)
        {
          
            return _iBaseManager.Update(entity);
        }

        /// <summary>
        /// 根据Id获取对应的实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">实体Id</param>
        /// <returns></returns>
        public T GetById(int id)
        {
           
                return _iBaseManager.GetById(id);
           
        }

        /// <summary>
        /// 获取所有的实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetAll()
        {
           
                return _iBaseManager.GetAll();
           
        }
        /// <summary>
        /// 获取所有的实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetAll(string where )
        {

            return _iBaseManager.GetAll(where);

        }
        /// <summary>
        /// 根基条件获取钱10行数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetTop10(string count, string where)
        {

            return _iBaseManager.GetTop10( count, where);

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
        public List<T> GetPage(out int count,int pageNumber = 1, int pageSize = 20, string condition = null, object param = null, SortParameters sort = null)
        {
            
            T t = new T();
            string key = string.Format(NEWS_PAGE, pageNumber, pageSize, condition, t.GetType().Name);
            int totalCount;
                var list = _iBaseManager.GetPage(out totalCount, pageNumber, pageSize, condition, param, sort);
                count = totalCount;
                return new PageModel<T>(pageSize, pageNumber, totalCount, list);
            


        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public int GetCount()
        {
            return _iBaseManager.GetCount();
        }
    }
}
