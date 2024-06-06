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

        public bool AddPage(Page page)
        {
            try
            {
                _db.Pages.Add(page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePage(Page page)
        {
            try
            {
                _db.Entry(page).State = EntityState.Modified;
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

    }
}
