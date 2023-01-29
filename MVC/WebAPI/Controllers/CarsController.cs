using Car;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    public class CarsController : ApiController
    {
        private CarRepo carDB = new CarRepo();

        // GET: api/Cars
        public IEnumerable<DB.Car> Get()
        {
            return carDB.GetCars();
        }
    }
}