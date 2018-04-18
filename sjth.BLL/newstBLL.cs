using sjth.DAO;
using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.BLL
{
    public class newstBLL : Base2DAOManager<newst>
    {
        private newstDAO dao = new newstDAO();
        /// <summary>
        /// 查询类别
        /// </summary>
        /// <returns></returns>
        public List<newst> getall()
        {
            return dao.GetAlls();
        }
    }
}
