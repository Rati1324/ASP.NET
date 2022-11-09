using homework_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace homework_2.Controllers {
	public class HomeController : Controller {
		public JsonResult Index() {
			return Json("{name:john}", JsonRequestBehavior.AllowGet);
			//return View();
		}

		public ViewResult AddUser() {
			return View();
		}

		[HttpPost]
		public ActionResult AddUser(User user) {
			if (ModelState.IsValid) {
				//return View("Message");
				return RedirectToAction("Message");
			}
			return View();
		}

		public ActionResult Message() {
			return View();
		}
	}
}