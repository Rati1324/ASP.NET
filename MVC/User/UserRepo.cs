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
        public DB.User GetUser(int id)
        {
            return db.Users.Find(id);
        }
        public void AddUser(DB.User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public void Rent(int userId, int carId) 
        {
            DB.User user = db.Users.Find(userId);
            DB.Car car = db.Cars.Find(carId);
            user.Cars.Add(car); 
            db.SaveChanges();
        }
    }
}
