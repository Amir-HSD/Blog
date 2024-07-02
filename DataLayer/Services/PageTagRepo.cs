using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageTagRepo : IPageTagRepo
    {
        WeblogContext _db;
        public PageTagRepo(WeblogContext ctx)
        {
            this._db = ctx;
        }

        // Tag Model Service
        public IEnumerable<Tag> GetAllTags()
        {
            return _db.Tags;
        }

        public Tag GetTagById(int id)
        {
            return _db.Tags.Find(id);
        }

        public bool IsTagExist(int id)
        {
            return _db.Tags.Where(x=>x.TagId == id).Select(x=>x.TagId).Equals(id);
        }

        public List<Tag> AddTags(List<Tag> tags_list)
        {
            try
            {
                List<Tag> Tags = new List<Tag>();

                foreach (Tag tag in tags_list)
                {
                    var checkExist = _db.Tags.Where(x => x.TagName == tag.TagName).FirstOrDefault();
                    if (checkExist == null)
                    {
                        var addedTag =_db.Tags.Add(tag);
                        Tags.Add(addedTag);
                    } else
                    {
                        Tags.Add(checkExist);
                    }
                }

                return Tags;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool UpdateTag(Tag tag)
        {
            try
            {
                _db.Entry(tag).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteTag(Tag tag)
        {
            try
            {
                _db.Entry(tag).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteTagById(int id)
        {
            try
            {
                Tag tag = _db.Tags.Find(id);
                _db.Entry(tag).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // end


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
