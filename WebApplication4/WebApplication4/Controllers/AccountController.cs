using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using API.Models;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.UserDTO user)
        {
            using (AppEntities db = new AppEntities())
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
                else //web api sent error response 
                {
                    //log response status here..

                    Users = Enumerable.Empty<UserDTO>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }

                var res = Users.Where(u => u.name == user.name && u.password == user.password).First();
                if (res != null)
                {
                    Session["userId"] = res.name;
                    Session["userType"] = 0;
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    TempData["msg"] = "incorrect credentials";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return View("Login");
        }
    }
}