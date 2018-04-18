using sjth.DAO;
using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.BLL
{
    public class lunboBLL :Base2DAOManager<lunbo>
    {
        private lunboDAO dao = new lunboDAO();
        public List<lunbo> allList(int? type = 0)
        {
            return dao.allList(type);
        }
    }
}
