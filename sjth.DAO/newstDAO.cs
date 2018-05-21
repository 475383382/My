using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.DAO
{
    public class newstDAO : BaseDAO<newst>
    {
        /// <summary>
        /// 查询10条数据
        /// </summary>
        /// <returns></returns>
        public IList<newst> top10()
        {

            return ConvertToListBySql<newst>("select top 10 * from   newst where del =1");
        }
        public List<newst> GetAlls()
        {
            string where = " del = 1 order by creationtime DESC";
            return GetAll(where);
        }
        /// <summary>
        /// 跟时间查询上一条
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public newst GetShangYiPianByDate(string dateTime)
        {

            string sql = @"select top 1 id,
            headline,
            contenttext,
            userid,
            CONVERT(varchar(100), creationtime, 20) as creationtime,
            newstype,
            del,
            type,
            newstkeywords,
            newstdescription
              from newst where CONVERT(varchar(100), creationtime, 20) <'" + dateTime + "' and del=1 order by creationtime desc";//--前一条
            IList<newst> ilst = new List<newst>();
            ilst = ConvertToListBySql(sql);
            newst model = new newst();
            if (ilst.Count > 0)
            {
                model = ilst.ToList()[0];
            }

            return model;
        }
        /// <summary>
        /// 后一条
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public newst GetXiaYiPian(string dateTime)
        {
            string sql = @"select top 1 id,
            headline,
            contenttext,
            userid,
            CONVERT(varchar(100), creationtime, 20) as creationtime,
            newstype,
            del,
            type,
            newstkeywords,
            newstdescription
              from newst  where CONVERT(varchar(100), creationtime, 20) >'" + dateTime + "' and del=1 order by creationtime ";//--后一条  
            IList<newst> ilst = new List<newst>();
            ilst = ConvertToListBySql(sql);
            newst model = new newst();
            if (ilst.Count > 0)
            {
                model = ilst.ToList()[0];
            }

            return model;
        }
    }
}
