using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserDTO User)
        {
            User.Role = 0;
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Users", User).Result;
            TempData["SuccessMessage"] = "Updated Successfully";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserDTO user)
        {
            IEnumerable<UserDTO> Users;
            var response = GlobalVariables.WebApiClient.GetAsync("users");
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<UserDTO>>();
                readTask.Wait();

                Users = readTask.Result;
            }
            else 
            {
                Users = Enumerable.Empty<UserDTO>();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            var res = Users.Where(u => u.Username == user.Username && u.Password == user.Password).First();
            if (res != null)
            {
                Session["userId"] = res.UserId;
                Session["userType"] = 0;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = "incorrect credentials";
            }
            return View();
        }
    }
}