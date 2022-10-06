using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1 {
	public class RouteConfig {
		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Users",
				url: "Users/{id}",
				defaults: new { controller = "Users", action = "Index", id = UrlParameter.Optional },
				constraints: new { id = @"\d+" }
			);
			routes.MapRoute(
				name: "Cars",
				url: "Cars/{id}",
				defaults: new { controller = "Cars", action = "Index", id = UrlParameter.Optional },
				constraints: new { id = @"\d+" }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
