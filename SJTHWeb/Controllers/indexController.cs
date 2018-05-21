using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sjth.BLL;
using sjth.Model;

namespace SJTHWeb.Controllers
{
    public class indexController : Controller
    {
        private newstBLL newsbll = new newstBLL();
        private AuthorityBLL authbll = new AuthorityBLL();
        // GET: index
        public ActionResult Index()
        {
              List<Authority> AuthList = new List<Authority>();
            List<newst> list = new List<newst>();
            list = newsbll.getall();
             AuthList = authbll.GetTop10("4", " del =1");
            ViewBag.AuthList = AuthList;
            return View(list);
        }
    }
}