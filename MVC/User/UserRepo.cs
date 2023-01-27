using DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class UserRepo
    {
        DBEntities db = new DBEntities();
        public DbSet<DB.User> GetUsers()
        {
            return db.Users;
        }
        public void AddUser(DB.User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
