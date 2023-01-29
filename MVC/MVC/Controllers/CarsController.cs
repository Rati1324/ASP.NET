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
                CarDTO rentedCar = carList.FirstOrDefault(c => c.User?.UserId == (int)Session["userId"]);
                if (rentedCar != null)
                {
                    ViewBag.rentedId = rentedCar.CarId;
                }
                else
                {
                    ViewBag.rentedId = null;
                }
                return View(carList);
            }
            else 
            {
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
                TempData["SuccessMessage"] = "Edited Successfully";
            }
            return RedirectToAction("Index", "Cars");
        }

        public ActionResult Cancel(int carId)
        {
            CarDTO car = new CarDTO { CarId = carId};
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("cars", car).Result;
            return RedirectToAction("Index", "Cars");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Cars/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index", "Cars");
        }
    }
}