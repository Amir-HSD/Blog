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

        public PostController()
        {
            ctx = new WeblogContext();
            PageRepo = new PageRepo(ctx);

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

    }
}