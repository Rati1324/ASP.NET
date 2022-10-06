using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DB;

namespace WebApplication1.Controllers {
	public class HomeController : Controller {
		public ActionResult Index() {
			return View();
		}
	}
}