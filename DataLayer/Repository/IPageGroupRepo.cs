using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageGroupRepo
    {
        
        IEnumerable<PageGroup> GetAllPageGroups();

        PageGroup GetPageGroupById(int id);

        bool AddPageGroup(PageGroup pageGroup);

        bool UpdatePageGroup(PageGroup pageGroup);

        bool DeletePageGroup(PageGroup pageGroup);

        bool DeletePageGroupById(int id);

        void SaveChanges();

        void Dispose();

    }
}
