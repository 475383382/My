using sjth.DAO;
using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.BLL
{
    public class videoBLL :Base2DAOManager<video>
    {
        private videoDAO dao = new videoDAO();
        public List<video> allList()
        {
            return dao.allList();
        }
    }
}
