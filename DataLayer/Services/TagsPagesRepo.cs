using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TagsPagesRepo: ITagsPagesRepo
    {
        WeblogContext _db;
        public TagsPagesRepo(WeblogContext Context)
        {
            _db = Context;
        }
        public IEnumerable<TagsPages> GetAllTagsPages()
        {
            return _db.TagsPages;
        }

        public IEnumerable<TagsPages> GetTagsPage(int PageId)
        {
            return _db.TagsPages.Where(t=>t.PageId == PageId);
        }

        public IEnumerable<TagsPages> GetTagPages(int TagId)
        {
            return _db.TagsPages.Where(t => t.TagId == TagId);
        }

        public bool AddTagsPages(ICollection<Tag> Tags, Page Page)
        {
            try
            {
                foreach (var item in Tags)
                {
                    _db.TagsPages.Add(new TagsPages {TagId = item.TagId, PageId = Page.PageId });
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool UpdateTagsPages(ICollection<Tag> Tags, Page Page)
        {
            try
            {
                bool result = DeleteTagsPages(Page.PageId);
                if (result)
                {
                    AddTagsPages(Tags, Page);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteTagsPages(int PageId)
        {
            try
            {
                var TagsPages = _db.TagsPages.Where(t => t.PageId == PageId);
                foreach (var item in TagsPages)
                {
                    _db.TagsPages.Remove(item);
                }
                
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
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
