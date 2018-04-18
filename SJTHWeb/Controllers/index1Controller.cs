using sjth.BLL;
using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJTHWeb.Controllers
{
    public class index1Controller : Controller
    {
        // GET: index
        private lunboBLL _lunbobll = new lunboBLL();
        public ActionResult Index()
        {
            List<lunbo> ListPC = new List<lunbo>();
            ListPC = _lunbobll.allList(1);
            ViewBag.ListPC = ListPC;
            List<lunbo> ListSJ = new List<lunbo>();
            ListSJ = _lunbobll.allList(2);
            ViewBag.ListSJ = ListSJ;
            return View();
        }
    }
}