using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Weblog.Controllers
{
    public class SearchController : Controller
    {
        WeblogContext ctx = new WeblogContext();
        IPageRepo PageRepo;

        public SearchController()
        {
            PageRepo = new PageRepo(ctx);   
        }
        // GET: Search
        public ActionResult Index(string q)
        {
            var Pages = PageRepo.SearchPage(q);
            ViewBag.SearchContent = q;
            return View(Pages);
        }
    }
}