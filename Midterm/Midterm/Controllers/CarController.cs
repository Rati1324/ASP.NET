using Microsoft.Ajax.Utilities;
using Midterm.AuthData;
using Midterm.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Midterm.Controllers
{
	//[AuthAttribute]
    public class CarController : Controller
    {
		CarRental DB = new CarRental();
        public ActionResult GetCars() {
			List<Car> cars = DB.Cars.Select(i => i).ToList();
			ViewBag.Cars = cars;
            return View();
        }

		public ActionResult InsertCar() {
			return View();
		}

		[HttpPost]
		public ActionResult InsertCar(Car car=null) {
			if (ModelState.IsValid) {
				DB.Cars.Add(car);
				DB.SaveChanges();
				return RedirectToAction("GetCars");
			}
			return View();
		}

		public ActionResult EditCar(int carId) {
			ViewBag.Car = DB.Cars.Where(i => i.id == carId).First();
			return View();
		}

		[HttpPost]
		public ActionResult EditCar(Car car) {
			if (ModelState.IsValid) {
				Car dbCar = DB.Cars.Where(i => i.id == car.id).First();
				dbCar.name = car.name;
				dbCar.speed = car.speed;
				dbCar.horsePower = car.horsePower;
				dbCar.price = car.price;
				DB.SaveChanges();
				return RedirectToAction("GetCars");
			}
			return View();
		}

		public ActionResult DeleteCar(int carId) {
			Car car = DB.Cars.Where(i => i.id == carId).First();
			DB.Cars.Remove(car);
			DB.SaveChanges();
			return RedirectToAction("GetCars");
		}
    }
}