using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.DAO
{
    public class AuthorityDAO : BaseDAO<Authority>
    {
        public List<Authority> getAll()
       {
           string where = " del = 1";
           return GetAll(where);
       }
      
    }
}
