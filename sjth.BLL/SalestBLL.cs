using sjth.DAO;
using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.BLL
{
    public class SalestBLL : Base2DAOManager<Salest>
    {
        private SalestDAO dao = new SalestDAO();
        public List<Salest> allList()
        {
            return dao.allList();
        }
           public List<Salest> allnian(string field)
        {
            return dao.allnian(field);
        }
    
    }
}
