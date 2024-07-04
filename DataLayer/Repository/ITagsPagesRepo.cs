using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ITagsPagesRepo
    {
        IEnumerable<TagsPages> GetAllTagsPages();

        IEnumerable<TagsPages> GetTagsPage(int PageId);

        IEnumerable<TagsPages> GetTagPages(int TagId);

        bool AddTagsPages(ICollection<Tag> Tags, Page Page);

        bool UpdateTagsPages(ICollection<Tag> Tags, Page Page);

        bool DeleteTagsPages(int PageId);

        void SaveChanges();

        void Dispose();

    }
}
