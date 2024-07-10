using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserRepo : IUserRepo
    {
        WeblogContext _db;
        public UserRepo(WeblogContext ctx)
        {

            _db = ctx;

        }

        public IEnumerable<User> GetAllUsers()
        {
            return _db.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _db.Users.Where(u=>u.Id == id).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return _db.Users.Where(u=> u.Email == email).FirstOrDefault();
        }
        public User AddUser(User user)
        {
            
            var User = _db.Users.Add(user);

            return User;
        }

        public bool UpdateUser(User user)
        {
            try
            {
                var User = _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            
        }

        public bool DeleteUser(User user)
        {
            try
            {
                var User = _db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
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
