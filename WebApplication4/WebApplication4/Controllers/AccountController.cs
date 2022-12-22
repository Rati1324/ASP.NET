using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using API.Models;


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
                Session["userId"] = "john";
                return RedirectToAction("Index", "Home");
                //var res = db.user2.Where(u => u.name == user.Username && u.password == user.Password);
                //if (res.Count() != 0)
                //{
                //    Session["userId"] = user.Username;
                //    return RedirectToAction("Index", "Home");
                //}
                //else
                //{
                //    TempData["msg"] = "incorrect credentials";
                //}
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