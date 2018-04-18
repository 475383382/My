using sjth.DAO;
using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjth.BLL
{
    public class AuthorityBLL : Base2DAOManager<Authority>
    {
        private AuthorityDAO dao = new AuthorityDAO();
              public List<Authority> getAll(){
                  return dao.getAll();
              }
    }
}
