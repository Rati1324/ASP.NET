using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CarsController : Controller
    {
        // GET: Cars
        public ActionResult Index()
        {
            var response = GlobalVariables.WebApiClient.GetAsync("cars");
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<CarDTO>>();
                readTask.Wait();
                var carList = readTask.Result;
                //ViewBag.cars = carList;
                return View(carList);
            }
            else 
            {
                // error
            }
            return View();
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new CarDTO());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("cars/" + id.ToString()).Result;
                var x = response.Content.ReadAsAsync<CarDTO>().Result;
                return View(x);
            }
        }
      
        [HttpPost]
        public ActionResult AddOrEdit(CarDTO car)
        {
            if (car.CarId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("cars", car).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Cars/" + car.CarId, car).Result;
            }
            return Redirect("Index");
        }
    }
}