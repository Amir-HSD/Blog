using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageCommentRepo : IPageCommentRepo
    {
        WeblogContext _db;

        public PageCommentRepo(WeblogContext context)
        {
            _db = context;
        }

        PageComment IPageCommentRepo.AddComment(PageComment comment)
        {
            comment.PageCommentCreateDate = DateTime.Now;
            var Comment = _db.PageComment.Add(comment);
            return Comment;
        }

        void IPageCommentRepo.Dispose()
        {
            _db.Dispose();
        }

        IEnumerable<PageComment> IPageCommentRepo.GetAllComment(int PageId)
        {
            return _db.PageComment.Where(c=>c.PageId == PageId).ToList();
        }

        void IPageCommentRepo.SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
