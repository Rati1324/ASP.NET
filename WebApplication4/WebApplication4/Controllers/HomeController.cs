using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using API.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                if (Session["userId"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    using (AppEntities db = new AppEntities())
                    {
                        var products = db.books.Select(b=>b).ToArray();
                        ViewBag.data = products;
                        return View();
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}