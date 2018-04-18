using sjth.DAO;
using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.BLL
{
    public class productBLL : Base2DAOManager<product>
    {
        private productDAO dao = new productDAO();

        public List<product> productList()
        {
            return dao.productList();
        }
        public List<product> shang(int id)
        {
            return dao.shang(id);
        }
        public List<product> xia(int id)
        {
            return dao.xia(id);
        }
    }
}
