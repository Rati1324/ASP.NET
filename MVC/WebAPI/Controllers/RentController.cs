using Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using User;

namespace WebAPI.Controllers
{
    public class RentController : ApiController
    {
        UserRepo userDB = new UserRepo();
        // POST: api/Rent
        public void Post(Models.RentData RentData)
        {
            userDB.Rent(RentData.UserId, RentData.CarId);
        }

        // GET: api/Rent
        public IEnumerable<string> Get(string x)
        {
            return new string[] {x};
        }

        // GET: api/Rent/5
        public string Get(int id)
        {
            return "value";
        }

        
        // PUT: api/Rent/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rent/5
        public void Delete(int id)
        {
        }
    }
}
