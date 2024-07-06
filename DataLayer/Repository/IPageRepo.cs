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

        IEnumerable<Page> SearchPage(string q);

        Page GetPageById(int id);

        Page AddPage(Page page);

        bool UpdatePage(Page page);
        
        bool DeletePage(Page page);

        bool DeletePageById(int id);

        void SaveChanges();

        void Dispose();

    }
}
