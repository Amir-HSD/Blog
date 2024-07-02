using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageTagRepo
    {
        // Tag Model Interface
        IEnumerable<Tag> GetAllTags();

        Tag GetTagById(int id);

        bool IsTagExist(int id);
        List<Tag> AddTags(List<Tag> tags);

        bool UpdateTag(Tag tag);

        bool DeleteTag(Tag tag);

        bool DeleteTagById(int id);

        // end

        void SaveChanges();

        void Dispose();

    }
}
