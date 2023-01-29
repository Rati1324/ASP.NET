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
            User.Password = Hash.HashString(User.Password);
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
            var response = GlobalVariables.WebApiClient.GetAsync("users");
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<UserDTO>>();
                readTask.Wait();
                var userList = readTask.Result;

                var userResult = userList.Where(u => u.Username == user.Username).FirstOrDefault();
                if (userResult != null) {
                    if (Hash.HashForComparison(user.Password, userResult.Password))
                    {
                        Session["userId"] = userResult.UserId;
                        Session["userType"] = userResult.Role;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["msg"] = "incorrect credentials";
                    }
                }
            }
            else 
            {
                var userResult = new UserDTO();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View();
        }

        public ActionResult Rent(int carId, int userId)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Rent", new RentData { UserId=userId, CarId=carId}).Result;
            return RedirectToAction("Index", "Cars");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}