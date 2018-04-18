using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.DAO
{
    public class newstypeDAO : BaseDAO<newstype>
    {
        /// <summary>
        /// 查询所有类别
        /// </summary>
        /// <returns></returns>
        public List<newstype> GetAlls()
        {
            string where = " del = 1 ";
            return GetAll(where);
        }
    }
}
