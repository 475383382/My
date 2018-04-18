using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.DAO
{
    public class SalestDAO : BaseDAO<Salest>
    {
        public List<Salest> allList()
        {
            string where = " del = 1";

            return GetAll(where);
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="field">排序字段asc</param>
        /// <returns></returns>
        public List<Salest> allnian(string field)
        {
            string where = " del = 1 ORDER BY " + field + " ASC";

            return GetAll(where);
        }
    }
}
