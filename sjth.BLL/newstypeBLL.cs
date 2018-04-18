using sjth.DAO;
using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.BLL
{
    public class newstypeBLL : Base2DAOManager<newstype>
    {
        private newstypeDAO dao = new newstypeDAO();
        /// <summary>
        /// 查询类别
        /// </summary>
        /// <returns></returns>
        public List<newstype> getall()
        {
           return dao.GetAlls();
        }
    }
}
