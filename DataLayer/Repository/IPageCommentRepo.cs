using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageCommentRepo
    {

        IEnumerable<PageComment> GetAllComment(int PageId);

        PageComment AddComment(PageComment comment);

        void SaveChanges();

        void Dispose();

    }
}
