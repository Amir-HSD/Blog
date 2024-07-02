using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Weblog.Controllers
{
    public class HomeController : Controller
    {
        WeblogContext ctx = new WeblogContext();
        IPageGroupRepo PageGroupRepo;
        IPageRepo PageRepo;
        public HomeController()
        {
            PageGroupRepo = new PageGroupRepo(ctx);
            PageRepo = new PageRepo(ctx);
        }
        public ActionResult Index()
        {
            ViewBag.ShowMainBanner = true;
            ViewBag.ShowPostBanner = true;
            var Pages = PageRepo.GetAllPages().OrderByDescending(x => x.PageId);
            return View(Pages);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ShowMainBanner()
        {
            return PartialView();
        }

        public ActionResult ShowPostsBanner()
        {
            return PartialView();
        }

        public ActionResult ShowCategory()
        {
            var Category = PageGroupRepo.GetGroupsCategory();
            return PartialView("_Category",Category);
        }

        public ActionResult ShowCategoryInBanner()
        {
            var Category = PageGroupRepo.GetGroupsCategory();
            return PartialView(Category);
        }

        public ActionResult ShowRecentPost()
        {
            var Pages = PageRepo.GetAllPages().OrderByDescending(x=>x.PageId).Take(3).ToList();
            return PartialView(Pages);
        }

    }
}