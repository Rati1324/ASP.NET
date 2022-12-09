using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (AppEntities db = new AppEntities())
            {
                var res = db.user2.Where(u => u.name == user.Username && u.password == user.Password);
                if (res.Count() != 0)
                {
                    Session["userId"] = user.Username;
                    return RedirectToAction("Index", "Home");
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