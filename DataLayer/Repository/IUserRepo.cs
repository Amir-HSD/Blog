using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUsers();

        User GetUserById(int id);

        User GetUserByEmail(string email);

        User AddUser(User user);

        bool UpdateUser(User user);

        bool DeleteUser(User user);

        void SaveChanges();

        void Dispose();
    }
}
