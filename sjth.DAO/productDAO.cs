using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.DAO
{
    public class productDAO : BaseDAO<product>
    {
        public List<product> productList()
        {
            string where = " del = 1 order by datatimes DESC";
            return GetAll(where);
        }
        public List<product> shang(int id)
        {
            string where = " del = 1 and id <"+id+" order by id DESC";
            return GetAll(where);
        }
        public List<product> xia(int id)
        {
            string where = " del = 1 and id > " + id + " order by id ASC";
            return GetAll(where);
        }
    }
}
