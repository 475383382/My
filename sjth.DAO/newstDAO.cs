using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.DAO
{
    public class newstDAO : BaseDAO<newst>
    {
        public List<newst> GetAlls()
        {
            string where = " del = 1 order by creationtime DESC";
            return GetAll(where);
        }
    }
}
