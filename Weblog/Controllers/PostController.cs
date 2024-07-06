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
        IPageCommentRepo PageCommentRepo;

        public PostController()
        {
            ctx = new WeblogContext();
            PageRepo = new PageRepo(ctx);
            TagsPagesRepo = new TagsPagesRepo(ctx);
            PageCommentRepo = new PageCommentRepo(ctx);

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

        [Route("Post/{postId}/{postTitle}")]
        public ActionResult ShowPost(int postId)
        {
            var Page = PageRepo.GetPageById(postId);
            return View(Page);
        }

        public ActionResult AddComment(int postId, string commentContent, string CommentName, string CommentEmail)
        {
            PageComment comment = new PageComment()
            {
                PageId = postId,
                PageCommentName = CommentName,
                PageCommentText = commentContent,
                PageCommentEmail = CommentEmail
            };

            var Comment = PageCommentRepo.AddComment(comment);

            PageCommentRepo.SaveChanges();

            return PartialView("ShowCommentsPage", PageCommentRepo.GetAllComment(postId));

        }

        public ActionResult ShowCommentsPage(int postId)
        {
            var Comments = PageCommentRepo.GetAllComment(postId);

            return PartialView(Comments);
        }

        public void Dispose()
        {
            PageCommentRepo.Dispose();
            TagsPagesRepo.Dispose();
            PageRepo.Dispose();
            ctx.Dispose();
        }

    }
}