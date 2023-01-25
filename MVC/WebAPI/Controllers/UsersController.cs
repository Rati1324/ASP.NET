using Repositories;
using Repositories.Repositories;
using Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private UnitOfWork<CRUDDBEntities> unitOfWork = new UnitOfWork<CRUDDBEntities>();
        private GenericRepository<User> repository;
        public UsersController()
        {
            //If you want to use Generic Repository with Unit of work
            this.repository = new GenericRepository<User>(unitOfWork);
            //If you want to use Specific Repository with Unit of work
        }
        public IEnumerable<User> GetUsers()
        {
            return repository.GetAll();
        }

        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = repository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //    // PUT: api/Users/5
        //    [ResponseType(typeof(void))]
        //    public IHttpActionResult PutUser(int id, User user)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        if (id != user.UserId)
        //        {
        //            return BadRequest();
        //        }

        //        db.Entry(user).State = EntityState.Modified;

        //        try
        //        {
        //            db.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return StatusCode(HttpStatusCode.NoContent);
        //    }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(user);
                unitOfWork.Save();
            }
            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        //    // DELETE: api/Users/5
        //    [ResponseType(typeof(User))]
        //    public IHttpActionResult DeleteUser(int id)
        //    {
        //        User user = db.Users.Find(id);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }

        //        db.Users.Remove(user);
        //        db.SaveChanges();

        //        return Ok(user);
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }

        //    private bool UserExists(int id)
        //    {
        //        return db.Users.Count(e => e.UserId == id) > 0;
        //    }
        //}
    }
}