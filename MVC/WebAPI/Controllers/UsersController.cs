using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using User;

namespace WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private UserRepo userDB = new UserRepo();
        // GET: api/Users
        public IEnumerable<DB.User> Get()
        {
            return userDB.GetUsers();
        }
        public void Rent(int userId, int carId)
        {

        }

        // GET: api/Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        public void Post(DB.User user)
        {
            userDB.AddUser(user);
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
