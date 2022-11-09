using Microsoft.Ajax.Utilities;
using Midterm.AuthData;
using Midterm.DB;
using System;
using System.Collections.Generic;
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
		public ActionResult InsertCar(Car car) {
			if (ModelState.IsValid) {
				DB.Cars.Add(car);
				DB.SaveChanges();
			}
			return View();
		}
    }
}