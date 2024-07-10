using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using Microsoft.Ajax.Utilities;
using Weblog.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Weblog.Areas.Admin.Controllers
{
    [CustomAuthorizeAttribute(Roles = "Admin")]
    public class PagesController : Controller
    {
        private WeblogContext ctx = new WeblogContext();

        IPageRepo PageRepo;

        IPageTagRepo TagRepo;

        ITagsPagesRepo TagsPagesRepo;

        public PagesController()
        {
            PageRepo = new PageRepo(ctx);
            TagRepo = new PageTagRepo(ctx);
            TagsPagesRepo = new TagsPagesRepo(ctx);
        }

        // GET: Admin/Pages
        public ActionResult Index()
        {
            var pages = PageRepo.GetAllPages();
            return View(pages.ToList());
        }

        // GET: Admin/Pages/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = PageRepo.GetPageById(id);
            if (page == null)
            {
                return HttpNotFound();
            }

            return View(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.PageGroupId = new SelectList(ctx.PageGroup, "PageGroupId", "PageGroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageId,PageGroupId,PageTitle,PageDescription,PageContent,PageImage")] Page page, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                page.PageVisitorCount = 0;
                page.PageCreateDate = DateTime.Now;


                var tags = Request.Form.GetValues("tags");

                List<Tag> tags_list = new List<Tag>();

                foreach (var item in tags)
                {
                    tags_list.Add(new Tag { TagName = item });
                }

                var Tags = TagRepo.AddTags(tags_list);
                TagRepo.SaveChanges();
                
                if (imgUp != null)
                {
                    page.PageImage = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Content/images/"+page.PageImage));
                }

                var Page = PageRepo.AddPage(page);
                PageRepo.SaveChanges();

                TagsPagesRepo.AddTagsPages(Tags, Page);
                TagsPagesRepo.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.PageGroupId = new SelectList(ctx.PageGroup, "PageGroupId", "PageGroupTitle", page.PageGroupId);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = PageRepo.GetPageById(id);
            if (page == null)
            {
                return HttpNotFound();
            }


            ViewBag.PageGroupId = new SelectList(ctx.PageGroup, "PageGroupId", "PageGroupTitle", page.PageGroupId);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageId,PageGroupId,PageTitle,PageDescription,PageContent,PageImage,PageVisitorCount,PageCreateDate")] Page page, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    if (page.PageImage != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Content/images/" + page.PageImage));
                    }
                    page.PageImage = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Content/images/" + page.PageImage));
                }

                var tags = Request.Form.GetValues("tags");

                List<Tag> tags_list = new List<Tag>();
                
                foreach (var item in tags)
                {
                    tags_list.Add(new Tag { TagName = item });
                }

                var Tags = TagRepo.AddTags(tags_list);
                TagRepo.SaveChanges();

                TagsPagesRepo.UpdateTagsPages(Tags, page);

                PageRepo.UpdatePage(page);
                PageRepo.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PageGroupId = new SelectList(ctx.PageGroup, "PageGroupId", "PageGroupTitle", page.PageGroupId);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = PageRepo.GetPageById(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Page page = PageRepo.GetPageById(id);
            PageRepo.DeletePage(page);
            PageRepo.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                PageRepo.Dispose();
                TagRepo.Dispose();
                TagsPagesRepo.Dispose();
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
