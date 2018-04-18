using sjth.BLL;
using sjth.Core;
using sjth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SJTHWeb.Controllers
{
    public class ConsultingController : Controller
    {
        private newstypeBLL newstypeBLL = new newstypeBLL();
        private newstBLL newsbll = new newstBLL();
        private productBLL _productbll = new productBLL();
        private videoBLL _video = new videoBLL();
        private SalestBLL _salest = new SalestBLL();
        // GET: Consulting
        #region 公司咨询
        public ActionResult Index(int pageIndex = 1, int pageSize = 10,int ? id =0)
        {
            List<newstype> typelist = new List<newstype>();
            string whereS = " PPID=1 and del =1";
             typelist = newstypeBLL.GetAll(whereS);
             ViewBag.data = typelist;
            List<newst> list = new List<newst>();
            List<newsName> li = new List<newsName>();
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["total"] = 0;
            int totalcount = 0;
            StringBuilder where = new StringBuilder();
            where.Append(" and del =1 and newstype = "+id);
            SortParameter sa = new SortParameter();
            sa.Field = "creationtime";
            sa.Direction = SortDirection.DESC;
            SortParameters ot = new SortParameters();
            ot.Add(sa);
            list = newsbll.GetPage(out totalcount, pageIndex, pageSize, where.ToString(), "", ot);
            // list = newsbll.getall();
            ViewData["total"] = totalcount;
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    newsName model = new newsName();
                    model.id = item.id;
                    model.headline = item.headline;
                    model.newstype = item.newstype;
                    model.newstypename = newstypeBLL.GetById((int)item.newstype).typename;
                    model.userid = item.userid;
                    model.del = item.del;
                    model.creationtime = item.creationtime;
                    model.contenttext = item.contenttext;
                    li.Add(model);
                }
            }
            return View(li);
        }
        #endregion
        #region 公司学院
        public ActionResult school(int pageIndex = 1, int pageSize = 10, int? id = 0)
        {
            List<newstype> typelist = new List<newstype>();
            string whereS = " PPID=2 and del =1";
            typelist = newstypeBLL.GetAll(whereS);
            ViewBag.data = typelist;
            List<newst> list = new List<newst>();
            List<newsName> li = new List<newsName>();
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["total"] = 0;
            ViewData["name"] = newstypeBLL.GetById((int)id).typename;
            int totalcount = 0;
            StringBuilder where = new StringBuilder();
            where.Append(" and del =1 and newstype = " + id);
            SortParameter sa = new SortParameter();
            sa.Field = "creationtime";
            sa.Direction = SortDirection.DESC;
            SortParameters ot = new SortParameters();
            ot.Add(sa);
            list = newsbll.GetPage(out totalcount, pageIndex, pageSize, where.ToString(), "", ot);
            // list = newsbll.getall();
            ViewData["total"] = totalcount;
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    newsName model = new newsName();
                    model.id = item.id;
                    model.headline = item.headline;
                    model.newstype = item.newstype;
                    model.newstypename = newstypeBLL.GetById((int)item.newstype).typename;
                    model.userid = item.userid;
                    model.del = item.del;
                    model.creationtime = item.creationtime;
                    model.contenttext = item.contenttext;
                    li.Add(model);
                }
            }
            return View(li);
        }
        #endregion
        #region 咨询详情
        public ActionResult Details(int id)
        {
            List<newstype> typelist = new List<newstype>();
            string whereS = " PPID=1 and del =1";
            typelist = newstypeBLL.GetAll(whereS);
            ViewBag.data = typelist;
            newst model = newsbll.GetById(id);
            return View(model);
        }
        #endregion
        #region 学院详情
        public ActionResult schoolDetails(int id)
        {
            List<newstype> typelist = new List<newstype>();
            string whereS = " PPID=2 and del =1";
            typelist = newstypeBLL.GetAll(whereS);
            ViewBag.data = typelist;
            newst model = newsbll.GetById(id);
            return View(model);
        }
        #endregion
        #region 产品
        public ActionResult product(int pageIndex = 1, int pageSize = 10)
        {
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["total"] = 0;
            int totalcount = 0;
            List<product> list = new List<product>();
            StringBuilder where = new StringBuilder();
            SortParameter sa = new SortParameter();
            sa.Field = "datatimes";
            sa.Direction = SortDirection.DESC;
            SortParameters ot = new SortParameters();
            ot.Add(sa);
            where.Append(" and del =1 ");
            list = _productbll.GetPage(out totalcount, pageIndex, pageSize, where.ToString(), "", ot);
            ViewData["total"] = totalcount;
            return View(list);
        }
        /// <summary>
        /// 产品详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult particulars(int? id =0)
        {
            product model = new product();
            try
            {
                model = _productbll.GetById((int)id);
                ViewBag.shang = _productbll.shang((int)id);
                ViewBag.xia = _productbll.xia((int)id);
                //select top 1 * from newst where id <2 order by id DESC

                //select top 1 * from newst where id > 2 order by id ASC
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
          
        }
        #endregion
        #region 视频欣赏
        public ActionResult videos()
        {
            List<video> List = new List<video>();
            List = _video.allList();
            return View(List);
        }
        #endregion
        #region 排行榜

        public ActionResult celebrity()
        {
            
          List<Salest> nian =  _salest.allnian("nian");
          List<Salest> yue = _salest.allnian("yue");
          List<Salest> jidu = _salest.allnian("jidu");
          ViewBag.nian = nian;
          ViewBag.yue = yue;
          ViewBag.jidu = jidu;
            return View();
        }

        #endregion
        #region 代理加盟
        public ActionResult dljm()
        {
            return View();
        }

        #endregion
        #region 关于我们
        public ActionResult Aboutus()
        {
            return View();
        }

        #endregion
        
    }
}