using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Weblog.Controllers
{
    public class PostController : Controller
    {
        WeblogContext ctx;
        IPageRepo PageRepo;
        ITagsPagesRepo TagsPagesRepo;

        public PostController()
        {
            ctx = new WeblogContext();
            PageRepo = new PageRepo(ctx);
            TagsPagesRepo = new TagsPagesRepo(ctx);

        }
        // GET: Post
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }

        [Route("Category/{groupId}/{groupTitle}")]
        public ActionResult ShowPostsByGroupId(int groupId, string groupTitle)
        {
            var Pages = PageRepo.GetPagesByGroupId(groupId);
            ViewBag.GroupTitle = groupTitle;
            return View(Pages);
        }

        [Route("Tags/{tagId}/{tagName}")]
        public ActionResult ShowPostsByTagId(int tagId, string tagName)
        {
            var TagPages = TagsPagesRepo.GetTagPages(tagId);

            ViewBag.GroupTitle = tagName;

            List<Page> pages = new List<Page>();

            foreach (var item in TagPages)
            {
                pages.Add(item.Page);
            }

            return View(pages);
        }

    }
}