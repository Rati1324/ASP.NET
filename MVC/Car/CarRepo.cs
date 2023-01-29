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
        public DB.Car GetCar(int carId)
        {
            return db.Cars.Find(carId);
        }
        public void AddCar(DB.Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();
        }
        public void EditCar(DB.Car car)
        {
            DB.Car Car = db.Cars.FirstOrDefault(x => x.CarId == car.CarId);
            if (car != null)
            {
                Car.Brand = car.Brand;
                Car.Model = car.Model;
                Car.Price = car.Price;
                db.SaveChanges();
            }
        }

        public void CancelRent(DB.Car car)
        {
            DB.Car Car = db.Cars.FirstOrDefault(x => x.CarId == car.CarId);
            if (car != null)
            {
                Car.User = null;
            }
            db.SaveChanges();
        }
        public void DeleteCar(int id)
        {
            DB.Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
        }
    }
}
