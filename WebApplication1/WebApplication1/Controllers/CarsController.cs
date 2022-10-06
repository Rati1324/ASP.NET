using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DB;

namespace WebApplication1.Controllers
{
    public class CarsController : Controller
    {
		CarRentalModel db = new CarRentalModel();

        public ActionResult Index(int id=0) {
			List<Car> c;
			if (id == 0) {
				c = db.Cars.Select(car => car).ToList();
			}
			else {
				c = db.Cars.Where(car => car.id == id).ToList();
			}
			ViewBag.Cars = c;
            return View();
        }
    }
}