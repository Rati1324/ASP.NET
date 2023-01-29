using DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public class CarRepo
    {
        DBEntities db = new DBEntities();
        public DbSet<DB.Car> GetCars()
        {
            return db.Cars;
        }
        public void AddCar(DB.Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();
        }
    }
}
