using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API.Controllers
{
    public class UsersController : ApiController
    {
        private AppEntities db = new AppEntities();
        // GET: Users
        public IQueryable<user2> Getbooks()
        {
            return db.user2;
        }
    }
}