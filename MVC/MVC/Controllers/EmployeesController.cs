using Microsoft.Ajax.Utilities;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            if (Session["userId"] != null)
            {
                var response = GlobalVariables.WebApiClient.GetAsync("employees");
                response.Wait();
                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readEmps = result.Content.ReadAsAsync<IList<EmployeeDTO>>();
                    readEmps.Wait();
                    var emps = readEmps.Result;
                    return View(emps);
                }
                return View();
            }
            return RedirectToAction("Login", "Users");
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new EmployeeDTO());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employees/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<EmployeeDTO>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(EmployeeDTO emp)
        {
            if (emp.EmployeeID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employees", emp).Result;
                TempData["SuccessMessage"] = "Saved";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Employees/" + emp.EmployeeID, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int ID)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Employees/" + ID.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}