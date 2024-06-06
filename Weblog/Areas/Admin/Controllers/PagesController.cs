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

namespace Weblog.Areas.Admin.Controllers
{
    public class PagesController : Controller
    {
        private WeblogContext ctx = new WeblogContext();

        IPageRepo PageRepo;

        public PagesController()
        {
            PageRepo = new PageRepo(ctx);
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
        public ActionResult Create([Bind(Include = "PageId,PageGroupId,PageTitle,PageDescription,PageContent,PageImage,PageVisitorCount,PageCreateDate")] Page page, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                page.PageVisitorCount = 0;
                page.PageCreateDate = DateTime.Now;

                if (imgUp != null)
                {
                    page.PageImage = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Content/images/"+page.PageImage));
                }

                PageRepo.AddPage(page);
                PageRepo.SaveChanges();
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
        public ActionResult Edit([Bind(Include = "PageId,PageGroupId,PageTitle,PageDescription,PageContent,PageImage,PageVisitorCount,PageCreateDate")] Page page)
        {
            if (ModelState.IsValid)
            {
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
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
