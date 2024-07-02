using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageRepo
    {
        IEnumerable<Page> GetAllPages();

        IEnumerable<Page> GetPagesByGroupId(int GroupId);

        Page GetPageById(int id);

        bool AddPage(Page page);

        bool UpdatePage(Page page);
        
        bool DeletePage(Page page);

        bool DeletePageById(int id);

        void SaveChanges();

        void Dispose();

    }
}
