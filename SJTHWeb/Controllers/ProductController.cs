using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sjth.Model;
using sjth.BLL;
using sjth.Core;
using System.Text;
namespace SJTHWeb.Controllers
{
    public class ProductController : BaseController
    {
        private newstypeBLL newstypeBLL = new newstypeBLL();
        private newstBLL newsbll = new newstBLL();
        private AuthorityBLL _aBLL = new AuthorityBLL();
        private productBLL prbll = new productBLL();
        private lunboBLL _lunbo = new lunboBLL();
        private videoBLL _video = new videoBLL();
        private SalestBLL _Salest = new SalestBLL();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        #region 新闻添加
        [AuthAttribute]
        public ActionResult addNews(int? id = 0)
        {
            select();
            if (id != 0)
            {
                newst model = new newst();
                model = newsbll.GetById((int)id);
                return View(model);
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        [ValidateInput(false)]
        [AuthAttribute]
        public ActionResult addNews(newst model)
        {
            select();
            if (model.id != 0)
            {
                newst models = new newst();
                models= newsbll.GetById(model.id);
                models.headline = model.headline;
                models.newstype = model.newstype;
                models.contenttext = model.contenttext;
                model.userid = USERID;
                newsbll.Update(models);
            }
            else
            {
                model.del = 1;
                newsbll.Insert(model);
            }
            return RedirectToAction("newsList", "Product");
        }
        #endregion
        #region 新闻列表
        [AuthAttribute]
        [ValidateInput(false)]
        public ActionResult newsList(int pageIndex = 1,int pageSize = 10)
        {
            List<newst> list = new List<newst>();
            List<newsName> li = new List<newsName>();
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["total"] = 0;
            try
            {
            string name = Request["name"];
            string start = Request["start"];
            string end = Request["end"];
            int totalcount = 0;
            StringBuilder where = new StringBuilder();
            where.Append(" and del =1 ");
            if (!string.IsNullOrWhiteSpace(name))
            {
                where.Append(" and headline like'%" + name.Trim() + "%'");
            }
            if (!string.IsNullOrWhiteSpace(start) && !string.IsNullOrWhiteSpace(end))
            {
                //where.Append(" and creationtime>='" + start + "'");
                //creationtime between '2016-12-07' and '2016-12-08 23:59:59'
                where.Append(" and creationtime between '" + start + "' and '" + end + "  23:59:59'");
            }
            if (!string.IsNullOrWhiteSpace(start) && string.IsNullOrWhiteSpace(end))
            {
                where.Append(" and creationtime>='" + start + "'");
            }
            if (string.IsNullOrWhiteSpace(start) && !string.IsNullOrWhiteSpace(end))
            {
                where.Append(" and creationtime<='" + end + " 23:59:59'");
            }
            SortParameter sa = new SortParameter();
            sa.Field = "creationtime";
            sa.Direction = SortDirection.DESC;
            SortParameters ot = new SortParameters();
            ot.Add(sa);
            list = newsbll.GetPage(out totalcount, pageIndex, pageSize, where.ToString(),"",ot);
           // list = newsbll.getall();
            ViewData["total"] = totalcount;
            if (list.Count>0)
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
            }
            catch (Exception)
            {

                
            }
            return View(li);
        }
        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string upnews(int id)
        {
            newst model = new newst();

          model =  newsbll.GetById(id);
          model.del = 0;
          newsbll.Update(model);
          return "1";
        }
        #endregion
        #region 类别列表
         [AuthAttribute]
        public ActionResult newstype()
        {
            List<newstype> List = new List<sjth.Model.newstype>();
            List = newstypeBLL.getall();
           return View(List);
        }
        #endregion
        #region 添加类别
         [AuthAttribute]
        public ActionResult addtype(int ? id =0)
        {
            sjth.Model.newstype model = new sjth.Model.newstype();
            if (id != 0)
            {
                model = newstypeBLL.GetById((int)id);

            }

            return View(model);
           
            
        }
        [HttpPost]
        public ActionResult addtype(sjth.Model.newstype model)
        {
            if (model.id==0)
            {
                model.datatimes = DateTime.Now;
                model.del = 1;
                newstypeBLL.Insert(model);
                return RedirectToAction("newstype", "Product");
            }
            else
            {
                sjth.Model.newstype models = new sjth.Model.newstype();
                models = newstypeBLL.GetById(model.id);
                models.typename = model.typename;
                newstypeBLL.Update(models);
                return RedirectToAction("newstype", "Product");
            }
        }
        /// <summary>
        /// 更新删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string update(int id)
        {
            sjth.Model.newstype models = new sjth.Model.newstype();
            models = newstypeBLL.GetById(id);
            models.del = 0;
            newstypeBLL.Update(models);
            return "1";
        }
        #endregion
        #region 权威认证
         [AuthAttribute]
        [ValidateInput(false)]
        public ActionResult AuthorityList(int pageIndex = 1, int pageSize = 10)
        {
            List<Authority> list = new List<Authority>();
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["total"] = 0;
            try
            {
            string name = Request["name"];
            string start = Request["start"];
            string end = Request["end"];
            int totalcount = 0;
            StringBuilder where = new StringBuilder();
            where.Append(" and del =1 ");
            if (!string.IsNullOrWhiteSpace(name))
            {
                where.Append( " and authorityName like'%" + name.Trim() + "%'");
            }
            if (!string.IsNullOrWhiteSpace(start) && !string.IsNullOrWhiteSpace(end))
            {
                //where.Append(" and creationtime>='" + start + "'");
                //creationtime between '2016-12-07' and '2016-12-08 23:59:59'
                where.Append(" and datatimes between '" + start + "' and '" + end + " 23:59:59'");
            }
            if (!string.IsNullOrWhiteSpace(start) && string.IsNullOrWhiteSpace(end))
            {
                where.Append(" and datatimes>='" + start + "'");
            }
            if (string.IsNullOrWhiteSpace(start) && !string.IsNullOrWhiteSpace(end))
            {
                where.Append(" and datatimes<='" + end + " 23:59:59'");
            }
            SortParameter sa = new SortParameter();
            sa.Field = "datatimes";
            sa.Direction = SortDirection.DESC;
            SortParameters ot = new SortParameters();
            ot.Add(sa);
            list = _aBLL.GetPage(out totalcount, pageIndex, pageSize, where.ToString(), "", ot);
           // list = _aBLL.getall();
            ViewData["total"] = totalcount;
            }
            catch (Exception)
            {

            }
            return View(list);

        }
        #endregion
        #region 权威认证添加
         [AuthAttribute]
        public ActionResult addAuthority(int? id = 0)
        {
            Authority model = new Authority();
            if (id != 0)
            {
                model = _aBLL.GetById((int)id);
            }
           return View(model);
        }
        [HttpPost]
        public ActionResult addAuthority(Authority model)
        {
            if (model.id != 0)
            {
                Authority models = new Authority();
                models = _aBLL.GetById((int)model.id);
                models.authorityName = model.authorityName;
                models.authoritytTop = model.authoritytTop;
                models.authorityUrl = model.authorityUrl;
                _aBLL.Update(models);
            }
            else
            {
                model.del = 1;
                _aBLL.Insert(model);
            }
            return RedirectToAction("AuthorityList", "Product"); 
        }
        /// <summary>
        /// 删除权威认证
        /// </summary>
        /// <returns></returns>
        public string upauth(int id)
        {
            Authority model = new Authority();
            model = _aBLL.GetById((int)id);
            model.del = 0;
            _aBLL.Update(model);
            return "1";
        }
        #endregion
        #region 产品列表
         [AuthAttribute]
        
        public ActionResult productList(int pageIndex = 1, int pageSize = 10)
        {
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["total"] = 0;
            List<product> list = new List<product>();
            try
            {
                string name = Request["name"];
                string start = Request["start"];
                string end = Request["end"];
                int totalcount = 0;
                StringBuilder where = new StringBuilder();
                where.Append(" and del =1 ");
                if (!string.IsNullOrWhiteSpace(name))
                {
                    where.Append(" and productName like'%" + name.Trim() + "%'");
                }
                if (!string.IsNullOrWhiteSpace(start) && !string.IsNullOrWhiteSpace(end))
                {
                    //where.Append(" and creationtime>='" + start + "'");
                    //creationtime between '2016-12-07' and '2016-12-08 23:59:59'
                    where.Append(" and datatimes between '" + start + "' and '" + end + "  23:59:59'");
                }
                if (!string.IsNullOrWhiteSpace(start) && string.IsNullOrWhiteSpace(end))
                {
                    where.Append(" and datatimes>='" + start + "'");
                }
                if (string.IsNullOrWhiteSpace(start) && !string.IsNullOrWhiteSpace(end))
                {
                    where.Append(" and datatimes<='" + end + " 23:59:59'");
                }
                SortParameter sa = new SortParameter();
                sa.Field = "datatimes";
                sa.Direction = SortDirection.DESC;
                SortParameters ot = new SortParameters();
                ot.Add(sa);
                list = prbll.GetPage(out totalcount, pageIndex, pageSize, where.ToString(), "", ot);
                // list = newsbll.getall();
                ViewData["total"] = totalcount;
            }
            catch (Exception)
            {

                throw;
            }
            return View(list);
        }
        #endregion
        #region 产品添加
        public ActionResult addproduct(int? id = 0)
        {
            product model = new product();
            if (id != 0)
            {
               
                model = prbll.GetById((int)id);
               
            }
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addproduct(product model)
        {
            if (model.id != 0)
            {
                product models = new product();
                models = prbll.GetById(model.id);
                models.productConstituent = model.productConstituent;
                models.productImage = model.productImage;
                models.productIntro = model.productIntro;
                models.productName = model.productName;
                models.productNotes = model.productNotes;
                models.productUrl = model.productUrl;
                models.productUsage = model.productUsage;
                prbll.Update(models);
            }
            else
            {
                model.datatimes = DateTime.Now;
                model.del = 1;
                prbll.Insert(model);
            }
            return RedirectToAction("productList", "Product");
        }
        /// <summary>
        /// 更新删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string upproduct(int id)
        {
            sjth.Model.product models = new sjth.Model.product();
            models = prbll.GetById(id);
            models.del = 0;
            prbll.Update(models);
            return "1";
        }
        #endregion
        #region 轮播图
        public ActionResult lunbo()
        {
            List<lunbo> list = new List<sjth.Model.lunbo>();
            list = _lunbo.allList();
            return View(list);
        }
        public ActionResult addlunbo(int ? id = 0)
        {
            lunbo model = new lunbo();
            if (id != 0)
            {
               model = _lunbo.GetById((int)id);
            }
            return View(model);

        }
        [HttpPost]
        public ActionResult addlunbo(lunbo model)
        {
            if(model.id!=0){
                lunbo models = new lunbo();
                models = _lunbo.GetById(model.id);
                models.htmlurl = model.htmlurl;
                models.imgurl = model.imgurl;
                models.name = model.name;
                models.type = model.type;
                _lunbo.Update(models);
            }else{
            model.del = 1;
            _lunbo.Insert(model);
            }
            return RedirectToAction("lunbo", "Product");
        }
        public string uplunbo(int id)
        {
            lunbo models = new lunbo();
            models = _lunbo.GetById(id);
            models.del = 0;
            _lunbo.Update(models);
            return "1";
        }
        #endregion
        #region 视频
        [AuthAttribute]
        [ValidateInput(false)]
        public ActionResult videoList(int pageIndex = 1, int pageSize = 10)
        {
            List<video> list = new List<sjth.Model.video>();


            List<video> li = new List<video>();
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["total"] = 0;

            string name = Request["name"];
            string start = Request["start"];
            string end = Request["end"];

            try
            {

            
            StringBuilder where = new StringBuilder();
            where.Append(" and del =1 ");
            if (!string.IsNullOrWhiteSpace(name))
            {
                where.Append(" and name like'%" + name.Trim() + "%'");
            }
            if (!string.IsNullOrWhiteSpace(start) && !string.IsNullOrWhiteSpace(end))
            {
                //where.Append(" and creationtime>='" + start + "'");
                //creationtime between '2016-12-07' and '2016-12-08 23:59:59'
                where.Append(" and datatimes between '" + start + "' and '" + end + "  23:59:59'");
            }
            if (!string.IsNullOrWhiteSpace(start) && string.IsNullOrWhiteSpace(end))
            {
                where.Append(" and datatimes>='" + start + "'");
            }
            if (string.IsNullOrWhiteSpace(start) && !string.IsNullOrWhiteSpace(end))
            {
                where.Append(" and datatimes<='" + end + " 23:59:59'");
            }
            SortParameter sa = new SortParameter();
            sa.Field = "datatimes";
            sa.Direction = SortDirection.DESC;
            SortParameters ot = new SortParameters();
            ot.Add(sa);
            int totalcount = 0;
            list = _video.GetPage(out totalcount, pageIndex, pageSize, where.ToString(), "", ot);
            // list = newsbll.getall();
            ViewData["total"] = totalcount;

           // list = _video.allList();
            return View(list);
            }
            catch (Exception)
            {
                return View(list);
                
            }
        }
        [AuthAttribute]
        public ActionResult addvideo(int? id = 0)
        {
            video model = new video();
            if (id != 0)
            {
                model = _video.GetById((int)id);
            }
            return View(model);

        }
        [HttpPost]
        [AuthAttribute]
        public ActionResult addvideo(video model)
        {
            if (model.id != 0)
            {
                video models = new video();
                models = _video.GetById(model.id);
                models.name = model.name;
                models.url = model.url;
                _video.Update(models);
            }
            else
            {
                model.del = 1;
                _video.Insert(model);
            }
            return RedirectToAction("videoList", "Product");
        }
        public string upvideo(int id)
        {
            video models = new video();
            models = _video.GetById(id);
            models.del = 0;
            _video.Update(models);
            return "1";
        }
        #endregion
        #region 销售
        public ActionResult addxiaoshou(int? id = 0)
        {
            Salest model = new Salest();
            if (id != 0)
            {
                model = _Salest.GetById((int)id);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult addxiaoshou(Salest model )
        {
            
            if(model.id!=0){
                Salest models = new Salest();
                models = _Salest.GetById(model.id);
                models.img = model.img;
                models.jidu = model.jidu;
                models.yue = model.yue;
                models.nian = model.nian;
                models.name = model.name;
                _Salest.Update(models);
            }
            else
            {
                model.del = 1;
                _Salest.Insert(model);
            }
            return RedirectToAction("xiaoshou", "Product");
        }

        public string upxiaoshou(int id)
        {
            Salest model = new Salest();

            model = _Salest.GetById(id);
            model.del = 0;
            _Salest.Update(model);
            return "1";
        }
        #endregion
        #region 销售列表
        public ActionResult xiaoshou(int pageIndex = 1, int pageSize = 10)
        {
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["total"] = 0;
            List<Salest> list = new List<Salest>();
            try
            {
                string name = Request["name"];
                string start = Request["start"];
                string end = Request["end"];
                int totalcount = 0;
                StringBuilder where = new StringBuilder();
                where.Append(" and del =1 ");
                if (!string.IsNullOrWhiteSpace(name))
                {
                    where.Append(" and name like'%" + name.Trim() + "%'");
                }
                if (!string.IsNullOrWhiteSpace(start) && !string.IsNullOrWhiteSpace(end))
                {
                    //where.Append(" and creationtime>='" + start + "'");
                    //creationtime between '2016-12-07' and '2016-12-08 23:59:59'
                    where.Append(" and datatimes between '" + start + "' and '" + end + "  23:59:59'");
                }
                if (!string.IsNullOrWhiteSpace(start) && string.IsNullOrWhiteSpace(end))
                {
                    where.Append(" and datatimes>='" + start + "'");
                }
                if (string.IsNullOrWhiteSpace(start) && !string.IsNullOrWhiteSpace(end))
                {
                    where.Append(" and datatimes<='" + end + " 23:59:59'");
                }
                SortParameter sa = new SortParameter();
                sa.Field = "datatimes";
                sa.Direction = SortDirection.DESC;
                SortParameters ot = new SortParameters();
                ot.Add(sa);
                list = _Salest.GetPage(out totalcount, pageIndex, pageSize, where.ToString(), "", ot);
                // list = newsbll.getall();
                ViewData["total"] = totalcount;
            }
            catch (Exception)
            {

                throw;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult xiaoshou(List<Salest> list)
        {
            return View();
        }
        #endregion
        #region 统计图
        public ActionResult count()
        {
           ViewBag.pcount = prbll.productList().Count();
          ViewBag.a = _aBLL.getAll().Count();
         
          ViewBag.gszx = newsbll.GetAll(" newstype in(SELECT id from newstype WHERE ppid = 1 and del =1)").Count();
          ViewBag.xuzn = newsbll.GetAll(" newstype in(SELECT id from newstype WHERE ppid = 2 and del =1)" ).Count();
          ViewBag.vo = _video.allList().Count();
            return View();
        }
        #endregion
        /// <summary>
        /// 下拉框
        /// </summary>
        /// <param name="id"></param>
        public void select(int ? id=0)
        {
            List<newstype> List = newstypeBLL.getall();
            SelectList select = new SelectList(List, "id", "typename");
            ViewBag.selecttype = select.AsEnumerable();
        }
    }
}