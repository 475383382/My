using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.DAO
{
    public class videoDAO : BaseDAO<video>
    {
        public List<video> allList(){
            string where = " del = 1 order by datatimes DESC";

            return GetAll(where);
        }
    }
}
