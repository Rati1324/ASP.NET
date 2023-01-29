using Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

        // GET: api/Cars/5
        public DB.Car Get(int id)
        {
            return carDB.GetCar(id);
        }

        // POST: api/Cars
        public void Post(DB.Car car)
        {
            carDB.AddCar(car);
        }

        // PUT: api/Cars/5
        public void Put(DB.Car car)
        {
            carDB.EditCar(car);
        }

        // DELETE: api/Cars/5
        public void Delete(int id)
        {
            carDB.DeleteCar(id);
        }
    }
}
