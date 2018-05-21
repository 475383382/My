using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sjth.BLL;
using sjth.Model;
using System.Text;
using sjth.Core;
using Webdiyer.WebControls.Mvc;

namespace SJTHWeb.Controllers
{
    public class pengbuController : Controller
    {
        // GET: pengbu
        private newstBLL newsbll = new newstBLL();
        private AuthorityBLL authbll = new AuthorityBLL();
        /// <summary>
        /// 煤车篷布资讯
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int pageIndex = 1, int pageSize = 5, int? id = 0)
        {
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["total"] = 0;
            int totalcount = 0;

            List<newst> list = new List<newst>();
            // list = newsbll.getall();
            
             StringBuilder where = new StringBuilder();
            where.Append(" and del =1");
            SortParameter sa = new SortParameter();
            sa.Field = "creationtime";
            sa.Direction = SortDirection.DESC;
            SortParameters ot = new SortParameters();
            ot.Add(sa);
            list = newsbll.GetPage(out totalcount, pageIndex, pageSize, where.ToString(), "", ot);
            ViewData["total"] = totalcount;
            
            return View(list);
        }
        /// <summary>
        /// 篷布新闻详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult PbxwInfo(int id)
        {

            List<newst> list = new List<newst>();
            list = newsbll.GetTop10("10", " del =1");
            ViewBag.list = list;
            newst model = new newst();
            model =newsbll.GetById(id);
            newst modelS = new newst();
            newst modelX = new newst();
            DateTime time = Convert.ToDateTime( model.creationtime);
            ViewBag.GetShangYiPianByDate = newsbll.GetShangYiPianByDate(time.ToString("yyyy-MM-dd HH:mm:ss"));
            ViewBag.GetXiaYiPian = newsbll.GetXiaYiPian(time.ToString("yyyy-MM-dd HH:mm:ss"));
            return View(model);
            
        }
        /// <summary>
        /// 篷布图片
        /// </summary>
        /// <returns></returns>
        public ActionResult Peng()
        {
            List<Authority> AuthList = new List<Authority>();
            List<newst> list = new List<newst>();
            list = newsbll.GetTop10("10", " del =1");
            AuthList = authbll.getAll();
            ViewBag.AuthList = AuthList;
            return View(list);
        }
        /// <summary>
        /// 篷布图片详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult PengInfo(int? id =0)
        {
            Authority model = new Authority();
            List<Authority> authlist = new List<Authority>();
            authlist = authbll.getAll();
                ViewBag.Authlist = authlist;
            model = authbll.GetById((int)id);
            return View(model);
        }
        /// <summary>
        /// 篷布批发
        /// </summary>
        /// <returns></returns>
       public ActionResult Ppifa()
        {
            List<newst> list = new List<newst>();
            list = newsbll.GetTop10("10", " del =1");
            return View(list);
        }
        /// <summary>
        /// 篷布价格
        /// </summary>
        /// <returns></returns>
        public ActionResult Pengjiage()
        {
            List<newst> list = new List<newst>();
            list = newsbll.GetTop10("10"," del =1");
            return View(list);
            
        }
        /// <summary>
        /// 联系我们
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact() {
            return View();
        }
    }
}