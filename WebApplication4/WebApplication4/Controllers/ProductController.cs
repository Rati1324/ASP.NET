using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ProductController : Controller
    {

        // GET: Books
        public ActionResult Index()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                IEnumerable<BookDTO> books; 
                IEnumerable<MovieDTO> movies; 
                var responseBooks = GlobalVariables.WebApiClient.GetAsync("books");
                var responseMovies = GlobalVariables.WebApiClient.GetAsync("movies");
                responseBooks.Wait();
                responseMovies.Wait();
        
                var resultBooks = responseBooks.Result;
                var resultMovies = responseMovies.Result;

                if (resultBooks.IsSuccessStatusCode && resultMovies.IsSuccessStatusCode)
                {
                    var readTaskBooks = resultBooks.Content.ReadAsAsync<IList<BookDTO>>();
                    var readTaskMovies = resultMovies.Content.ReadAsAsync<IList<MovieDTO>>();
                    readTaskBooks.Wait();
                    readTaskMovies.Wait();

                    books = readTaskBooks.Result;
                    movies = readTaskMovies.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    books = Enumerable.Empty<BookDTO>();
                    movies = Enumerable.Empty<MovieDTO>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                ViewBag.APIAddress = ConfigurationManager.AppSettings["APIAddress"];
                ViewBag.Books = books;
                ViewBag.Movies = movies;
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}
