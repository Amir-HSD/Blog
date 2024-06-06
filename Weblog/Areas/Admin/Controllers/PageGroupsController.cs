using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Weblog.Areas.Admin.Controllers
{
    public class PageGroupsController : Controller
    {

        IPageGroupRepo PageGroupRepo;
        WeblogContext ctx = new WeblogContext();

        public PageGroupsController()
        {
            PageGroupRepo = new PageGroupRepo(ctx);
        }

        // GET: Admin/PageGroups
        public ActionResult Index()
        {
            return View(PageGroupRepo.GetAllPageGroups());
        }

        // GET: Admin/PageGroups/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = PageGroupRepo.GetPageGroupById(id);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        // GET: Admin/PageGroups/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/PageGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageGroupId,PageGroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                PageGroupRepo.AddPageGroup(pageGroup);
                PageGroupRepo.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = PageGroupRepo.GetPageGroupById(id);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        // POST: Admin/PageGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageGroupId,PageGroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                PageGroupRepo.UpdatePageGroup(pageGroup);
                PageGroupRepo.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = PageGroupRepo.GetPageGroupById(id);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        // POST: Admin/PageGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PageGroup pageGroup = PageGroupRepo.GetPageGroupById(id);
            PageGroupRepo.DeletePageGroup(pageGroup);
            PageGroupRepo.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                PageGroupRepo.Dispose();
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
