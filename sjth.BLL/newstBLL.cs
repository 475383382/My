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
        /// <summary>
        /// 根据时间查询上一条
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public newst GetShangYiPianByDate(string dateTime) {
            return dao.GetShangYiPianByDate(dateTime);
        }
        /// <summary>
        /// 根据时间查询下一条
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public newst GetXiaYiPian(string dateTime)
        {
            return dao.GetXiaYiPian(dateTime);
        }
    }
}
