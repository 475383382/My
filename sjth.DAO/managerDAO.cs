using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sjth.Model;


namespace sjth.DAO
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class managerDAO : BaseDAO<manager>
    {
        public manager managerLogin( string name,string pw)
        {
            //username
            //userpwassord
            string strSql = string.Format(" username ='{0}' and userpwassord='{1}'", name, pw);
            return FindOne(strSql);
        }

    }
}
