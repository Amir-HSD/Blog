using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepo : IPageRepo
    {
        WeblogContext _db;

        public PageRepo(WeblogContext Context)
        {
            _db = Context;
        }

        public IEnumerable<Page> GetAllPages()
        {
            return _db.Pages;
        }

        public Page GetPageById(int id)
        {
            return _db.Pages.Find(id);
        }

        public Page AddPage(Page page)
        {
            try
            {
                var Page = _db.Pages.Add(page);
                return Page;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdatePage(Page page)
        {
            try
            {
                //_db.Entry(page).State = EntityState.Modified;
                var p = _db.Pages.Find(page.PageId);
                p.PageTitle = page.PageTitle;
                p.PageGroup = page.PageGroup;
                p.PageDescription = page.PageDescription;
                p.PageContent = page.PageContent;
                p.PageImage = page.PageImage;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePage(Page page)
        {
            try
            {
                _db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePageById(int id)
        {
            try
            {
                var page = _db.Pages.Find(id);
                DeletePage(page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IEnumerable<Page> GetPagesByGroupId(int GroupId)
        {
            return _db.Pages.Where(p=> p.PageGroupId == GroupId);

        }
    }
}
