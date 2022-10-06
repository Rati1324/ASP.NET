using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index(int id=0)
        {
			if (id == 0) {
				ViewBag.Users = "All users";
			}
			else {
				ViewBag.Users = id.ToString();
			}
            return View();
        }
    }
}