using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    }
}