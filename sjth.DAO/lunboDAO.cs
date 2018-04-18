using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.DAO
{
    public class lunboDAO :BaseDAO<lunbo>
    {

        public List<lunbo> allList(int? type = 0)
        {
            string where = " del = 1";
            if (type != 0)
            {
                where += " and type =" + type;
            }
            return GetAll(where);
        }
    }
}
