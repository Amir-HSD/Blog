using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroupRepo : IPageGroupRepo
    {
        WeblogContext _db;

        public PageGroupRepo(WeblogContext Context)
        {
            this._db = Context;
        }

        public IEnumerable<PageGroup> GetAllPageGroups()
        {
            return _db.PageGroup;
        }

        public PageGroup GetPageGroupById(int id)
        {
            return _db.PageGroup.Find(id);
        }

        public bool AddPageGroup(PageGroup pageGroup)
        {
            try
            {
                _db.PageGroup.Add(pageGroup);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePageGroup(PageGroup pageGroup)
        {
            try
            {
                _db.Entry(pageGroup).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePageGroup(PageGroup pageGroup)
        {
            try
            {
                _db.Entry(pageGroup).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePageGroupById(int id)
        {
            try
            {
                var pageGroup = _db.PageGroup.Find(id);
                DeletePageGroup(pageGroup);
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
