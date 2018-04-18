using sjth.BLL;
using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJTHWeb.Controllers
{
    public class authorityController : Controller
    {
        private AuthorityBLL _aBLL = new AuthorityBLL();
        // GET: authority
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            int totalcount = 0;
            List<Authority> list = new List<Authority>();
            string where = " and del =1 ";
            list = _aBLL.GetPage(out totalcount, pageIndex, pageSize, where);
            // list = _aBLL.getall();
            ViewData["total"] = totalcount;
            return View(list);
        }
        public ActionResult Authority(int? id = 0)
        {
            
            Authority model = new Authority();
            if (id != 0)
            {
                model = _aBLL.GetById((int)id);
            }
            return View(model);
        }
    }
}