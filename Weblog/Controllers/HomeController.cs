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
        ITagsPagesRepo TagsPagesRepo;
        public HomeController()
        {
            PageGroupRepo = new PageGroupRepo(ctx);
            PageRepo = new PageRepo(ctx);
            TagsPagesRepo = new TagsPagesRepo(ctx);
        }
        public ActionResult Index()
        {
            ViewBag.ShowMainBanner = true;
            ViewBag.ShowPostBanner = true;
            ViewBag.ShowCategory = true;
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
            var Pages = PageRepo.GetAllPages().OrderByDescending(x => x.PageVisitorCount).Take(3).ToList();
            return PartialView(Pages);
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

        public ActionResult ShowTags()
        {
            List<ShowTags> showTags = new List<ShowTags>();
            var Tags = TagsPagesRepo.GetAllTagsPages();

            foreach (var Tag in Tags)
            {
                showTags.Add(new ShowTags
                {
                    TagId = Tag.TagId,
                    TagName = Tag.Tag.TagName
                });
            }
            
            return PartialView(showTags);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                PageRepo.Dispose();
                TagsPagesRepo.Dispose();
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}