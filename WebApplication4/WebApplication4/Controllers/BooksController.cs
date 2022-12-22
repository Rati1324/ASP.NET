using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            //HttpClient WebApiClient = new HttpClient();
            //WebApiClient.BaseAddress = new Uri("https://localhost:44308/api/");
            //WebApiClient.DefaultRequestHeaders.Clear();
            //WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<BookDTO> books; 
            var response = GlobalVariables.WebApiClient.GetAsync("books");
            response.Wait();
    
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<BookDTO>>();
                readTask.Wait();

                books = readTask.Result;
            }
            else //web api sent error response 
            {
                //log response status here..

                books = Enumerable.Empty<BookDTO>();

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(books);
        }
    }
}
