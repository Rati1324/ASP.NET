using homework_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace homework_2.Controllers {
	public class HomeController : Controller {
		public List<User> GetUsers() {
			List<User> users = new List<User>() {
				new User { Id = 1, Name = "John", Age = 20 },
				new User { Id = 2, Name = "John 2", Age = 22 },
				new User { Name = "John 2", Age = 22 },
			};
			return users;
		}

		public ActionResult Index() {
			return View();
		}

		[HttpPost]
		public ActionResult Index(User user) {
			if (ModelState.IsValid) {
				return RedirectToAction("Message");
			}
			return View();
		}

		public ActionResult Message() {
			return View();
		}
	}
}